namespace Bb.StarteKit.Components.Sql
{
    public class RemoteColumnReferenceListDescriptor : ColumnReferenceListDescriptor
    {


        public RemoteColumnReferenceListDescriptor()
        {

        }

        public RemoteColumnReferenceListDescriptor(int capacity) : base(capacity)
        {

        }

        public string Schema { get; set; }

        public string TableName { get; set; }

    }

}