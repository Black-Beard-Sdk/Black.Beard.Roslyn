using System.Xml.Linq;

namespace Bb.Nugets
{

    /// <summary>
    /// Nuget repository informations
    /// </summary>
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

        /// <summary>
        /// Type of repository
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Url of the repository
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Branch of the repository
        /// </summary>
        public string Branch { get; }

        /// <summary>
        /// Commit of the repository
        /// </summary>
        public string Commit { get; }

        public override string ToString()
        {
            return Type.ToString() + " " + Url.ToString();
        }

    }


}
