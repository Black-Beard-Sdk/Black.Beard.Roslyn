using ICSharpCode.Decompiler.Metadata;
using System.Diagnostics;

namespace Bb.Builds
{

    /// <summary>
    /// Nutget version
    /// </summary>
    [DebuggerDisplay("{Parent.Name} {Version}")]
    public class FileNugetVersion
    {


        /// <summary>
        /// create a new instance of <see cref="FileNugetVersion"/>
        /// </summary>
        /// <param name="dir"></param>
        public FileNugetVersion(DirectoryInfo dir)
        {
            _list = new List<(string, string, string, Version)>();
            this._path = dir;
            this.Version = Helper.ResolveVersion(dir.Name);
        }


        public List<(string, string, string, Version)> GetLibs()
        {

            if (!_initialized)
                Initialize();

            return _list;

        }


        internal FileNugetVersion Initialize()
        {

            _initialized = true;
            foreach (var file in this._path.GetFiles("*.dll", SearchOption.AllDirectories))
                try
                {
                    using (var lib = new PEFile(file.FullName))
                    {
                        var n = lib.Name;
                        _list.Add((file.FullName, file.Directory.Name, n, lib.Version));
                    }
                }
                catch (Exception)
                {

                }

            return this;

        }

        public Version Version { get; }

        public FileNugetFolder Parent { get; internal set; }


        private readonly List<(string, string, string, Version)> _list;
        private DirectoryInfo _path;
        private bool _initialized;

        private static HashSet<string> _frameworkVersionList = new HashSet<string>()
        {
            "netstandard2.0",
            "netcoreapp2.1",
            "netcoreapp2.2",
            "netcoreapp3.0",
            "netcoreapp3.1",
            "net461",
            "net462",
            "net472",
            "net4.8",
            "net5.0",
            "net6.0",
            "net7.0",
            "net8.0"
        };



    }


}
