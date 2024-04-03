using Bb.Analysis;
using Bb.Analysis.DiagTraces;
using Bb.Codings;
using Bb.Compilers;
using Bb.Metrology;
using Bb.Nugets;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;
using static Refs.System;

namespace Bb.Builds
{

    /// <summary>
    /// Build Csharp
    /// </summary>
    [DebuggerDisplay("{AssemblyName}")]
    public class BuildCSharp
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="BuildCSharp"/> class.
        /// </summary>
        /// <param name="configureCompilation">The configure compilation.</param>
        public BuildCSharp(Func<CSharpCompilationOptions, CSharpCompilationOptions> configureCompilation = null)
        {

            RuntimeConfig = new RuntimeConfig();
            Platform = Platform.AnyCpu;
            this.OutputKind = OutputKind.DynamicallyLinkedLibrary;
            _diagnostics = new ScriptDiagnostics();
            _compiledAssemblies = new Dictionary<int, AssemblyResult>();
            _suppress = new Dictionary<string, ReportDiagnostic>();


            Framework = new Frameworks();
            ConfigureCompilations = new List<Func<CSharpCompilationOptions, CSharpCompilationOptions>>(2);
            this.References = new AssemblyReferences();
            Sources = new SourceCodes();
            OutputPath = Path.Combine(Path.GetTempPath(), "_builds");


            if (configureCompilation != null)
                this.ConfigureCompilations.Add(configureCompilation);

            if (!Directory.Exists(OutputPath))
                Directory.CreateDirectory(OutputPath);

        }


        #region Packages and references

        /// <summary>
        /// Add references to the build.
        /// </summary>
        /// <param name="types"></param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp AddReferences(params Type[] types)
        {
            this.References.AddByTypes(types);
            return this;
        }

        /// <summary>
        /// Add references to the build.
        /// </summary>
        /// <param name="types"></param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp AddReferences(params Assembly[] types)
        {
            this.References.AddByAssemblies(types);
            return this;
        }

        /// <summary>
        /// Add references to the build.
        /// </summary>
        /// <param name="assemblyLocation"></param>
        /// <param name="assemblyName"></param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp AddReferences(string assemblyLocation)
        {
            this.References.AddAssemblyLocation(assemblyLocation);
            return this;
        }



        /// <summary>
        /// Replace the current nuget controller
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public BuildCSharp SetNugetController(NugetController controller)
        {
            controller.CopyPackagesFrom(this.Nugets);
            this._nugets = controller;
            return this;
        }

        /// <summary>
        /// Add packages on the build.
        /// </summary>
        /// <param name="packageName">name of the package</param>
        /// <param name="version">version of the package. If null the last version is used</param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp AddPackage(string packageName, Version version)
        {
            this.Nugets.AddPackage(packageName, version);
            return this;
        }

        /// <summary>
        /// Add packages on the build.
        /// </summary>
        /// <param name="packageName">name of the package</param>
        /// <param name="version">version of the package. If null the last version is used</param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp AddPackage(string packageName, string? version = null)
        {
            this.Nugets.AddPackage(packageName, version);
            return this;
        }

        /// <summary>
        /// Add packages on the build.
        /// </summary>
        /// <param name="packageName">name of the package</param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp AddPackage(string packageName)
        {
            this.Nugets.AddPackage(packageName);
            return this;
        }

        #endregion Packages and references


        #region Sources

        /// <summary>
        /// Load the sources from the project file.
        /// </summary>
        /// <param name="paths"></param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp AddSource(params FileInfo[] paths)
        {

            foreach (var file in paths)
                this.Sources.Add(file.FullName);

            return this;

        }

        /// <summary>
        /// Adds the source code by filename.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp AddSource(params string[] paths)
        {
            foreach (var file in paths)
            {
                this.Sources.Add(file);
            }
            return this;
        }

        /// <summary>
        /// Adds the source code by filename.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp AddSource(string documentName, string payload)
        {
            this.Sources.Add(documentName, payload);
            return this;
        }

        #endregion Packages and references

        /// <summary>
        /// Active the implicit usings.
        /// </summary>
        /// <param name="enable"></param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp EnableImplicitUsings(bool enable = true)
        {
            if (enable)
            {


                var o = new List<string>
                {
                    "System",
                    "System.Collections.Generic",
                    "System.Linq",
                    "System.Text",
                    "System.IO",
                    "System.Net.Http",
                    "System.Threading",
                    "System.Threading.Tasks",
                    "System.Threading"
                };


                if (this.Framework.Sdk == FrameworkType.AspNetCore)
                {
                    o.Add("System.Net.Http.Json");
                    o.Add("System.Text.Json");
                    o.Add("Microsoft.AspNetCore.Builder");
                    o.Add("Microsoft.AspNetCore.Hosting");
                    o.Add("Microsoft.AspNetCore.Http");
                    o.Add("Microsoft.AspNetCore.Routing");
                    o.Add("Microsoft.Extensions.Configuration");
                    o.Add("Microsoft.Extensions.DependencyInjection");
                    o.Add("Microsoft.Extensions.Hosting");
                    o.Add("Microsoft.Extensions.Logging");
                }


                Usings(o.ToArray(), c => c.IsGlobal = true);

            }
            else
                _usings.Clear();

            return this;
        }



        #region Sdk

        /// <summary>
        /// Add available sdk.
        /// </summary>
        /// <param name="frameworkVersions"></param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp AddAvailableSdk(string[] frameworkVersions)
        {

            var type = this.Framework.Sdk;

            List<FrameworkKey> versions = new List<FrameworkKey>();
            foreach (var item in frameworkVersions)
            {
                var version = FrameworkKey.Resolve(item);
                if (version != null)
                    versions.Add(version);
            }

            FrameworkKey key = versions.OrderBy(c => c).Last();

            this.Framework.Versions.Add(FrameworkVersion.Resolve(key, type));

            return this;

        }

        /// <summary>
        /// Remove all available sdk.
        /// </summary>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp ResetSdk()
        {
            this.References.Sdk = null;
            this.Framework.Reset();
            foreach (var item in this._children.Children)
                item.Value.ResetSdk();
            return this;
        }


        /// <summary>
        /// Set the sdk dotnet.
        /// </summary>
        /// <param name="frameworkKey"></param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp SetSdk(string frameworkKey)
        {
            var key = FrameworkKey.Resolve(frameworkKey);
            SetSdk(key);
            return this;
        }

        /// <summary>
        /// Set the sdk dotnet.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp SetSdk(FrameworkKey key, FrameworkType type = null)
        {
            var version = FrameworkVersion.Resolve(key, type);
            SetSdk(version);
            return this;
        }

        /// <summary>
        /// Set the current running sdk dotnet.
        /// </summary>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp SetSdk()
        {
            SetSdk(FrameworkVersion.CurrentVersion);
            return this;
        }

        /// <summary>
        /// Set the sdk dotnet.
        /// </summary>
        /// <param name="framework"></param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp SetSdk(FrameworkVersion framework)
        {
            this.Framework.Sdk = framework.Type;
            this.References.Sdk = framework;
            this.Framework.Versions.Add(framework);
            return this;
        }





        #endregion Sdk


        #region Usings

        /// <summary>
        /// append using directives in the source code with specified name.
        /// </summary>
        /// <param name="usings">The usings.</param>
        /// <returns></returns>
        public BuildCSharp Usings(params Type[] usings)
        {
            foreach (var @using in usings)
                if (!string.IsNullOrEmpty(@using.Namespace))
                    Using(@using.Namespace);
            return this;
        }

        /// <summary>
        /// append static using directives in the source code with specified name.
        /// </summary>
        /// <param name="usings">The static usings to append.</param>
        /// <returns></returns>
        public BuildCSharp UsingStatics(params string[] usings)
        {
            foreach (var @using in usings)
                Using(new CSUsing(@using) { IsStatic = true });

            return this;
        }

        /// <summary>
        /// append using directives in the source code with specified name.
        /// </summary>
        /// <param name="usings">The usings to append.</param>
        /// <param name="action">action to execute for every namespace.</param>
        /// <returns></returns>
        public BuildCSharp Usings(string[] usings, Action<CSUsing> action = null)
        {

            foreach (var @using in usings)
            {
                var u = new CSUsing(@using);
                if (action != null)
                    action(u);
                Using(u);
            }
            return this;
        }

        /// <summary>
        /// append using directives in the source code with specified name.
        /// </summary>
        /// <param name="usings">The usings to append.</param>
        /// <param name="action">action to execute for every namespace.</param>
        /// <returns></returns>
        public BuildCSharp Using(string @using, Action<CSUsing> action = null)
        {

            var u = new CSUsing(@using);

            if (action != null)
                action(u);

            Using(u);

            return this;
        }

        /// <summary>
        /// append using directives in the source code with specified name.
        /// </summary>
        /// <param name="usings">The usings to append.</param>
        /// <param name="action">action to execute for every namespace.</param>
        /// <returns></returns>
        public BuildCSharp Using(CSUsing @using)
        {

            if (_usings.TryGetValue(@using.NamespaceOrType, out CSUsing u))
                _usings[@using.NamespaceOrType] = @using;
            else
                _usings.Add(@using.NamespaceOrType, @using);

            return this;
        }

        #endregion Usings


        #region properties

        /// <summary>
        /// Gets the references assemblies.
        /// </summary>
        /// <value>
        /// The references.
        /// </value>
        public AssemblyReferences References { get; }

        /// <summary>
        /// Gets or sets the output path of the build.
        /// </summary>
        /// <value>
        /// The output path.
        /// </value>
        public string OutputPath { get; set; }

        /// <summary>
        /// Gets the file name's list of sources code.
        /// </summary>
        /// <value>
        /// The sources.
        /// </value>
        public SourceCodes Sources { get; }

        /// <summary>
        /// Set type of output library
        /// </summary>
        /// <param name="kind">kind of library</param>
        /// <param name="mainTypeName">Name of main type name</param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp SetOutputKind(OutputKind kind, string mainTypeName)
        {
            this.MainTypeName = mainTypeName;
            this.OutputKind = kind;
            return this;
        }

        /// <summary>
        /// Set type of output library
        /// </summary>
        /// <param name="kind">kind of library</param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp SetOutputKind(OutputKind kind)
        {
            this.OutputKind = kind;
            return this;
        }

        /// <summary>
        /// Suppresses the specified ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp Suppress(params string[] ids)
        {

            foreach (var item in ids)
                _suppress.Add(item, ReportDiagnostic.Suppress);

            return this;

        }

        /// <summary>
        /// suppress diagnostic items.
        /// </summary>
        /// <param name="reportMode">The report mode.</param>
        /// <param name="ids">The ids.</param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp SuppressDiagnostic(ReportDiagnostic reportMode, params string[] ids)
        {

            foreach (var idKey in ids)
            {
                if (!_suppress.ContainsKey(idKey))
                    _suppress.Add(idKey, reportMode);
                else
                    _suppress[idKey] = reportMode;
            }

            return this;

        }

        /// <summary>
        /// Add configuration options action.
        /// </summary>
        /// <value>
        /// The configure compilation.
        /// </value>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp ConfigureCompilation(Func<CSharpCompilationOptions, CSharpCompilationOptions> action)
        {
            ConfigureCompilations.Add(action);
            return this;
        }

        /// <summary>
        /// referential nuget controller
        /// </summary>
        public NugetController Nugets
        {
            get
            {

                if (_nugets == null)
                {

                    this._nugets = new NugetController();

                    if (NugetController.IsWindowsPlatform)
                        this.Nugets.AddDefaultWindowsFolder();

                }

                return _nugets;
            }
        }

        /// <summary>
        /// get the framework
        /// </summary>
        public Frameworks Framework { get; internal set; }

        /// <summary>
        /// Gets or sets the key file.
        /// </summary>
        /// <value>
        /// The key file.
        /// </value>
        public string KeyFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [delay sign].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [delay sign]; otherwise, <c>false</c>.
        /// </value>
        public bool DelaySign { get; set; }

        /// <summary>
        /// Gets or sets the strong name key.
        /// </summary>
        /// <value>
        /// The strong name key.
        /// </value>
        public ImmutableArray<byte> StrongNameKey { get; set; }

        public List<Func<CSharpCompilationOptions, CSharpCompilationOptions>> ConfigureCompilations { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether [resolve objects].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [resolve objects]; otherwise, <c>false</c>.
        /// </value>
        public bool ResolveObjects { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BuildCSharp"/> is debug mode.
        /// </summary>
        /// <value>
        ///   <c>true</c> if debug; otherwise, <c>false</c>.
        /// </value>
        public bool Debug { get; set; }

        /// <summary>
        /// Gets or sets the documentation mode.
        /// </summary>
        /// <value>
        /// The documentation mode.
        /// </value>
        public DocumentationMode DocumentationMode { get; set; } = DocumentationMode.Parse;

        /// <summary>
        /// Set the assembly name.
        /// </summary>
        public string AssemblyName { get; internal set; }

        /// <summary>
        /// Gets the last build result.
        /// </summary>
        public AssemblyResult LastBuild { get; private set; }

        /// <summary>
        /// Gets or sets the platform. AnyCpu by default.
        /// </summary>
        public Platform Platform { get; set; }

        /// <summary>
        /// Gets or sets the output kind. DynamicallyLinkedLibrary by default.
        /// </summary>
        public OutputKind OutputKind { get; private set; }

        /// <summary>
        /// main type name
        /// </summary>
        public string MainTypeName { get; set; }

        /// <summary>
        /// Gets or sets the runtime configuration.
        /// </summary>
        public RuntimeConfig RuntimeConfig { get; internal set; }

        #endregion properties



        /// <summary>
        /// Add attribute on the assembly
        /// </summary>
        /// <param name="attributeName">name of the attribute</param>
        /// <param name="arguments">arguments of the attribute</param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp AddAssemblyAttribute(string attributeName, params object[] arguments)
        {
            if (_attributes.ContainsKey(attributeName))
                _attributes.Remove(attributeName);
            _attributes.Add(attributeName, arguments);
            return this;
        }

        /// <summary>
        /// Add attribute on the assembly
        /// </summary>
        /// <param name="attribute">attribute type</param>
        /// <param name="arguments">arguments of the attribute</param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp AddAssemblyAttribute(Type attribute, params object[] arguments)
        {
            var attributeName = attribute.Name;
            if (_attributes.ContainsKey(attributeName))
                _attributes.Remove(attributeName);
            _attributes.Add(attributeName, arguments);
            this.References.AddByTypes(attribute);
            return this;
        }

        /// <summary>
        /// Apply a filter for manage the sources to integrate in the build.
        /// </summary>
        /// <param name="value"></param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public BuildCSharp FilterSources(Func<SourceCode, bool> value)
        {
            this.Sources.Filter = value;
            return this;
        }


        /// <summary>
        /// Builds the specified assembly name.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        public AssemblyResult Build(string assemblyName = null)
        {

            if (!Sources.Documents.Any())
            {
                _diagnostics.Error("No code", "No source code to build");
                return null;
            }

            _inBuild = true;

            try
            {

                BuildDependencies();
                if (Sources.EnsureUptodated())
                {
                    _diagnostics.Warning("code", "the code has changed");
                    if (!Sources.Documents.Any())
                    {
                        _diagnostics.Error("No code", "No source code to build");
                        return null;
                    }
                }

                var key = Sources.GetHashCode();

                if (!_compiledAssemblies.TryGetValue(key, out AssemblyResult result))
                {

                    this.LastBuild = null;

                    if (References.Sdk == null)
                    {
                        if (this.Framework != null && this.Framework.HasVersion)
                            SetSdk(this.Framework.GetFrameworkVersion());
                        else
                            SetSdk();
                    }

                    foreach (var item in _dependencies)
                    {
                        if (item.LastBuild == null || !item.LastBuild.Success)
                        {
                            _diagnostics.Error(item.AssemblyName, $"Dependency {item.AssemblyName} not built");
                            return null;
                        }
                        else
                            References.AddAssemblyLocation(item.LastBuild.FullAssemblyFile);
                    }

                    Nugets.ResolvePackages(References, this._diagnostics);

                    RoslynCompiler compiler = CreateBuilder();

                    result = compiler.Generate(assemblyName ?? this.AssemblyName);

                    if (result.Success)
                    {
                        _compiledAssemblies.Add(key, result);
                        this.LastBuild = result;
                    }
                }


                return result;

            }
            finally
            {
                _inBuild = false;
            }


        }


        #region subBuild

        internal BuildCSharp SetCompiledAssemblies(Dictionary<int, AssemblyResult> compiledAssemblies)
        {
            _compiledAssemblies = compiledAssemblies;
            return this;
        }

        /// <summary>
        /// Set diagnostics
        /// </summary>
        /// <param name="diagnostics"></param>
        /// <returns><see cref="BuildCSharp"/>fluent notation</returns>
        internal BuildCSharp SetDiagnostics(ScriptDiagnostics diagnostics)
        {
            _diagnostics = diagnostics;
            return this;
        }

        internal void AppendProject(FileInfo path)
        {

            if (!_children.Children.TryGetValue(path.FullName, out BuildCSharp builder))
            {

                builder = path.CreateCsharpBuild(this.Debug, this.ConfigureCompilations, _children)
                              .SetCompiledAssemblies(this._compiledAssemblies)
                              .SetDiagnostics(this._diagnostics)
                            ;

                _children.Children.Add(path.FullName, builder);

                var docProject = ProjectRoslynBuilderHelper.LoadXml(path.FullName);
                builder.LoadSources(path)
                       .Visit(docProject.DocumentElement, path.Directory);

            }

            this.AddDependency(builder);

        }

        private void AddDependency(BuildCSharp buildCSharp)
        {
            _dependencies.Add(buildCSharp);
        }

        private RoslynCompiler CreateBuilder()
        {

            References.Next(Nugets);


            var compiler = new RoslynCompiler(this.OutputKind, References, _diagnostics)
            {
                ConfigureCompilation = Configure,
                DocumentationMode = this.DocumentationMode,
                KeyFile = this.KeyFile,
                DelaySign = this.DelaySign,
                StrongNameKey = this.StrongNameKey,
                ResolveObjects = this.ResolveObjects,
                Debug = this.Debug,
                Usings = _usings.Values.ToArray(),
                AssemblyAttributes = this._attributes,
                MainTypeName = this.MainTypeName,
                Platform = this.Platform,
                RuntimeConfig = RuntimeConfig,
            }

            .AddCodeSource(Sources)
            .SetOutput(OutputPath)
            ;


            return compiler;

        }

        private void BuildDependencies()
        {

            if (_children.Children.Any())
            {
                foreach (var item in _children.Children)
                    if (item.Value.CanBeBuilt())
                    {

                        var build = item.Value;

                        foreach (var subBuild in build._dependencies)
                            if (subBuild.CanBeBuilt())
                                subBuild.Build();

                        if (build.CanBeBuilt())
                            build.Build();


                    }
            }

        }

        private CSharpCompilationOptions Configure(CSharpCompilationOptions obj)
        {

            if (_suppress.Count > 0)
            {
                var dic = ImmutableDictionary.CreateRange(_suppress);
                obj = obj.WithSpecificDiagnosticOptions(dic);

                if (RoslynActivityProvider.WithTelemetry)
                    RoslynActivityProvider.AddProperty("suppress", string.Join(", ", dic.Keys));

            }

            if (ConfigureCompilations.Count > 0)
                foreach (var item in ConfigureCompilations)
                    obj = item(obj);

            return obj;

        }

        /// <summary>
        /// the current instance can be built
        /// </summary>
        /// <returns>boolean</returns>
        public bool CanBeBuilt()
        {

            if (this.LastBuild != null && this.LastBuild.Success)
                return false;

            if (this._inBuild)
                return false;

            if (_dependencies.Count == 0)
                return true;

            bool result = true;
            foreach (var item in _dependencies)
                if (item.LastBuild == null || !item.LastBuild.Success)
                {
                    result = false;
                    break;
                }

            return result;

        }


        #endregion subBuild


        private List<BuildCSharp> _dependencies = new List<BuildCSharp>();
        internal BuildList _children = new BuildList();
        private ScriptDiagnostics _diagnostics;
        private Dictionary<int, AssemblyResult> _compiledAssemblies;
        private readonly Dictionary<string, ReportDiagnostic> _suppress;
        private Dictionary<string, CSUsing> _usings = new Dictionary<string, CSUsing>();
        private Dictionary<string, object[]> _attributes = new Dictionary<string, object[]>();
        private NugetController _nugets;
        private bool _inBuild = false;

    }

    internal class BuildList
    {

        public Dictionary<string, BuildCSharp> Children = new Dictionary<string, BuildCSharp>();


    }


}
