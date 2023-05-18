using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;

namespace Bb.Codings
{



    public static class CodeLevelBlockHelper
    {

        public static CodeLevelBlock Return(this CodeLevelBlock self, ExpressionSyntax returnValue)
        {
            return self.Add(returnValue.Return());
        }

        public static CodeLevelBlock DeclareLocalVar(this CodeLevelBlock self, TypeSyntax type, string variableName, ExpressionSyntax initializer)
        {
            var t = variableName.DeclareLocalVar(type, initializer);
            return self.Add(t);
        }

        public static CodeLevelBlock DeclareLocalVar(this CodeLevelBlock self, TypeSyntax type, string variableName)
        {
            var t = variableName.DeclareLocalVar(type);
            return self.Add(t);
        }


        public static CodeLevelBlock TryCatchs(this CodeLevelBlock self, Action<CodeLevelBlock> tryAction, params CatchClauseSyntax[] catchs)
        {

            var list = new StatementList();
            using (var blk = self.Stack(list))
            {
                tryAction(blk);
            }

            var blockTry = SyntaxFactory.Block(list.ToSyntaxList());

            return self.Add(CodeHelper.TryCatchs(blockTry, catchs));

        }

        //public static CodeBlock TryCatchs(this CodeBlock self, FinallyClauseSyntax @finally, BlockSyntax @try, params Func<CatchClauseSyntax>[] catchs)
        //{
        //    return self.Add(CodeHelper.TryCatchs(@try, @finally, catchs));
        //}

        public static CodeLevelBlock If(this CodeLevelBlock self, ExpressionSyntax condition, Func<StatementSyntax> _true, Func<StatementSyntax> _false = null)
        {
            return self.Add(CodeHelper.If(condition, _true, _false));
        }

        public static CodeLevelBlock Thrown(this CodeLevelBlock self, ExpressionSyntax exception)
        {
            return self.Add(exception.Thrown());
        }

        public static CodeLevelBlock Foreach(this CodeLevelBlock self, ExpressionSyntax variable, ExpressionSyntax inVariable, Func<StatementSyntax> block)
        {
            return self.Add(CodeHelper.Foreach(variable, inVariable, block));
        }

        public static CodeLevelBlock Set(this CodeLevelBlock self, ExpressionSyntax left, ExpressionSyntax right)
        {
            return self.Add(left.Set(right));
        }

    }

}
