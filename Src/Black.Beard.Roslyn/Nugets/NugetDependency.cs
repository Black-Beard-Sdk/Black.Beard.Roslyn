using Bb.Nugets.Versions;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;

namespace Bb.Nugets
{

    /// <summary>
    /// Nuget dependency
    /// </summary>
    public class NugetDependency
    {

        /// <summary>
        /// create a new instance of <see cref="NugetDependency"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="versionMin"></param>
        /// <param name="versionMax"></param>
        /// <param name="parent"></param>
        /// <param name="nuget"></param>
        public NugetDependency(string id, Version versionMin, Version versionMax, NugetGroupDependency parent, NugetDocument nuget)
        {

            this.Nuget = nuget;
            this.Group = parent;
            Id = id;

            ConstraintVersion = new ConstraintVersion(-1, versionMin, ContraintEnum.Upper & ContraintEnum.Equal, ContraintEnum.None)
                .Append(new ConstraintVersion(-1, versionMax, ContraintEnum.None, ContraintEnum.Lower & ContraintEnum.Equal));

        }

        /// <summary>
        /// create a new instance of <see cref="NugetDependency"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="parent"></param>
        /// <param name="nuget"></param>
        public NugetDependency(string id, Version version, NugetGroupDependency parent, NugetDocument nuget)
        {

            this.Nuget = nuget;
            this.Group = parent;
            Id = id;
            ConstraintVersion = new ConstraintVersion(-1, version, ContraintEnum.Upper & ContraintEnum.Equal, ContraintEnum.Lower & ContraintEnum.Equal);
        }


        internal NugetDependency(XElement item,  NugetGroupDependency parent, NugetDocument nuget)
        {

            foreach (var c in item.Attributes())
            {
                var n = c.Name.LocalName;
                switch (n.ToLower())
                {
                    case "id":
                        Id = c.Value;
                        break;
                    case "version":
                        this.ConstraintVersion = VersionMatcher.Parse(c.Value);
                        break;
                }
            }

        }

        /// <summary>
        /// Package nuget Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Root parent nuget document
        /// </summary>
        public NugetDocument Nuget { get; }

        /// <summary>
        /// Parent framework group of dependency
        /// </summary>
        public NugetGroupDependency Group { get; }

        /// <summary>
        /// Constraint version
        /// </summary>
        public ConstraintVersion ConstraintVersion { get; private set; }

        public override string ToString()
        {
            return ConstraintVersion?.ToString() ?? "no constraint";
        }

    }


}
