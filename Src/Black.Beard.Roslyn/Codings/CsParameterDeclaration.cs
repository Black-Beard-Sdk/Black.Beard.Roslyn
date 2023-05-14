using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bb.Codings
{

    public class CsParameterDeclaration : CSMemberDeclaration
    {

        #region ctors

        public CsParameterDeclaration(string name, string type)
            : base(name)
        {
            TypeReturn = type.AsType();
        }

        public CsParameterDeclaration(string name, TypeSyntax type)
            : base(name)
        {
            TypeReturn = type;
        }

        public CsParameterDeclaration(string name, Type type)
            : base(name)
        {
            TypeReturn = type.Name.AsType();
        }

        #endregion ctors

        #region ReturnType

        public CsParameterDeclaration ReturnType(Type type)
        {
            TypeReturn = type.AsType();
            return this;
        }

        public CsParameterDeclaration ReturnType(string type)
        {
            TypeReturn = type.AsType();
            return this;
        }

        public CsParameterDeclaration ReturnType(TypeSyntax type)
        {
            TypeReturn = type;
            return this;
        }

        #endregion ReturnType

        #region attributes

        public new CsParameterDeclaration Attribute(string attributeName, Action<CsAttributeDeclaration> action)
        {
            base.Attribute(attributeName, action);
            return this;
        }

        #endregion attributes

        internal override SyntaxNode Build()
        {

            var parameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier(Name))
            .WithType(TypeReturn);

            #region attributes

            var attr = GetAttributes();
            foreach (var attribute in attr)
                parameter = parameter.AddAttributeLists(attribute);

            #endregion attributes

            return parameter;

        }

        private TypeSyntax TypeReturn;

    }


}
