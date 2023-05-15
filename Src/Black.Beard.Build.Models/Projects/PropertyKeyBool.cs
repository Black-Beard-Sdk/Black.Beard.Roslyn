using System.Xml.Linq;

namespace Bb.Projects
{
    public class PropertyKeyBool : PropertyKey
    {

        public PropertyKeyBool(string key, bool value) : base(key, value ? "True" : "False")
        {

        }

        public override XObject Serialize()
        {
            return new XElement(Name, Value);
        }

    }


}
