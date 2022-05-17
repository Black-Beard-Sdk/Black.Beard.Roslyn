using System.CodeDom;

namespace Bb.Schemas.Database.CodeDom
{

    public class CodeOnRaiseDeclaration : CodeTypeMember
    {

        public CodeOnRaiseDeclaration(string name, CodeSnippetExpression eventAction)
        {
            base.Name = name;
            this.Action = eventAction;
        }    

        public CodeSnippetExpression Action { get; }

    }


}
