namespace Bb.StarteKit.Components.Sql
{
    public class SqlDataTypeDescriptor
    {

        public SqlDataTypeDescriptor() { }

        public SqlDataTypeDescriptor(string SqlLabel, Type type) 
        {
        
            this.SqlLabel = SqlLabel;
            this.Type = type;
        
        }

        public string SqlLabel { get; }

        public Type Type { get; }
    
    
    }


}