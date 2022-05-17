using System.Xml.Linq;

namespace Bb.DacPacs
{

    public partial class DacDataSchemaModel : ModelBase
    {


        public string GetToString()
        {

            var txtDac = "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                + Environment.NewLine
                + this.Serialize()
                .ToString(SaveOptions.OmitDuplicateNamespaces)
                .Replace(" xmlns=\"\"", "");

            return txtDac;

        }

        public DacDataSchemaModel ForeignKey(string @namespace, string constraintName, string tableName, string[] columns, string remoteTableName, string[] remoteColumns)
        {

            if (string.IsNullOrEmpty(@namespace))
                @namespace = "dbo";

            if (string.IsNullOrEmpty(constraintName))
                throw new ArgumentNullException(nameof(constraintName));

            this.Model.SqlForeignKeyConstraint($"[{@namespace}].[{constraintName}]", p =>
            {

                p.Relationship(RelationshipNamePropertyValue.Columns, r1 =>
                {
                    foreach (var item in columns)
                    {
                        r1.Entry(e1 =>
                        {
                            e1.References($"[{@namespace}].[{tableName}].[{item}]");
                        });
                    }
                });

                p.Relationship(RelationshipNamePropertyValue.DefiningTable, r2 =>
                {
                    r2.Entry(e1 =>
                    {
                        e1.References($"[{@namespace}].[{tableName}]");
                    });
                });

                p.Relationship(RelationshipNamePropertyValue.ForeignColumns, r3 =>
                {
                    foreach (var item in remoteColumns)
                    {
                        r3.Entry(e1 =>
                        {
                            e1.References($"[{@namespace}].[{remoteTableName}].[{item}]");
                        });
                    }
                });

                p.Relationship(RelationshipNamePropertyValue.ForeignTable, r4 =>
                {
                    r4.Entry(e1 =>
                    {
                        e1.References($"[{@namespace}].[{remoteTableName}]");
                    });
                });

            });

            return this;

        }
        public DacDataSchemaModel PrimaryKey(string @namespace, string table, params string[] fields)
        {

            if (string.IsNullOrEmpty(@namespace))
                @namespace = "dbo";

            if (string.IsNullOrEmpty(@table))
                throw new ArgumentNullException(nameof(table));

            if (fields == null || fields.Length == 0)
                throw new ArgumentNullException(nameof(fields));

            this.Model.SqlPrimaryKeyConstraint(p =>
            {
                p.Relationship(RelationshipNamePropertyValue.ColumnSpecifications,
                    r => r.Entry(e => e.SqlIndexedColumnSpecification(e2 => e2.Relationship(RelationshipNamePropertyValue.Column,
                        r2 =>
                        {

                            foreach (var field in fields)
                            {
                                r2.Entry(e3 =>
                                {
                                    e3.References($"[{@namespace}].[{table}].[{field}]");
                                });
                            }

                        })))
                )
                .Relationship(RelationshipNamePropertyValue.DefiningTable,
                    r => r.Entry(e => e.References($"[{@namespace}].[{table}]"))
                )
                //.Annotation(AnnotationTypePropertyValue.SqlInlineConstraintAnnotation, a =>
                //{
                //    a.Disambiguator = 3;
                //})
                ;
            });

            return this;

        }

        public DacDataSchemaModel Table(string @namespace, string table, Action<DacRelationship> action)
        {

            if (string.IsNullOrEmpty(@namespace))
                @namespace = "dbo";

            if (string.IsNullOrEmpty(@table))
                throw new ArgumentNullException(nameof(table));


            this.Model.SqlTable($"[{@namespace}].[{table}]", p =>
            {
                p.Property("IsAnsiNullsOn", "True")
                .Relationship(RelationshipNamePropertyValue.Columns, action)
                .Relationship(RelationshipNamePropertyValue.Schema, r =>
                {
                    r.Entry(e =>
                    {
                        e.References($"[{@namespace}]", "BuiltIns");
                    });
                })
                //.AttachedAnnotation(null, a =>
                //{
                //    a.Disambiguator = 5;
                //});
                ;
            });

            return this;

        }


    }



}
