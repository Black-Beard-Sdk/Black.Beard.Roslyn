namespace Bb.DacPacs
{

    public class DacHeader : DacListOfModel<DacCustomData>
    {

        public DacHeader()
            : base("Header")
        {

            this.Add(new DacCustomData(CategoryPropertyValue.AnsiNulls)
                .Metadata("AnsiNulls", "True")
            );

            this.Add(new DacCustomData(CategoryPropertyValue.QuotedIdentifier)
                .Metadata("QuotedIdentifier", "True")
            );

            this.Add(new DacCustomData(CategoryPropertyValue.CompatibilityMode)
                .Metadata("CompatibilityMode", "130")
            );

            //this.Add(new CustomData(CategoryPropertyValue.Reference)
            //    .Metadata("LogicalName", "DatabaseTest.dll")
            //    .Metadata("FileName", @"C:\SRC\BLACK.BEARD.ROSLYN\SRC\DATABASETEST\OBJ\DEBUG\DATABASETEST.DLL")
            //    .Metadata("AssemblySymbolsName", "C:\Src\Black.Beard.Roslyn\Src\DatabaseTest\obj\Debug\DatabaseTest.pdb")
            //    .Metadata("AssemblyName", "DatabaseTest")
            //    .Metadata("PermissionSet", "SAFE")
            //    .Metadata("Owner", "")
            //    .Metadata("GenerateSqlClrDdl", "True")
            //    .Metadata("IsVisible", "True")
            //    .Metadata("IsModelAware", "True")
            //    .Metadata("SkipCreationIfEmpty", "True")
            //);

            this.Add(new DacCustomData(CategoryPropertyValue.SqlCmdVariables) { Type = "SqlCmdVariable" });

        }

    }



}
