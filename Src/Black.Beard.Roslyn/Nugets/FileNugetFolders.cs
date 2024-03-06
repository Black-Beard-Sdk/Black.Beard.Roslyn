using Bb.Metrology;
using System.Diagnostics;
using static Bb.Nugets.NugetDocument;

namespace Bb.Nugets
{

    public class FileNugetFolders
    {


        /// <summary>
        /// Create a new instance of <see cref="FileNugetFolders"/>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="host"></param>
        public FileNugetFolders(string path, params string[] hosts)
        {

            Path = new DirectoryInfo(path);

            if (!Path.Exists)
                Path.Create();

            if (hosts != null && hosts.Length > 0)
                _hosts = new List<string>(hosts);
            else
                _hosts = new List<string>(0);

        }


        /// <summary>
        /// return true if the resolver can used for download nuget
        /// </summary>
        public bool WithResolver => Hosts.Length > 0;


        public FileNugetFolders Refresh()
        {

            foreach (var item in Path.GetDirectories())
            {
                var l = new FileNugetFolder(item);
                if (!_folders.TryGetValue(l.Name, out var f))
                    _folders.Add(l.Name.ToLower(), l);
            }

            return this;

        }

        /// <summary>
        /// Resolve by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public FileNugetFolder Resolve(string name)
        {
            _folders.TryGetValue(name.ToLower(), out FileNugetFolder folder);
            return folder;
        }

        /// <summary>
        /// resolve by name and version
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public LocalFileNugetVersion Resolve(string name, Version version)
        {
            if (_folders.TryGetValue(name.ToLower(), out FileNugetFolder folder))
                return folder.Resolve(version);
            return default;
        }

        /// <summary>
        /// resolve by name and version
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public LocalFileNugetVersion Resolve((string, Version) item)
        {

            if (_folders.TryGetValue(item.Item1.ToLower(), out FileNugetFolder folder))
                return folder.Resolve(item.Item2);

            return default;

        }

        /// <summary>
        /// resolve all version by name
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IEnumerable<LocalFileNugetVersion> ResolveAll((string, Version) item)
        {
            if (_folders.TryGetValue(item.Item1.ToLower(), out FileNugetFolder folder))
                foreach (var version in folder)
                    if (version.Version >= item.Item2)
                        yield return version;
        }


        public bool TryToDownload(NugetDependency dependency)
        {
            return TryToDownload(dependency.Id, dependency.VersionMin);
        }

        /// <summary>
        /// Try to download the package nuget
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryToDownload(string name, Version version = null)
        {

            if (Parent != null)
                if (Parent.Intercept != null)
                {
                    var result = Parent.Intercept("download package", new object[] { name, version });
                    if (result)
                        return true;
                }

            using (var activity = RoslynActivityProvider.StartActivity("Try to download", ActivityKind.Producer))
                foreach (var host in Hosts)
                {

                    string file = null;

                    // Url
                    var uri = host.Url(name, version?.ToString());

                    // target path
                    var tempPath = Helper.GetTempDir();

                    Trace.TraceInformation($"Try to download {name} {version?.ToString()} from {host}");

                    try
                    {

                        if (RoslynActivityProvider.WithTelemetry)
                        {
                            RoslynActivityProvider.AddTag("urlTag", uri.ToString());
                            RoslynActivityProvider.AddProperty("urlProperty", uri.ToString());
                        }

                        // download
                        file = uri.Download(tempPath);

                    }
                    catch (Exception ex)
                    {

                        if (RoslynActivityProvider.WithTelemetry)
                            RoslynActivityProvider.AddProperty("exception", ex.ToString());
                       
                        return false;

                    }

                    // resolve id & version
                    (name, version) = file.ResolveIdAndVersion(System.IO.Path.Combine(tempPath.FullName, "unzip"));

                    // unzipping
                    var targetfolder = file.Unzip(System.IO.Path.Combine(Path.FullName, name, version.ToString()));

                    if (targetfolder.Exists)
                    {

                        if (RoslynActivityProvider.WithTelemetry)
                            RoslynActivityProvider.AddProperty("result", true);

                        var l = new FileNugetFolder(targetfolder.Parent);
                        if (!_folders.TryGetValue(l.Name.ToLower(), out var f))
                            _folders.Add(l.Name.ToLower(), l);
                        else
                            f.Reset();

                        return true;

                    }

                    if (RoslynActivityProvider.WithTelemetry)
                        RoslynActivityProvider.AddProperty("result", false);

                }

            return false;

        }

        public DirectoryInfo Path { get; }

        public string[] Hosts => _hosts.ToArray();

        public NugetController Parent { get; internal set; }


        private readonly List<string> _hosts;
        private Dictionary<string, FileNugetFolder> _folders = new Dictionary<string, FileNugetFolder>();


    }


}
