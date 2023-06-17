namespace Bb.StarteKit.Components.Sql
{
    public class SqlTypeWithPrecisionAndScaleDescriptor : SqlTypeWithPrecisionDescriptor
    {

        public SqlTypeWithPrecisionAndScaleDescriptor(int argument1, int argument2)
            : base(argument1)
        {
            this.Argument2 = argument2;
        }

        public SqlTypeWithPrecisionAndScaleDescriptor(int argument1, int argument2, SqlDataTypeDescriptor type)
            : base(argument1, type)
        {
            this.Argument2 = argument2;
        }

        public SqlTypeWithPrecisionAndScaleDescriptor(int argument1, int argument2, string sqlLabel)
            : base(argument1, sqlLabel)
        {
            this.Argument2 = argument2;
        }

        public bool IsIdentity { get; set; }

        public int Argument2 { get; set; }

    }

}