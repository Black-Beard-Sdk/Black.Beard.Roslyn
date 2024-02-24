using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bb.Codings
{
    public static class StatementListHelper
    {

        public static StatementList Return(this StatementList self, ExpressionSyntax returnValue)
        {
            self.Add(returnValue.Return());
            return self;
        }

        public static StatementList Thrown(this StatementList self, ExpressionSyntax exception)
        {
            self.Add(exception.Thrown());
            return self;
        }

        public static StatementList Thrown(this StatementList self)
        {
            self.Add(CodeHelper.Thrown());
            return self;
        }

        public static StatementList DeclareLocalVar(this StatementList self, TypeSyntax type, string variableName, ExpressionSyntax initializer)
        {
            var t = variableName.DeclareLocalVar(type, initializer);
            self.Add(t);
            return self;
        }

        public static StatementList DeclareLocalVar(this StatementList self, TypeSyntax type, string variableName)
        {
            var t = variableName.DeclareLocalVar(type);
            self.Add(t);
            return self;
        }

                
        public static StatementList If(this StatementList self, ExpressionSyntax condition, Func<StatementSyntax> _true, Func<StatementSyntax> _false = null)
        {
            self.Add(CodeHelper.If(condition, _true, _false));
            return self;
        }
             
        public static StatementList Foreach(this StatementList self, ExpressionSyntax variable, ExpressionSyntax inVariable, Func<StatementSyntax> block)
        {
            self.Add(CodeHelper.Foreach(variable, inVariable, block));
            return self;
        }

        public static StatementList Set(this StatementList self, ExpressionSyntax left, ExpressionSyntax right)
        {
            self.Add(left.Set(right));
            return self;
        }

    }

}
