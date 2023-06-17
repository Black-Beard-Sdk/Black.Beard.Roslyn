using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bb.Codings
{

    public abstract class CSharpNode
    {

        public CSharpNode()
        {
            //this._parent = parent ?? throw new NullReferenceException(nameof(parent));
        }

        internal abstract SyntaxNode Build();

        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        public void Stop()
        {
            System.Diagnostics.Debugger.Break();
        }

    }

}
