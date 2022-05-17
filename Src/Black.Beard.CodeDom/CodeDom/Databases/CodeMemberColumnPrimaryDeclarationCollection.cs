using Bb.Generators.SqlServer;
using System.CodeDom;

namespace Bb.Schemas.Database.CodeDom
{

    public class CodeMemberColumnPrimaryDeclarationCollection : CodeTypeMember
    {

        public CodeMemberColumnPrimaryDeclarationCollection()
        {
            Keys = new List<CodeMemberColumnPrimaryDeclaration>();
        }

        public List<CodeMemberColumnPrimaryDeclaration> Keys { get; }

        public CodeSnippetExpression PrimaryDeclaration { get; set; }

    }

}
