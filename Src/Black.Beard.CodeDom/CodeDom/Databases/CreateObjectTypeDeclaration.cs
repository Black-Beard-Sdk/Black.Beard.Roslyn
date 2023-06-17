using Bb.Generators.SqlServer;
using System.CodeDom;

namespace Bb.Schemas.Database.CodeDom
{

    public abstract class CreateObjectTypeDeclaration : CodeTypeDeclaration
    {

        public CreateObjectTypeDeclaration(CodePropertyReferenceExpression reference)
        {
            this.Reference = reference;
        }

        public CreateObjectTypeDeclaration(string name)
        {
            base.Name = name;
        }

        public CodePropertyReferenceExpression Reference { get; set; }

    }


}
