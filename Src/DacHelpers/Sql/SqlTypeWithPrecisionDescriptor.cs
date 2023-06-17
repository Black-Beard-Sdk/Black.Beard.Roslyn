namespace Bb.StarteKit.Components.Sql
{
    public class SqlTypeWithPrecisionDescriptor : SqlTypeDescriptor
    {

        public SqlTypeWithPrecisionDescriptor(int argument1) 
            : base()
        {
            this.Argument1 = argument1;
        }

        public SqlTypeWithPrecisionDescriptor(int argument1, string sqlLabel)
            : base(sqlLabel)
        {
            this.Argument1 = argument1;
        }

        public SqlTypeWithPrecisionDescriptor(int argument1, SqlDataTypeDescriptor type) 
            : base(type)
        {
            this.Argument1 = argument1;
        }

        public int Argument1 { get; set;  }
    }

}