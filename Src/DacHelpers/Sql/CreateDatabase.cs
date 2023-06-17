using Bb.Sql;

namespace Bb.StarteKit.Components.Sql
{
    public class CreateDatabase
    {


        public CreateDatabase(Writer writer)
        {
            this._writer = writer;
        }


        internal void Parse(DatabaseStructure structure)
        {

            Parse(structure.Tables);

        }


        private void Parse(TableListDescriptor tables)
        {

            foreach (var table in tables)
            {

                Parse(table);

            }

        }

        private void Parse(TableDescriptor table)
        {

            /*
             CREATE TABLE nom_de_la_table
            */

            _writer.Append("CREATE TABLE ");
            _writer.AppendLabel(table.Schema, table.Name);

            _writer.AddIndent();
            _writer.AppendEndLine();

            Parse(table.Columns);

            _writer.DelIndent();
            _writer.AppendEndLine();

        }


        private void Parse(ColumnListDescriptor columns)
        {

            bool f = false;

            foreach (var column in columns)
            {

                if (f)
                {
                    _writer.Append(", ");
                    _writer.AppendEndLine();
                }

                Parse(column);

                f = true;

            }

        }

        private void Parse(ColumnDescriptor column)
        {

            //    <column_definition> ::=
            //       column_name <data_type>
            _writer.AppendLabel(column.Name);

            Parse(column.Type);

            //           [ FILESTREAM ]
            //           [ COLLATE collation_name ]
            //           [ SPARSE ]
            //           [ MASKED WITH ( FUNCTION = 'mask_function' ) ]
            //           [ [ CONSTRAINT constraint_name ] DEFAULT constant_expression ]
            //           [ NOT FOR REPLICATION ]
            //           [ GENERATED ALWAYS AS { ROW | TRANSACTION_ID | SEQUENCE_NUMBER } { START | END } [ HIDDEN ] ]
            //           [ [ CONSTRAINT constraint_name ] {NULL | NOT NULL} ]
            //           [ ROWGUIDCOL ]
            //           [ ENCRYPTED WITH
            //               ( COLUMN_ENCRYPTION_KEY = key_name ,
            //                 ENCRYPTION_TYPE = { DETERMINISTIC | RANDOMIZED } ,
            //                 ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256'
            //               ) ]
            //           [ <column_constraint> [ ,... n ] ]
            //           [ <column_index> ]
            //

        }

        private void Parse(SqlTypeDescriptor type)
        {
            //   <data_type> ::=
            //       [ type_schema_name. ] type_name
            if (!string.IsNullOrEmpty(type.TypeSchemaName))
                _writer.AppendLabel(type.TypeSchemaName, type.Type.SqlLabel);
            else
                _writer.AppendLabel(type.Type.SqlLabel);

            //           [ ( precision [ , scale ] | max |
            if (type is SqlTypeWithPrecisionDescriptor size)
            {

                //           [ IDENTITY [ ( seed , increment ) ]

                _writer.Append("(");

                if (!string.IsNullOrEmpty(type.XmlSchemaCollection))
                {

                    if (size.Argument1 == -1)
                        _writer.Append("MAX");
                    else
                        _writer.Append(size.Argument1);

                    if (type is SqlTypeWithPrecisionAndScaleDescriptor scale)
                    {
                        _writer.Append(", ");
                        _writer.Append(scale.Argument2);
                    }

                }
                else
                {
                    //               [ { CONTENT | DOCUMENT } ] xml_schema_collection ) ]
                    _writer.Append(type.XmlSchemaCollection);
                }

                _writer.Append(")");

            }

        }

        private readonly Writer _writer;


    }


}