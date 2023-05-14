using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;

namespace Bb.Codings
{
    public static class CodeBlockHelper
    {


        public static CodeBlock If(this CodeBlock self, ExpressionSyntax condition, Func<StatementSyntax> _true, Func<StatementSyntax> _false = null)
        {
            return self.Add(CodeHelper.If(condition, _true, _false));
        }

        public static CodeBlock Thrown(this CodeBlock self, ExpressionSyntax exception)
        {
            return self.Add(exception.Thrown());
        }

        public static CodeBlock Foreach(this CodeBlock self, ExpressionSyntax variable, ExpressionSyntax inVariable, Func<StatementSyntax> block)
        {
            return self.Add(CodeHelper.Foreach(variable, inVariable, block));
        }

        public static CodeBlock Set(this CodeBlock self, ExpressionSyntax left, ExpressionSyntax right)
        {
            return self.Add(left.Set(right));
        }

    }

}
