using Bb.Builds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;

namespace Bb.Beard.Roslyn.XTests
{
    public class BuildUnitTest1
    {

        public BuildUnitTest1()
        {
            this._assemblyFile = new FileInfo(typeof(BuildUnitTest1).Assembly.Location);

        }

        [Fact]
        public void Build1()
        {

            var file2 = Path.Combine(_assemblyFile.Directory.FullName, "Class1.cs");

            // Build assembly
            BuildCSharp builder = new BuildCSharp()
            {
                ResolveAssembliesInCode = true,
                Debug = true,
                LanguageVersion = Microsoft.CodeAnalysis.CSharp.LanguageVersion.CSharp7,
            }
            .AddSource(file2)
            .Suppress("CS1702", "CS1998")
            ;

            var result = builder.Build();

            var assembly = result.LoadAssembly();
            var types= assembly.GetExportedTypes();

            var instance = Activator.CreateInstance(types[0]);

            Assert.NotNull(instance);

        }


        private readonly FileInfo _assemblyFile;

    }
}