using Microsoft.CodeAnalysis.MSBuild;
using System.Xml.Linq;
using Bb;
using System.Collections.Generic;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.Build.Locator;

namespace Bb.Build
{

    public class MsProject : Group
    {

        public MsProject(string name, DirectoryInfo dir) 
            : base (false)
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

        public string ProjectFile { get; }

        public MsProject Sdk(ProjectSdk value)
        {
            Add(value as PropertyKey);
            return this;
        }

        public MsProject DefaultTargets(DefaultTargets value)
        {
            Add(value as PropertyKey);
            return this;
        }

        public MsProject InitialTargets(InitialTargets value)
        {
            Add(value as PropertyKey);
            return this;
        }

        public MsProject ToolsVersion(ToolsVersion value)
        {
            Add(value as PropertyKey);
            return this;
        }

        public MsProject SetPropertyGroup(Action<PropertyGroup> action)
        {

            if (action != null)
                action(this.PropertyGroup);

            return this;

        }

        public MsProject ItemGroup(Action<ItemGroup> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            var item = new ItemGroup();
            _itemGroups.Add(item);
            action(item);
            return this;
        }

        public MsProject Packages(Action<PackageReferences> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (this._packages == null)
                _itemGroups.Add(this._packages = new PackageReferences());

            action(_packages);

            return this;

        }

        public MsProject References(Action<References> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (this._references == null)
                _itemGroups.Add(this._references = new References());

            action(_references);

            return this;

        }

        public MsProject ProjectReferences(Action<ProjectReferences> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (this._projectReferences == null)
                _itemGroups.Add(this._projectReferences = new ProjectReferences());

            action(_projectReferences);

            return this;

        }

        private MsProject Save()
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
                file.FullName.Save(payload);
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

        public MsProject Build()
        {

            Save();

            var task = Task.Run(async () =>
            {

                var vsInstance = MSBuildLocator.RegisterDefaults();

                using (var workspace = MSBuildWorkspace.Create())
                {

                    Project project = await workspace.OpenProjectAsync(ProjectFile).ConfigureAwait(false);

                    Compilation? compilation = await project.GetCompilationAsync();

                    if (compilation != null)
                    {
                        var result = compilation.Emit(Stream.Null);
                        if (result.Success)
                        {
                            var ass = compilation.Assembly;
                        }
                        else
                        {
                            //Console.WriteLine("Compilation failed. Errors:");

                            foreach (var diagnostic in result.Diagnostics)
                            {
                                if (diagnostic.Severity == DiagnosticSeverity.Error)
                                {
                                    //Console.WriteLine(diagnostic);
                                }
                            }
                        }
                    }

                }
            });


            task.Wait();

            return this;
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
