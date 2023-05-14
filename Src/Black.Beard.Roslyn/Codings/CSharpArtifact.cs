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


    public class CSharpArtifact : CSMemberDeclaration
    {

        public CSharpArtifact(string name) 
            : base(name)
        {
            _usings = new HashSet<string>();
        }

        /// <summary>
        /// append using directives in the source code.
        /// </summary>
        /// <param name="usings">The usings to append.</param>
        /// <returns></returns>
        public CSharpArtifact Usings(params string[] usings)
        {
            foreach (var @using in usings)
                _usings.Add(@using);
            return this;
        }

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

        public CSharpArtifact Namespace(string @namespace, Action<CSNamespace> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            action(Namespace(@namespace));
            return this;
        }


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

        private readonly HashSet<string> _usings;

    }




    //public class CsClassDeclaration : TypeDeclaration
    //{
    //}

    //public class TypeDeclaration : BaseTypeDeclaration
    //{
    //}

    //public class BaseTypeDeclaration : CSMemberDeclaration
    //{
    //}

}
