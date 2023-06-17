using System.CodeDom;

namespace Bb.Schemas.Database.CodeDom
{

    public class CodeContraintDeclaration : CodeTypeMember
    {

        public CodeContraintDeclaration(string name)
        {
            base.Name = name;
            LocalColumns = new List<CodePropertyReferenceExpression>();
            RemoteColumns = new List<CodePropertyReferenceExpression>();
            OnRaises = new List<CodeOnRaiseDeclaration>();
        }

        public CodePropertyReferenceExpression RemoteTable { get; set; }

        public List<CodePropertyReferenceExpression> LocalColumns { get;  }

        public List<CodePropertyReferenceExpression> RemoteColumns { get; }

        public List<CodeOnRaiseDeclaration> OnRaises { get; }

    }

}


