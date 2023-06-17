using System.Xml.Linq;

namespace Bb.DacPacs
{

    public class DacReferences : DacEntityContains
    {

        public DacReferences()
            : base("References")
        {

        }

        public string Name { get; set; }

        public string ExternalSource { get; set; }

        public override XElement Serialize()
        {
            
            var xml = new XElement(XName.Get(this.Key));

            if (!string.IsNullOrEmpty(ExternalSource))
                xml.Add(new XAttribute(XName.Get("ExternalSource"), ExternalSource));

            xml.Add(new XAttribute(XName.Get("Name"), Name));

            return xml;

        }

        private PropertyValue _value;

    }


}
