using Bb.Schemas.Database.CodeDom;
using System.Data;

namespace Bb.Schemas.Database
{

    public class SqlserverTargetServer : TargetServer
    {

        public SqlserverTargetServer()
        {

        }

        public override void Apply()
        {

            Options.PrimaryKeyInline = false;

        }

        public override void InitializeTable(CreateTableTypeDeclaration table)
        {

        }

        public override void ApplyTable(CreateTableTypeDeclaration table)
        {

        }

        public override void ApplyPrimaryKeys(CodeMemberColumnPrimaryDeclarationCollection keys, CreateTableTypeDeclaration table, DataTable node)
        {

            keys.PrimaryDeclaration = new System.CodeDom.CodeSnippetExpression("PRIMARY KEY CLUSTERED");


        }

        public override void ApplyIndexes(CreateTableTypeDeclaration table, DataTable node)
        {

        }


        private string ConvertOnOff(bool self)
        {
            return self ? "ON" : "OFF";
        }

        public const string PAD_INDEX = "PAD_INDEX";
        public const string STATISTICS_NORECOMPUTE = "STATISTICS_NORECOMPUTE";
        public const string IGNORE_DUP_KEY = "IGNORE_DUP_KEY";
        public const string ALLOW_ROW_LOCKS = "ALLOW_ROW_LOCKS";
        public const string ALLOW_PAGE_LOCKS = "ALLOW_PAGE_LOCKS";
        public const string OPTIMIZE_FOR_SEQUENTIAL_KEY = "OPTIMIZE_FOR_SEQUENTIAL_KEY";



    }

}
