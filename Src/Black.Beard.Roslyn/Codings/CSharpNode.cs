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
