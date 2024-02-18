using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Bb.Builds
{


    /// <summary>
    /// Sdk installed on the system.
    /// </summary>
    [DebuggerDisplay("{Version} : {Type}")]
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

            this.Version = new Version(directory.Name);
            this.Name = GetName(this.Version);
            this.Directory = directory;
            this.Compatibilities = new List<string>();

            
            if (Version.Major >= 5)
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


            switch (Version.Major)
            {
                case 2:
                    LanguageVersion = LanguageVersion.CSharp8;
                    break;

                case 3:
                case 5:
                    LanguageVersion = LanguageVersion.CSharp9;
                    break;

                case 6:
                    LanguageVersion = LanguageVersion.CSharp10;
                    break;

                case 7:
                    LanguageVersion = LanguageVersion.CSharp11;
                    break;

                case 8:
                    LanguageVersion = LanguageVersion.CSharp12;
                    break;

                default:
                    Stop();
                    break;

            }


            return this;

        }


        public static string GetName(Version version)
        {

            switch (version.Major.ToString() + "." + version.Minor.ToString())
            {
                case "2.0":
                    return "netstandard2.0";

                case "2.1":
                    return "netcoreapp2.1";
                case "2.2":
                    return "netcoreapp2.2";
                case "3.0":
                    return "netcoreapp3.0";
                case "3.1":
                    return "netcoreapp3.1";

                case "4.6":
                    return "net4.6" + version.Build.ToString();
                case "4.8":
                    return "net4.8";
                case "5.0":
                    return "net5.0";
                case "6.0":
                    return "net6.0";
                case "7.0":
                    return "net7.0";
                case "8.0":
                    return "net8.0";
                default:
                    Stop();
                    break;
            }

            return null;

        }

        /// <summary>
        /// Gets the version of dotnet.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public Version Version { get; private set; }
        public string Name { get; private set; }


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

        /// <summary>
        /// Try to Resolve specified versions in the available version installed on system
        /// </summary>
        /// <param name="frameworkVersion">The framework version.</param>
        /// <param name="type">The type of sdk.</param>
        /// <returns></returns>
        public static FrameworkVersion Resolve(string frameworkVersion, string type = null)
        {
            return ResolveVersions(new Version(frameworkVersion), type).LastOrDefault();
        }

        /// <summary>
        /// Try to Resolve specified versions in the available version installed on system
        /// </summary>
        /// <param name="frameworkVersion">The framework version.</param>
        /// <param name="type">The type of sdk.</param>
        /// <returns></returns>
        public static FrameworkVersion Resolve(Version frameworkVersion, string type = null)
        {
            return ResolveVersions(frameworkVersion, type).LastOrDefault();
        }

        /// <summary>
        /// Try to Resolve specified versions in the available version installed on system
        /// </summary>
        /// <param name="frameworkVersion">The framework version.</param>
        /// <param name="type">The type of sdk.</param>
        /// <returns></returns>
        public static IEnumerable<FrameworkVersion> ResolveVersions(string frameworkVersion, string type = null)
        {
            return ResolveVersions(new Version(frameworkVersion), type);
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
            var list = _versions.Where(c => c.Version.Major == major).ToList();

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

            _versions = versions.OrderBy(c => c.Version).ToList();

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
