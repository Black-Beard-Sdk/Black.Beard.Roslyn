using Bb.Analysis.DiagTraces;
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

        public string OutputPah { get; internal set; }

        public string FullAssemblyFile { get; internal set; }

        public string FullAssemblyFilePdb { get; internal set; }

        public string AssemblyName { get; internal set; }
        
        public ScriptDiagnostics Diagnostics { get; internal set; }

        public IEnumerable<Analysis.DiagTraces.ScriptDiagnostic> Errors { get => Diagnostics.Where(c => c.Severity == "Error"); }

        public IEnumerable<Analysis.DiagTraces.ScriptDiagnostic> Warnings { get => Diagnostics.Where(c => c.Severity == "Warning"); }

        public List<string> Documents { get; }

        public bool Success { get; internal set; }

        public Exception Exception { get; internal set; }

        public List<CodeObject> Objects { get; internal set; }

        public SyntaxTree[] SyntaxTree { get; internal set; }
        public string AssemblyFile { get; internal set; }
        public string AssemblyPdb { get; internal set; }
        public AssemblyReferences References { get; internal set; }

        public Assembly LoadAssembly()
        {

            Trace.WriteLine($"Loading assembly {FullAssemblyFile}");
            var data = File.ReadAllBytes(FullAssemblyFile);
            var pdbData = File.ReadAllBytes(FullAssemblyFilePdb);
            var assembly = Assembly.Load(data, pdbData);
            // return Assembly.LoadFile(AssemblyFile);

            return assembly;

        }

        public DirectoryInfo PrepareFolderToExecute()
        {
            var directory = Helper.GetTempDir();
            PrepareFolderToExecute(directory);
            return directory;
        }

        public void PrepareFolderToExecute(string directory)
        {
            PrepareFolderToExecute(new DirectoryInfo(directory) ?? throw new ArgumentNullException(nameof(directory)));
        }

        public void PrepareFolderToExecute(DirectoryInfo directory)
        {

            directory.Refresh();

            if (!directory.Exists)
                directory.Create();

            var items = ResolveDependencies(References, true);

            foreach (var item in items)
            {
                var file = new FileInfo(item.Location);
                file.CopyTo(Path.Combine(directory.FullName, file.Name), true);
            }

            new FileInfo(FullAssemblyFile).CopyTo(Path.Combine(directory.FullName, new FileInfo(FullAssemblyFile).Name), true);
            new FileInfo(FullAssemblyFilePdb).CopyTo(Path.Combine(directory.FullName, new FileInfo(FullAssemblyFilePdb).Name), true);

        }

        public List<DependencyAssemblyNameResolver.AssemblyReference> ResolveDependencies(AssemblyReferences references, bool download)
        {
            return DependencyAssemblyNameResolver.Resolve(new FileInfo(FullAssemblyFile), references, download);

        }


    }

}
