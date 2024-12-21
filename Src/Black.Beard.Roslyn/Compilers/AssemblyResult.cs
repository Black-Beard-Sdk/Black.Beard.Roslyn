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
        public FrameworkVersion Sdk { get; internal set; }

        /// <summary>
        /// Load assembly in the current app domain
        /// </summary>
        /// <returns></returns>
        public Assembly LoadAssembly()
        {

            Trace.WriteLine($"Loading assembly {FullAssemblyFile}");
            var data = File.ReadAllBytes(FullAssemblyFile);
            var pdbData = File.ReadAllBytes(FullAssemblyFilePdb);
            var assembly = Assembly.Load(data, pdbData);
            // return Assembly.LoadFile(AssemblyFile);

            return assembly;

        }

        /// <summary>
        /// Prepare the folder to execute the assembly. copy all dependencies in the specified folder.
        /// </summary>
        /// <returns></returns>
        public FileInfo PrepareFolderToExecute()
        {
            var directory = Helper.GetTempDir();
            return PrepareFolderToExecute(directory);
        }

        /// <summary>
        /// Prepare the folder to execute the assembly. copy all dependencies in the specified folder.
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public FileInfo PrepareFolderToExecute(string directory)
        {
            return PrepareFolderToExecute(new DirectoryInfo(directory) ?? throw new ArgumentNullException(nameof(directory)));
        }

        /// <summary>
        /// Prepare the folder to execute the assembly. copy all dependencies in the specified folder.
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Return the list of dependencies
        /// </summary>
        /// <returns></returns>
        public List<DependencyAssemblyNameResolver.AssemblyReference> ResolveDependencies()
        {
            return ResolveDependencies(References);
        }

        /// <summary>
        /// Return the list of dependencies
        /// </summary>
        /// <param name="references"></param>
        /// <returns></returns>
        public List<DependencyAssemblyNameResolver.AssemblyReference> ResolveDependencies(AssemblyReferences references)
        {
            return DependencyAssemblyNameResolver.Resolve(new FileInfo(FullAssemblyFile), references);

        }


    }

}
