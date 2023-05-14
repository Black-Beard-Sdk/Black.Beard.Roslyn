using System.Xml.Linq;

namespace Bb.Projects
{
    public class LangVersion : PropertyKey
    {

        public LangVersion(Version value) : base("LangVersion", value.ToString())
        {

        }

        public override XObject Serialize()
        {
            return new XElement(Name, Value);
        }

    }

}
