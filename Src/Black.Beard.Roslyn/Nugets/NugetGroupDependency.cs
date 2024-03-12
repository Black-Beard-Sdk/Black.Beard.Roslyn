using Bb.Analysis;
using System.Xml.Linq;

namespace Bb.Nugets
{

    /// <summary>
    /// Nuget group dependency for specific framework
    /// </summary>
    public class NugetGroupDependency
    {

        internal NugetGroupDependency(XElement item, NugetDocument parent)
        {

            this.Nuget = parent;

            foreach (var attribute in item.Attributes())
                if (attribute.Name.LocalName == "targetFramework")
                {

                    TargetFramework = attribute.Value;

                    if (TargetFramework == FrameworkKey.Unknown)
                    {

                    }

                }

            foreach (var c in item.Elements())
            {
                var n = c.Name.LocalName;
                if (n.ToLower() == "dependency")
                    _dependencies.Add(new NugetDependency(c, this, parent));
            }

        }

        /// <summary>
        /// target framework
        /// </summary>
        public FrameworkKey TargetFramework { get; }

        /// <summary>
        /// Root parent nuget document
        /// </summary>
        public NugetDocument Nuget { get; }

        override public string ToString()
        {
            return TargetFramework.Name;
        }

        /// <summary>
        /// List of package dependencies
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NugetDependency> Dependencies() => _dependencies;


        private readonly List<NugetDependency> _dependencies = new List<NugetDependency>();

    }


}
