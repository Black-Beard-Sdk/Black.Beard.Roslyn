using System.Xml.Linq;

namespace Bb.DacPacs
{
    public class DacCustomData : DacListOfModel<DacMetadata>
    {

        public DacCustomData(CategoryPropertyValue category = null)
            : base("CustomData")
        {
            if (category != null)
                this.Category = category;
        }

        public CategoryPropertyValue Category
        {
            get => GetValue<CategoryPropertyValue>("Category");
            set => Set("Category", value);
        }

        public StringPropertyValue Type
        {
            get => GetValue<StringPropertyValue>("Type");
            set => Set("Type", value);

        }
        public DacCustomData Metadata(string key, string value)
        {

            var metadata = new DacMetadata()
            {
                Name = new StringPropertyValue(key),
                Value = new StringPropertyValue(value),
            };

            this.Add(metadata);

            return this;

        }


        public override XElement Serialize()
        {

            var xml = new XElement(XName.Get(this.Key));

            xml.Add(Get("Category").SerializeToAttribute());
            
            if (Exists("Type"))
                xml.Add(Get("Type").SerializeToAttribute());

            foreach (var item in this)
                xml.Add(item.Serialize());

            return xml;

        }

    }



}
