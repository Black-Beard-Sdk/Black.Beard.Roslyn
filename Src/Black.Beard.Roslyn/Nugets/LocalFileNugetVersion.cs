using Bb.Analysis;
using Bb.Builds;
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

            _path = dir;
            Version = dir.Name.ResolveVersion();
            Name = dir.Parent.Name;

            this.Metadata = NugetDocument.ResolveNugetDocument(_path);

        }

        public IEnumerable<Reference> References
        {
            get
            {

                if (!_initialized)
                    this.Initialize();

                return this.Metadata.References;

            }

        }


        /// <summary>
        /// Return true if the folder has no library.
        /// </summary>
        public bool Empty => References.Any();

        internal LocalFileNugetVersion Initialize()
        {

            _initialized = true;

            var dir = _path;

            if (this.Metadata.IsMultipleTarget)
                dir = new DirectoryInfo(Path.Combine(_path.FullName, "lib"));

            foreach (var file in dir.GetFiles("*.dll", SearchOption.AllDirectories))
            {

                var k = FrameworkKey.Resolve(file.Directory.Name);

                var reference = new Reference(file.FullName) { Framework = k};
                this.Metadata.Add(reference);
            }

            return this;

        }

        public Version Version { get; }

        public string Name { get; }

        public FileNugetFolder Parent { get; internal set; }

        public NugetDocument Metadata { get; private set; }

        private DirectoryInfo _path;
        private bool _initialized;


    }


}
