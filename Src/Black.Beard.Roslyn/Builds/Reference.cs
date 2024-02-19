using Microsoft.CodeAnalysis;

namespace Bb.Builds
{
    public class Reference
    {

        public Reference(string location, string assemblyName)
        {
            this.Location = location;
            this.AssemblyName = assemblyName;

            this.Version = Helper.ResolveVersion(location);

        }

        public string Location { get; private set; }

        public string AssemblyName { get; private set; }
        public Version Version { get; private set; }

        public PortableExecutableReference ExecutableReference => _executableReference ?? (_executableReference = MetadataReference.CreateFromFile(Location));

        private PortableExecutableReference _executableReference;

        internal void SelectLastest(string location)
        {

            var newVersion = Helper.ResolveVersion(location);
            if (newVersion > this.Version)
            {
                this.Location = location;
                this.Version = Version;
                _executableReference = null;
            }

        }

    }




}
