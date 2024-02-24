using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

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
        public CSharpArtifact()
           : base()
        {
            _usings = new Dictionary<string, CSUsing>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpArtifact"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="projectPath">The project path.</param>
        public CSharpArtifact(string name, string projectPath = null)
            : base(name)
        {
            this.ProjectPath = projectPath;
            _usings = new Dictionary<string, CSUsing>();
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
                    Usings(@using.Namespace);
            return this;
        }

        /// <summary>
        /// append using directives in the source code with specified name.
        /// </summary>
        /// <param name="usings">The usings to append.</param>
        /// <returns></returns>
        public CSharpArtifact Usings(params string[] usings)
        {
            foreach (var @using in usings)
                Using(new CSUsing(@using));
            return this;
        }

        /// <summary>
        /// append static using directives in the source code with specified name.
        /// </summary>
        /// <param name="usings">The static usings to append.</param>
        /// <returns></returns>
        public CSharpArtifact UsingStatics(params string[] usings)
        {
            foreach (var @using in usings)
                Using(new CSUsing(@using) { IsStatic = true });

            return this;
        }

        /// <summary>
        /// append using directives in the source code with specified name.
        /// </summary>
        /// <param name="usings">The usings to append.</param>
        /// <param name="action">action to execute for every namespace.</param>
        /// <returns></returns>
        public CSharpArtifact Usings(string[] usings, Action<CSUsing> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));

            foreach (var @using in usings)
            {
                var u = new CSUsing(@using);
                action(u);
                Using(u);
            }
            return this;
        }

        /// <summary>
        /// append using directives in the source code with specified name.
        /// </summary>
        /// <param name="usings">The usings to append.</param>
        /// <param name="action">action to execute for every namespace.</param>
        /// <returns></returns>
        public CSharpArtifact Using(string @using, Action<CSUsing> action)
        {

            if (action is null)
                throw new ArgumentNullException(nameof(action));

            var u = new CSUsing(@using);

            action(u);

            Using(u);

            return this;
        }

        /// <summary>
        /// append using directives in the source code with specified name.
        /// </summary>
        /// <param name="usings">The usings to append.</param>
        /// <param name="action">action to execute for every namespace.</param>
        /// <returns></returns>
        public CSharpArtifact Using(CSUsing @using)
        {

            if (_usings.TryGetValue(@using.NamespaceOrType, out CSUsing u))
                _usings[@using.NamespaceOrType] = @using;
            else
                _usings.Add(@using.NamespaceOrType, @using);
                  
            return this;
        }


        public CSNamespace Namespace(string @namespace)
        {
            return Add(new CSNamespace(@namespace));
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

        /// <summary>
        /// Get the tree of the code generated
        /// </summary>
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
        /// return the source code generated.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Code().ToString();
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

        /// <summary>
        /// Save the document
        /// </summary>
        public string Save()
        {

            string p = string.Empty;
            if (!string.IsNullOrEmpty(ProjectPath))
                p = System.IO.Path.Combine(ProjectPath, p, this.Name);

            if (!p.ToLower().StartsWith(".cs"))
                p += ".cs";

            return Save(p);

        }

        /// <summary>
        /// Save the document in the specified path.
        /// </summary>
        /// <param name="path">full path where the file must write</param>
        public string Save(string path)
        {
            var file = new FileInfo(path);
            var code = Code().ToString();
            file.Save(code);
            return file.FullName;
        }

        public string ProjectPath { get; }


        private CompilationUnitSyntax AppendUsings(CompilationUnitSyntax self)
        {

            foreach (var @using in _usings)
                self = self.AddUsings((UsingDirectiveSyntax)@using.Value.Build());

            return self;
        }

        private readonly Dictionary<string, CSUsing> _usings;

    }

}
