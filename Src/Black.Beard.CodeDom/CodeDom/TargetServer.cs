using Bb.Schemas.Database.CodeDom;
using System.Data;

namespace Bb.Schemas.Database
{

    public class TargetServer
    {


        public TargetServer()
        {

        }

        public DataSetToCodeDomOption Options { get; internal set; }

        public virtual void Apply()
        {

        }

        public virtual void InitializeTable(CreateTableTypeDeclaration table)
        {
            
        }

        public virtual void ApplyTable(CreateTableTypeDeclaration table)
        {

        }

        public virtual void ApplyPrimaryKeys(CodeMemberColumnPrimaryDeclarationCollection keys, CreateTableTypeDeclaration table, DataTable node)
        {

        }

        public virtual void ApplyIndexes(CreateTableTypeDeclaration table, DataTable node)
        {

        }

    }

}
