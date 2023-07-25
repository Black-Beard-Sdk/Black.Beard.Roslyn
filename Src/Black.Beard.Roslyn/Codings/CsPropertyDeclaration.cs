using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace Bb.Codings
{

    public class CsPropertyDeclaration : CSMemberDeclaration
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CsPropertyDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="typeName">Name of the type.</param>
        public CsPropertyDeclaration(string name, string typeName)
            : base(name)
        {
            TypeReturn = typeName.AsType();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CsPropertyDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        public CsPropertyDeclaration(string name, Type type)
            : base(name)
        {
            TypeReturn = type.Name.AsType();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CsPropertyDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        public CsPropertyDeclaration(string name, TypeSyntax type)
            : base(name)
        {
            TypeReturn = type;
        }

        #region ReturnType

        /// <summary>
        /// Specify the type of the property.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public CsPropertyDeclaration ReturnType(string type)
        {
            TypeReturn = type.AsType();
            return this;
        }

        /// <summary>
        /// Specify the type of the property
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public CsPropertyDeclaration ReturnType(TypeSyntax type)
        {
            TypeReturn = type;
            return this;
        }

        /// <summary>
        /// Specify the type of the property
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public CsPropertyDeclaration ReturnType(Type type)
        {
            TypeReturn = type.AsType();
            return this;
        }

        #endregion ReturnType

        /// <summary>
        /// generate empty set. { set; }
        /// </summary>
        /// <returns></returns>
        public CsPropertyDeclaration AutoSet()
        {
            _autoSet = true;
            return this;
        }

        /// <summary>
        /// Manipulate the set body.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">action</exception>
        public CsPropertyDeclaration BodySet(Action<CodeBlock> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            _bodySet = new CodeBlock();
            action(_bodySet);
            return this;
        }

        /// <summary>
        /// Manipulate the get body.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">action</exception>
        public CsPropertyDeclaration BodyGet(Action<CodeBlock> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            _bodyGet = new CodeBlock();
            action(_bodyGet);
            return this;
        }

        /// <summary>
        /// generate empty get. { get; }
        /// </summary>
        /// <returns></returns>
        public CsPropertyDeclaration AutoGet()
        {
            _autoGet = true;
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
