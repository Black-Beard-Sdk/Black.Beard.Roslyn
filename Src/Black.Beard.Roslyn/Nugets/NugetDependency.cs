using System.Xml.Linq;

namespace Bb.Nugets
{
    public class NugetDependency
    {


        public NugetDependency(string id, Version version)
        {
            Id = id;
            Version = version;
        }


        internal NugetDependency(XElement item)
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
                        Version = new Version(c.Value);
                        break;
                    default:
                        break;
                }
            }

        }

        public string Id { get; set; }

        public Version Version { get; set; }

        public override string ToString()
        {
            return Id.ToString() + " " + Version.ToString();
        }

    }


}
