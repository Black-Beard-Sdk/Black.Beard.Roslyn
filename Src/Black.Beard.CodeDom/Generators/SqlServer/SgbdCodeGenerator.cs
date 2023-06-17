using Bb.Generators.Csharp;
using Bb.Schemas.Database.CodeDom;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Generators.SqlServer
{

    internal partial class SgbdCodeGenerator : VisitorMethodResolver, ICodeGenerator
    {

        public SgbdCodeGenerator(Type type, IDictionary<string, string> providerOptions = null)
            : base(type)
        {
            this._providerOptions = providerOptions;
        }


        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Diagnostics.DebuggerStepThrough]
        protected static void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }

        #region ICodeCompiler

        public bool IsValidIdentifier(string value)
        {
            throw new NotImplementedException();
        }

        public void ValidateIdentifier(string value)
        {
            throw new NotImplementedException();
        }

        public virtual string CreateEscapedIdentifier(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return "[" + name + "]";
        }

        public string CreateValidIdentifier(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (CSharpHelpers.IsPrefixTwoUnderscore(name))
            {
                name = "_" + name;
            }

            while (CSharpHelpers.IsKeyword(name))
            {
                name = "_" + name;
            }

            return name;
        }

        public virtual string GetTypeOutput(CodeTypeReference typeRef)
        {

            string s = string.Empty;

            CodeTypeReference baseTypeRef = typeRef;
            //while (baseTypeRef.ArrayElementType != null)
            //{
            //    baseTypeRef = baseTypeRef.ArrayElementType;
            //}

            s += GetBaseTypeOutput(baseTypeRef);

            return s;

        }

        public bool Supports(GeneratorSupport supports)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeFromExpression(CodeExpression e, TextWriter w, CodeGeneratorOptions o)
        {
            bool setLocal = false;
            if (_output != null && w != _output.InnerWriter)
            {
                throw new InvalidOperationException(ResourceString.CodeGenOutputWriter);
            }
            if (_output == null)
            {
                setLocal = true;
                _options = o ?? new CodeGeneratorOptions();
                _output = new ExposedTabStringIndentedTextWriter(w, _options.IndentString);
            }

            try
            {
                GenerateExpression(e);
            }
            finally
            {
                if (setLocal)
                {
                    _output = null;
                    _options = null;
                }
            }
        }

        public void GenerateCodeFromStatement(CodeStatement e, TextWriter w, CodeGeneratorOptions o)
        {

            bool setLocal = false;
            if (_output != null && w != _output.InnerWriter)
            {
                throw new InvalidOperationException(ResourceString.CodeGenOutputWriter);
            }
            if (_output == null)
            {
                setLocal = true;
                _options = o ?? new CodeGeneratorOptions();
                _output = new ExposedTabStringIndentedTextWriter(w, _options.IndentString);
            }

            try
            {
                GenerateStatement(e);
            }
            finally
            {
                if (setLocal)
                {
                    _output = null;
                    _options = null;
                }
            }

        }

        public void GenerateCodeFromNamespace(CodeNamespace e, TextWriter w, CodeGeneratorOptions o)
        {

            bool setLocal = false;
            if (_output != null && w != _output.InnerWriter)
                throw new InvalidOperationException(ResourceString.CodeGenOutputWriter);

            if (_output == null)
            {
                setLocal = true;
                _options = o ?? new CodeGeneratorOptions();
                _output = new ExposedTabStringIndentedTextWriter(w, _options.IndentString);
            }

            try
            {
                GenerateNamespace(e);
            }
            finally
            {
                if (setLocal)
                {
                    _output = null;
                    _options = null;
                }
            }

        }

        public void GenerateCodeFromCompileUnit(CodeCompileUnit e, TextWriter w, CodeGeneratorOptions o)
        {
            bool setLocal = false;
            if (_output != null && w != _output.InnerWriter)
            {
                throw new InvalidOperationException(ResourceString.CodeGenOutputWriter);
            }
            if (_output == null)
            {
                setLocal = true;
                _options = o ?? new CodeGeneratorOptions();
                _output = new ExposedTabStringIndentedTextWriter(w, _options.IndentString);
            }

            try
            {
                if (e is CodeSnippetCompileUnit)
                {
                    GenerateSnippetCompileUnit((CodeSnippetCompileUnit)e);
                }
                else
                {
                    GenerateCompileUnit(e);
                }
            }
            finally
            {
                if (setLocal)
                {
                    _output = null;
                    _options = null;
                }
            }
        }

        public void GenerateCodeFromType(CodeTypeDeclaration e, TextWriter w, CodeGeneratorOptions o)
        {
            bool setLocal = false;

            if (_output != null && w != _output.InnerWriter)
                throw new InvalidOperationException(ResourceString.CodeGenOutputWriter);

            if (_output == null)
            {
                setLocal = true;
                _options = o ?? new CodeGeneratorOptions();
                _output = new ExposedTabStringIndentedTextWriter(w, _options.IndentString);
            }

            try
            {
                GenerateType(e);
            }
            finally
            {
                if (setLocal)
                {
                    _output = null;
                    _options = null;
                }
            }
        }

        #endregion ICodeCompiler

        protected virtual void GenerateType(CodeTypeDeclaration e)
        {

            if (e.StartDirectives.Count > 0)
                GenerateDirectives(e.StartDirectives);

            GenerateCommentStatements(e.Comments);

            if (!Visit(e))
                Stop();

            if (e.EndDirectives.Count > 0)
                GenerateDirectives(e.EndDirectives);

        }

        public virtual void GeneratePropertyReference(CodePropertyReferenceExpression reference)
        {

            if (reference.TargetObject != null)
            {
                if (reference.TargetObject is CodePropertyReferenceExpression ref2)
                    GeneratePropertyReference(ref2);

                else
                {

                    Stop();

                }
            }

            OutputIdentifier(reference.PropertyName);

        }


        public virtual void GenerateCreateTableTypeDeclaration(CreateTableTypeDeclaration table)
        {

            Output.Write("CREATE TABLE ");
            GeneratePropertyReference(table.Reference);
            Output.WriteLine();
            using (NewIndentParenth())
            {
                GenerateMembers(table);
            }

            Output.WriteLine(";");

        }

        public virtual void GenerateAlterTableTypeDeclaration(AlterTableTypeDeclaration table)
        {

            Output.Write($"ALTER TABLE {GetBaseTypeOutput(table.ObjectReference)}");

            using (NewIndent())
            {
                GenerateMembers(table);
            }

            Output.WriteLine(";");

        }

        protected virtual void OutputStartingBrace()
        {

            Output.WriteLine(" (");

        }

        public virtual void GenerateMembers(CodeTypeDeclaration e)
        {

            var last = e.Members[e.Members.Count - 1];

            foreach (CodeTypeMember current in e.Members)
            {

                if (_options.BlankLinesBetweenMembers)
                    Output.WriteLine();

                if (current.StartDirectives.Count > 0)
                    GenerateDirectives(current.StartDirectives);

                GenerateCommentStatements(current.Comments);

                if (!Visit(current))
                    Stop();

                if (current != last)
                    Output.Write(", ");
                
                if (current.EndDirectives.Count > 0)
                    GenerateDirectives(current.EndDirectives);

            }

        }

        protected virtual void GenerateExpression(CodeExpression e)
        {
            if (!Visit(e))
                Stop();
        }

        public virtual void GenerateStatement(CodeStatement e)
        {

            if (e == null)
                throw new ArgumentNullException(nameof(e));

            if (e.StartDirectives.Count > 0)
                GenerateDirectives(e.StartDirectives);

            if (e is CodeSnippetStatement)
            {

                // Don't indent snippet statements, in order to preserve the column
                // information from the original code.  This improves the debugging
                // experience.
                int savedIndent = Indent;
                Indent = 0;

                GenerateSnippetStatement((CodeSnippetStatement)e);

                // Restore the indent
                Indent = savedIndent;

            }

            else
            {
                throw new ArgumentException(string.Format(ResourceString.InvalidElementType, e.GetType().FullName), nameof(e));
            }

            if (e.EndDirectives.Count > 0)
                GenerateDirectives(e.EndDirectives);

        }

        protected void GenerateSnippetStatement(CodeSnippetStatement e)
        {
            Output.WriteLine(e.Value);
        }

        public void GenerateStatements(CodeStatementCollection stmts)
        {
            foreach (CodeStatement stmt in stmts)
            {
                ((ICodeGenerator)this).GenerateCodeFromStatement(stmt, _output.InnerWriter, _options);
            }
        }

        public void GenerateNamespace(CodeNamespace e)
        {

            GenerateCommentStatements(e.Comments);

            Output.WriteLine();

            GenerateTypes(e);

        }

        protected virtual void GenerateTypes(CodeNamespace e)
        {

            foreach (CodeTypeDeclaration c in e.Types)
            {

                if (_options.BlankLinesBetweenMembers)
                    Output.WriteLine();

                ((ICodeGenerator)this).GenerateCodeFromType(c, _output.InnerWriter, _options);

            }

        }

        protected virtual void GenerateSnippetCompileUnit(CodeSnippetCompileUnit e)
        {

            GenerateDirectives(e.StartDirectives);

            Output.WriteLine(e.Value);

            if (e.EndDirectives.Count > 0)
                GenerateDirectives(e.EndDirectives);

        }

        protected virtual void GenerateCompileUnit(CodeCompileUnit e)
        {
            GenerateCompileUnitStart(e);
            GenerateNamespaces(e);
            GenerateCompileUnitEnd(e);
        }

        protected virtual void GenerateNamespaces(CodeCompileUnit e)
        {
            foreach (CodeNamespace n in e.Namespaces)
            {
                ((ICodeGenerator)this).GenerateCodeFromNamespace(n, _output.InnerWriter, _options);
            }
        }

        public void GenerateSnippetExpression(CodeSnippetExpression e)
        {
            Output.Write(e.Value);
        }

        protected virtual void GenerateCompileUnitStart(CodeCompileUnit e)
        {

            if (e.StartDirectives.Count > 0)
                GenerateDirectives(e.StartDirectives);

            Output.WriteLine("-- ------------------------------------------------------------------------------");
            Output.Write("-- <");
            Output.WriteLine(ResourceString.AutoGen_Comment_Line1);
            Output.Write("--     ");
            Output.WriteLine(ResourceString.AutoGen_Comment_Line2);
            Output.WriteLine("--");
            Output.Write("--     ");
            Output.WriteLine(ResourceString.AutoGen_Comment_Line4);
            Output.Write("--     ");
            Output.WriteLine(ResourceString.AutoGen_Comment_Line5);
            Output.Write("-- </");
            Output.WriteLine(ResourceString.AutoGen_Comment_Line1);
            Output.WriteLine("-- ------------------------------------------------------------------------------");
            Output.WriteLine();

        }

        protected virtual void GenerateDirectives(CodeDirectiveCollection startDirectives)
        {
            foreach (var item in startDirectives)
            {
                GenerateDirective(item);
            }
        }

        protected virtual void GenerateDirective(object item)
        {
            Stop();
        }

        protected virtual void GenerateCompileUnitEnd(CodeCompileUnit e)
        {
            if (e.EndDirectives.Count > 0)
            {
                GenerateDirectives(e.EndDirectives);
            }
        }


        #region Comments

        public void GenerateCommentStatements(CodeCommentStatementCollection e)
        {
            foreach (CodeCommentStatement comment in e)
            {
                GenerateCommentStatement(comment);
            }
        }

        public void GenerateCommentStatement(CodeCommentStatement e)
        {

            if (e.Comment == null)
                throw new ArgumentException(string.Format(ResourceString.Argument_NullComment, nameof(e)), nameof(e));

            GenerateComment(e.Comment);

        }

        public void GenerateComment(CodeComment e)
        {
            string commentLineStart = e.DocComment ? "///" : "//";
            Output.Write(commentLineStart);
            Output.Write(' ');

            string value = e.Text;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '\u0000')
                {
                    continue;
                }
                Output.Write(value[i]);

                if (value[i] == '\r')
                {
                    if (i < value.Length - 1 && value[i + 1] == '\n')
                    { // if next char is '\n', skip it
                        Output.Write('\n');
                        i++;
                    }
                    _output.InternalOutputTabs();
                    Output.Write(commentLineStart);
                }
                else if (value[i] == '\n')
                {
                    _output.InternalOutputTabs();
                    Output.Write(commentLineStart);
                }
                else if (value[i] == '\u2028' || value[i] == '\u2029' || value[i] == '\u0085')
                {
                    Output.Write(commentLineStart);
                }
            }
            Output.WriteLine();
        }

        #endregion Comments


        protected int Indent
        {
            get => _output.Indent;
            set => _output.Indent = value;
        }

        protected void OutputIdentifier(string ident) => Output.Write(CreateEscapedIdentifier(ident));

        public string GetBaseTypeOutput(CodeTypeReference typeRef, bool preferBuiltInTypes = true)
        {

            string s = typeRef.BaseType;

            if (preferBuiltInTypes)
            {

                if (s.Length == 0)
                    return "void";

                string lowerCaseString = s.ToLowerInvariant().Trim();

                if (_types.TryGetValue(lowerCaseString, out var type))
                    return type;

            }

            string baseType = typeRef.BaseType;

            return CreateEscapedIdentifier(baseType);

        }

        protected void AddTypeMap(string key, string value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            this._types.Add(key, value);

        }

        protected IDisposable NewIndent()
        {
            return new IndentBloc(this, null, null);
        }

        protected IDisposable NewIndentParenth()
        {
            return new IndentBloc(this, "(", ")");
        }

        protected class IndentBloc : IDisposable
        {

            public IndentBloc(SgbdCodeGenerator parent, string start, string end)
            {
                this._parent = parent;
                this._end = end;
                if (!string.IsNullOrEmpty(start))
                    _parent.Output.Write(start);
                this._parent.Indent++;
            }

            private readonly SgbdCodeGenerator _parent;
            private string _end;

            public void Dispose()
            {
                this._parent.Indent--;
                if (!string.IsNullOrEmpty(this._end))
                    _parent.Output.Write(this._end);

            }

        }


        protected TextWriter Output => _output;
        private ExposedTabStringIndentedTextWriter _output;
        private readonly IDictionary<string, string> _providerOptions;
        private CodeGeneratorOptions _options;

        private Dictionary<string, string> _types = new Dictionary<string, string>();

    }
}
