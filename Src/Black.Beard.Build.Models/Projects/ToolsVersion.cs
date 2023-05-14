using System.Xml.Linq;

namespace Bb.Projects
{
    public class ToolsVersion : PropertyKey
    {

        public ToolsVersion(Version value) : base("ToolsVersion", value.ToString())
        {

        }

        public override XObject Serialize()
        {
            return new XAttribute(Name, Value);
        }

    }

}
