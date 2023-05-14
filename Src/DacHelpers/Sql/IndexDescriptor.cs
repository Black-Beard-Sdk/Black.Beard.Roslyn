using Bb.DacPacs;
using System.Diagnostics;

namespace Bb.StarteKit.Components.Sql
{

    [DebuggerDisplay("{Name}")]
    public class IndexDescriptor : List<IndexedColumnReferenceDescriptor>
    {

        public IndexDescriptor()
        {
            Properties = new IndexProperties();
        }

        public IndexDescriptor(int capacity) : base(capacity)
        {
            Properties = new IndexProperties();
        }

        public IndexDescriptor AddColumns(params IndexedColumnReferenceDescriptor[] columns)
        {
            this.AddRange(columns);
            return this;
        }

        public IndexDescriptor SetProperties(Action<IndexProperties> action)
        {
            action(this.Properties);
            return this;
        }

        public string Name { get; set; }

        public IndexProperties Properties { get; set; }

        public bool Clustered { get; set; } = true;

        public bool Unique { get; set; } = true;

        public string PartitionSchemeName { get; set; } = "PRIMARY";


    }



}