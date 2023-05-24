using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace Bb.Codings
{
    public class CsPropertyDeclaration : CSMemberDeclaration
    {

        public CsPropertyDeclaration(string name, string typeName)
            : base(name)
        {
            TypeReturn = typeName.AsType();
        }

        public CsPropertyDeclaration(string name, Type type)
            : base(name)
        {
            TypeReturn = type.Name.AsType();
        }

        public CsPropertyDeclaration(string name, TypeSyntax type)
            : base(name)
        {
            TypeReturn = type;
        }

        #region ReturnType

        public CsPropertyDeclaration ReturnType(string type)
        {
            TypeReturn = type.AsType();
            return this;
        }

        public CsPropertyDeclaration ReturnType(TypeSyntax type)
        {
            TypeReturn = type;
            return this;
        }

        public CsPropertyDeclaration ReturnType(Type type)
        {
            TypeReturn = type.AsType();
            return this;
        }

        #endregion ReturnType


        public CsPropertyDeclaration AutoSet()
        {
            _autoSet = true;
            return this;
        }

        public CsPropertyDeclaration BodySet(Action<CodeBlock> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            _bodySet = new CodeBlock();
            action(_bodySet);
            return this;
        }

        public CsPropertyDeclaration BodyGet(Action<CodeBlock> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            _bodyGet = new CodeBlock();
            action(_bodyGet);
            return this;
        }

        public CsPropertyDeclaration AutoGet()
        {
            _autoGet = true;
            return this;
        }

        #region Modifiers

        public new CsPropertyDeclaration IsStatic()
        {
            base.IsStatic();
            return this;
        }

        public new CsPropertyDeclaration IsPublic()
        {
            base.IsPublic();
            return this;
        }

        public new CsPropertyDeclaration IsPrivate()
        {
            base.IsPrivate();
            return this;
        }

        public new CsPropertyDeclaration IsInternal()
        {
            base.IsInternal();
            return this;
        }

        public new CsPropertyDeclaration IsProtected()
        {
            base.IsProtected();
            return this;
        }

        #endregion Modifiers

        public new CsPropertyDeclaration Attribute(string attributeName, Action<CsAttributeDeclaration> action)
        {
            base.Attribute(attributeName, action);
            return this;
        }

        public new CsPropertyDeclaration Attribute(Type attribute, Action<CsAttributeDeclaration> action)
        {
            base.Attribute(attribute, action);
            return this;
        }

        internal override SyntaxNode Build()
        {

            var v = Name.DeclareVar(TypeReturn);

            PropertyDeclarationSyntax propertyDeclaration = SyntaxFactory.PropertyDeclaration(TypeReturn, Name);

            #region attributes

            var attr = GetAttributes();
            foreach (var attribute in attr)
                propertyDeclaration = propertyDeclaration.AddAttributeLists(attribute);

            #endregion attributes

            #region Modifiers

            if (_isPublic)
                propertyDeclaration = propertyDeclaration.AddModifiers(SyntaxKind.PublicKeyword.ToToken());

            else if (_isPrivate)
                propertyDeclaration = propertyDeclaration.AddModifiers(SyntaxKind.PrivateKeyword.ToToken());

            if (_isInternal)
                propertyDeclaration = propertyDeclaration.AddModifiers(SyntaxKind.InternalKeyword.ToToken());

            if (_isProtected)
                propertyDeclaration = propertyDeclaration.AddModifiers(SyntaxKind.ProtectedKeyword.ToToken());

            if (_isStatic)
                propertyDeclaration = propertyDeclaration.AddModifiers(SyntaxKind.StaticKeyword.ToToken());

            #endregion Modifiers

            AccessorDeclarationSyntax set = null;
            AccessorDeclarationSyntax get = null;

            if (_autoGet)
                get = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

            else if (_bodyGet != null)
                get = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithBody(_bodyGet.Build());

            if (get != null)
                propertyDeclaration = propertyDeclaration.AddAccessorListAccessors(get);


            if (_autoSet)
                set = SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

            else if (_bodySet != null)
                set = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithBody(_bodySet.Build());

            if (set != null)
                propertyDeclaration = propertyDeclaration.AddAccessorListAccessors(set);

            propertyDeclaration = ApplyXmlDocumentation(propertyDeclaration);

            return propertyDeclaration;

        }

        private TypeSyntax TypeReturn;
        private bool _autoSet;
        private bool _autoGet;
        private CodeBlock _bodySet;
        private CodeBlock _bodyGet;
    }


}
