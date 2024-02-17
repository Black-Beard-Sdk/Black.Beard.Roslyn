using Bb.ComponentModel;
using Bb.Builds;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System.Diagnostics;
using System.Text;
using System.Collections.Immutable;
using Bb.Codings;
using System.Reflection;
using System.Linq;
using Refs;

namespace Bb.Compilers
{



    public class RoslynCompiler
    {

        public RoslynCompiler(AssemblyReferences assemblies)
        {

            this._assemblies = assemblies;
            this.LanguageVersion = assemblies.Sdk.LanguageVersion;

            assemblies.AddByType(typeof(object));
            assemblies.ResolveFilename(Refs.mscorlib.AssemblyFile);
            assemblies.ResolveFilename(Refs.System.Runtime.AssemblyFile);

            _resolver = new ReferenceResolver(assemblies);

        }

        public string KeyFile { get; set; }

        public bool DelaySign { get; set; }

        public ImmutableArray<byte> StrongNameKey { get; set; } = ImmutableArray<byte>.Empty;

        public DocumentationMode DocumentationMode { get; set; } = DocumentationMode.Parse;

        #region Methods

        public RoslynCompiler AddCodeSource(string source, string path = null)
        {
            this._sources.Add(new FileCode() { Content = source, Filepath = path ?? string.Empty });
            this._hash ^= source.CalculateCrc32();
            return this;
        }

        public RoslynCompiler SetOutput(string outputPah)
        {
            this._outputPah = outputPah;
            return this;
        }

        public Action<CSharpCompilationOptions> ConfigureCompilation { get; internal set; }

        private readonly AssemblyReferences _assemblies;

        public LanguageVersion LanguageVersion { get; set; }

        public bool ResolveObjects { get; set; }

        public bool Debug { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CSUsing[] Usings { get; internal set; }



        public AssemblyResult Generate(string? assemblyName = null)
        {

            var date = DateTime.Now;
            this._assemblyName = assemblyName ?? $"assembly_{this._hash}_{date.Year}{date.Month}{date.Day}_{date.Hour}{date.Minute}{date.Second}{date.Millisecond}";

            AssemblyResult result = GetAssemblyResult();
            CSharpCompilation compilation = GetCsharpContext(result);

            try     // emit the compilation result to a byte array corresponding to {AssemblyName}.netmodule byte code
            {

                using (var peStream = File.Create(result.AssemblyFile))
                using (var pdbStream = File.Create(result.AssemblyFilePdb))
                {
                    EmitResult resultEmit = compilation.Emit(peStream, pdbStream);
                    var diags = resultEmit.Diagnostics.ToList().Select(c => c.ToString()).ToArray();
                    AnalyzeCompilation(result, resultEmit, diags);
                }

            }
            catch (Exception ex)
            {

                result.Exception = ex;

                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();

                Trace.WriteLine(new { Message = $"Compilation of {result.AssemblyName} return : ", Exception = ex });

            }

            if (this.ResolveObjects)
                result.Objects = ResolveObjects_Impl(result);

            return result;

        }

        private CSharpCompilation GetCsharpContext(AssemblyResult result)
        {

            CSharpCompilationOptions compilationOptions = GetCompilationOptions(result);

            var _defaultReferences = _assemblies.Libraries().ToList();

            return CSharpCompilation.Create
            (
                result.AssemblyName,
                 result.SyntaxTree,
                _defaultReferences,
                compilationOptions
            );
        }

        private static List<CodeObject> ResolveObjects_Impl(AssemblyResult result)
        {
            List<CodeObject> objects = new List<CodeObject>();
            foreach (var item in result.SyntaxTree)
                objects.AddRange(ObjectResolverVisitor.GetObjects(item));
            return objects;
        }

        private CSharpCompilationOptions GetCompilationOptions(AssemblyResult result)
        {

            CSharpCompilationOptions compilationOptions = new CSharpCompilationOptions
                (OutputKind.DynamicallyLinkedLibrary,
                    allowUnsafe: true,
                    xmlReferenceResolver: null, // no support for permission set and doc includes in interactive
                    metadataReferenceResolver: _resolver,
                    assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default
                )
                .WithModuleName($"{_assemblyName}.dll")
                .WithOptimizationLevel(this.Debug ? OptimizationLevel.Debug : OptimizationLevel.Release)
                .WithPlatform(Platform.AnyCpu)
                //.WithUsings(result.Usings)
                ;

            if (this.KeyFile != null)
                AddSignature(compilationOptions);

            if (ConfigureCompilation != null)
                ConfigureCompilation(compilationOptions);

            return compilationOptions;

        }

        private void AddSignature(CSharpCompilationOptions compilationOptions)
        {
            if (File.Exists(this.KeyFile))
                compilationOptions.WithCryptoKeyFile(this.KeyFile)
                                  .WithDelaySign(this.DelaySign)
                                  .WithCryptoPublicKey(StrongNameKey);
        }

        private static void AnalyzeCompilation(AssemblyResult result, EmitResult resultEmit, string[] diags)
        {
            Trace.WriteLine
            (new
            {
                Message = $"Compilation of {result.AssemblyName} return : " + (resultEmit.Success ? " Success!!" : " Failed"),
                Diagnostics = string.Join(", ", diags),
            });

            var missingRefs = resultEmit.Diagnostics.Where(c => c.Id == "CS0246").ToList();

            foreach (var item in missingRefs)
            {
                var tt = item.Descriptor.MessageFormat;
            }

            // Map diagnostic for not reference roslyn outsite this assembly
            foreach (Diagnostic diagnostic in resultEmit.Diagnostics)
                result.Diagnostics.Add(diagnostic.Map());

            result.Success = resultEmit.Success;
        }

        private AssemblyResult GetAssemblyResult()
        {

            if (!Directory.Exists(_outputPah))
                Directory.CreateDirectory(_outputPah);

            var result = new AssemblyResult()
            {
                AssemblyName = _assemblyName,
                AssemblyFile = Path.Combine(_outputPah, $"{_assemblyName}.dll"),
                AssemblyFilePdb = Path.Combine(_outputPah, $"{_assemblyName}.pdb"),
            };

            ResetFilesIfExists(result);

            var sources = new List<SyntaxTree>();

            if (this.Usings.Any())
            {

                bool isGlobal = false;

                var builder = new CSharpArtifact();
                foreach (var item in this.Usings)
                {
                    if (item.IsGlobal)
                    {

                        switch (item.NamespaceOrType)
                        {

                            case "System.Linq":
                                this._assemblies.ResolveFilename(Refs.System.Linq.AssemblyFile);
                                break;

                            case "System.Net.Http":
                                this._assemblies.ResolveFilename(Refs.System.Net.Http.AssemblyFile);
                                break;

                            case "System.Threading":
                                this._assemblies.ResolveFilename(Refs.System.Threading.AssemblyFile);
                                break;

                            default:
                                break;

                        }

                        isGlobal = true;
                    }

                    builder.Using(item);
                }

                var src = builder.Code().ToString();

                sources.Add(builder.Build().SyntaxTree);

                if (isGlobal && LanguageVersion < LanguageVersion.CSharp12)
                    LanguageVersion = LanguageVersion.CSharp12;

            }

            Parse(result, sources);

            //// Try to resolve assemblies
            //CSharpVisitor visitor = new CSharpVisitor();
            //foreach (var item in sources)
            //    visitor.Visit(item.GetRoot());
            //var usings = visitor.GetUsings();
            //var _references = ResolveAsemblies(usings);

            return result;

        }

        //private List<MetadataReference> ResolveAsemblies(HashSet<string> usings)
        //{
        //    // find assemblies that contains usings.
        //    var lst = usings.ToList();
        //    foreach (var item in _assemblies)
        //    {
        //        var lib = Refs.Libs.ResolveLibraryByFilename(item.Key);
        //        if (lib != null)
        //        {
        //            var rr = lst.Intersect(lib.Namespaces).ToArray();
        //            foreach (var ns in rr)
        //            {
        //                lst.Remove(ns);
        //            }
        //        }
        //        if (lst.Count == 0)
        //            break;
        //    }

        //    List<ILib> _list = new List<ILib>();

        //    foreach (var item in lst)
        //        _list.AddRange( Refs.Libs.GetAssembliesWithNamespace(item).ToList());
        //    return null;
        //}

        private static void ResetFilesIfExists(AssemblyResult result)
        {

            if (File.Exists(result.AssemblyFile))
                File.Delete(result.AssemblyFile);

            if (File.Exists(result.AssemblyFilePdb))
                File.Delete(result.AssemblyFilePdb);
        }

        private void Parse(AssemblyResult result, List<SyntaxTree> sources = null)
        {

            if (sources == null)
                sources = new List<SyntaxTree>();

            foreach (var item in this._sources)
            {

                result.Documents.Add(item.Filepath);

                CSharpParseOptions options = CSharpParseOptions.Default.WithLanguageVersion(this.LanguageVersion);

                if (this.DocumentationMode != options.DocumentationMode)
                    options.WithDocumentationMode(this.DocumentationMode);

                var stringText = Microsoft.CodeAnalysis.Text.SourceText.From(item.Content, Encoding.UTF8);
                var tree = SyntaxFactory.ParseSyntaxTree(stringText, options, item.Filepath);
                sources.Add(tree);
            }

            result.SyntaxTree = sources.ToArray();

        }

        #endregion Methods

        private readonly ReferenceResolver _resolver;
        private List<FileCode> _sources = new List<FileCode>();
        private string _assemblyName;
        private string _outputPah;
        private uint _hash;
    }


}
