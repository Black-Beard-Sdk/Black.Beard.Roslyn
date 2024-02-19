using System.Collections;

namespace Bb.Builds
{
    /// <summary>
    /// File nuget folder
    /// </summary>
    public class FileNugetFolder : IEnumerable<FileNugetVersion>
    {

        /// <summary>
        /// Create a new instance of <see cref="FileNugetFolder"/>
        /// </summary>
        /// <param name="dir"></param>
        public FileNugetFolder(DirectoryInfo dir)
        {
            this._path = dir;
            this.Name = dir.Name;
        }

        /// <summary>
        /// Initializes folder.
        /// </summary>
        /// <returns></returns>
        internal FileNugetFolder Initialize()
        {

            _initializd = true;
            foreach (var item in this._path.GetDirectories())
            {
                var l = new FileNugetVersion(item) { Parent = this };
                if ( !_versions.ContainsKey(l.Version.ToString()))
                    _versions.Add(l.Version.ToString(), l);
            }

            return this;

        }

        internal FileNugetVersion Resolve(Version version)
        {

            if (!_initializd)
                Initialize();

            if (version != null)
                if (_versions.TryGetValue(version.ToString(), out FileNugetVersion v))
                    return v;

            //var lst = _versions.Where(c => c.Value.Version.Major == version.Major).ToList();
            //if (lst .Count > 0)
            //{
             
            //    if (lst.Count == 1)
            //        return lst.Last().Value;

            //}

            return null;

        }

        public IEnumerator<FileNugetVersion> GetEnumerator()
        {

            if (!_initializd)
                Initialize();

            return _versions.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            if (!_initializd)
                Initialize(); 
            
            return _versions.Values.GetEnumerator();

        }

        internal void Refresh()
        {
            _initializd = false;
        }

        public string Name { get; }

        private Dictionary<string, FileNugetVersion> _versions = new Dictionary<string, FileNugetVersion>();
        private DirectoryInfo _path;
        private bool _initializd;
    }


}
