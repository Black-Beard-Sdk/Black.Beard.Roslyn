using System.Xml.Linq;

namespace Bb.Projects
{

    public class PropertyKey : Group
    {

        public PropertyKey(string name, string value) 
            : base (name, true)
        {
            this.Value = value;
        }

        public PropertyKeyKind Kind { get; protected set; }

        public string Value { get; }


        public override void Serialize(XElement parent)
        {
            if (Kind == PropertyKeyKind.XElement)
                parent.Add(new XElement(Name, Value));
            else
                parent.Add(new XAttribute(Name, Value));
        }

        public override string ToString()
        {
            return Serialize().ToString();
        }

    }

    public enum PropertyKeyKind
    {
        XElement,
        XAttribute
    }

}
