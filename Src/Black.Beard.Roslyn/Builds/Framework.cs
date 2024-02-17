
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bb.Builds
{


    public class Framework
    {

        public Framework()
        {
            this.Versions = new List<FrameworkVersion>();
            Sdk = "Microsoft.NET.Sdk";
        }

        /// <summary>
        /// Gets or sets the SDK.
        /// </summary>
        /// <value>
        /// The SDK.
        /// </value>
        public string Sdk { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public Version Version { get; set; }


        public List<FrameworkVersion> Versions { get; }

        /// <summary>
        /// Resolve the framework to use for build.
        /// </summary>
        /// <returns></returns>
        public FrameworkVersion GetFrameworkVersion()
        {

            if (this.Sdk == null)
                this.Sdk = ".NETCore.App";

            if (this.Versions.Count == 0)
            {
                if (this.Version == null)
                    this.Versions.Add(FrameworkVersion.ResolveSdk(this.Sdk).OrderBy(c => c.Version.Major).Last());
                else
                    this.Versions.Add(FrameworkVersion.ResolveVersions(this.Version, this.Sdk).Last());
            }

            if (this.Versions.Count > 1 && this.Version == null)
                this.Version = this.Versions.OrderBy(c => c.Version)
                                            .Last().Version;
            else if (this.Version == null)
                this.Version = this.Versions.FirstOrDefault().Version;

            var m = this.Version.Major;

            var result = this.Versions
                .Where(c => c.Version.Major == m)
                .OrderBy(c => c.Version)
                .LastOrDefault();

            return result;

        }

        /// <summary>
        /// Gets or sets the language version.
        /// </summary>
        /// <value>
        /// The language version.
        /// </value>
        public LanguageVersion GetLanguageVersion()
        {
            var f = GetFrameworkVersion();
            if (f == null)
                throw new InvalidDataException("Framework not found");
            return f.LanguageVersion;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void Reset()
        {
            this.Versions.Clear();
        }

        public LanguageVersion LanguageVersion { get; set; } = LanguageVersion.CSharp6;
        
        /// <summary>
        /// return true whether has version.
        /// </summary>
        public bool HasVersion => this.Versions.Any();

    }



}
