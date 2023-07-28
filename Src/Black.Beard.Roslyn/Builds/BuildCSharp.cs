using Bb.Analysis;
using Bb.Compilers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static Bb.Compilers.CommentHelper;

namespace Bb.Builds
{

    public class BuildCSharp
    {


        public BuildCSharp(Action<CSharpCompilationOptions> configureCompilation = null)
        {

            if (configureCompilation != null)
                this.ConfigureCompilation = configureCompilation;

            this.References = new AssemblyReferences();
            Sources = new SourceCodes();

            this.LanguageVersion = LanguageVersion.CSharp6;
            _compiledAssemblies = new Dictionary<string, AssemblyResult>();

            OutputPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "_builds");

            if (!System.IO.Directory.Exists(OutputPath))
                System.IO.Directory.CreateDirectory(OutputPath);

            this._suppress = new Dictionary<string, ReportDiagnostic>();

            ResolveAssembliesInCode = false;

        }

        public BuildCSharp AddSource(FileInfo path)
        {
            AddSource(path.FullName);
            return this;

        }

        public BuildCSharp AddSource(string path)
        {
            this.Sources.Add(path);
            return this;
        }

        public LanguageVersion LanguageVersion { get; set; }

        public string OutputPath { get; set; }

        public SourceCodes Sources { get; }

        public AssemblyReferences References { get; }

        public string KeyFile { get; set; }

        public bool DelaySign { get; set; }

        public ImmutableArray<byte> StrongNameKey { get; set; }

        public Action<CSharpCompilationOptions> ConfigureCompilation { get; }

        public bool ResolveObjects { get; set; }

        public bool ResolveAssembliesInCode { get; set; }

        public bool Debug { get; set; }

        public DocumentationMode DocumentationMode { get; set; } = DocumentationMode.Parse;


        public BuildCSharp Suppress(params string[] ids)
        {

            foreach (var item in ids)
                _suppress.Add(item, ReportDiagnostic.Suppress);

            return this;

        }

        public BuildCSharp SetDiagnostic(ReportDiagnostic reportMode, params string[] ids)
        {

            foreach (var idKey in ids)
            {
                if (!_suppress.ContainsKey(idKey))
                    _suppress.Add(idKey, reportMode);
                else
                    _suppress[idKey] = reportMode;
            }

            return this;

        }


        public AssemblyResult Build(string assemblyName = null)
        {

            List<KeyValuePair<string, Exception>> e = new List<KeyValuePair<string, Exception>>();
            var key = assemblyName ?? Sources.GetUniqueAssemblyName();

            if (!_compiledAssemblies.TryGetValue(key, out AssemblyResult result))
            {

                if (ResolveAssembliesInCode)
                {

                    CompilationProperties compilationProperties = new CompilationProperties();
                    foreach (var item in Sources.Documents)
                    {
                        try
                        {
                            item.Datas.ResolveProperties(compilationProperties);
                            compilationProperties.Apply(this);
                        }
                        catch (Exception ex)
                        {
                            e.Add(new KeyValuePair<string, Exception>(item.Filename, ex));
                        }
                    }

                }

                var compiler = new RoslynCompiler(References)
                {
                    ConfigureCompilation = Configure,
                    DocumentationMode = this.DocumentationMode,
                    KeyFile = this.KeyFile,
                    DelaySign = this.DelaySign,
                    StrongNameKey = this.StrongNameKey,
                    ResolveObjects = this.ResolveObjects,
                    Debug = this.Debug,
                    LanguageVersion = this.LanguageVersion,
                    
                }
                ;

                foreach (var item in Sources.Documents)
                    compiler.AddCodeSource(item.Datas, item.Filename);

                result = compiler
                    .SetOutput(OutputPath)
                    .Generate(key)
                   ;

                if (result.Success)
                    _compiledAssemblies.Add(key, result);

                foreach (var item in e)
                    result.Diagnostics.Insert(0,
                        new DiagnosticReport()
                        {
                            Id = String.Empty,
                            SeverityLevel = 3,
                            IsSeverityAsError = false,
                            Severity = "Warning",
                            Message = item.Value.Message,
                            Locations = new List<DiagnosticLocation>()
                            {
                                new DiagnosticLocation(item.Key)
                            }
                        });



            }

            return result;

        }

        private void Configure(CSharpCompilationOptions obj)
        {

            if (_suppress.Count > 0)
            {
                var dic = ImmutableDictionary.CreateRange(_suppress);
                obj.WithSpecificDiagnosticOptions(dic);
            }
            if (ConfigureCompilation != null)
                ConfigureCompilation(obj);

        }

        private readonly Dictionary<string, AssemblyResult> _compiledAssemblies;

        private readonly Dictionary<string, ReportDiagnostic> _suppress;

    }



}
