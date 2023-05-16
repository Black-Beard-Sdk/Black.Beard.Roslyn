using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace Bb.Codings
{

    public class CsFieldDeclaration : CSMemberDeclaration
    {

        public CsFieldDeclaration(string name, TypeSyntax typeName)
            : base(name)
        {
            TypeReturn = typeName;

        }

        public CsFieldDeclaration(string name, string typeName)
            : base(name)
        {
            TypeReturn = typeName.AsType();

        }

        #region ReturnType

        public CsFieldDeclaration ReturnType(string type)
        {
            TypeReturn = type.AsType();
            return this;
        }

        public CsFieldDeclaration ReturnType(TypeSyntax type)
        {
            TypeReturn = type;
            return this;
        }

        public CsFieldDeclaration ReturnType(Type type)
        {
            TypeReturn = type.AsType();
            return this;
        }

        #endregion ReturnType

        public new CsFieldDeclaration Attribute(string attributeName, Action<CsAttributeDeclaration> action)
        {
            base.Attribute(attributeName, action);
            return this;
        }

        #region Modifiers

        public new CsFieldDeclaration IsStatic()
        {
            base.IsStatic();
            return this;
        }

        public new CsFieldDeclaration IsPublic()
        {
            base.IsPublic();
            return this;
        }

        public new CsFieldDeclaration IsPrivate()
        {
            base.IsPrivate();
            return this;
        }

        public new CsFieldDeclaration IsInternal()
        {
            base.IsInternal();
            return this;
        }

        public new CsFieldDeclaration IsProtected()
        {
            base.IsProtected();
            return this;
        }

        #endregion Modifiers

        internal override SyntaxNode Build()
        {

            var v = Name.DeclareVar(TypeReturn);

            FieldDeclarationSyntax fieldDeclaration = SyntaxFactory.FieldDeclaration(v);

            #region attributes

            var attr = GetAttributes();
            foreach (var attribute in attr)
                fieldDeclaration = fieldDeclaration.AddAttributeLists(attribute);

            #endregion attributes


            #region Modifiers

            if (_isPublic)
                fieldDeclaration = fieldDeclaration.AddModifiers(SyntaxKind.PublicKeyword.ToToken());

            else if (_isPrivate)
                fieldDeclaration = fieldDeclaration.AddModifiers(SyntaxKind.PrivateKeyword.ToToken());

            if (_isInternal)
                fieldDeclaration = fieldDeclaration.AddModifiers(SyntaxKind.InternalKeyword.ToToken());

            if (_isProtected)
                fieldDeclaration = fieldDeclaration.AddModifiers(SyntaxKind.ProtectedKeyword.ToToken());

            if (_isStatic)
                fieldDeclaration = fieldDeclaration.AddModifiers(SyntaxKind.StaticKeyword.ToToken());

            #endregion Modifiers

            fieldDeclaration = ApplyXmlDocumentation(fieldDeclaration);

            return fieldDeclaration;

        }

        private TypeSyntax TypeReturn;

    }

}
