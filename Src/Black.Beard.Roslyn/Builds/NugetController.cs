using Bb.Analysis.Traces;
using ICSharpCode.Decompiler.Util;
using System.Threading;

namespace Bb.Builds
{


    public class NugetController : IAssemblyReferenceResolver
    {


        /// <summary>
        /// Create a new instance of <see cref="NugetController"/>
        /// </summary>
        public NugetController()
        {
            _folders = new List<FileNugetFolders>();
        }


        /// <summary>
        /// Add the default repository to resolve nuget for windows
        /// </summary>
        /// <returns></returns>
        public NugetController AddDefaultWindowsFolder()
        {
            return AddFolder(DefaultWindowsLocalFolder);
        }


        /// <summary>
        /// Add the default repository to resolve nuget for windows
        /// </summary>
        /// <param name="path">path to store the package downloaded</param>
        /// <param name="host">host where search package on line</param>
        /// <returns></returns>
        public NugetController AddFolder(string path)
        {
            AddFolder(DefaultWindowsLocalFolder, HostNugetOrg);
            return this;
        }


        /// <summary>
        /// Add the default repository to resolve nuget for windows
        /// </summary>
        /// <param name="path">path to store the package downloaded</param>
        /// <param name="host">host where search package on line</param>
        /// <returns></returns>
        public NugetController AddFolder(string path, params string[] hosts)
        {

            if (!_folders.Any(c => c.Path.FullName == path))
                _folders.Add(new FileNugetFolders(path, hosts).Initialize());

            return this;

        }     
        

        public NugetController CopyFrom(NugetController source)
        {

            foreach (var item in source._folders)
                if (!_folders.Any(c => c.Path.FullName == item.Path.FullName))
                    _folders.Add(item);

            return this;

        }



        /// <summary>
        /// Add a reference to resolve in the build
        /// </summary>
        /// <param name="nugetName">nuget reference to add</param>
        /// <param name="version">minimum version to add</param>
        public void AddReference(string nugetName, string version)
        {
            AddReference(nugetName, new Version(version));
        }

        /// <summary>
        /// Add a reference to resolve in the build
        /// </summary>
        /// <param name="nugetName">nuget reference to add</param>
        /// <param name="version">minimum version to add</param>
        public void AddReference(string nugetName, Version version)
        {

            var items = _references.Where(c => c.Item1 == nugetName).ToList();

            if (items.Any(c => c.Item2 == version))
                return;

            if (items.Any())
            {
                
                var max = items.Max(c => c.Item2);
                if (max > version)
                    return;

                foreach (var item in items)
                    _references.Remove(item);

            }

            _references.Add((nugetName, version));

        }


        public string ResolveAssemblyName(string assemblyName, FrameworkVersion framework)
        {
            var result = TryToResolve((assemblyName, null), out var empty, framework.Name).LastOrDefault();
            if ( string.IsNullOrEmpty(result.Item1))
                foreach (var compatibility in framework.Compatibilities)
                {
                    result = TryToResolve((assemblyName, null), out empty, compatibility).LastOrDefault();
                    if (!string.IsNullOrEmpty(result.Item1))
                        break;
                }

            return result.Item1;

        }


        internal void Resolve(AssemblyReferences references, ScriptDiagnostics diagnostics)
        {

            string framework = references.Sdk.Name;
            foreach (var item in _references)
            {

                var list = TryToResolve(item, out var empty, framework);

                if (list.Count == 0)   // If missing try to download
                {

                    if (empty)                    
                        diagnostics.Information(item.Item1,  $"the package nuget {item.Item1} {item.Item2} not contains library.");
                    
                    else
                    {
                        if (TryToDownload(item.Item1, item.Item2))
                            list = TryToResolve(item, out empty, framework);
                    }

                }

                if (list.Count > 0)   // Append references
                    foreach (var c in list.OrderBy(c => c.Item4))
                    {
                        references.AddAssemblyLocation(c.Item1, c.Item3);
                        break;
                    }
            }

        }

        /// <summary>
        /// Try to download the package nuget
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryToDownload(string name, Version? version = null)
        {

            foreach (var nugetFolder in _folders)
                if (nugetFolder.WithResolver)
                    if (nugetFolder.TryToDownload(name, version))
                        return true;

            return false;

        }

        private List<(string, string, string, Version)> TryToResolve((string, Version) item, out bool empty, string framework = null)
        {
            empty = false;
            var lst = new List<(string, string, string, Version)>();

            foreach (var nugetFolder in _folders)
                foreach (var version in nugetFolder.ResolveAll(item))
                {
                    var libs = version.GetLibs();
                    if (libs.Count == 0)
                        empty = true;

                    else
                    {
                        var lst2 = libs.Where(c => string.IsNullOrEmpty(framework) || c.Item2 == framework).ToList();
                        lst.AddRange(lst2);
                    }
                }

            return lst;

        }


        public void Next(IAssemblyReferenceResolver next)
        {
            if (_next == null)
                _next = next;
            else
                _next.Next(next);
        }


        public static string HostNugetOrg = "https://www.nuget.org/api/v2/package";
        public static string DefaultWindowsLocalFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".nuget", "packages");


        private IAssemblyReferenceResolver _next;
        private List<(string, Version)> _references = new List<(string, Version)>();
        private readonly List<FileNugetFolders> _folders;

    }


}
