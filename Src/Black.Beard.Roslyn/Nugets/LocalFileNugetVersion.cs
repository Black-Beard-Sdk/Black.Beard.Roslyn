using Bb.Analysis;
using ICSharpCode.Decompiler.Metadata;
using System.Diagnostics;

namespace Bb.Nugets
{

    /// <summary>
    /// Nutget version
    /// </summary>
    [DebuggerDisplay("{Parent.Name} {Version}")]
    public class LocalFileNugetVersion
    {


        /// <summary>
        /// create a new instance of <see cref="LocalFileNugetVersion"/>
        /// </summary>
        /// <param name="dir"></param>
        public LocalFileNugetVersion(DirectoryInfo dir)
        {
            _list = new List<(string, FrameworkKey, string, Version)>();
            _path = dir;
            Version = dir.Name.ResolveVersion();
        }


        public NugetDocument Nuspec => NugetDocument.ResolveNugetDocument(_path);


        /// <summary>
        /// return the list of libraries
        /// </summary>
        /// <returns></returns>
        public List<(string, FrameworkKey, string, Version)> GetLibs()
        {

            if (!_initialized)
                Initialize();

            return _list.Where(c => c.Item2 != FrameworkKeys.Unknown).ToList();

        }


        /// <summary>
        /// Return true if the folder has no library.
        /// </summary>
        public bool Empty => _list.Count == 0;

        internal LocalFileNugetVersion Initialize()
        {

            _initialized = true;
            foreach (var file in _path.GetFiles("*.dll", SearchOption.AllDirectories))
                try
                {
                    using (var lib = new PEFile(file.FullName))
                    {
                        var n = lib.Name;
                        _list.Add((file.FullName,  FrameworkKeys.Resolve(file.Directory.Name), n, lib.Version));
                    }
                }
                catch (Exception)
                {

                }

            return this;

        }

        public Version Version { get; }

        public FileNugetFolder Parent { get; internal set; }


        private readonly List<(string, FrameworkKey, string, Version)> _list;
        private DirectoryInfo _path;
        private bool _initialized;


    }


}
