using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bb.Codings
{
    public class CsAttributeDeclaration : CSMemberDeclaration
    {

        public CsAttributeDeclaration(Type type)
            : base(FormatName(type))
        {
        }

        private static string FormatName(Type type)
        {

            var e = "Attribute";
            var n = type.Name;

            if (n != null && n.EndsWith(e))
                n = n.Substring(0, n.Length - e.Length);

            return n;

        }

        public CsAttributeDeclaration(string typeName)
            : base(typeName)
        {

        }


        #region arguments

        public CsAttributeDeclaration Argument(string value)
        {
            Add(new CsAttributeParameterDeclaration(value));
            return this;
        }

        public CsAttributeDeclaration Argument(ExpressionSyntax value)
        {
            Add(new CsAttributeParameterDeclaration(value));
            return this;
        }

        public CsAttributeDeclaration Argument(string name, string value)
        {
            Add(new CsAttributeParameterDeclaration(name, value));
            return this;
        }

        public CsAttributeDeclaration Argument(string name, ExpressionSyntax value)
        {
            Add(new CsAttributeParameterDeclaration(name, value));
            return this;
        }

        public CsAttributeDeclaration Argument(string name, Action<CsAttributeParameterDeclaration> action)
        {

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var argument = Add(new CsAttributeParameterDeclaration());
            argument.ResetName(name);

            action(argument);

            return this;

        }

        #endregion arguments


        internal override SyntaxNode Build()
        {

            AttributeSyntax attribute = SyntaxFactory.Attribute(Name.Identifier());

            var _parameters = Members.ToList();

            if (_parameters.Count > 0)
            {

                var p1 = _parameters[0];
                var lst = new List<SyntaxNodeOrToken>(_parameters.Count)
                {
                    (AttributeArgumentSyntax)p1.Build()
                };

                for (int i = 1; i < _parameters.Count; i++)
                {
                    lst.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
                    lst.Add((AttributeArgumentSyntax)_parameters[i].Build());
                }

                attribute = attribute.WithArgumentList(SyntaxFactory.AttributeArgumentList(SyntaxFactory.SeparatedList<AttributeArgumentSyntax>(lst.ToArray())));

                //SyntaxFactory.AttributeArgument(SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression,SyntaxFactory.Literal("value1"))),
                //SyntaxFactory.AttributeArgument(SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression,SyntaxFactory.Literal("value2")))

            }

            return attribute;

        }

    }


}
