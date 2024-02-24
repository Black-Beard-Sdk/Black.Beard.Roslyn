﻿
namespace Bb.Builds
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

            this.Path = new DirectoryInfo(path);

            if (!Path.Exists)
                Path.Create();

            if (hosts != null && hosts.Length > 0)
                this._hosts = new List<string>(hosts);
            else
                this._hosts = new List<string>(0);

        }


        /// <summary>
        /// return true if the resolver can used for download nuget
        /// </summary>
        public bool WithResolver => Hosts.Length > 0;


        internal FileNugetFolders Initialize()
        {

            foreach (var item in this.Path.GetDirectories())
            {
                var l = new FileNugetFolder(item);
                if (!_folders.TryGetValue(l.Name, out var f))
                    _folders.Add(l.Name.ToLower(), l);
            }

            return this;

        }

        internal FileNugetVersion Resolve((string, Version) item)
        {

            if (_folders.TryGetValue(item.Item1.ToLower(), out FileNugetFolder folder))
                return folder.Resolve(item.Item2);

            return default;

        }

        internal IEnumerable<FileNugetVersion> ResolveAll((string, Version) item)
        {
            if (_folders.TryGetValue(item.Item1.ToLower(), out FileNugetFolder folder))
                foreach (var version in folder)
                    if (version.Version >= item.Item2)
                        yield return version;
        }


        /// <summary>
        /// Try to download the package nuget
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryToDownload(string name, Version? version = null)
        {

            foreach (var host in Hosts)
            {

                // Url
                var uri = host.Url(name, version?.ToString());

                // target path
                var tempPath = Helper.GetTempDir();

                // download
                var file = uri.Download(tempPath);

                // resolve id & version
                (name, version) = file.ResolveIdAndVersion(System.IO.Path.Combine(tempPath.FullName, "unzip"));

                // unzipping
                var targetfolder = file.Unzip(System.IO.Path.Combine(Path.FullName, name, version.ToString()));

                if (targetfolder.Exists)
                {

                    var l = new FileNugetFolder(targetfolder.Parent);
                    if (!_folders.TryGetValue(l.Name.ToLower(), out var f))
                        _folders.Add(l.Name.ToLower(), l);
                    else                    
                        f.Refresh();
                    

                    return true;

                }

            }

            return false;

        }

        public DirectoryInfo Path { get; }

        public string[] Hosts => _hosts.ToArray();



        private readonly List<string> _hosts;

        private Dictionary<string, FileNugetFolder> _folders = new Dictionary<string, FileNugetFolder>();

    }


}
