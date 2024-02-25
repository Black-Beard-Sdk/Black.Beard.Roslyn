using System.Xml.Linq;

namespace Bb.Nugets
{
    public class NugetRepository
    {

        internal NugetRepository(XElement item)
        {

            foreach (var c in item.Attributes())
            {
                var n = c.Name.LocalName;
                switch (n.ToLower())
                {
                    case "type":
                        Type = c.Value;
                        break;
                    case "url":
                        Url = c.Value;
                        break;
                    case "branch":
                        Branch = c.Value;
                        break;
                    case "commit":
                        Commit = c.Value;
                        break;
                    default:
                        break;
                }
            }

        }

        public string Type { get; }

        public string Url { get; }

        public string Branch { get; }

        public string Commit { get; }

        public override string ToString()
        {
            return Type.ToString() + " " + Url.ToString();
        }

    }


}
