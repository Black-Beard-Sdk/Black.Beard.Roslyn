using System.Xml.Linq;

namespace Bb.DacPacs
{

    public class DacMetadata : ModelBase
    {

        public DacMetadata()
            : base("Metadata")
        {

        }

        public StringPropertyValue Name
        {
            get => GetValue<StringPropertyValue>("Name");
            set => Set("Name", value);
        }

        public StringPropertyValue Value
        {
            get => GetValue<StringPropertyValue>("Value");
            set => Set("Value", value);
        }

        public override XElement Serialize()
        {

            var xml = new XElement(XName.Get(this.Key));

            xml.Add(Get("Name").SerializeToAttribute());
            xml.Add(Get("Value").SerializeToAttribute());

            return xml;

        }

    }



}
