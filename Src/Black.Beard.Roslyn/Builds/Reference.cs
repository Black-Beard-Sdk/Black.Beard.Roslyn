using Bb.Analysis;
using Bb.Nugets;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.Decompiler.TypeSystem;
using Microsoft.CodeAnalysis;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Bb.Builds
{


    [DebuggerDisplay("{AssemblyName} {Version}")]
    public class Reference
    {
        public Reference(string location)
        {
            this.Location = location;

            try
            {

                using (var lib = new PEFile(location))
                {
                    this.AssemblyName = lib.Name;
                    Version = lib.Version;

                    this.PublicKeyToken = lib.FullName.Split(',')
                        .Where(c => c.Trim().StartsWith("PublicKeyToken"))
                        .Select(c => c.Substring("PublicKeyToken=".Length + 1))
                        .FirstOrDefault();
                }

            }
            catch (Exception)
            {

                this.Failed = true;
            }

        }


        public Reference(string location, string assemblyName, Version version, string publicKeyToken)
        {
            this.Location = location;
            this.AssemblyName = assemblyName;
            this.PublicKeyToken = publicKeyToken;
            this.Version = version ?? Helper.ResolveVersion(location);
        }

        public string Location { get; set; }

        public string AssemblyName { get; private set; }

        public string PublicKeyToken { get; private set; }

        public Version Version { get; private set; }


        public PortableExecutableReference ExecutableReference => _executableReference ?? (_executableReference = MetadataReference.CreateFromFile(Location));

        public bool Failed { get; }
        public FrameworkKey? Framework { get; internal set; }
        public NugetDocument Package { get; internal set; }

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

        private PortableExecutableReference _executableReference;

    }




}
