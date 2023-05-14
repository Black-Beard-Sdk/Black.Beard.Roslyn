using System;
using System.Diagnostics;

namespace Bb.StarteKit.Components.Sql
{

    [DebuggerDisplay("{ColumnType}")]
    public class SqlTypeDescriptor
    {

        static SqlTypeDescriptor()
        {

            SqlTypeDescriptor.Types = new Dictionary<string, SqlDataTypeDescriptor>();

            AddType(SqlServer._BIGINT, typeof(long));
            AddType(SqlServer._NUMERIC, typeof(decimal));
            AddType(SqlServer._BIT, typeof(bool));
            AddType(SqlServer._SMALLINT, typeof(short));
            AddType(SqlServer._DECIMAL, typeof(decimal));
            AddType(SqlServer._SMALLMONEY, typeof(decimal));
            AddType(SqlServer._INT, typeof(int));
            AddType(SqlServer._TINYINT, typeof(byte));
            AddType(SqlServer._MONEY, typeof(decimal));

            AddType(SqlServer._FLOAT, typeof(double));
            AddType(SqlServer._REAL, typeof(Single));

            AddType(SqlServer._DATE, typeof(DateTime));
            AddType(SqlServer._DATETIMEOFFSET, typeof(DateTimeOffset));
            AddType(SqlServer._DATETIME2, typeof(DateTime));
            AddType(SqlServer._SMALLDATETIME, typeof(DateTime));
            AddType(SqlServer._DATETIME, typeof(DateTime));
            AddType(SqlServer._TIME, typeof(TimeSpan));
            AddType(SqlServer._TIMESTAMP, typeof(byte[]));


            AddType(SqlServer._CHAR, typeof(string));
            AddType(SqlServer._FILESTREAM, typeof(byte[]));
            AddType(SqlServer._VARCHAR, typeof(string));
            AddType(SqlServer._TEXT, typeof(string));
            AddType(SqlServer._NCHAR, typeof(string));
            AddType(SqlServer._NVARCHAR, typeof(string));
            AddType(SqlServer._NTEXT, typeof(string));
            AddType(SqlServer._BINARY, typeof(byte[]));
            AddType(SqlServer._VARBINARY, typeof(byte[]));
            AddType(SqlServer._IMAGE, typeof(byte[]));
            AddType(SqlServer._ROWVERSION, typeof(byte[]));
            AddType(SqlServer._UNIQUEIDENTIFIER, typeof(Guid));
            AddType(SqlServer._SQL_VARIANT, typeof(object));
            AddType(SqlServer._XML, typeof(System.Xml.XmlElement));
            AddType(SqlServer._GEOMETRY, typeof(object));
            AddType(SqlServer._GEOGRAPHY, typeof(object));


            //AddType(CURSOR, typeof());
            //AddType(HIERARCHID, typeof());
        }


        public SqlTypeDescriptor()
        {


        }

        public SqlTypeDescriptor(string sqlLabel)
        {
            this.ColumnType = sqlLabel;

        }

        public SqlTypeDescriptor(SqlDataTypeDescriptor type)
        {
            this.ColumnType = type.SqlLabel;

        }

        public string TypeSchemaName { get; set; }

        public string XmlSchemaCollection { get; set; }

        public SqlDataTypeDescriptor Type
        {
            get
            {
                return Types[this.ColumnType];
            }
            set
            {
                ColumnType = value.SqlLabel;
            }
        }

        public string ColumnType { get; set; }


        private static void AddType(string sqlType, Type type)
        {
            SqlTypeDescriptor.Types.Add(sqlType, new SqlDataTypeDescriptor(sqlType, type));
        }

        private static Dictionary<string, SqlDataTypeDescriptor> Types { get; }


        //AddType("CURSOR", typeof());
        //AddType("HIERARCHID", typeof());

    }

}