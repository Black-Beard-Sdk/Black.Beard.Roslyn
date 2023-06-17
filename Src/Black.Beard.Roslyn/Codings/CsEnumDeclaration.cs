using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace Bb.Codings
{
    public class CsEnumDeclaration : CsBaseTypeDeclaration
    {

        public CsEnumDeclaration(string name)
           : base(name)
        {
            this.BaseType = typeof(Int32);
        }

        #region Members

        public CsFieldDeclaration EnumMember(string fieldName, string type)
        {
            return Add(new CsFieldDeclaration(fieldName, type) { IsEnumMember = true });
        }

        public CsFieldDeclaration EnumMember(string fieldName, string type, Action<CsFieldDeclaration> action)
        {
            var e = new CsFieldDeclaration(fieldName, type) { IsEnumMember = true };
            action(e);
            return Add(e);
        }

        public void EnumMember(object name1, string name2, Action<CsFieldDeclaration> value)
        {
            throw new NotImplementedException();
        }


        #endregion Members

        internal override SyntaxNode Build()
        {

            EnumDeclarationSyntax enumDeclaration = SyntaxFactory.EnumDeclaration(Name);
            enumDeclaration = enumDeclaration.AddBaseListTypes(SyntaxFactory.SimpleBaseType(BaseType.AsType()));

            #region attributes

            var attr = GetAttributes();
            foreach (var attribute in attr)
                enumDeclaration = enumDeclaration.AddAttributeLists(attribute);

            #endregion attributes

            #region Modifiers

            if (_isPublic)
                enumDeclaration = enumDeclaration.AddModifiers(SyntaxKind.PublicKeyword.ToToken());

            else if (_isPrivate)
                enumDeclaration = enumDeclaration.AddModifiers(SyntaxKind.PrivateKeyword.ToToken());

            if (_isInternal)
                enumDeclaration = enumDeclaration.AddModifiers(SyntaxKind.InternalKeyword.ToToken());

            if (_isProtected)
                enumDeclaration = enumDeclaration.AddModifiers(SyntaxKind.ProtectedKeyword.ToToken());

            if (_isPartial)
                enumDeclaration = enumDeclaration.AddModifiers(SyntaxKind.PartialKeyword.ToToken());

            #endregion Modifiers

            #region members

            foreach (var item in Members)
            {
                var member = item.Build();
                if (member != null)
                {
                    if (member is EnumMemberDeclarationSyntax b)
                        enumDeclaration = enumDeclaration.AddMembers(b);

                    else
                        Stop();

                    enumDeclaration = enumDeclaration.WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed);

                }
            }

            #endregion members

            enumDeclaration = ApplyXmlDocumentation(enumDeclaration);

            return enumDeclaration;

        }


        private bool _isPartial;

        public Type BaseType { get; set; }

    }

}
