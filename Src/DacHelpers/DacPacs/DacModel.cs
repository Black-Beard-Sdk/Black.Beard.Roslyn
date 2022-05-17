using System.Xml.Linq;

namespace Bb.DacPacs
{

    public class DacModel : DacListOfModel<DacElement>
    {

        public DacModel() : base("Model")
        {
            AddSqlDatabaseOptions();
        }

        public DacModel AddSqlDatabaseOptions()
        {
            var item = new DacSqlDatabaseOptions();
            this.Add(item);
            return this;

        }

        public DacModel SqlForeignKeyConstraint(string name, Action<SqlForeignKeyConstraint> action)
        {
            var item = new SqlForeignKeyConstraint()
            {
                Name = name
            };
            this.Add(item);
            action(item);
            return this;
        }

        public DacModel SqlTable(string name, Action<SqlTable> action)
        {
            var item = new SqlTable()
            {
                Name = name,
            };
            this.Add(item);
            action(item);
            return this;
        }

        public DacModel SqlDescription(string @namespace, string table, string field, string description)
        {

            var name = $"[SqlColumn].[{base.Dequote(@namespace)}].[{base.Dequote(table)}].[{base.Dequote(field)}].[MS_Description]";

            var item = new SqlExtendedProperty()
            {
                Name = name,
            };
            this.Add(item);

            Action<SqlExtendedProperty> action = a =>
            {
                a.SetDescription(description, @namespace, table, field);
            };

            action(item);

            return this;
        
        }

        public DacModel SqlDescription(string @namespace, string table, string description)
        {

            var name = $"[SqlColumn].[{base.Dequote(@namespace)}].[{base.Dequote(table)}].[MS_Description]";

            var item = new SqlExtendedProperty()
            {
                Name = name,
            };
            this.Add(item);

            Action<SqlExtendedProperty> action = a =>
            {
                a.SetDescription(description, @namespace, table);
            };

            action(item);

            return this;

        }

        public DacModel SqlPrimaryKeyConstraint(Action<SqlPrimaryKeyConstraint> action)
        {
            var item = new SqlPrimaryKeyConstraint();
            this.Add(item);
            action(item);
            return this;
        }
       
        public override XElement Serialize()
        {

            var xml = new XElement(XName.Get(this.Key));

            foreach (var item in this)
                xml.Add(item.Serialize());

            return xml;

        }

    }



}
