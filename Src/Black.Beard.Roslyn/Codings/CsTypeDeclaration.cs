namespace Bb.Codings
{

    public abstract class CsTypeDeclaration : CsBaseTypeDeclaration
    {

        public CsTypeDeclaration(string name)
           : base(name)
        {

        }

        public CsMethodDeclaration Method(string methodName)
        {
            return Add(new CsMethodDeclaration(methodName));
        }

        internal bool _isSealed;
        internal bool _isPartial;


    }

}
