using System.CodeDom;

namespace Bb.Schemas.Database.CodeDom
{

    public abstract class AlterObjectTypeDeclaration : CodeTypeDeclaration
    {

        public AlterObjectTypeDeclaration(CodeTypeReference @object)
        {
            this.ObjectReference = @object;
        }

        public CodeTypeReference ObjectReference { get; }

    }


}
