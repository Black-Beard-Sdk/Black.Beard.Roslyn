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

        public CsParameterDeclaration Way(ParameterWay way)
        {
            this._parameterWay = way;
            return this;
        }

        internal override SyntaxNode Build()
        {

            var parameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier(Name));

            switch (_parameterWay)
            {

                case ParameterWay.Ref:
                    break;

                case ParameterWay.Out:
                    break;

                case ParameterWay.Params:
                    parameter = parameter.WithModifiers
                    (
                        SyntaxFactory.TokenList
                        (
                            SyntaxFactory.Token
                            (
                                SyntaxFactory.TriviaList(),
                                SyntaxKind.ParamsKeyword,
                                SyntaxFactory.TriviaList(SyntaxFactory.Space)
                            )
                        )
                    );

                    if (!(TypeReturn is ArrayTypeSyntax))
                    {
                        var txt = TypeReturn.ToString();
                        TypeReturn = SyntaxFactory.ArrayType(SyntaxFactory.IdentifierName(txt))
                            .WithRankSpecifiers
                             (
                                 SyntaxFactory.SingletonList
                                 (
                                     SyntaxFactory.ArrayRankSpecifier
                                     (
                                         SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>
                                         (
                                             SyntaxFactory.OmittedArraySizeExpression()
                                             .WithOmittedArraySizeExpressionToken(SyntaxFactory.Token(SyntaxKind.OmittedArraySizeExpressionToken))
                                         )
                                     )
                                     .WithOpenBracketToken(SyntaxFactory.Token(SyntaxKind.OpenBracketToken))
                                     .WithCloseBracketToken
                                     (
                                         SyntaxFactory.Token
                                         (
                                             SyntaxFactory.TriviaList(),
                                             SyntaxKind.CloseBracketToken,
                                             SyntaxFactory.TriviaList(SyntaxFactory.Space)
                                         )
                                     )
                                 )
                             );

                    }

                    break;

                case ParameterWay.In:
                default:
                    break;
            }



            parameter = parameter.WithType(TypeReturn);


            #region attributes

            var attr = GetAttributes();
            foreach (var attribute in attr)
                parameter = parameter.AddAttributeLists(attribute);

            #endregion attributes

            return parameter;

        }

        private TypeSyntax TypeReturn;
        private ParameterWay _parameterWay;

    }

    public enum ParameterWay
    {
        In,
        Ref,
        Out,
        Params,
    }

}
