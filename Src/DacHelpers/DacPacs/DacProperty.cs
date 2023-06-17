using System.Xml.Linq;

namespace Bb.DacPacs
{

    public class DacProperty : ModelBase
    {

        public DacProperty(string key = null)
            : base(key ?? "Property")
        {

        }

        public bool Inline { get; set; } = true;

        public string Name { get; set; }

        public T GetValue<T>()
            where T : PropertyValue
        {
            return (T)this._value;
        }

        public DacProperty SetValue<T>(T value)
            where T : PropertyValue
        {
            this._value = value;
        return this;
        }

        public override XElement Serialize()
        {
            var xml = new XElement(XName.Get(this.Key));

            xml.Add(new XAttribute(XName.Get("Name"), this.Name));
            
            if (Inline)
            {
                xml.Add(new XAttribute(XName.Get("Value"), this._value.Value));
            }
            else
            {
                var value = new XElement(XName.Get("Value"));
                value.Add(new XCData(this._value.Value));
                xml.Add(value);
            }

            return xml;
        }

        private PropertyValue _value;

    }



}
