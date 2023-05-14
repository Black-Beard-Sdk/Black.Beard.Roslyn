using System.Xml.Linq;

namespace Bb.Projects
{
    public class RazorLangVersion : PropertyKey
    {

        public RazorLangVersion(Version value) : base("RazorLangVersion", value.ToString())
        {

        }

        public override XObject Serialize()
        {
            return new XElement(Name, Value);
        }

    }

}
