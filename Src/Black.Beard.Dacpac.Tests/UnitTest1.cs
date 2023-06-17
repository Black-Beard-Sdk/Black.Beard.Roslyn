using Bb;
using Bb.Sql;
using Bb.StarteKit.Components.Sql;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;

namespace Black.Beard.StarterKit.Tests
{

    [TestClass]
    public class UnitTest1
    {
        private readonly string _root;

        public UnitTest1()
        {
            this._root = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;
        }


        [TestMethod]
        public void TestMethod1()
        {

            string Server = ".";
            var schema = "dbo";
            var checkCtx = new CheckContext();

            var db = new DatabaseStructure()

                .AddTables(

                    new TableDescriptor(schema, "DiskTables")
                        .AddColumns(
                            new ColumnDescriptor() { Name = "Id", Type = SqlServer.IdentityBigInt(1,1), AllowNull = false },
                            new ColumnDescriptor() { Name = "TableSchema", Type = SqlServer.Varchar(70), AllowNull = false },
                            new ColumnDescriptor() { Name = "Name", Type = SqlServer.Varchar(70), AllowNull = false },
                            new ColumnDescriptor() { Name = "PartitionSchemeName", Type = SqlServer.Varchar(160), AllowNull = true }
                    )
                    .AddPrimaryKeys(
                        new IndexedColumnReferenceDescriptor() { Name = "Id" }
                    ),

                    new TableDescriptor(schema, "DiskTablesIndex")
                        .AddColumns(
                           new ColumnDescriptor() { Name = "Id", Type = SqlServer.IdentityBigInt(1, 1), AllowNull = false },
                           new ColumnDescriptor() { Name = "Table", Type = SqlServer.BigInt(), AllowNull = false },
                           new ColumnDescriptor() { Name = "PrimaryKey", Type = SqlServer.Bit(), AllowNull = false },
                           new ColumnDescriptor() { Name = "Name", Type = SqlServer.Varchar(70), AllowNull = false },
                           new ColumnDescriptor() { Name = "Clustered", Type = SqlServer.Bit(), AllowNull = false },
                           new ColumnDescriptor() { Name = "Unique", Type = SqlServer.Bit(), AllowNull = false },
                           new ColumnDescriptor() { Name = "PartitionSchemeName", Type = SqlServer.Varchar(60), AllowNull = true },
                           new ColumnDescriptor() { Name = "PadIndex", Type = SqlServer.Bit(), AllowNull = true },
                           new ColumnDescriptor() { Name = "StatisticsNoRecompute", Type = SqlServer.Bit(), AllowNull = true },
                           new ColumnDescriptor() { Name = "AllowRowLocks", Type = SqlServer.Bit(), AllowNull = true },
                           new ColumnDescriptor() { Name = "AllowPageLocks", Type = SqlServer.Bit(), AllowNull = true },
                           new ColumnDescriptor() { Name = "OptimizeForSequentialKey", Type = SqlServer.Bit(), AllowNull = true }
                    )
                    .AddPrimaryKeys(
                        new IndexedColumnReferenceDescriptor() { Name = "Id" }
                    )
                    .AddForeignKey("FK_DiskTablesIndex_Table_2_DiskTables_Id", schema, "DiskTables", c =>
                    {
                        c.AddLocalColumns("Table");
                        c.AddRemoteColumns("Id");
                    }),

                    new TableDescriptor(schema, "DiskTablesColumns")
                        .AddColumns(
                            new ColumnDescriptor() { Name = "Id", Type = SqlServer.IdentityBigInt(1, 1), AllowNull = false },
                            new ColumnDescriptor() { Name = "Table", Type = SqlServer.BigInt(), AllowNull = false },
                            new ColumnDescriptor() { Name = "Name", Type = SqlServer.Varchar(70), AllowNull = false },
                            new ColumnDescriptor() { Name = "Type", Type = SqlServer.Varchar(70), AllowNull = false },
                            new ColumnDescriptor() { Name = "Precision", Type = SqlServer.Int(), AllowNull = false },
                            new ColumnDescriptor() { Name = "Scale", Type = SqlServer.Int(), AllowNull = false },
                            new ColumnDescriptor() { Name = "AllowNull", Type = SqlServer.Bit(), AllowNull = true },
                            new ColumnDescriptor() { Name = "Caption", Type = SqlServer.Varchar(160), AllowNull = true },
                            new ColumnDescriptor() { Name = "DefaultValue", Type = SqlServer.Varchar(160), AllowNull = true }
                    )
                    .AddPrimaryKeys(
                        new IndexedColumnReferenceDescriptor() { Name = "Id" }
                    )
                    .AddForeignKey("FK_DiskTablesColumns_Table_2_DiskTables_Id", schema, "DiskTables", c =>
                    {
                        c.AddLocalColumns("Table");
                        c.AddRemoteColumns("Id");
                    })

                 .SetFilegroupOnPrimaryKeys("PRIMARY")

                 //.AddIndexes(
                 //    new IndexDescriptor()
                 //    {
                 //        Name = "Index1",
                 //        Clustered = false,
                 //        //Unique = false
                 //    }
                 //    .SetProperties(c =>
                 //    {
                 //        c.AllowRowLocks = false;
                 //    })
                 //    .AddColumns(
                 //        new IndexedColumnReferenceDescriptor() { Name = "Queue", Sort = SortIndex.Descending }
                 //    )
                 //)

                )
                .Check(checkCtx);

            var ctx = new DacpacContext(new Variables(new KeyValuePair<string, string>("tableQueue", "table1")));
            var dacpack = db.GenerateDacpac("stream", ctx);
            var file = Path.Combine(this._root, "test.dacpac");

            dacpack.Write(file, true);

            //var cnx = new SqlConnectionStringBuilder();
            //cnx.IntegratedSecurity = true;
            //cnx.Encrypt = false;
            //cnx["Server"] = ".";
            //var package = DacPackage.Load(file);
            //DacServices service = new DacServices(cnx.ConnectionString);
            //var options = new DacDeployOptions()
            //{
            //    CreateNewDatabase = true,
            //};
            //service.Deploy(package, "test", true, options);


            var result = DotnetCommand.DacpacPublishWithCreateDatabase(this._root, "test.dacpac", Server, "baseTest1", new DacpacArguments() { CreateNewDatabase = false });


            // dotnet dacpac publish --dacpath=C:\Src\Black.Beard.Roslyn\Src\Black.Beard.Dacpac.Tests\bin\Debug\net6.0 --namePattern=test.dacpac --server=. --databaseNames=baseTest1 --UseSspi=true --createNewDatabase=true
            // dotnet dacpac publish --dacpath=C:\Src\Black.Beard.Roslyn\Src\Black.Beard.Dacpac.Tests\bin\Debug\net6.0 --namePattern=test.dacpac --server=. --databaseNames=baseTest1 --UseSspi=true --createNewDatabase=false
            var processInfo = new ProcessStartInfo(result.Item1, result.Item2);

            var thread = System.Diagnostics.Process.Start(processInfo);

        }

    }
}