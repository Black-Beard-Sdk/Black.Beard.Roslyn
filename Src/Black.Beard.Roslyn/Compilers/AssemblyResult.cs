using Bb.Analysis.Traces;
using Bb.Builds;
using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;

namespace Bb.Compilers
{

    [System.Diagnostics.DebuggerDisplay("{AssemblyName}")]
    public class AssemblyResult
    {

        public AssemblyResult(ScriptDiagnostics diagnostics)
        {
            Diagnostics = diagnostics ?? new ScriptDiagnostics();
            this.Documents = new List<string>();
        }

        public string AssemblyName { get; internal set; }

        public string AssemblyFile { get; internal set; }

        public string AssemblyFilePdb { get; internal set; }

        public ScriptDiagnostics Diagnostics { get; internal set; }

        public IEnumerable<Analysis.Traces.ScriptDiagnostic> Errors { get => Diagnostics.Where(c => c.Severity == "Error"); }

        public IEnumerable<Analysis.Traces.ScriptDiagnostic> Warnings { get => Diagnostics.Where(c => c.Severity == "Warning"); }

        public List<string> Documents { get; }

        public bool Success { get; internal set; }

        public Exception Exception { get; internal set; }

        public List<CodeObject> Objects { get; internal set; }

        public SyntaxTree[] SyntaxTree { get; internal set; }

        public Assembly LoadAssembly()
        {

            Trace.WriteLine($"Loading assembly {AssemblyFile}");
            var data = File.ReadAllBytes(AssemblyFile);
            var pdbData = File.ReadAllBytes(AssemblyFilePdb);
            var assembly = Assembly.Load(data, pdbData);
            // return Assembly.LoadFile(AssemblyFile);

            return assembly;

        }

        public List<DependencyAssemblyNameResolver.AssemblyReference> ResolveDependencies(AssemblyReferences references, bool download)
        {
            return DependencyAssemblyNameResolver.Resolve(new FileInfo(AssemblyFile), references, download);

        }


    }

}
