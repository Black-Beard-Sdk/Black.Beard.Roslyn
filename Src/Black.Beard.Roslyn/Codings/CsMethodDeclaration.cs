using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bb.Codings
{

    public class CsMethodDeclaration : CSMemberDeclaration
    {

        public CsMethodDeclaration(string name, TypeSyntax type)
            : base(name)
        {
            TypeReturn = type;
        }

        public CsMethodDeclaration(string name, Type type)
            : base(name)
        {
            TypeReturn = type.AsType();
        }

        public CsMethodDeclaration(string name, string typeName = "void")
            : base(name)
        {
            TypeReturn = typeName.AsType();
        }

        public CsMethodDeclaration(string name)
            : base(name)
        {
            TypeReturn = "void" .AsType();
        }

        #region ReturnType

        public CsMethodDeclaration ReturnType(string type)
        {
            TypeReturn = type.AsType();
            return this;
        }

        public CsMethodDeclaration ReturnType(TypeSyntax type)
        {
            TypeReturn = type;
            return this;
        }

        public CsMethodDeclaration ReturnType(Type type)
        {
            TypeReturn = type.AsType();
            return this;
        }

        #endregion ReturnType    

        public CsParameterDeclaration Parameter(string name, string typeName)
        {
            return Add(new CsParameterDeclaration(name, typeName));
        }

        public CsParameterDeclaration Parameter(string name, Type type)
        {
            return Add(new CsParameterDeclaration(name, type));
        }

        public CsMethodDeclaration Parameter(string name, string typeName, Action<CsParameterDeclaration> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            action(Parameter(name, typeName));
            return this;
        }

        public CsMethodDeclaration Parameter(string name, Type type, Action<CsParameterDeclaration> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            action(Parameter(name, type));
            return this;
        }

        public CsMethodDeclaration Body(Action<CodeBlock> action)
        {
            _body = new CodeBlock();
            action(_body);
            return this;
        }



        internal override SyntaxNode Build()
        {

            var methodDeclaration = SyntaxFactory.MethodDeclaration(TypeReturn, Name);

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

        protected ParameterListSyntax GetMethodParameters()
        {
            List<SyntaxNodeOrToken> lst = GetParameters();
            if (lst.Count > 0)
                return SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList<ParameterSyntax>(lst.ToArray()));
            return null;

        }

        protected CodeBlock BodyCode => _body;
        private TypeSyntax TypeReturn;
        protected CodeBlock _body;
    }

}
