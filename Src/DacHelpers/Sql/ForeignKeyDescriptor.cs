using Microsoft.VisualBasic;

namespace Bb.StarteKit.Components.Sql
{
    public class ForeignKeyDescriptor : SqlServerDescriptor
    {


        public ForeignKeyDescriptor()
        {
            LocalColumns = new ColumnReferenceListDescriptor();
            RemoteColumns = new RemoteColumnReferenceListDescriptor();
        }


        public ColumnReferenceListDescriptor LocalColumns { get; set; }

        public ForeignKeyDescriptor AddLocalColumns()
        {


            return this;

        }

        public RemoteColumnReferenceListDescriptor RemoteColumns { get; set; }

        public ForeignKeyDescriptor AddRemoteColumns(params string[] columns)
        {

            foreach (var item in columns)
                this.RemoteColumns.Add(new ColumnReferenceDescriptor() { Name = item });

            return this;

        }

        public ForeignKeyDescriptor AddLocalColumns(params string[] columns)
        {

            foreach (var item in columns)
                this.LocalColumns.Add(new ColumnReferenceDescriptor() { Name = item });

            return this;

        }

        public bool OnDeleteCascade { get; set; } = false;

        public bool OnUpdateCascade { get; set; } = false;


    }


}