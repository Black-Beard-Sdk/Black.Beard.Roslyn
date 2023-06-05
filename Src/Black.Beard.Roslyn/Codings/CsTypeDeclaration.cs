using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace Bb.Codings
{

    public abstract class CsTypeDeclaration : CsBaseTypeDeclaration
    {

        public CsTypeDeclaration(string name)
           : base(name)
        {

        }

        #region methods

        public CsMethodDeclaration Method(string methodName)
        {
            return Add(new CsMethodDeclaration(methodName));
        }

        public CsMethodDeclaration Method(string methodName, string type)
        {
            return Add(new CsMethodDeclaration(methodName, type));
        }

        public CsMethodDeclaration Method(string methodName, Type type)
        {
            return Add(new CsMethodDeclaration(methodName, type));
        }

        public CsMethodDeclaration Method(string methodName, TypeSyntax type)
        {
            return Add(new CsMethodDeclaration(methodName, type));
        }

        #endregion methods

        internal bool _isSealed;
        internal bool _isPartial;


    }

}
