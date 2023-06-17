using System.Xml.Linq;
using Bb.DacPacs;
using Bb.StarteKit.Components.Sql;

namespace Bb.Sql
{


    public class DatabaseStructure
    {


        public DatabaseStructure()
        {
            Tables = new TableListDescriptor();
            Schemas = new SchemaDescriptorListDescriptor();
        }

        public DatabaseStructure(params SqlServerDescriptor[] objects) : this()
        {

            foreach (var item in objects)
            {

                if (item is TableDescriptor o1)
                    Tables.Add(o1);

                else
                    throw new NotImplementedException(item.GetType().Name);

            }

        }



        public DatabaseStructure AddTables(params TableDescriptor[] tables)
        {

            Tables.AddRange(tables);

            return this;

        }

        public DacPackage GenerateDacpac(string dacpacName, DacpacContext ctx)
        {

            var converter = new ConvertStructureToDacPac(dacpacName, this, ctx);
            var result = converter.GenerateDacpac();

            return result;

        }

        public TableListDescriptor Tables { get; }
        
        public SchemaDescriptorListDescriptor Schemas { get; }


        public DatabaseStructure Check(CheckContext ctx)
        {

            var t2 = Tables.ToList();

            CheckForeignKeys(ctx, t2);

            return this;

        }

        private void CheckForeignKeys(CheckContext ctx, List<TableDescriptor> t2)
        {

            foreach (var tableParent in Tables)
            {
                foreach (var foreignKey in tableParent.ForeignKeys)
                {

                    var tables = t2.Where(c => c.Name == foreignKey.RemoteColumns.TableName).ToList();
                    if (tables.Count == 0)
                        ctx.Add(foreignKey.RemoteColumns
                            , nameof(RemoteColumnReferenceListDescriptor.TableName)
                            , $"Missing table named {foreignKey.RemoteColumns.TableName}"
                            , LevelCheck.Error);

                    else
                    {

                        var schemas = tables.Select(c => c.Schema).ToList();
                        tables = tables.Where(c => c.Schema == foreignKey.RemoteColumns.Schema).ToList();
                        if (tables.Count == 0)
                            ctx.Add(foreignKey.RemoteColumns
                                , nameof(RemoteColumnReferenceListDescriptor.Schema)
                                , $"Table {foreignKey.RemoteColumns.TableName} exists but with different schema {string.Join(", ", schemas)}"
                                , LevelCheck.Error);

                        else if (tables.Count  > 1)
                             ctx.Add(foreignKey.RemoteColumns
                                , nameof(RemoteColumnReferenceListDescriptor.Schema)
                                , $"Ambigues tables {foreignKey.RemoteColumns.Schema}.{foreignKey.RemoteColumns.TableName}"
                                , LevelCheck.Error);

                        else
                        {

                            var tableChild = tables[0];

                            if (foreignKey.LocalColumns.Count == foreignKey.RemoteColumns.Count)
                            {
                                for (int i = 0; i < foreignKey.LocalColumns.Count; i++)
                                {

                                    var c1 = tableParent.Columns.Where(c => c.Name == foreignKey.LocalColumns[i].Name).FirstOrDefault();
                                    var c2 = tableChild.Columns.Where(c => c.Name == foreignKey.RemoteColumns[i].Name).FirstOrDefault();

                                    if (c1 == null)
                                        ctx.Add(foreignKey.LocalColumns
                                            , "local reference column"
                                            , $"Column {foreignKey.LocalColumns[i].Name} is missing in the table {tableParent.Name}."
                                            , LevelCheck.Error);

                                    if (c2 == null)
                                        ctx.Add(foreignKey.RemoteColumns
                                            , "remote reference column"
                                            , $"Column {foreignKey.RemoteColumns[i].Name} is missing in the table {tableChild.Name}."
                                            , LevelCheck.Error);

                                    if (c1 != null && c2 != null)
                                    {
                                        if (c1.Type.Type.SqlLabel != c2.Type.Type.SqlLabel)
                                            ctx.Add(foreignKey
                                                , "Type"
                                                , $"Column {c1.Name} of type {c1.Type.Type.SqlLabel} and {c2.Name} of type {c2.Type.Type.SqlLabel} donst match."
                                                , LevelCheck.Error);
                                    }

                                }

                            }
                            else
                                ctx.Add(foreignKey
                                    , "Columns.Count"
                                    , $"tables {foreignKey.Name} haven't same count of column"
                                    , LevelCheck.Error);

                        }

                    }

                }
            }

        }


    }

    public enum LevelCheck
    {
        Verbose = 0,
        Warning = 1,
        Error = 2,
    }

}