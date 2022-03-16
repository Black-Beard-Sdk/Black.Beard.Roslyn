using Bb.Compilers;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static Bb.Compilers.CommentHelper;

namespace Bb.Json.Jslt.Builds
{


    public class BuildCSharp
    {


        public BuildCSharp()
        {

            this.References = new AssemblyReferences();
            Sources = new SourceCodes();

            this.LanguageVersion = LanguageVersion.CSharp6;
            _compiledAssemblies = new Dictionary<string, AssemblyResult>();

            OutputPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "_builds");

            if (!System.IO.Directory.Exists(OutputPath))
                System.IO.Directory.CreateDirectory(OutputPath);

            ResolveAssembliesInCode = false;

        }

        public LanguageVersion LanguageVersion { get; set; }

        public string OutputPath { get; set; }

        public SourceCodes Sources { get; }

        public AssemblyReferences References { get; }

        public Action<CSharpCompilationOptions> ConfigureCompilation { get; internal set; }

        public bool ResolveObjects { get; set; }

        public bool ResolveAssembliesInCode { get; set; }

        public bool Debug { get; set; }


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

                var compiler = new RoslynCompiler(References, this.ResolveObjects, this.Debug)
                {
                    ConfigureCompilation = Configure,
                }
                .SetLanguage(LanguageVersion)
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
                    result.Disgnostics.Insert(0,
                        new DiagnosticResult()
                        {
                            Id = String.Empty,
                            WarningLevel = 3,
                            IsWarningAsError = false,
                            Severity = "Warning",
                            Message = item.Value.Message,
                            Locations = new List<LocationResult>()
                            {
                                new LocationResult()
                                {
                                    FilePath = item.Key,
                                }
                            }
                        });

                

            }

            return result;

        }

        private void Configure(CSharpCompilationOptions obj)
        {

            if (ConfigureCompilation != null)
                ConfigureCompilation(obj);

        }

        private readonly Dictionary<string, AssemblyResult> _compiledAssemblies;

    }



}
