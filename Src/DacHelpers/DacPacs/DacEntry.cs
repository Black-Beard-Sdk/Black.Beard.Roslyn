using System.Xml.Linq;

namespace Bb.DacPacs
{

    public class DacEntry : DacListOfModel<DacEntityContains>
    {


        public DacEntry()
            : base("Entry")
        {

        }


        public override XElement Serialize()
        {
            var xml = new XElement(XName.Get(this.Key));

            foreach (var item in this)
                xml.Add(item.Serialize());

            return xml;
        }

        public DacEntry SqlIndexedColumnSpecification(Action<SqlIndexedColumnSpecification> action)
        {
            var item = new SqlIndexedColumnSpecification();
            this.Add(item);
            action(item);
            return this;
        }

        public DacEntry Column(string columnName, Action<DacSqlSimpleColumn> action)
        {
            var item = new DacSqlSimpleColumn()
            {
                Name = columnName,
            };
            this.Add(item);
            action(item);
            return this;
        }

        public DacEntry References(string name, string ExternalSource = null)
        {
            
            var item = new DacReferences();

            if (ExternalSource != null)
                item.ExternalSource = ExternalSource;

            item.Name = name;

            this.Add(item);

            return this;

        }

        public DacEntry Element(ElementTypePropertyValue type, Action<DacElement> action)
        {
            var item = new DacElement(type);
            this.Add(item);
            action(item);
            return this;

        }

        protected override T1 Create<T1>()
        {
            T1 value = default(T1);
            
            if (typeof(T1) == typeof(DacReferences))
                value = (T1)(Object)new DacReferences();
            else
                value = (T1)(Object)new DacElement(ElementTypePropertyValue.Empty);

            return value;

        }

    }


}
