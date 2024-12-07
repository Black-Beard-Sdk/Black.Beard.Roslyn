//using Microsoft.CodeAnalysis.MSBuild;
using System.IO;
using System;
using Microsoft.CodeAnalysis;
using System.Reflection;
using Microsoft.CodeAnalysis.Emit;
using Bb.Projects;

namespace Bb.Build
{

    public class MsProjectForBuild : MsProject
    {

        public MsProjectForBuild(string name, DirectoryInfo dir)
            : base(name, dir)
        {

            this.AssemblyFile = Path.Combine(this.Directory.FullName, "bin", $"{KeyName}.dll");
            this.SymbolFile = Path.Combine(this.Directory.FullName, "bin", $"{KeyName}.pdb");
        
        }


        #region GenerateOnMemory


        protected static Assembly Load(MemoryStream ass, MemoryStream pdb)
        {
            Assembly assembly;
            ass.Seek(0, SeekOrigin.Begin);

            if (IsRunningOnMono)
            {
                assembly = Assembly.Load(ass.ToArray());
            }
            else
            {
                pdb.Seek(0, SeekOrigin.Begin);
                assembly = Assembly.Load(ass.ToArray(), pdb.ToArray());
            }

            return assembly;
        }

        protected static MemoryStream GetStream()
        {
            return new MemoryStream();
        }


        #endregion GenerateOnMemory


        protected Assembly Load()
        {
            this.Assembly = Assembly.LoadFile(this.AssemblyFile);
            return this.Assembly;
        }

        //public bool Build(bool inMemory = true, bool load = true)
        //{

        //    var vsInstance = MSBuildLocator.RegisterDefaults();

        //    Save();

        //    var task = Task.Run<bool>(async () =>
        //    {

        //    using (Workspace workspace = MSBuildWorkspace.Create())
        //        {

        //            Project project = await workspace.OpenProjectAsync(ProjectFile).ConfigureAwait(false);
        //            Compilation? compilation = await project.GetCompilationAsync();

        //            if (compilation != null)
        //            {

        //                if (inMemory)
        //                    return GenerateOnMemory(load, compilation);

        //                else
        //                {

        //                    var r = GenerateAssemblyOnDisk(compilation);
        //                    if (r != null)
        //                    {
        //                        if (load)
        //                        {
        //                            var result = Load();
        //                            return Assembly != null;
        //                        }
        //                    }

        //                }

        //            }
                
        //        }

        //        return false;

        //    });

        //    task.Wait();

        //    return task.Result;

        //}

        public Assembly Assembly { get; protected set; }

        public string SymbolFile { get; protected set; }

        public string AssemblyFile { get; protected set; }

        public new MsProjectForBuild SetPropertyGroup(Action<PropertyGroup> action)
        {
            base.SetPropertyGroup(action);
            return this;

        }

        public new MsProjectForBuild Packages(Action<PackageReferences> action)
        {
            base.Packages(action);
            return this;
        }

        public new MsProjectForBuild Sdk(ProjectSdk value)
        {
            base.Sdk(value);
            return this;
        }

        public new MsProjectForBuild DefaultTargets(string value)
        {
            base.DefaultTargets(value);            
            return this;
        }

        public new MsProjectForBuild InitialTargets(string value)
        {
            base.InitialTargets(value);
            return this;
        }

        public new MsProjectForBuild ToolsVersion(Version value)
        {
            base.ToolsVersion(value);
            return this;
        }
               
        public new MsProjectForBuild ItemGroup(Action<ItemGroup> action)
        {
            base.ItemGroup(action);
            return this;
        }

        public new MsProjectForBuild SqlCmdVariables(Action<SqlCmdVariables> action)
        {
            base.SqlCmdVariables(action);
            return this;

        }

        public new MsProjectForBuild SqlDeploy(Action<SqlDeploy> action)
        {
            base.SqlDeploy(action);
            return this;
        }
         
        public new MsProjectForBuild References(Action<References> action)
        {
            base.References(action);
            return this;
        }

        public new MsProjectForBuild ProjectReferences(Action<ProjectReferences> action)
        {
            base.ProjectReferences(action);
            return this;
        }



        private bool GenerateOnMemory(bool load, Compilation compilation)
        {

            using (var ass = GetStream())
            using (var pdb = GetStream())
            {

                EmitResult result = GenerateAssemblyOnMemory(compilation, ass, pdb);

                if (result.Success)
                {

                    if (load)
                    {
                        Assembly = Load(ass, pdb);
                        return Assembly != null;
                    }

                }

                return result.Success;

            }

        }

        private EmitResult GenerateAssemblyOnDisk(Compilation compilation)
        {

            EmitResult result;

            if (IsRunningOnMono)
            {
                result = compilation.Emit(this.AssemblyFile);

            }
            else
            {
                result = compilation.Emit(this.AssemblyFile, this.SymbolFile);
            }

            if (!result.Success)
                Trace(result);

            return result;

        }

        private static void Trace(Microsoft.CodeAnalysis.Emit.EmitResult result)
        {
            System.Diagnostics.Trace.TraceError("Compilation failed. Errors : ");

            foreach (var diagnostic in result.Diagnostics)
                switch (diagnostic.Severity)
                {

                    case DiagnosticSeverity.Info:
                        System.Diagnostics.Trace.TraceInformation(diagnostic.ToString());
                        break;

                    case DiagnosticSeverity.Warning:
                        System.Diagnostics.Trace.TraceWarning(diagnostic.ToString());
                        break;

                    case DiagnosticSeverity.Error:
                        System.Diagnostics.Trace.TraceError(diagnostic.ToString());
                        break;

                    case DiagnosticSeverity.Hidden:
                    default:
                        break;

                }
        }

        private static EmitResult GenerateAssemblyOnMemory(Compilation compilation, Stream ass, Stream pdb)
        {

            EmitResult result;

            if (IsRunningOnMono)
            {
                result = compilation.Emit(ass, pdbStream: null);

            }
            else
            {
                result = compilation.Emit(ass, pdbStream: pdb);
                pdb.Flush();
            }

            ass.Flush();


            if (!result.Success)
                Trace(result);

            return result;

        }



    }

}

// https://gitter.im/dotnet/roslyn?at=5de833f855066245986b8467


//using System;
//using System.Collections.Generic;
//using System.IO;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.Emit;
//using Microsoft.CodeAnalysis.MSBuild;

//namespace Roslyn.TryItOut
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string solutionUrl = "C:\\Dev\\Roslyn.TryItOut\\Roslyn.TryItOut.sln";
//            string outputDir = "C:\\Dev\\Roslyn.TryItOut\\output";

//            if (!Directory.Exists(outputDir))
//            {
//                Directory.CreateDirectory(outputDir);
//            }

//            bool success = CompileSolution(solutionUrl, outputDir);

//            if (success)
//            {
//                Console.WriteLine("Compilation completed successfully.");
//                Console.WriteLine("Output directory:");
//                Console.WriteLine(outputDir);
//            }
//            else
//            {
//                Console.WriteLine("Compilation failed.");
//            }

//            Console.WriteLine("Press the any key to exit.");
//            Console.ReadKey();
//        }

//        private static bool CompileSolution(string solutionUrl, string outputDir)
//        {
//            bool success = true;
            
//            MSBuildWorkspace workspace = MSBuildWorkspace.Create();
//            Solution solution = workspace.OpenSolutionAsync(solutionUrl).Result;
//            ProjectDependencyGraph projectGraph = solution.GetProjectDependencyGraph();
//            Dictionary<string, Stream> assemblies = new Dictionary<string, Stream>();

//            foreach (ProjectId projectId in projectGraph.GetTopologicallySortedProjects())
//            {
//                Compilation projectCompilation = solution.GetProject(projectId).GetCompilationAsync().Result;
//                if (null != projectCompilation && !string.IsNullOrEmpty(projectCompilation.AssemblyName))
//                {
//                    using (var stream = new MemoryStream())
//                    {
//                        EmitResult result = projectCompilation.Emit(stream);
//                        if (result.Success)
//                        {
//                            string fileName = string.Format("{0}.dll", projectCompilation.AssemblyName);

//                            using (FileStream file = File.Create(outputDir + '\\' + fileName))
//                            {
//                                stream.Seek(0, SeekOrigin.Begin);
//                                stream.CopyTo(file);
//                            }
//                        }
//                        else
//                        {
//                            success = false;
//                        }
//                    }
//                }
//                else
//                {
//                    success = false;
//                }
//            }

//            return success;
//        }
//    }
//}