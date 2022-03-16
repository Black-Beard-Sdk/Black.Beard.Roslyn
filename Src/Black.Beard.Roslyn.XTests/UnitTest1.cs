using Bb.Builds;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Black.Beard.Roslyn.XTests
{
    public class UnitTest1
    {

        public UnitTest1()
        {
            this._assemblyFile = new FileInfo(typeof(UnitTest1).Assembly.Location);

        }

        [Fact]
        public void Test1()
        {

            var file2 = Path.Combine(_assemblyFile.Directory.FullName, "Class1.cs");

            // Build assembly
            BuildCSharp builder = new BuildCSharp()
            {
                ResolveAssembliesInCode = true,
                Debug = true,
                LanguageVersion = Microsoft.CodeAnalysis.CSharp.LanguageVersion.CSharp7,
            }
            .AddSource(file2);

            var result = builder.Build();

            var assembly = result.LoadAssembly();
            var types= assembly.GetExportedTypes();

            var instance = Activator.CreateInstance(types[0]);

            Assert.NotNull(instance);

        }


        private readonly FileInfo _assemblyFile;

    }
}