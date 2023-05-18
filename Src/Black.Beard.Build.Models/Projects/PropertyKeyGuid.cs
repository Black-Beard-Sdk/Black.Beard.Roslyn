using System.Xml.Linq;

namespace Bb.Projects
{
    public class PropertyKeyGuid : PropertyKey
    {

        public PropertyKeyGuid(string key, string uuid)
           : base(key, uuid)
        {

        }

        public PropertyKeyGuid(string key, Guid uuid)
            : base(key, uuid.ToString("D"))
        {

        }

        public override XObject Serialize()
        {
            return new XElement(Name, Value);
        }

    }

}
