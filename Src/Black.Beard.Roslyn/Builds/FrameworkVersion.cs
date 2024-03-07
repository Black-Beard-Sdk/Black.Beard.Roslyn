using Bb.Analysis;
using Bb.Util;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using static Refs.Microsoft;

namespace Bb.Builds
{


    /// <summary>
    /// Sdk installed on the system.
    /// </summary>
    [DebuggerDisplay("{Key} : {Type}")]
    public class FrameworkVersion
    {


        private FrameworkVersion()
        {

        }


        public static FrameworkVersion CurrentVersion
        {
            get
            {

                if (_current == null)
                    lock (_lock)
                        if (_current == null)
                        {

                            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                                return SetCurrentWindows();
                            
                            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                                return SetCurrentLinux();
                            
                            else
                                throw new NotImplementedException("Not implemented for this platform");
                        }

                return _current;

            }

        }


        private static FrameworkVersion SetCurrentWindows()
        {

            var _trustedAssembliesPaths = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")).Split(Path.PathSeparator);
            HashSet<string> directories = new HashSet<string>(_trustedAssembliesPaths.Select(c => new FileInfo(c).Directory.FullName));

            string RuntimeDirectory = string.Empty;
            foreach (var toFind in FrameworkType.All())
                foreach (var directory in directories)
                    if (directory.Contains(toFind.WindowDirectory))
                    {
                        _current = new FrameworkVersion().Intialize(new DirectoryInfo(directory), null, null);
                        return _current;
                    }

            return _current;

        }

        private static FrameworkVersion SetCurrentLinux()
        {

            var _trustedAssembliesPaths = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")).Split(Path.PathSeparator);
            HashSet<string> directories = new HashSet<string>(_trustedAssembliesPaths.Select(c => new FileInfo(c).Directory.FullName));

            string RuntimeDirectory = string.Empty;
            foreach (var toFind in FrameworkType.All())
                foreach (var directory in directories)
                    if (directory.Contains(toFind.WindowDirectory))
                    {
                        _current = new FrameworkVersion().Intialize(new DirectoryInfo(directory), null, null);
                        return _current;
                    }

            return _current;

        }

        private FrameworkVersion Intialize(DirectoryInfo directory, string Name, Version version)
        {

            this.Directory = directory;
            this.Compatibilities = new List<string>();

            ResolveType(Name);
            ResolveVersion(version);

            this.Key = FrameworkKey.Resolve(Version);

            this.LanguageVersion = (LanguageVersion)Key.languageVersion;
            if (Key.Version.Major >= 5)
                this.Compatibilities.Add("netstandard2.0");

            return this;

        }

        private void ResolveType(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                var file = this.Directory.GetFiles("*.deps.json", SearchOption.AllDirectories).FirstOrDefault();
                if (file != null)
                    this.Type = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(file.Name));
                else
                    this.Type = this.Directory?.Parent?.Name;
            }
            else
                this.Type = name;
        }

        private void ResolveVersion(Version version)
        {
            if (version != null)
                Version = version;

            else
            {
                var p = Path.Combine(this.Directory.FullName, ".version");
                if (File.Exists(p))
                {
                    var v = File.ReadAllText(p).Split(Environment.NewLine);
                    Version = new Version(v[1]);
                }
                else
                    Version = new Version(this.Directory.Name);
            }
        }


        public FrameworkKey Key { get; private set; }


        /// <summary>
        /// Gets the directory where the libraries can be found.
        /// </summary>
        /// <value>
        /// The directory.
        /// </value>
        public DirectoryInfo Directory { get; private set; }


        public string Name { get; private set; }

        public Version Version { get; private set; }

        /// <summary>
        /// Gets the type of sdk.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public FrameworkType Type { get; private set; }


        public LanguageVersion LanguageVersion { get; set; } = LanguageVersion.CSharp6;


        #region Resolve

        public static FrameworkVersion Resolve(FrameworkKey key, FrameworkType type = null)
        {
            return ResolveVersions(key, type).LastOrDefault();
        }

        /// <summary>
        /// Try to Resolve specified versions in the available version installed on system.
        /// </summary>
        /// <param name="frameworkVersion">The framework version.</param>
        /// <param name="type">The type of sdk.</param>
        /// <returns></returns>
        public static IEnumerable<FrameworkVersion> ResolveVersions(Version frameworkVersion, FrameworkType type = null)
        {

            if (_versions == null)
                InitializeAllFrameworks();

            var major = frameworkVersion.Major;
            var list = _versions.Where(c => c.Key.Version.Major == major).ToList();

            if (type != null)
                list = list.Where(c => c.Type == type).ToList();

            return list;

        }

        /// <summary>
        /// Try to Resolve specified versions in the available version installed on system.
        /// </summary>
        /// <param name="frameworkVersion">The framework version.</param>
        /// <param name="type">The type of sdk.</param>
        /// <returns></returns>
        public static IEnumerable<FrameworkVersion> ResolveVersions(FrameworkKey frameworkVersion, FrameworkType type = null)
        {

            if (_versions == null)
                InitializeAllFrameworks();

            var list = _versions.Where(c => c.Key == frameworkVersion).ToList();

            if (type != null)
                list = list.Where(c => c.Type == type).ToList();

            return list;

        }

        public static IEnumerable<FrameworkVersion> ResolveSdk(FrameworkType type)
        {

            if (_versions == null)
                InitializeAllFrameworks();

            var list = _versions.Where(c => c.Type == type).ToList();

            return list;

        }

        /// <summary>
        /// Gets the framework versions installed on the system.
        /// </summary>
        /// <value>
        /// The framework versions.
        /// </value>
        public static IEnumerable<FrameworkVersion> All => _versions;

        public List<string> Compatibilities { get; private set; }


        #endregion Resolve


        #region Initialize

        /// <summary>
        /// Discover all available framework versions from system directory.
        /// </summary>
        public static void InitializeAllFrameworks()
        {
            lock (_lock)
            {
                var resolver = new ComponentModel.AssemblyDirectoryResolver();
                var tt2 = resolver.GetSystemDirectories().ToList();
                var lst2 = tt2.Where(c => c.Contains("\\dotnet\\shared\\")).FirstOrDefault();
                var dirSystem = new DirectoryInfo(lst2).Parent.Parent;
                Initialize_AllVersions_Impl(dirSystem);
            }
        }

        /// <summary>
        /// Discover all available framework versions from directory.
        /// </summary>
        /// <param name="dir">The dir.</param>
        public static void InitializeAllFrameworks(string dir)
        {
            lock (_lock)
                Initialize_AllVersions_Impl(new DirectoryInfo(dir));
        }

        /// <summary>
        /// Discover all available framework versions from directory.
        /// </summary>
        /// <param name="dir">The dir.</param>
        public static void Initialize(DirectoryInfo dir)
        {
            lock (_lock)
                Initialize_AllVersions_Impl(dir);
        }

        /// <summary>
        /// Discover all available framework versions in the directory.
        /// </summary>
        /// <param name="dir">The dir.</param>
        private static void Initialize_AllVersions_Impl(DirectoryInfo dir)
        {

            var versions = new List<FrameworkVersion>(10);
            var dirs = dir.GetDirectories("*", SearchOption.TopDirectoryOnly);

            foreach (var item in dirs)
            {
                var versionList = item?.GetDirectories("*", SearchOption.TopDirectoryOnly);
                foreach (var directoryVersion in versionList)
                    versions.Add(new FrameworkVersion().Intialize(directoryVersion, null, null));
            }

            _versions = versions.OrderBy(c => c.Key.Version).ToList();

        }

        #endregion Initialize


        /// <summary>
        /// Gets the references of the directory.
        /// </summary>
        /// <returns></returns>
        public FileReferences GetReferences()
        {
            return _references ?? (_references = new FileReferences(this.Directory));
        }




        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        private static void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }

        /// <summary>
        /// return true if the file is located in the sdk directory.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool IsInSdk(FileInfo file)
        {
            return file.Directory.FullName == this.Directory.FullName;
        }
            

        private static FrameworkVersion _current;
        private static object _lock = new object();
        private static List<FrameworkVersion> _versions;
        private FileReferences _references;

    }


}
