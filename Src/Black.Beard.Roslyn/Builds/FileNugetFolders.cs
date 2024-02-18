using Bb.Http;
using System.Xml.Linq;

namespace Bb.Builds
{

    public class FileNugetFolders
    {

        /// <summary>
        /// Create a new instance of <see cref="FileNugetFolders"/>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="host"></param>
        public FileNugetFolders(string path, string host)
        {

            this._path = new DirectoryInfo(path);

            if (!_path.Exists)
                _path.Create();

            if (!string.IsNullOrEmpty(host))
                this._host = "https://" + host;

        }


        /// <summary>
        /// return true if the resolver can used for download nuget
        /// </summary>
        public bool WithResolver => !string.IsNullOrEmpty(_host);


        internal FileNugetFolders Initialize()
        {

            foreach (var item in this._path.GetDirectories())
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
                    yield return version;
        }


        /// <summary>
        /// Try to download the package nuget
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryToDownload(string name, Version? version = null)
        {

            // Url
            var uri = new Uri(_host).Url("api", "v2", "package", name, version?.ToString());

            // target path
            var tempPath = Helper.GetTempDir();

            // download
            var file = uri.Download(tempPath);


            (name, version) = file.ResolveIdAndVersion(Path.Combine(tempPath.FullName, "unzip"));


            // unzipping
            var targetfolder = file.Unzip(Path.Combine(_path.FullName, name, version.ToString()));

            if (targetfolder.Exists)
            {
                var l = new FileNugetFolder(targetfolder.Parent);
                if (!_folders.TryGetValue(l.Name, out var f))
                    _folders.Add(l.Name.ToLower(), l);

                return true;

            }

            return false;

        }


        private readonly DirectoryInfo _path;
        private readonly string _host;
        private Dictionary<string, FileNugetFolder> _folders = new Dictionary<string, FileNugetFolder>();

        /*
         * {host} : www.nuget.org
         * {package} : Black.Beard.Analysis
         * {version}
         https://{host}/api/v2/package/{package}/{version}
        */

    }


}
