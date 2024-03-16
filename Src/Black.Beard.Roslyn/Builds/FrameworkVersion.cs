using Bb.Analysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Diagnostics;
using System.Runtime.InteropServices;

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
            _directories = new List<DirectoryInfo>();
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
                                SetCurrentWindows();

                            if (_current == null)
                                SetFromGlobal();

                            if (_current == null)
                                SetFromCurrentFolder();

                            if (_current == null)
                                throw new NotImplementedException("Not implemented for this platform");

                            if (FrameworkVersion._versions == null)
                                InitializeAllFrameworks();

                            if (FrameworkVersion._versions != null)
                            {

                                var uu = FrameworkVersion._versions.Where(c => c.Key == _current.Key
                                                                            && c.Type == _current.Type
                                                                            && c.Version == _current.Version
                                                                         ).FirstOrDefault();

                                if (uu != null)
                                    _current = uu;

                            }

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
                        _current = new FrameworkVersion()
                            .Intialize(new DirectoryInfo(directory), null, null);
                        return _current;
                    }

            return _current;

        }

        private static void SetFromGlobal()
        {

            var _trustedAssembliesPaths = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")).Split(Path.PathSeparator);
            HashSet<string> directories = new HashSet<string>(_trustedAssembliesPaths.Select(c => new FileInfo(c).Directory.FullName));

            string RuntimeDirectory = string.Empty;
            foreach (var toFind in FrameworkType.All())
                foreach (var directory in directories)
                    if (directory.Contains(toFind.WindowDirectory))
                    {
                        _current = new FrameworkVersion().Intialize(new DirectoryInfo(directory), null, null);
                        return;
                    }

        }

        private static void SetFromCurrentFolder()
        {


            var currentType = FrameworkType.Current;
            var currentKey = FrameworkKey.Current;


            //var loc = GetLocations();
            var _trustedAssembliesPaths = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")).Split(Path.PathSeparator);
            HashSet<string> directories = new HashSet<string>(_trustedAssembliesPaths.Select(c => new FileInfo(c).Directory.FullName));

            string RuntimeDirectory = string.Empty;
            foreach (var directory in directories)
            {
                var t = new FrameworkVersion().Intialize(new DirectoryInfo(directory), currentType.Name, currentKey.Version);
                if (t.CorreclyIdentified)
                {
                    _current = t;
                    return;
                }
            }

        }


        #region Resolve current key


        private FrameworkVersion Intialize(DirectoryInfo directory, string Name, Version version)
        {

            this._directories.Add(directory);

            ResolveType(Name);
            ResolveVersion(version);

            if (Version != null)
            {
                this.Key = FrameworkKey.Resolve(Version);
                this.LanguageVersion = (LanguageVersion)Key.languageVersion;
                this.CorreclyIdentified = (Type != null && Type != FrameworkType.Unknown) && Key != null;
            }

            return this;

        }

        private void ResolveType(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                var file = this.Directory.GetFiles("Microsoft.*.deps.json", SearchOption.AllDirectories).FirstOrDefault();
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

            var p = this.Directory.Combine(".version");
            this._fileVersionExists = File.Exists(p);

            if (version != null)
                Version = version;

            else
            {

                if (this._fileVersionExists)
                {
                    var v = File.ReadAllText(p).Split(Environment.NewLine);
                    Version = new Version(v[1]);
                }
                else
                {

                    var t = FrameworkKey.GetVersion(this.Directory, this.Directory.Parent.Name);
                    if (t != null && t != FrameworkKey.Unknown)
                        Version = t.Version;

                    //else
                    //{
                    //    Stop();
                    //}

                }

            }
        }


        public FrameworkKey Key { get; private set; }


        /// <summary>
        /// Gets the directory where the libraries can be found.
        /// </summary>
        /// <value>
        /// The directory.
        /// </value>
        public DirectoryInfo Directory => _directories.FirstOrDefault();

        public IEnumerable<DirectoryInfo> Directories { get; private set; }

        private List<DirectoryInfo> _directories;


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

        /// <summary>
        /// Gets the base framework.
        /// </summary>
        public FrameworkVersion Base { get; private set; }

        public bool CorreclyIdentified { get; private set; }


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
                {
                    var version = new FrameworkVersion().Intialize(directoryVersion, null, null);
                    if (version._fileVersionExists)
                        versions.Add(version);
                }
            }

            // for aspnet and windows resolve the base framework
            var l = versions.Where(c => c.Type != FrameworkType.NETCore).ToList();
            foreach (var item in l)
                if (item.Type.BaseType != null)
                {
                    var l2 = versions.Where(c =>
                        c.Key == item.Key
                        && c.Type == FrameworkType.NETCore
                        && c.Version == item.Version
                    ).FirstOrDefault();

                    if (l2 != null)
                        item.Base = l2;

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
            return _references ?? (_references = new FileReferences(this.Directories));
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

        internal bool Accept(FrameworkKey framework)
        {

            if (framework == null)
                return false;

            return this.Key.Accept(framework);

        }

        private static FrameworkVersion _current;
        private static object _lock = new object();
        private static List<FrameworkVersion> _versions;
        private FileReferences _references;
        private bool _fileVersionExists;
    }


}
