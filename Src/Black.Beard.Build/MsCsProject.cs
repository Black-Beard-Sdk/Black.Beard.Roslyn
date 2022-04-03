using Microsoft.CodeAnalysis.MSBuild;
using System.Xml.Linq;
using Bb;
using System.Collections.Generic;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.Build.Locator;
using System.Diagnostics;
using System.Reflection;
using Microsoft.CodeAnalysis.Emit;

namespace Bb.Build
{


    public class MsCsProject : Group
    {

        public MsCsProject(string name, DirectoryInfo dir)
            : base(false)
        {

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (dir == null)
                throw new ArgumentNullException(nameof(dir));

            if (!dir.Exists)
                dir.Create();

            this.Name = name;
            this.Directory = dir;

            this.ProjectFile = Path.Combine(this.Directory.FullName, $"{Name}.csproj");

            this._itemGroups = new List<ItemGroup>();
            this.PropertyGroup = new PropertyGroup();

            Add(ProjectSdk.MicrosoftNETSdk);

        }

        public string Name { get; }

        public DirectoryInfo Directory { get; }

        public PropertyGroup PropertyGroup { get; }

        public IEnumerable<ItemGroup> ItemGroups { get => _itemGroups; }

        public string AssemblyFile { get; private set; }

        public string SymbolFile { get; private set; }

        public Assembly Assembly { get; private set; }

        public string ProjectFile { get; }

        public MsCsProject Sdk(ProjectSdk value)
        {
            Add(value as PropertyKey);
            return this;
        }

        public MsCsProject DefaultTargets(DefaultTargets value)
        {
            Add(value as PropertyKey);
            return this;
        }

        public MsCsProject InitialTargets(InitialTargets value)
        {
            Add(value as PropertyKey);
            return this;
        }

        public MsCsProject ToolsVersion(ToolsVersion value)
        {
            Add(value as PropertyKey);
            return this;
        }

        public MsCsProject SetPropertyGroup(Action<PropertyGroup> action)
        {

            if (action != null)
                action(this.PropertyGroup);

            return this;

        }

        public MsCsProject ItemGroup(Action<ItemGroup> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            var item = new ItemGroup();
            _itemGroups.Add(item);
            action(item);
            return this;
        }

        public MsCsProject Packages(Action<PackageReferences> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (this._packages == null)
                _itemGroups.Add(this._packages = new PackageReferences());

            action(_packages);

            return this;

        }

        public MsCsProject References(Action<References> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (this._references == null)
                _itemGroups.Add(this._references = new References());

            action(_references);

            return this;

        }

        public MsCsProject ProjectReferences(Action<ProjectReferences> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (this._projectReferences == null)
                _itemGroups.Add(this._projectReferences = new ProjectReferences());

            action(_projectReferences);

            return this;

        }

        private MsCsProject Save()
        {

            var payload = this.Serialize().ToString();

            var file = new FileInfo(ProjectFile);
            if (!file.Directory.Exists)
                file.Directory.Create();

            FileInfo backup = new FileInfo(Path.Combine(file.Directory.FullName, Path.GetFileNameWithoutExtension(file.Name) + ".bck"));

            if (file.Exists)
            {

                if (backup.Exists)
                    backup.Delete();

                file.MoveTo(backup.FullName);

                backup.Refresh();

                file = new FileInfo(ProjectFile);
                file.Refresh();

            }

            try
            {
                file.Save(payload);
                SaveNugetDotConfig(file.Directory);
            }
            catch (Exception ex)
            {
                if (backup.Exists)
                    backup.MoveTo(file.FullName);
            }
            finally
            {
                backup.Refresh();
                if (backup.Exists)
                    backup.Delete();
            }

            return this;

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


        #region GenerateOnMemory

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

        private static Assembly Load(MemoryStream ass, MemoryStream pdb)
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

        private static MemoryStream GetStream()
        {
            return new MemoryStream();
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

        #endregion GenerateOnMemory



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

        private Assembly Load()
        {
            this.Assembly = Assembly.LoadFile(this.AssemblyFile);
            return this.Assembly;
        }



        private static bool IsRunningOnMono { get => Type.GetType("Mono.Runtime") != null; }

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

        private void SaveNugetDotConfig(DirectoryInfo dir)
        {
            FileInfo fileNuget = new FileInfo(Path.Combine(dir.FullName, "nuget.config"));

            var datas = new XDocument();
            datas.Add
            (
                new XElement("configuration",
                new XElement
                (
                    "packageRestore",

                    new XElement("add",
                        new XAttribute("key", "enabled"),
                        new XAttribute("value", "True")
                        ),

                    new XElement("add",
                        new XAttribute("key", "automatic"),
                        new XAttribute("value", "True")
                        )
                ),

                new XElement
                (
                    "packageSources",

                    new XElement("add",
                        new XAttribute("key", "NuGet official package source"),
                        new XAttribute("value", "https://api.nuget.org/v3/index.json")
                        )
                )

            ));

            fileNuget.Save(datas.ToString());
        }

        internal XElement Serialize()
        {

            var result = new XElement("Project");
            Serialize(result);

            result.Add(PropertyGroup.Serialize());

            foreach (ItemGroup group in ItemGroups)
            {
                var i = group.Serialize();
                result.Add(i);
            }

            return result;

        }

        private List<ItemGroup> _itemGroups;
        private PackageReferences _packages;
        private References _references;
        private ProjectReferences _projectReferences;
        private readonly List<PropertyKey> _keys;



    }

}

// https://gitter.im/dotnet/roslyn?at=5de833f855066245986b8467
