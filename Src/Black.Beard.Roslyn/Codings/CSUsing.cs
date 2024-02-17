using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;

namespace Bb.Codings
{
    [DebuggerDisplay("{NamespaceOrType}")]
    public class CSUsing : CSharpNode
    {

        /// <summary>
        ///  Initializes a new instance of the <see cref="CSUsing"/> class.
        /// </summary>
        /// <param name="namespaceOrType"></param>
        public CSUsing(string namespaceOrType)
        {
                this.NamespaceOrType = namespaceOrType;
        }

        /// <summary>
        /// Namespace or type to use
        /// </summary>
        public string NamespaceOrType { get; set; }

        /// <summary>
        /// Using is static
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// Using has alias
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Using is global
        /// </summary>
        public bool IsGlobal { get; set; }


        internal override SyntaxNode Build()
        {
                        
            UsingDirectiveSyntax directive = SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(this.NamespaceOrType));

            if (this.IsGlobal)
                directive = directive.WithGlobalKeyword(Token(SyntaxKind.GlobalKeyword));

            if (this.IsStatic)
                directive = directive.WithStaticKeyword(Token(SyntaxKind.StaticKeyword));

            if (this.Alias != null)
                directive = directive.WithAlias(SyntaxFactory.NameEquals(SyntaxFactory.IdentifierName(this.Alias)));

            return directive;

        }
           

    }

}
