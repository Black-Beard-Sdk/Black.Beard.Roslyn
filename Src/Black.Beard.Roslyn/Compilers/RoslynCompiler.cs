using Bb.ComponentModel;
using Bb.Builds;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System.Diagnostics;
using System.Text;
using System.Collections.Immutable;
using Bb.Codings;
using Bb.Analysis.DiagTraces;
using SharpCompress.Common;
using System.Reflection.Metadata;
using Bb.Metrology;

namespace Bb.Compilers
{



    public class RoslynCompiler
    {

        public RoslynCompiler(OutputKind kind, AssemblyReferences assemblies, ScriptDiagnostics diagnostics)
        {

            this.Platform = Platform.AnyCpu;
            this.AssemblyKind = kind;
            this._diagnostics = diagnostics ?? new ScriptDiagnostics();
            this._assemblies = assemblies;
            this.LanguageVersion = assemblies.Sdk.LanguageVersion;

            assemblies.AddByType(typeof(object));
            assemblies.AddResolveFilename(Refs.mscorlib.AssemblyFile);
            assemblies.AddResolveFilename(Refs.System.Runtime.AssemblyFile);

            _resolver = new ReferenceResolver(assemblies, diagnostics);

        }

        public string KeyFile { get; set; }

        public bool DelaySign { get; set; }

        public ImmutableArray<byte> StrongNameKey { get; set; } = ImmutableArray<byte>.Empty;

        public DocumentationMode DocumentationMode { get; set; } = DocumentationMode.Parse;

        #region Methods

        /// <summary>
        /// Add sources to the compiler
        /// </summary>
        /// <param name="sources"></param>
        /// <returns></returns>
        public RoslynCompiler AddCodeSource(SourceCodes sources)
        {

            foreach (var item in sources.Documents)
                AddCodeSource(item.Source, item.Filename);

            if (this._sources.Count == 0)
            {
                _diagnostics.Error("Compilation", "No source code to compile");
            }

            return this;

        }

        /// <summary>
        /// Add source document to the compiler
        /// </summary>
        /// <param name="source"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public RoslynCompiler AddCodeSource(string source, string path = null)
        {

            this._sources.Add(new FileCode()
            {
                Filepath = path ?? string.Empty,
                Content = source
            });
            hastHey = 0;
            return this;
        }

        /// <summary>
        /// Set the output path
        /// </summary>
        /// <param name="outputPah"></param>
        /// <returns></returns>
        public RoslynCompiler SetOutput(string outputPah)
        {
            this._outputPah = outputPah;
            return this;
        }

        public Func<CSharpCompilationOptions, CSharpCompilationOptions> ConfigureCompilation { get; internal set; }

        public LanguageVersion LanguageVersion { get; set; }

        public bool ResolveObjects { get; set; }

        public bool Debug { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CSUsing[] Usings { get; internal set; }

        public uint Hash
        {
            get
            {
                if (hastHey == 0)
                    foreach (var item in _sources.OrderBy(c => c.Filepath))
                        hastHey ^= item.Content.CalculateCrc32();
                return hastHey;
            }
        }

        public AssemblyResult Generate(string? assemblyName = null)
        {

            if (string.IsNullOrEmpty(assemblyName))
            {
                var h = this.Hash;
                var date = DateTime.Now;
                this._assemblyName = assemblyName ?? $"assembly_{h}_{date.Year.ToString().Substring(2)}{date.Month.ToString("D2")}{date.Day}_{date.Hour.ToString("D2")}{date.Minute.ToString("D2")}{date.Second.ToString("D2")}";
            }
            else
                _assemblyName = assemblyName;

            using (var activity = RoslynActivityProvider.StartActivity("Compile", ActivityKind.Internal))
            {

                AssemblyResult result = GetAssemblyResult();
                CSharpCompilation compilation = GetCsharpContext(result);

                try     // emit the compilation result to a byte array corresponding to {AssemblyName}.netmodule byte code
                {

                    using (var peStream = File.Create(result.FullAssemblyFile))
                    using (var pdbStream = File.Create(result.FullAssemblyFilePdb))
                    {
                        EmitResult resultEmit = compilation.Emit(peStream, pdbStream);
                        var diags = resultEmit.Diagnostics.ToList().Select(c => c.ToString()).ToArray();
                        AnalyzeCompilation(result, resultEmit, diags);

                        result.References = this._assemblies;
                    }

                }
                catch (Exception ex)
                {

                    result.Exception = ex;

                    if (System.Diagnostics.Debugger.IsAttached)
                        System.Diagnostics.Debugger.Break();

                    _diagnostics.Error("Compilation", ex.Message);

                    Trace.WriteLine(new { Message = $"Compilation of {result.AssemblyName} return : ", Exception = ex });

                }

                if (this.ResolveObjects)
                    result.Objects = ResolveObjects_Impl(result);


                return result;

            }

        }

        private CSharpCompilation GetCsharpContext(AssemblyResult result)
        {

            CSharpCompilationOptions compilationOptions = GetCompilationOptions(result);
            var lst = _assemblies.Libraries().ToList();

            var _defaultReferences = new List<PortableExecutableReference>(lst.Count);

            foreach (var item in lst)
            {

                if (item.Item2.Count == 1)
                    _defaultReferences.Add(item.Item2[0].Item2);

                else
                {
                    _defaultReferences.Add(item.Item2[0].Item2);
                }

            }

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

        public OutputKind AssemblyKind { get; }

        public string MainTypeName { get; set; }

        public Platform Platform { get; set; }

        /// <summary>
        /// Add attributes in the assembly
        /// </summary>
        public Dictionary<string, object[]> AssemblyAttributes { get; set; }
        public RuntimeConfig RuntimeConfig { get; set; }

        private CSharpCompilationOptions GetCompilationOptions(AssemblyResult result)
        {

            bool allowUnsafe = false;

            var optimizationLevel = this.Debug ? OptimizationLevel.Debug : OptimizationLevel.Release;

            CSharpCompilationOptions compilationOptions = new CSharpCompilationOptions
                (
                    AssemblyKind,
                    allowUnsafe: allowUnsafe,
                    xmlReferenceResolver: null, // no support for permission set and doc includes in interactive
                    metadataReferenceResolver: _resolver,
                    assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default
                )
                .WithModuleName($"{_assemblyName}.dll")
                .WithOptimizationLevel(optimizationLevel)
                .WithPlatform(this.Platform)
                //.WithUsings(result.Usings)
                ;

            if (RoslynActivityProvider.WithTelemetry)
                RoslynActivityProvider.Set(c =>
                {
                    c.SetCustomProperty("AssemblyKind", AssemblyKind.ToString());
                    c.SetCustomProperty("allowUnsafe", allowUnsafe.ToString());
                    c.SetCustomProperty("optimizationLevel", optimizationLevel.ToString());
                    c.SetCustomProperty("MainTypeName", this.MainTypeName ?? string.Empty);
                });

            if (!string.IsNullOrEmpty(this.MainTypeName))            
                compilationOptions = compilationOptions.WithMainTypeName(this.MainTypeName);
            
            if (this.KeyFile != null)
                compilationOptions = AddSignature(compilationOptions);

            if (ConfigureCompilation != null)
                compilationOptions = ConfigureCompilation(compilationOptions);

            return compilationOptions;

        }

        private CSharpCompilationOptions AddSignature(CSharpCompilationOptions compilationOptions)
        {
            if (File.Exists(this.KeyFile))
            {
                compilationOptions = compilationOptions.WithCryptoKeyFile(this.KeyFile)
                                  .WithDelaySign(this.DelaySign)
                                  .WithCryptoPublicKey(StrongNameKey);

                if (RoslynActivityProvider.WithTelemetry)
                    RoslynActivityProvider.Set(c =>
                    {
                        c.SetCustomProperty("KeyFile", KeyFile ?? string.Empty);
                        c.SetCustomProperty("DelaySign", DelaySign.ToString());
                        c.SetCustomProperty("StrongNameKey", StrongNameKey != null ? Convert.ToBase64String(StrongNameKey.ToArray()) : string.Empty);
                    });

            }

            return compilationOptions;

        }

        private void AnalyzeCompilation(AssemblyResult result, EmitResult resultEmit, string[] diags)
        {

            if (RoslynActivityProvider.WithTelemetry)
                RoslynActivityProvider.Set(c =>
                {
                    c.SetCustomProperty("Success", result.Success);
                    c.SetCustomProperty("Diagnostics", string.Join(", ", diags));
                });

            //var missingRefs = resultEmit.Diagnostics.Where(c => c.Id == "CS0246").ToList();
            //foreach (var item in missingRefs)
            //    item.Descriptor.MessageFormat;

            // Map diagnostic for not reference Roslyn outsite this assembly
            foreach (Diagnostic diagnostic in resultEmit.Diagnostics)
                result.Diagnostics.Add(diagnostic.Map());

            if (resultEmit.Success)
            {

                if (this.RuntimeConfig == null)
                    this.RuntimeConfig = new RuntimeConfig();

                this.RuntimeConfig.SetFramework(this._assemblies.Sdk);

                if (File.Exists(result.AssemblyBuildConfig))
                    File.Delete(result.AssemblyBuildConfig);

                var t = this.RuntimeConfig.ToString();
                result.FullAssemblyBuildConfig.Save(t);

            }

            result.Success = resultEmit.Success;

        }

        private AssemblyResult GetAssemblyResult()
        {

            if (!Directory.Exists(_outputPah))
                Directory.CreateDirectory(_outputPah);

            var result = new AssemblyResult(_diagnostics)
            {
                OutputPah = _outputPah,
                AssemblyName = _assemblyName,
                AssemblyFile = $"{_assemblyName}.dll",
                AssemblyPdb = $"{_assemblyName}.pdb",
                AssemblyBuildConfig = $"{_assemblyName}.runtimeconfig.json",
            };

            if (RoslynActivityProvider.WithTelemetry)
                RoslynActivityProvider.Set(c =>
                {
                    c.SetCustomProperty("sdkName",          this._assemblies.Sdk.Key.Name);
                    c.SetCustomProperty("sdkVersion",       this._assemblies.Sdk.Key.Version);
                    c.SetCustomProperty("frameworkVersion", this._assemblies.Sdk.Key.Name);
                    c.SetCustomProperty("frameworkName",    this._assemblies.Sdk.Type.Name);

                    c.SetCustomProperty("AssemblyName", result.AssemblyName);
                    c.SetCustomProperty("AssemblyFile", result.FullAssemblyFile);
                    c.SetCustomProperty("AssemblyFilePdb", result.FullAssemblyFilePdb);

                });

            ResetFilesIfExists(result);

            var sources = new List<SyntaxTree>();

            ManageUsings(sources);
            ManageAssembliesAttributes(sources);

            Parse(result, sources);

            //// Try to resolve assemblies
            //CSharpVisitor visitor = new CSharpVisitor();
            //foreach (var item in sources)
            //    visitor.Visit(item.GetRoot());
            //var usings = visitor.GetUsings();
            //var _references = ResolveAsemblies(usings);

            return result;

        }
        private void ManageAssembliesAttributes(List<SyntaxTree> sources)
        {

            if (this.AssemblyAttributes.Any())
            {

                var builder = new CSharpArtifact();


                AddUsingIfNotInGlobal(builder, "System");
                AddUsingIfNotInGlobal(builder, "System.Reflection");

                foreach (var item in this.AssemblyAttributes)
                {

                    var attribute = builder.Attribute(item.Key);
                    foreach (var arg in item.Value)
                    {
                        if (arg is Version v)
                            attribute.Argument(CSharpNode.Literal(arg.ToString()));
                        else
                            attribute.Argument(CSharpNode.Literal(arg));
                    }
                }

                var src = builder.Code().ToString();

                sources.Add(builder.Build().SyntaxTree);

            }

        }

        private void AddUsingIfNotInGlobal(CSharpArtifact builder, string @namespace)
        {
            if (!this.Usings.Where(c => c.IsGlobal && c.NamespaceOrType == @namespace).Any())
                builder.Using(@namespace);
        }

        private void ManageUsings(List<SyntaxTree> sources)
        {

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
                                this._assemblies.AddResolveFilename(Refs.System.Linq.AssemblyFile);
                                break;

                            case "System.Net.Http":
                                this._assemblies.AddResolveFilename(Refs.System.Net.Http.AssemblyFile);
                                break;

                            case "System.Threading":
                                this._assemblies.AddResolveFilename(Refs.System.Threading.AssemblyFile);
                                break;

                            default:
                                break;

                        }

                        isGlobal = true;
                    }

                    builder.Using(item);
                }

                RoslynActivityProvider.Set(c =>
                {
                    c.SetCustomProperty("GlobalUsings", builder.Code().ToString());
                });

                //var src = builder.Code().ToString();
                sources.Add(builder.Build().SyntaxTree);

                if (isGlobal && LanguageVersion < LanguageVersion.CSharp12)
                    LanguageVersion = LanguageVersion.CSharp12;

            }

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

            if (File.Exists(result.FullAssemblyFile))
                File.Delete(result.FullAssemblyFile);

            if (File.Exists(result.FullAssemblyFilePdb))
                File.Delete(result.FullAssemblyFilePdb);
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

            if (result.SyntaxTree.Length == 0)
            {
                _diagnostics.Error("Compilation", "No source code to compile");
            }

            if (RoslynActivityProvider.WithTelemetry)
                RoslynActivityProvider.AddProperty("scripts", string.Join(", ", this._sources.Select(d => d.Filepath)));
            
        }

        #endregion Methods

        private readonly ScriptDiagnostics _diagnostics;
        private readonly AssemblyReferences _assemblies;
        private readonly ReferenceResolver _resolver;
        private List<FileCode> _sources = new List<FileCode>();
        private string _assemblyName;
        private string _outputPah;
        private uint hastHey = 0;


    }


}
