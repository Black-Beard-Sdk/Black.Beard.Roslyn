using Bb.Analysis;
using Bb.Analysis.DiagTraces;
using Bb.Builds;
using ICSharpCode.Decompiler.Util;

namespace Bb.Nugets
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
                _folders.Add(new FileNugetFolders(path, hosts).Refresh());

            return this;

        }

        /// <summary>
        /// Copy the nuget folder from the source
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Resolve assembly name
        /// </summary>
        /// <param name="assemblyName">name of the assembly</param>
        /// <param name="framework"><see cref="FrameworkVersion"/> </param>
        /// <returns></returns>
        public string ResolveAssemblyName(string assemblyName, Version version, FrameworkVersion framework, bool download)
        {

            if (framework == null)
                framework = FrameworkVersion.CurrentVersion;

            var result = TryToResolve((assemblyName, version), out var empty, framework.Key).LastOrDefault();
            if (string.IsNullOrEmpty(result.Item1))
                foreach (var compatibility in framework.Compatibilities)
                {
                    result = TryToResolve((assemblyName, version), out empty, compatibility).LastOrDefault();
                    if (!string.IsNullOrEmpty(result.Item1))
                        break;
                }

            if (string.IsNullOrEmpty(result.Item1) && download)
                if (TryToDownload(assemblyName, version))
                    return ResolveAssemblyName(assemblyName, version, framework, false);

            return result.Item1;

        }


        internal void Resolve(AssemblyReferences references, ScriptDiagnostics diagnostics)
        {

            var framework = references.Sdk.Key;
            foreach (var item in _references)
            {

                List<(string, FrameworkKey, string, Version)> list = TryToResolve(item, out var empty, framework.Name);

                if (list.Count == 0)   // If missing try to download
                {

                    if (empty)
                        diagnostics.Information(item.Item1, $"the package nuget {item.Item1} {item.Item2} not contains library.");

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
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public FileNugetFolder Resolve(string name)
        {

            foreach (var nugetFolder in _folders)
            {
                var o = nugetFolder.Resolve(name);
                if (o != null)
                    return o;
            }

            return default;

        }

        public LocalFileNugetVersion Resolve(string name, Version version)
        {

            foreach (var nugetFolder in _folders)
            {
                var o = nugetFolder.Resolve(name, version);
                if (o != null)
                    return o;
            }

            return default;

        }

        /// <summary>
        /// Try to download the package nuget
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryToDownload(string name, Version version = null)
        {

            foreach (var nugetFolder in _folders)
                if (nugetFolder.WithResolver)
                    if (nugetFolder.TryToDownload(name, version))
                        return true;

            return false;

        }


        private List<(string, FrameworkKey, string, Version)> TryToResolve((string, Version) item, out bool empty, FrameworkKey framework = null)
        {
            empty = false;
            var lst = new List<(string, FrameworkKey, string, Version)>();

            foreach (var nugetFolder in _folders)
                foreach (var version in nugetFolder.ResolveAll(item))
                {
                    var libs = version.GetLibs();
                    if (libs.Count == 0)
                        empty = true;

                    else
                    {
                        var lst2 = libs.Where(c => framework == null || c.Item2 == framework).ToList();
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
