using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bb.Compilers
{

    internal class CSharpVisitor : CSharpSyntaxWalker
    {


        public CSharpVisitor()
        {
            this._usings = new HashSet<string>();
        }

        //public override void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        //{
        //    base.VisitObjectCreationExpression(node);
        //}

        //public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
        //{
        //    base.VisitFieldDeclaration(node);
        //}

        //public override void VisitArrayType(ArrayTypeSyntax node)
        //{
        //    base.VisitArrayType(node);
        //}

        //public override void VisitParameter(ParameterSyntax node)
        //{
        //    base.VisitParameter(node);
        //}

        //public override void VisitAliasQualifiedName(AliasQualifiedNameSyntax node)
        //{
        //    base.VisitAliasQualifiedName(node);
        //}

        //public override void VisitDeclarationExpression(DeclarationExpressionSyntax node)
        //{
        //    var type = node.Type;
        //    base.VisitDeclarationExpression(node);
        //}

        //public override void VisitRefTypeExpression(RefTypeExpressionSyntax node)
        //{
        //    base.VisitRefTypeExpression(node);
        //}

        //public override void VisitCompilationUnit(CompilationUnitSyntax node)
        //{
        //    base.VisitCompilationUnit(node);
        //}

        //public override void VisitUsingStatement(UsingStatementSyntax node)
        //{
        //    base.VisitUsingStatement(node);
        //}

        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {

            this._usings.Add(node.Name.ToString());

            base.VisitUsingDirective(node);
        }

        public HashSet<string> GetUsings()
        {
            return this._usings;
        }


        private readonly HashSet<string> _usings;

    }

}
