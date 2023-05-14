using System.Drawing;
using System.Text;
using Bb.Sql;

namespace Bb.StarteKit.Components.Sql
{


    public static class SqlServer
    {

        public static int Max { get => -1; }

        public static SqlTypeDescriptor BigInt()
        {
            return new SqlTypeDescriptor(_BIGINT);
        }

        //public  static  SqlTypeDescriptor Numeric()
        //{
        //    return new SqlTypeDescriptor(_NUMERIC);
        //}

        public static SqlTypeDescriptor Numeric()
        {
            return new SqlTypeDescriptor(_BIT);
        }

        public static SqlTypeDescriptor SmallInt()
        {
            return new SqlTypeDescriptor(_SMALLINT);
        }

        public static SqlTypeDescriptor Bit()
        {
            return new SqlTypeDescriptor(_BIT);
        }

        public static SqlTypeDescriptor Decimal()
        {
            return new SqlTypeDescriptor(_DECIMAL);
        }

        public static SqlTypeDescriptor SmallMoney()
        {
            return new SqlTypeDescriptor(_SMALLMONEY);
        }

        public static SqlTypeDescriptor Int()
        {
            return new SqlTypeDescriptor(_INT);
        }

        public static SqlTypeDescriptor TinyInt()
        {
            return new SqlTypeDescriptor(_TINYINT);
        }

        public static SqlTypeDescriptor Money()
        {
            return new SqlTypeDescriptor(_MONEY);
        }

        public static SqlTypeDescriptor Float()
        {
            return new SqlTypeDescriptor(_FLOAT);
        }

        public static SqlTypeDescriptor Real()
        {
            return new SqlTypeDescriptor(_REAL);
        }

        public static SqlTypeDescriptor Date()
        {
            return new SqlTypeDescriptor(_DATE);
        }

        public static SqlTypeDescriptor DateTimeOffset()
        {
            return new SqlTypeDescriptor(_DATETIMEOFFSET);
        }

        public static SqlTypeDescriptor DateTime2()
        {
            return new SqlTypeDescriptor(_DATETIME2);
        }

        public static SqlTypeDescriptor SmallDateTime()
        {
            return new SqlTypeDescriptor(_SMALLDATETIME);
        }

        public static SqlTypeDescriptor DateTime()
        {
            return new SqlTypeDescriptor(_DATETIME);
        }

        public static SqlTypeDescriptor Time()
        {
            return new SqlTypeDescriptor(_TIME);
        }

        public static SqlTypeDescriptor Timestamp()
        {
            return new SqlTypeDescriptor(_TIMESTAMP);
        }

        public static SqlTypeDescriptor Char(int size)
        {
            return new SqlTypeWithPrecisionDescriptor(size, _CHAR);
        }

        public static SqlTypeDescriptor Filestream()
        {
            return new SqlTypeDescriptor(_FILESTREAM);
        }

        public static SqlTypeDescriptor Varchar(int size)
        {
            return new SqlTypeWithPrecisionDescriptor(size, _VARCHAR);
        }

        public static SqlTypeDescriptor Text(int size)
        {
            return new SqlTypeWithPrecisionDescriptor(size, _TEXT);
        }

        public static SqlTypeDescriptor Nchar(int size)
        {
            return new SqlTypeWithPrecisionDescriptor(size, _NCHAR);
        }

        public static SqlTypeDescriptor NVarchar(int size)
        {
            return new SqlTypeWithPrecisionDescriptor(size, _NVARCHAR);
        }

        public static SqlTypeDescriptor NText(int size)
        {
            return new SqlTypeWithPrecisionDescriptor(size, _NTEXT);
        }

        public static SqlTypeDescriptor Binary(int size)
        {
            return new SqlTypeWithPrecisionDescriptor(size, _BINARY);
        }

        public static SqlTypeDescriptor VarBinary(int size)
        {
            return new SqlTypeWithPrecisionDescriptor(size, _VARBINARY);
        }

        public static SqlTypeDescriptor Image(int size)
        {
            return new SqlTypeWithPrecisionDescriptor(size, _IMAGE);
        }

        public static SqlTypeDescriptor RowVersion()
        {
            return new SqlTypeDescriptor(_ROWVERSION);
        }

        public static SqlTypeDescriptor UniqueIDentifier()
        {
            return new SqlTypeDescriptor(_UNIQUEIDENTIFIER);
        }

        public static SqlTypeDescriptor SqlVariant()
        {
            return new SqlTypeDescriptor(_SQL_VARIANT);
        }

        public static SqlTypeDescriptor Xml()
        {
            return new SqlTypeDescriptor(_XML);
        }

        public static SqlTypeDescriptor Geometry()
        {
            return new SqlTypeDescriptor(_GEOMETRY);
        }

        public static SqlTypeDescriptor Geography()
        {
            return new SqlTypeDescriptor(_GEOGRAPHY);
        }


        public static SqlTypeWithPrecisionAndScaleDescriptor IdentityInt(int start = 1, int step = 1)
        {
            return new SqlTypeWithPrecisionAndScaleDescriptor(start, step, _INT);
        }

        public static SqlTypeWithPrecisionAndScaleDescriptor IdentityBigInt(int start = 1, int step = 1)
        {
            return new SqlTypeWithPrecisionAndScaleDescriptor(start, step, _BIGINT);
        }

        //public static StringBuilder Create(DatabaseStructure structure)
        //{
        //    var sb = new StringBuilder();
        //    var wrt = new Writer(sb);
        //    var createbase = new CreateDatabase(wrt);

        //    createbase.Parse(structure);

        //    return sb;
        //}


        public const string _BIGINT = "BIGINT";
        public const string _NUMERIC = "NUMERIC";
        public const string _BIT = "BIT";
        public const string _SMALLINT = "SMALLINT";
        public const string _DECIMAL = "DECIMAL";
        public const string _SMALLMONEY = "SMALLMONEY";
        public const string _INT = "INT";
        public const string _TINYINT = "TINYINT";
        public const string _MONEY = "MONEY";
        public const string _FLOAT = "FLOAT";
        public const string _REAL = "REAL";
        public const string _DATE = "DATE";
        public const string _DATETIMEOFFSET = "DATETIMEOFFSET";
        public const string _DATETIME2 = "DATETIME2";
        public const string _SMALLDATETIME = "SMALLDATETIME";
        public const string _DATETIME = "DATETIME";
        public const string _TIME = "TIME";
        public const string _TIMESTAMP = "TIMESTAMP";
        public const string _CHAR = "CHAR";
        public const string _FILESTREAM = "FILESTREAM";
        public const string _VARCHAR = "VARCHAR";
        public const string _TEXT = "TEXT";
        public const string _NCHAR = "NCHAR";
        public const string _NVARCHAR = "NVARCHAR";
        public const string _NTEXT = "NTEXT";
        public const string _BINARY = "BINARY";
        public const string _VARBINARY = "VARBINARY";
        public const string _IMAGE = "IMAGE";
        public const string _ROWVERSION = "ROWVERSION";
        public const string _UNIQUEIDENTIFIER = "UNIQUEIDENTIFIER";
        public const string _SQL_VARIANT = "SQL_VARIANT";
        public const string _XML = "XML";
        public const string _GEOMETRY = "GEOMETRY";
        public const string _GEOGRAPHY = "GEOGRAPHY";

    }


}