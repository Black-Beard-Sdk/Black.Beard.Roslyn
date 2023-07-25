using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bb.Codings
{


    /// <summary>
    /// Manage csharp code artifact for generate the code.
    /// </summary>
    /// <seealso cref="Bb.Codings.CSMemberDeclaration" />
    public class CSharpArtifact : CSMemberDeclaration
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpArtifact"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="projectPath">The project path.</param>
        public CSharpArtifact(string name, string projectPath = null) 
            : base(name)
        {
            this.ProjectPath = projectPath;
            _usings = new HashSet<string>();
        }

        /// <summary>
        /// append using directives in the source code with specified name.
        /// </summary>
        /// <param name="usings">The usings to append.</param>
        /// <returns></returns>
        public CSharpArtifact Usings(params string[] usings)
        {
            foreach (var @using in usings)
                _usings.Add(@using);
            return this;
        }

        /// <summary>
        /// append using directives in the source code with specified name.
        /// </summary>
        /// <param name="usings">The usings.</param>
        /// <returns></returns>
        public CSharpArtifact Usings(params Type[] usings)
        {
            foreach (var @using in usings)
                if (!string.IsNullOrEmpty(@using.Namespace))
                    _usings.Add(@using.Namespace);
            return this;
        }


        public CSNamespace Namespace(string @namespace)
        {
            return Add( new CSNamespace(@namespace));
        }

        /// <summary>
        /// Add a new Namespace with specified name.
        /// </summary>
        /// <param name="namespace">The namespace.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">action</exception>
        public CSharpArtifact Namespace(string @namespace, Action<CSNamespace> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            action(Namespace(@namespace));
            return this;
        }


        public CompilationUnitSyntax Tree => (CompilationUnitSyntax)Build();

        /// <summary>
        /// return the code generated
        /// </summary>
        /// <returns></returns>
        public StringBuilder Code()
        {
            CompilationUnitSyntax b = (CompilationUnitSyntax)Build();
            var sb = new StringBuilder
                (
                    b.NormalizeWhitespace()
                     .ToFullString()
                );
            return sb;
        }

        /// <summary>
        /// return the code generated.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Code().ToString();
        }

        private CompilationUnitSyntax AppendUsings(CompilationUnitSyntax self)
        {
            foreach (var @using in _usings)
            {
                var u = SyntaxFactory.ParseName(@using);
                UsingDirectiveSyntax directive = SyntaxFactory.UsingDirective(u);
                self = self.AddUsings(directive);
            }

            return self;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        internal override SyntaxNode Build()
        {

            CompilationUnitSyntax syntaxFactory = SyntaxFactory.CompilationUnit();
            syntaxFactory = AppendUsings(syntaxFactory);

            foreach (var @namespace in Members)
            {

                var result = @namespace.Build();
                if (result != null)
                {
                    if (result is MemberDeclarationSyntax ns)
                        syntaxFactory = syntaxFactory.AddMembers(ns);

                }

            }

            return syntaxFactory;

        }

        public string ProjectPath { get; }

        private readonly HashSet<string> _usings;

    }

}
