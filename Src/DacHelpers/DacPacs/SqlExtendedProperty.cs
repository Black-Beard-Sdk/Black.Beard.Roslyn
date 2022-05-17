namespace Bb.DacPacs
{
    public class SqlExtendedProperty : DacElement
    {

        public SqlExtendedProperty()
            : base(ElementTypePropertyValue.SqlExtendedProperty)
        {

        }

        public SqlExtendedProperty SetDescription(string description, string @namespace, string table, string field)
        {

            var property = new DacProperty("Value")
            {
                Inline = false,
            }.SetValue(new StringPropertyValue(description))
            ;

            this.Properties.Add(property);

            this.Relationship(RelationshipNamePropertyValue.Host, c =>
            {
                c.Entry
                (
                  e =>
                  {
                      e.References($"[{Dequote(@namespace)}].[{Dequote(table)}].[{Dequote(field)}]");
                  }
                );
            });

            return this;

        }

        public SqlExtendedProperty SetDescription(string description, string @namespace, string table)
        {

            var property = new DacProperty("Value")
            {
                Inline = false,
            }.SetValue(new StringPropertyValue(description))
            ;

            this.Properties.Add(property);

            this.Relationship(RelationshipNamePropertyValue.Host, c =>
            {
                c.Entry
                (
                  e =>
                  {
                      e.References($"[{Dequote(@namespace)}].[{Dequote(table)}]");
                  }
                );
            });

            return this;

        }

    }



}
