using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bb.Codings
{
    public class CsAttributeParameterDeclaration : CSMemberDeclaration
    {

        public CsAttributeParameterDeclaration()
            : base(null)
        {

        }

        public CsAttributeParameterDeclaration(string value)
            : this(null, Literal(value))
        {

        }

        public CsAttributeParameterDeclaration(ExpressionSyntax value)
            : this(null, value)
        {
            
        }

        public CsAttributeParameterDeclaration(string name, string value)
            : this(name, Literal(value))
        {

        }

        public CsAttributeParameterDeclaration(string name, ExpressionSyntax value)
            : base(name)
        {
            Value = value;
        }


        internal override SyntaxNode Build()
        {

            AttributeArgumentSyntax argument;

            if (!string.IsNullOrEmpty(this.Name))
                argument = SyntaxFactory.AttributeArgument(SyntaxFactory.NameEquals(SyntaxFactory.IdentifierName(this.Name)), null, Value);
            else
                argument = SyntaxFactory.AttributeArgument(Value);

            return argument;
        }


        public ExpressionSyntax Value { get; set; }

    }


}
