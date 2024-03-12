using Bb.Analysis;
using Bb.Analysis.DiagTraces;
using Bb.Builds;
using Bb.Nugets.Versions;
using ICSharpCode.Decompiler.Util;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Bb.Nugets
{


    public class NugetController : IAssemblyReferenceResolver
    {


        /// <summary>
        /// Is Windows platform
        /// </summary>
        public static bool IsWindowsPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        /// <summary>
        /// Is Linux platform
        /// </summary>
        public static bool IsLinuxPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        /// <summary>
        /// Is FreeBSD platform
        /// </summary>
        public static bool IsFreeBSDPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD);

        /// <summary>
        /// Is OSX platform
        /// </summary>
        public static bool IsOsxPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);


        /// <summary>
        /// Create a new instance of <see cref="NugetController"/>
        /// </summary>
        public NugetController()
        {
            _folders = new List<FileNugetFolders>();
        }


        /// <summary>
        /// Add the default repository to resolve nuget for windows
        /// </summary>
        /// <returns></returns>
        public NugetController AddDefaultWindowsFolder()
        {
            return AddFolder(DefaultWindowsLocalFolder);
        }


        /// <summary>
        /// Add the default repository to resolve nuget if filter is true
        /// </summary>
        /// <param name="filter">condition for adding folder</param>
        /// <param name="path">path to store the package downloaded</param>
        /// <returns></returns>
        public NugetController AddFolderIf(bool filter, string path)
        {
            if (filter)
                AddFolder(path);
            return this;
        }


        /// <summary>
        /// Add the default repository to resolve nuget for windows
        /// </summary>
        /// <param name="path">path to store the package downloaded</param>
        /// <returns></returns>
        public NugetController AddFolder(string path)
        {
            AddFolder(DefaultWindowsLocalFolder, HostNugetOrg);
            return this;
        }


        /// <summary>
        /// Add the default repository to resolve nuget if filter is true
        /// </summary>
        /// <param name="filter">condition for adding folder</param>
        /// <param name="path">path to store the package downloaded</param>
        /// <param name="hosts">host where search package on line</param>
        /// <returns></returns>
        public NugetController AddFolderIf(bool filter, string path, params string[] hosts)
        {
            if (filter)
                AddFolder(path, hosts);
            return this;
        }


        /// <summary>
        /// Add the default repository to resolve nuget for windows
        /// </summary>
        /// <param name="path">path to store the package downloaded</param>
        /// <param name="host">host where search package on line</param>
        /// <returns></returns>
        public NugetController AddFolder(string path, params string[] hosts)
        {

            if (!_folders.Any(c => c.Path.FullName == path))
                _folders.Add(new FileNugetFolders(path, hosts)
                {
                    Parent = this,
                }
                    .Refresh()
                    );

            return this;

        }


        /// <summary>
        /// Copy the nuget folder from the source
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public NugetController CopyFolderFrom(NugetController source)
        {

            foreach (var item in source._folders)
                if (!_folders.Any(c => c.Path.FullName == item.Path.FullName))
                    _folders.Add(item);

            return this;

        }


        /// <summary>
        /// Copy the nuget folder from the source
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public NugetController CopyPackagesFrom(NugetController source)
        {

            foreach (var item in source._packages)
                this.AddPackage(item.Item1, item.Item2);

            return this;

        }


        /// <summary>
        /// Add a reference to resolve in the build
        /// </summary>
        /// <param name="nugetName">nuget reference to add</param>
        public void AddPackage(string nugetName)
        {
            AddPackage(nugetName, (Version)null);
        }


        /// <summary>
        /// Add a reference to resolve in the build
        /// </summary>
        /// <param name="nugetName">nuget reference to add</param>
        /// <param name="versionMin">minimum version to add</param>
        public void AddPackage(string nugetName, string versionMin)
        {
            Version min = string.IsNullOrEmpty(versionMin) ? null : new Version(versionMin);
            AddPackage(nugetName, min);
        }


        /// <summary>
        /// Add a reference to resolve in the build
        /// </summary>
        /// <param name="nugetName">nuget reference to add</param>
        /// <param name="version">minimum version to add</param>
        public void AddPackage(string nugetName, Version version)
        {

            if (version == null)
                version = new Version(1, 0, 0);

            var items = _packages.Where(c => c.Item1 == nugetName).ToList();

            if (items.Any(c => c.Item2 == version))
                return;

            if (items.Any())
            {

                var max = items.Max(c => c.Item2);
                if (max > version)
                    return;

                foreach (var item in items)
                    _packages.Remove(item);

            }

            _packages.Add((nugetName, version));

        }


        /// <summary>
        /// Resolve assembly name
        /// </summary>
        /// <param name="assemblyName">name of the assembly</param>
        /// <param name="framework"><see cref="FrameworkVersion"/> </param>
        /// <returns></returns>
        public Reference ResolveAssemblyName(string assemblyName, FrameworkVersion framework, Func<ReferenceType, List<Reference>, Reference> func)
        {

            Reference reference = null;

            if (framework == null)
                framework = FrameworkVersion.CurrentVersion;

            List<Reference> list = TryToResolve(assemblyName, out var empty, framework);

            if (list.Count > 0)
            {

                reference = func(ReferenceType.Nuget, list);

                if (reference == null)
                    Trace.TraceWarning($"assembly {assemblyName} is not resolved by {nameof(NugetController)}");

                if (_next != null)
                    return _next.ResolveAssemblyName(assemblyName, framework, func);

            }

            return reference;

        }


        internal void ResolvePackages(AssemblyReferences references, ScriptDiagnostics diagnostics)
        {

            var framework = references.Sdk;
            var test = true;
            HashSet<string> _h = new HashSet<string>();

            while (test)
            {

                var listSource = _packages.ToList();
                test = false;

                foreach (var item in listSource)
                    if (_h.Add(item.Item1))
                    {

                        List<Reference> list = TryToResolve(item, out var empty, framework);
                        if (list.Count == 0)   // If missing try to download
                        {
                            if (empty)
                                diagnostics.Information(item.Item1, $"the package nuget {item.Item1} {item.Item2} not contains library.");

                            else if (TryToDownload(framework, item.Item1, item.Item2))
                                list = TryToResolve(item, out empty, framework);
                        }

                        if (list.Count > 0)   // Append references
                        {
                            var reference = list.SelectOptimized(framework);
                            references.AddReference(reference);
                            foreach (var r in EnsureDependencies(reference, framework))
                                if (!_packages.Any(c => c.Item1 != r.Item1 || c.Item2 != r.Item2.Version))
                                {
                                    _packages.Add((r.Item1, r.Item2.Version));
                                    test = true;
                                }   
                        }
                    }

            }

        }

        private IEnumerable<(string, ConstraintVersion)> EnsureDependencies(Reference reference, FrameworkVersion frameworkTarget)
        {

            NugetDocument nuget = reference.Package;
            FrameworkKey framework = reference.Framework;

            var list = nuget.GroupDependencies(frameworkTarget.Key).ToList();
            foreach (var dependencyGroup in list)
                foreach (var dependency in dependencyGroup.Dependencies())
                    yield return (dependency.Id, dependency.ConstraintVersion);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public FileNugetFolder Resolve(string name)
        {

            foreach (var nugetFolder in _folders)
            {
                var o = nugetFolder.Resolve(name);
                if (o != null)
                    return o;
            }

            return default;

        }

        public LocalFileNugetVersion Resolve(string name, Version version, bool refresh)
        {

            foreach (var nugetFolder in _folders)
            {
                var o = nugetFolder.Resolve(name, version, refresh);
                if (o != null)
                    return o;
            }

            return default;

        }

        /// <summary>
        /// Try to download the package nuget
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool TryToDownload(FrameworkVersion framework, string name, Version version = null)
        {

            bool result = false;

            if (Filter != null && !Filter(name, version))
                return false;

            foreach (var nugetFolder in _folders)
                if (nugetFolder.WithResolver)
                    if (nugetFolder.TryToDownload(name, version))
                    {
                        result = true;
                        break;
                    }

            return result;

        }


        public NugetController WithFilter(Func<string, Version, bool> filter)
        {
            Filter = filter;
            return this;
        }


        public Func<string, Version, bool> Filter { get; set; }


        private List<Reference> TryToResolve((string, Version) item, out bool empty, FrameworkVersion framework = null)
        {

            empty = false;
            var lst = new List<Reference>();

            foreach (var nugetFolder in _folders)
                foreach (LocalFileNugetVersion version in nugetFolder.ResolveAll(item))
                {
                    var libs = version.Metadata;
                    if (version.Metadata != null && !version.Empty)
                        empty = true;

                    else
                        foreach (var reference in version.Metadata.References)
                            if (framework == null || framework.Accept(reference.Framework))
                                lst.Add(reference);

                }

            return lst;

        }

        private List<Reference> TryToResolve(string item, out bool empty, FrameworkVersion framework = null)
        {

            empty = false;
            var lst = new List<Reference>();

            foreach (var nugetFolder in _folders)
                foreach (var version in nugetFolder.ResolveAll(item))
                {
                    var libs = version.Metadata;

                    if (version.Metadata != null && !version.Empty)
                        empty = true;

                    else
                        foreach (var reference in version.Metadata.References)
                            if (framework == null || framework.Accept(reference.Framework))
                                lst.Add(reference);


                }

            return lst;

        }


        public void Next(IAssemblyReferenceResolver next)
        {
            if (_next == null)
                _next = next;
            else
                _next.Next(next);
        }

        /// <summary>
        /// Intercept functions. return true to bypass the process
        /// </summary>
        public Func<string, object[], bool> Intercept { get; set; }


        public static string HostNugetOrg = "https://www.nuget.org/api/v2/package";
        public static string DefaultWindowsLocalFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".nuget", "packages");


        private IAssemblyReferenceResolver _next;
        private List<(string, Version)> _packages = new List<(string, Version)>();
        private readonly List<FileNugetFolders> _folders;

    }

}
