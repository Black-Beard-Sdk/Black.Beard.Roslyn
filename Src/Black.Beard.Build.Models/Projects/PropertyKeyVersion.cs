using System.Xml.Linq;

namespace Bb.Projects
{

    public class PropertyKeyVersion : PropertyKey
    {

        public PropertyKeyVersion(string key, Version value) 
            : base(key, value?.ToString())
        {

        }

        public override XObject Serialize()
        {
            return new XElement(KeyName, Value);
        }

    }

}
