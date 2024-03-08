using System.Diagnostics;
using System.Xml.Linq;

namespace Bb.Nugets
{
    public class NugetDependency
    {


        public NugetDependency(string id, Version version, NugetGroupDependency parent, NugetDocument nuget)
        {

            this.Nuget = nuget;
            this.Group = parent;
            Id = id;
            VersionMin = version;
            VersionMax = version;
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

                        if (c.Value.StartsWith("[") && c.Value.EndsWith("]"))
                        {

                            var value = c.Value.Substring(1, c.Value.Length - 2).Split(',');
                            if (value.Length > 0)
                            {
                                var v1 = value[0];
                                if (Version.TryParse(v1.Trim(), out Version v))
                                    VersionMin = v;
                                VersionMax = v;
                            }
                            if (value.Length > 1)
                            {
                                var v1 = value[1];
                                if (Version.TryParse(v1.Trim(), out Version v2))
                                    VersionMax = v2;
                            }
                        }
                        else if (Version.TryParse(c.Value.Trim(), out Version v3))
                            VersionMax = v3;

                        else
                            Trace.TraceInformation($"Version {c.Value} is not valid");

                        break;
                    default:
                        break;
                }
            }

        }

        public string Id { get; set; }

        public Version VersionMin { get; set; }

        public Version VersionMax { get; set; }
        public NugetDocument Nuget { get; }
        public NugetGroupDependency Group { get; }

        public override string ToString()
        {
            if (VersionMin == null)
                return Id.ToString();

            if (VersionMin != VersionMax)
                return Id.ToString() + " " + VersionMin.ToString() + " " + VersionMax.ToString();

            return Id.ToString() + " " + VersionMin.ToString();
        }

    }


}
