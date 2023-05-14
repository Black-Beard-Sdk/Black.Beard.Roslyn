using Microsoft.CodeAnalysis.MSBuild;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.Build.Locator;
using System.Reflection;
using Microsoft.CodeAnalysis.Emit;
using Bb.Projects;
using System.Collections.Generic;

namespace Bb.Build
{

    public class MsProjectForBuild : MsProject
    {

        public MsProjectForBuild(string name, DirectoryInfo dir)
            : base(name, dir)
        {

            this.AssemblyFile = Path.Combine(this.Directory.FullName, "bin", $"{Name}.dll");
            this.SymbolFile = Path.Combine(this.Directory.FullName, "bin", $"{Name}.pdb");
        
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

        public bool Build(bool inMemory = true, bool load = true)
        {

            var vsInstance = MSBuildLocator.RegisterDefaults();

            Save();

            var task = Task.Run<bool>(async () =>
            {

                using (var workspace = MSBuildWorkspace.Create())
                {

                    Project project = await workspace.OpenProjectAsync(ProjectFile).ConfigureAwait(false);
                    Compilation? compilation = await project.GetCompilationAsync();

                    if (compilation != null)
                    {

                        if (inMemory)
                            return GenerateOnMemory(load, compilation);

                        else
                        {

                            var r = GenerateAssemblyOnDisk(compilation);
                            if (r != null)
                            {
                                if (load)
                                {
                                    var result = Load();
                                    return Assembly != null;
                                }
                            }

                        }

                    }

                }

                return false;

            });

            task.Wait();

            return task.Result;

        }

        public Assembly Assembly { get; protected set; }

        public string SymbolFile { get; protected set; }

        public string AssemblyFile { get; protected set; }

        private bool GenerateOnMemory(bool load, Compilation? compilation)
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

        public new MsProjectForBuild DefaultTargets(DefaultTargets value)
        {
            base.DefaultTargets(value);
            Add(value);
            return this;
        }

        public new MsProjectForBuild InitialTargets(InitialTargets value)
        {
            base.InitialTargets(value);
            return this;
        }

        public new MsProjectForBuild ToolsVersion(ToolsVersion value)
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


    }

}

// https://gitter.im/dotnet/roslyn?at=5de833f855066245986b8467
