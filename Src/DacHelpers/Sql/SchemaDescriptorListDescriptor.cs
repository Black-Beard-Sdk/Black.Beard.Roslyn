namespace Bb.StarteKit.Components.Sql
{
    public class SchemaDescriptorListDescriptor : List<SchemaDescriptor>
    {

        public SchemaDescriptorListDescriptor() : base()
        {

        }


        public SchemaDescriptorListDescriptor(int capacity) : base(capacity)
        {

        }



        public void AddSchemaIfNotExists(string schema, string parent)
        {

            var item = this.Where(c => c.Name == schema).ToList();

            if (item.Count() == 0)
            {

                this.Add(new SchemaDescriptor() { Name = schema, Parent = parent });

            }
            else
            {

            }

        }


    }



}