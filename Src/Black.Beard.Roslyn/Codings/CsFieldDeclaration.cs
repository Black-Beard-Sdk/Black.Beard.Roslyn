using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bb.Codings
{

    public class CsFieldDeclaration : CSMemberDeclaration
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CsFieldDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="typeName">Name of the type.</param>
        public CsFieldDeclaration(string name, TypeSyntax typeName)
            : base(name)
        {
            TypeReturn = typeName;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CsFieldDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="typeName">Name of the type.</param>
        public CsFieldDeclaration(string name, string typeName)
            : base(name)
        {
            TypeReturn = typeName.AsType();

        }

        #region ReturnType

        /// <summary>
        /// Specify the type of the field
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public CsFieldDeclaration ReturnType(string type)
        {
            TypeReturn = type.AsType();
            return this;
        }

        /// <summary>
        /// Specify the type of the field
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public CsFieldDeclaration ReturnType(TypeSyntax type)
        {
            TypeReturn = type;
            return this;
        }

        /// <summary>
        /// Specify the type of the field
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public CsFieldDeclaration ReturnType(Type type)
        {
            TypeReturn = type.AsType();
            return this;
        }

        #endregion ReturnType

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

        /// <summary>
        /// Sets the initial value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
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
