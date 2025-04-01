
using Bb.Analysis;

namespace Bb.Builds
{


    public class Frameworks
    {

        public Frameworks()
        {
            this.Versions = new List<FrameworkVersion>();
            Sdk = FrameworkType.NETCore;
        }

        /// <summary>
        /// Gets or sets the SDK.
        /// </summary>
        /// <value>
        /// The SDK.
        /// </value>
        public FrameworkType Sdk { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public Version Version { get; set; }


        public List<FrameworkVersion> Versions { get; }

        /// <summary>
        /// Resolve the framework to use for build.
        /// </summary>
        /// <returns></returns>
        public FrameworkVersion GetFrameworkVersion()
        {

            if (this.Sdk == null)
                Sdk = FrameworkType.NETCore;

            if (this.Versions.Count == 0)
            {
                if (this.Version == null)
                    this.Versions.Add(FrameworkVersion.ResolveSdk(this.Sdk).OrderBy(c => c.Key.Version.Major).Last());
                else
                    this.Versions.Add(FrameworkVersion.ResolveVersions(this.Version, this.Sdk).Last());
            }

            if (this.Versions.Count > 1 && this.Version == null)
                this.Version = this.Versions.OrderBy(c => c.Key.Version)
                                            .Last().Key.Version;
            else if (this.Version == null)
                this.Version = this.Versions.FirstOrDefault().Key.Version;

            var m = this.Version.Major;

            var result = this.Versions
                .Where(c => c.Key.Version.Major == m)
                .OrderBy(c => c.Key.Version)
                .LastOrDefault();

            return result;

        }

        /// <summary>
        /// Gets or sets the language version.
        /// </summary>
        /// <value>
        /// The language version.
        /// </value>
        public CsLanguageVersion GetLanguageVersion()
        {
            var f = GetFrameworkVersion();
            if (f == null)
                throw new InvalidDataException("Framework not found");
            return f.LanguageVersion;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            this.Versions.Clear();
        }

        public CsLanguageVersion LanguageVersion { get; set; } = CsLanguageVersion.CSharp6;

        /// <summary>
        /// return true whether has version.
        /// </summary>
        public bool HasVersion => this.Versions.Any();

    }



}
