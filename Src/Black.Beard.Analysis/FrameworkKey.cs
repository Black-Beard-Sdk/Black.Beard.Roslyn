using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Bb.Analysis
{
    [DebuggerDisplay("{Name} {Version}")]
    public class FrameworkKey
    {

        internal FrameworkKey()
        {
                
        }

        /// <summary>
        /// ctor with name and version
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <param name="languageVersion"></param>
        public FrameworkKey(string name, Version version, int languageVersion)
        {
            this.Name = name;
            this.Version = version;
            this.languageVersion = languageVersion;

            

        }

        public string Name { get; internal set; }

        public Version Version { get; internal set; }

        public int languageVersion { get; internal set; }

        /// <summary>
        /// convert a string to a framework key
        /// </summary>
        /// <param name="name"></param>
        public static implicit operator FrameworkKey(string name)
        {
            return FrameworkKeys.Resolve(name);
        }

        /// <summary>
        /// convert a version to a framework key
        /// </summary>
        /// <param name="name"></param>
        public static implicit operator FrameworkKey(Version name)
        {
            return FrameworkKeys.Resolve(name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

    }

}
