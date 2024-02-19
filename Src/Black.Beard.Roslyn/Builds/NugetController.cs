

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
        /// <param name="nugetName"></param>
        /// <param name="version"></param>
        public void AddReference(string nugetName, string version)
        {
            _references.Add((nugetName, new Version(version)));
        }


        public string ResolveAssemblyName(string assemblyName, FrameworkVersion framework)
        {
            var result = TryToResolve((assemblyName, null), framework.Name).LastOrDefault();
            if ( string.IsNullOrEmpty(result.Item1))
                foreach (var compatibility in framework.Compatibilities)
                {
                    result = TryToResolve((assemblyName, null), compatibility).LastOrDefault();
                    if (!string.IsNullOrEmpty(result.Item1))
                        break;
                }

            return result.Item1;

        }


        internal void Resolve(AssemblyReferences references)
        {

            string framework = references.Sdk.Name;

            foreach (var item in _references)
            {

                var list = TryToResolve(item, framework);

                if (list == null)   // If missing try to download
                    if (TryToDownload(item.Item1, item.Item2))
                        list = TryToResolve(item, framework);

                if (list != null)   // Append references
                    foreach (var c in list.OrderByDescending(c => c.Item4))
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

        private List<(string, string, string, Version)> TryToResolve((string, Version) item, string framework = null)
        {

            var lst = new List<(string, string, string, Version)>();
         
            foreach (var nugetFolder in _folders)
                foreach (var version in nugetFolder.ResolveAll(item))
                {
                    var libs = version.GetLibs();
                    var lst2 = libs.Where(c => string.IsNullOrEmpty(framework) || c.Item2 == framework).ToList();
                    lst.AddRange(lst2);
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
