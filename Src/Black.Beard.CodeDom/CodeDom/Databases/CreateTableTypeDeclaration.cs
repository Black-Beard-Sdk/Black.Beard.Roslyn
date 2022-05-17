using Bb.Generators.SqlServer;
using System.CodeDom;

namespace Bb.Schemas.Database.CodeDom
{

    public class CreateTableTypeDeclaration : CreateObjectTypeDeclaration
    {

        public CreateTableTypeDeclaration(string name) : base(name)
        {
            
        }

        public CreateTableTypeDeclaration(CodePropertyReferenceExpression reference) : base (reference)
        {

        }

    }


}
