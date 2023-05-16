using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;

namespace Bb.Codings
{
    public class CsCtorDeclaration : CsMethodDeclaration
    {

        public CsCtorDeclaration(string name)
           : base(name)
        {
            _callBase = new List<SyntaxNode>();
        }


        public new CsCtorDeclaration Attribute(string attributeName, Action<CsAttributeDeclaration> action)
        {
            base.Attribute(attributeName, action);
            return this;
        }

        public new CsCtorDeclaration Parameter(string name, string typeName, Action<CsParameterDeclaration> action)
        {


            base.Parameter(name, typeName, action);
            return this;
        }

        public new CsCtorDeclaration Parameter(string name, Type type, Action<CsParameterDeclaration> action)
        {
            base.Parameter(name, type, action);
            return this;
        }

        public new CsCtorDeclaration Body(Action<CodeBlock> action)
        {
            base.Body(action);
            return this;
        }

        internal override SyntaxNode Build()
        {

            var methodDeclaration = SyntaxFactory.ConstructorDeclaration(Name);


            if (_callBase.Count > 0)
            {
                var arguments = _callBase.ToListSaparated(SyntaxKind.CommaToken);
                methodDeclaration.WithInitializer
                (
                    SyntaxFactory.ConstructorInitializer
                    (
                        SyntaxKind.BaseConstructorInitializer,
                        SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList<ArgumentSyntax>(arguments))
                    )
                  );
            }

            #region attributes

            var attr = GetAttributes();
            foreach (var attribute in attr)
                methodDeclaration = methodDeclaration.AddAttributeLists(attribute);

            #endregion attributes

            #region Modifiers

            if (_isPublic)
                methodDeclaration = methodDeclaration.AddModifiers(SyntaxKind.PublicKeyword.ToToken());

            else if (_isPrivate)
                methodDeclaration = methodDeclaration.AddModifiers(SyntaxKind.PrivateKeyword.ToToken());

            if (_isInternal)
                methodDeclaration = methodDeclaration.AddModifiers(SyntaxKind.InternalKeyword.ToToken());

            if (_isProtected)
                methodDeclaration = methodDeclaration.AddModifiers(SyntaxKind.ProtectedKeyword.ToToken());

            if (_isStatic)
                methodDeclaration = methodDeclaration.AddModifiers(SyntaxKind.StaticKeyword.ToToken());

            #endregion Modifiers

            #region parameters

            var parameters = GetMethodParameters();
            if (parameters != null)
                methodDeclaration = methodDeclaration.WithParameterList(parameters);

            #endregion parameters         

            if (BodyCode != null)
                methodDeclaration = methodDeclaration.WithBody(BodyCode.Build());

            methodDeclaration = ApplyXmlDocumentation(methodDeclaration);

            return methodDeclaration;

        }

        private readonly List<SyntaxNode> _callBase;


    }

}
