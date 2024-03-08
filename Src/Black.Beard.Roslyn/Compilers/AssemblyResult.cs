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

        public string FullAssemblyFile => Path.Combine(OutputPah, AssemblyFile);

        public string FullAssemblyFilePdb => Path.Combine(OutputPah, AssemblyPdb);
        public string FullAssemblyBuildConfig => Path.Combine(OutputPah, AssemblyBuildConfig);

        public string AssemblyName { get; internal set; }

        public ScriptDiagnostics Diagnostics { get; internal set; }

        public List<string> Documents { get; }

        public bool Success { get; internal set; }

        public Exception Exception { get; internal set; }

        public List<CodeObject> Objects { get; internal set; }

        public SyntaxTree[] SyntaxTree { get; internal set; }
        public string AssemblyFile { get; internal set; }
        public string AssemblyPdb { get; internal set; }
        public AssemblyReferences References { get; internal set; }
        public string AssemblyBuildConfig { get; internal set; }

        public Assembly LoadAssembly()
        {

            Trace.WriteLine($"Loading assembly {FullAssemblyFile}");
            var data = File.ReadAllBytes(FullAssemblyFile);
            var pdbData = File.ReadAllBytes(FullAssemblyFilePdb);
            var assembly = Assembly.Load(data, pdbData);
            // return Assembly.LoadFile(AssemblyFile);

            return assembly;

        }

        public FileInfo PrepareFolderToExecute()
        {
            var directory = Helper.GetTempDir();
            return PrepareFolderToExecute(directory);
        }

        public FileInfo PrepareFolderToExecute(string directory)
        {
            return PrepareFolderToExecute(new DirectoryInfo(directory) ?? throw new ArgumentNullException(nameof(directory)));
        }

        public FileInfo PrepareFolderToExecute(DirectoryInfo directory)
        {

            directory.Refresh();

            if (!directory.Exists)
                directory.Create();


            var target = Path.Combine(directory.FullName, AssemblyFile);
            new FileInfo(FullAssemblyFile).CopyTo(target, true);
            new FileInfo(FullAssemblyFilePdb).CopyTo(Path.Combine(directory.FullName, AssemblyPdb), true);
            new FileInfo(FullAssemblyBuildConfig).CopyTo(Path.Combine(directory.FullName, AssemblyBuildConfig), true);

            var items = ResolveDependencies(References);

            foreach (var item in items)
            {

                if (!item.Resolved)
                {

                }

                var file = new FileInfo(item.Location);
                file.CopyTo(Path.Combine(directory.FullName, file.Name), true);

            }

            return new FileInfo(target);

        }

        public List<DependencyAssemblyNameResolver.AssemblyReference> ResolveDependencies(AssemblyReferences references)
        {
            return DependencyAssemblyNameResolver.Resolve(new FileInfo(FullAssemblyFile), references);

        }


    }

}
