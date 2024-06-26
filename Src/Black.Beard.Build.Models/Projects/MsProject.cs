﻿using System.Xml.Linq;
using System.Reflection;
using System.Text;
using System.IO;

namespace Bb.Projects
{

    public class MsProject : Group
    {

        public MsProject(string projectName, DirectoryInfo dir)
            : base("Project", false)
        {

            if (string.IsNullOrEmpty(projectName))
                throw new ArgumentNullException(nameof(projectName));

            if (dir == null)
                throw new ArgumentNullException(nameof(dir));

            dir.Refresh();

            if (!dir.Exists)
                dir.Create();

            this.ProjectName = projectName;
            this.Directory = dir;

            this.ProjectFile = Path.Combine(this.Directory.FullName, $"{projectName}.csproj");

            this._itemGroups = new List<ItemGroup>();
            this.PropertyGroup = new PropertyGroup();

            Add(ProjectSdk.MicrosoftNETSdk);

        }

        public string ProjectName { get; }

        public DirectoryInfo Directory { get; }

        public PropertyGroup PropertyGroup { get; }

        public IEnumerable<ItemGroup> ItemGroups { get => _itemGroups; }



        public string ProjectFile { get; }

        public MsProject Sdk(ProjectSdk value)
        {
            Add(value);
            return this;
        }

        public MsProject DefaultTargets(string value)
        {
            Add("DefaultTargets", value);
            return this;
        }

        public MsProject InitialTargets(string value)
        {
            Add("InitialTargets", value);
            return this;
        }

        public MsProject ToolsVersion(Version value)
        {
            Add("ToolsVersion", value);
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

        public MsProject SqlCmdVariables(Action<SqlCmdVariables> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (this._packages == null)
                _itemGroups.Add(this._sqlCmdVariables = new SqlCmdVariables());

            action(_sqlCmdVariables);

            return this;

        }

        public MsProject SqlDeploy(Action<SqlDeploy> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (this._packages == null)
                _itemGroups.Add(this._sqlDeploy = new SqlDeploy());

            action(_sqlDeploy);

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

        public MsProject Save()
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

        /// <summary>
        /// Appends a new document in the project.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public MsProject AppendDocument(string path, string filename, StringBuilder content)
        {
            var file = ComputeFullPath(path, filename);
            file.Save(content.ToString());
            return this;
        }


        /// <summary>
        /// Appends a new document in the project.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public MsProject AppendDocument(string filename, StringBuilder content)
        {
            var file = ComputeFullPath(null, filename);
            file.Save(content.ToString());
            return this;
        }

        /// <summary>
        /// Appends a new document in the project.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public MsProject AppendDocument(string filename, string content)
        {
            var file = ComputeFullPath(null, filename);
            file.Save(content);
            return this;
        }

        /// <summary>
        /// Appends a new document in the project.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public MsProject AppendDocument(string path, string filename, string content)
        {
            var file = ComputeFullPath(path, filename);
            file.Save(content);
            return this;
        }

        /// <summary>
        /// Computes the full path for the file you want to append to project.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public string ComputeFullPath(string? path, string filename)
        {
            var _path = ComputeFullPath(path);
            var file = Path.Combine(_path, filename);
            return file;

        }

        /// <summary>
        /// Computes the full path for the file you want to append to project.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public string ComputeFullPath(string? path)
        {
            var targetDirectory = this.Directory.FullName;
            if (!string.IsNullOrEmpty(path))
                targetDirectory = Path.Combine(this.Directory.FullName, path);
            var dir = new DirectoryInfo(targetDirectory);

            if (!dir.Exists)
                dir.Create();

            return dir.FullName;

        }


        protected static bool IsRunningOnMono { get => Type.GetType("Mono.Runtime") != null; }

        
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

        public override XObject Serialize()
        {

            var result = (XElement)base.Serialize();

            PropertyGroup.Serialize(result);

            foreach (ItemGroup group in ItemGroups)
                group.Serialize(result);

            return result;

        }

        private List<ItemGroup> _itemGroups;
        private PackageReferences _packages;
        private SqlCmdVariables _sqlCmdVariables;
        private SqlDeploy _sqlDeploy;
        private References _references;
        private ProjectReferences _projectReferences;

    }

}

// https://gitter.im/dotnet/roslyn?at=5de833f855066245986b8467
