using Bb.Generators.SqlServer;
using System.CodeDom;

namespace Bb.Schemas.Database.CodeDom
{
    public class CodeMemberColumnPrimaryDeclaration : CodeTypeMember
    {

        public CodeMemberColumnPrimaryDeclaration(CodeMemberColumnDeclaration column)
        {
            this.Column = column;
            base.Name = column.Name;
        }

        public CodeMemberColumnDeclaration Column { get; }

        public bool Asc { get;set; }

    }


}
