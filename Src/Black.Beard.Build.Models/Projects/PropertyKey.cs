using System.Xml.Linq;

namespace Bb.Projects
{

    public class PropertyKey
    {

        public PropertyKey(string key, string value)
        {
            this.Name = key;
            this.Value = value;
        }

        public string Name { get; }

        public string Value { get; }


        public virtual XObject Serialize()
        {
            return new XElement(Name, Value);
        }

        public override string ToString()
        {
            return Serialize().ToString();
        }

    }


}
