using Bb.Analysis;
using Bb.Util;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Diagnostics;

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
                            var _trustedAssembliesPaths = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")).Split(Path.PathSeparator);
                            HashSet<string> directories = new HashSet<string>(_trustedAssembliesPaths.Select(c => new FileInfo(c).Directory.FullName));

                            string RuntimeDirectory = string.Empty;
                            foreach (var toFind in DirectoriesToMatchs)
                                foreach (var directory in directories)
                                    if (directory.Contains(toFind))
                                    {
                                        _current = new FrameworkVersion().Intialize(new DirectoryInfo(directory));
                                        return _current;
                                    }
                        }

                return _current;

            }

        }



        private FrameworkVersion Intialize(DirectoryInfo directory)
        {

            var version = new Version(directory.Name);
            //this.Name = GetName(this.Version);

            this.Key = FrameworkKeys.Resolve(version);


            this.Directory = directory;
            this.Compatibilities = new List<string>();


            if (Key.Version.Major >= 5)
                this.Compatibilities.Add("netstandard2.0");


            switch (this.Directory.Parent.Name)
            {

                case "Microsoft.AspNetCore.App":
                    this.Type = ".AspNetCore.App";
                    break;

                case "Microsoft.NETCore.App":
                    this.Type = ".NETCore.App";
                    break;

                case "Microsoft.WindowsDesktop.App":
                    this.Type = ".WindowsDesktop.App";
                    break;

                default:
                    Stop();
                    break;
            }

            this.LanguageVersion = (LanguageVersion)Key.languageVersion;

            return this;

        }

        /// <summary>
        /// Gets the version of dotnet.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        //public Version Version { get; private set; }

        public FrameworkKey Key { get; private set; }


        /// <summary>
        /// Gets the directory where the libraries can be found.
        /// </summary>
        /// <value>
        /// The directory.
        /// </value>
        public DirectoryInfo Directory { get; private set; }

        /// <summary>
        /// Gets the type of sdk.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; private set; }


        public LanguageVersion LanguageVersion { get; set; } = LanguageVersion.CSharp6;


        #region Resolve

        public static FrameworkVersion Resolve(FrameworkKey key, string type = null)
        {
            return ResolveVersions(key, type).LastOrDefault();
        }
                
        /// <summary>
        /// Try to Resolve specified versions in the available version installed on system.
        /// </summary>
        /// <param name="frameworkVersion">The framework version.</param>
        /// <param name="type">The type of sdk.</param>
        /// <returns></returns>
        public static IEnumerable<FrameworkVersion> ResolveVersions(Version frameworkVersion, string type = null)
        {

            if (_versions == null)
                InitializeAllFrameworks();

            var major = frameworkVersion.Major;
            var list = _versions.Where(c => c.Key.Version.Major == major).ToList();

            if (!string.IsNullOrEmpty(type))
                list = list.Where(c => c.Type == type).ToList();

            return list;

        }

        /// <summary>
        /// Try to Resolve specified versions in the available version installed on system.
        /// </summary>
        /// <param name="frameworkVersion">The framework version.</param>
        /// <param name="type">The type of sdk.</param>
        /// <returns></returns>
        public static IEnumerable<FrameworkVersion> ResolveVersions(FrameworkKey frameworkVersion, string type = null)
        {

            if (_versions == null)
                InitializeAllFrameworks();

            var list = _versions.Where(c => c.Key == frameworkVersion).ToList();

            if (!string.IsNullOrEmpty(type))
                list = list.Where(c => c.Type == type).ToList();

            return list;

        }

        public static IEnumerable<FrameworkVersion> ResolveSdk(string type)
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

        public static string ResolveSdkName(string sdk)
        {

            switch (sdk.ToLower())
            {

                case "microsoft.net.sdk":
                    return ".NETCore.App";

                case "microsoft.net.sdk.windowsdesktop":
                    return ".WindowsDesktop.App";

                case "microsoft.net.sdk.web":
                    return ".AspNetCore.App";

                default:
                    Stop();
                    break;

            }

            return ".NETCore.App";

        }

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
                foreach (var version in versionList)
                    versions.Add(new FrameworkVersion().Intialize(version));
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

        private static FrameworkVersion _current;

        public static string[] DirectoriesToMatchs = new string[]
        {
            "Microsoft.NETCore.App",
            "Microsoft.AspNetCore.App",
            "Microsoft.WindowsDesktop.App",
        };

        private static object _lock = new object();
        private static List<FrameworkVersion> _versions;
        private FileReferences _references;

    }

  
}
