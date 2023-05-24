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

            if (IsEnumMember)
            {

                EnumMemberDeclarationSyntax enumMemberDeclaration = SyntaxFactory.EnumMemberDeclaration(Name);
                SetAttribute(enumMemberDeclaration);
                enumMemberDeclaration = ApplyXmlDocumentation(enumMemberDeclaration);

                if (this.InitialValue != null)
                    enumMemberDeclaration = enumMemberDeclaration.WithEqualsValue(SyntaxFactory.EqualsValueClause(this.InitialValue));

                return enumMemberDeclaration;

            }

            VariableDeclarationSyntax variable;
            if (this.InitialValue != null)
                variable = Name.DeclareVar(TypeReturn, this.InitialValue);
            else
                variable = Name.DeclareVar(TypeReturn);

            FieldDeclarationSyntax fieldDeclaration = SyntaxFactory.FieldDeclaration(variable);
            SetAttribute(fieldDeclaration);

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

        private FieldDeclarationSyntax SetAttribute(FieldDeclarationSyntax declaration)
        {
            var attr = GetAttributes();
            foreach (var attribute in attr)
                declaration = declaration.AddAttributeLists(attribute);
            return declaration;
        }

        private EnumMemberDeclarationSyntax SetAttribute(EnumMemberDeclarationSyntax declaration)
        {
            var attr = GetAttributes();
            foreach (var attribute in attr)
                declaration = declaration.AddAttributeLists(attribute);
            return declaration;
        }

        public CsFieldDeclaration SetInitialValue(object value)
        {
            this.InitialValue = value.Literal();
            return this;
        }


        private TypeSyntax TypeReturn;

        public bool IsEnumMember { get; set; }
        public ExpressionSyntax InitialValue { get; private set; }

    }

}
