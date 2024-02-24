using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bb.Codings
{

    public abstract class CSharpNode
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpNode"/> class.
        /// </summary>
        public CSharpNode()
        {
            //this._parent = parent ?? throw new NullReferenceException(nameof(parent));
        }

        internal abstract SyntaxNode Build();

        public static LiteralExpressionSyntax Literal(object value)
        {

            if (value == null)
                return SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression);   

            else if (value is bool b)
                return SyntaxFactory.LiteralExpression(b ? SyntaxKind.TrueLiteralExpression : SyntaxKind.FalseLiteralExpression);

            else if (value is int i)
                return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(i));

            else if (value is uint ui)
                return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(ui));

            else if (value is long l)
                return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(l));

            else if (value is ulong ul)
                return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(ul));

            else if (value is float f)
                return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(f));

            else if (value is double d)
                return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(d));

            else if (value is decimal de)
                return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(de));

            else if (value is char c)
                return SyntaxFactory.LiteralExpression(SyntaxKind.CharacterLiteralExpression, SyntaxFactory.Literal(c));

            else if (value is string s)
                return SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(s));

            throw new NotSupportedException();

        }

        /// <summary>
        /// Creates a token corresponding to a syntax kind. This method can be used for token syntax kinds whose text
        /// can be inferred by the kind alone.
        /// </summary>
        /// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
        /// <returns></returns>
        public static SyntaxToken Token(SyntaxKind kind)
        {
            return SyntaxFactory.Token(kind);
        }


        /// <summary>
        /// Parse a NameSyntax node using the grammar rule for names.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static NameSyntax Name(string name)
        {
            return SyntaxFactory.ParseName(name);
        }

        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        public void Stop()
        {
            System.Diagnostics.Debugger.Break();
        }




    }

}
