using System.Collections;
using System.Diagnostics;

namespace Bb.Nugets
{


    /// <summary>
    /// File nuget folder
    /// </summary>
    [DebuggerDisplay("{_path}")]
    public class FileNugetFolder : IEnumerable<LocalFileNugetVersion>
    {

        /// <summary>
        /// Create a new instance of <see cref="FileNugetFolder"/>
        /// </summary>
        /// <param name="dir"></param>
        public FileNugetFolder(DirectoryInfo dir)
        {
            _path = dir;
            Name = dir.Name;
        }

        /// <summary>
        /// Initializes folder.
        /// </summary>
        /// <returns></returns>
        public FileNugetFolder Refresh()
        {

            _initializd = true;
            foreach (var item in _path.GetDirectories())
            {
                var l = new LocalFileNugetVersion(item) { Parent = this };
                if (!_versions.ContainsKey(l.Version.ToString()))
                    _versions.Add(l.Version.ToString(), l);
            }

            return this;

        }

        /// <summary>
        /// Resolve the version
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public LocalFileNugetVersion Resolve(Version version, bool refresh)
        {

            if (!_initializd || refresh)
                Refresh();

            if (version != null)
                if (_versions.TryGetValue(version.ToString(), out LocalFileNugetVersion v))
                    return v;

            KeyValuePair<string, LocalFileNugetVersion> result = _versions.OrderByDescending(c => c.Value.Version).FirstOrDefault();

            return result.Value;

        }

        /// <summary>
        /// Resolve the version
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public LocalFileNugetVersion Last()
        {

            if (!_initializd)
                Refresh();

            return _versions.OrderByDescending(c => c.Value.Version).FirstOrDefault().Value;

        }

        public IEnumerator<LocalFileNugetVersion> GetEnumerator()
        {

            if (!_initializd)
                Refresh();

            return _versions.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            if (!_initializd)
                Refresh();

            return _versions.Values.GetEnumerator();

        }

        internal void Reset()
        {
            _initializd = false;
        }

        public string Name { get; }

        private Dictionary<string, LocalFileNugetVersion> _versions = new Dictionary<string, LocalFileNugetVersion>();
        private DirectoryInfo _path;
        private bool _initializd;
    }


}
