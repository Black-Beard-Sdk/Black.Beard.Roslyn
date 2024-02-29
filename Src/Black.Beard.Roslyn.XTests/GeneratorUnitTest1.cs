using Bb.Analysis;
using Bb.Analysis.DiagTraces;
using Bb.Builds;
using Bb.Codings;
using Bb.Nugets;
using Bb.Process;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;
using static Refs.System;

namespace Bb.Roslyn.XTests
{
    public class GeneratorUnitTest
    {

        public GeneratorUnitTest()
        {
            this._assemblyFile = new FileInfo(typeof(GeneratorUnitTest).Assembly.Location);
            this._directoryProject = this._assemblyFile.Directory.Parent.Parent.Parent.Parent;
        }

        [Fact]
        public void TestReservedNames()
        {

            var artifact = new CSharpArtifact("test1")
                .Namespace("namespace", ns =>
                {
                    ns.Class("class", cls =>
                    {
                        cls.Property("get", nameof(String), property =>
                        {
                            property.AutoGet().AutoSet();
                        });
                    });
                })
                ;

            var code = artifact.ToString();

            Assert.True(code.Contains("namespace @namespace"));
            Assert.True(code.Contains("class @class"));
            Assert.True(code.Contains("public String @get {"));

        }


        [Fact]
        public void InitializeFrameworks()
        {


            var resolver = new ComponentModel.AssemblyDirectoryResolver();
            var tt2 = resolver.GetSystemDirectories().ToList();
            var lst2 = tt2.Where(c => c.Contains("\\dotnet\\shared\\")).FirstOrDefault();
            var dirSystem = new DirectoryInfo(lst2).Parent.Parent;
            FrameworkVersion.Initialize(dirSystem);

            var version = FrameworkVersion.Resolve("net6.0", ".NETCore.App");
            var references = version.GetReferences();

        }

        [Fact]
        public void BuildConsole()
        {

            bool testSuccess = false;

            string payload = @"

public class Program
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine(""Hello World!"");
    }
}
";
            var builder = new BuildCSharp()
                .SetOutputKind(Microsoft.CodeAnalysis.OutputKind.ConsoleApplication, "Program")
                .AddSource("Program.cs", payload)
                ;

            var result = builder.Build();

            if (result != null && result.Success)
            {

                TaskEventHandler log = (sender, args) =>
                {
                    if (args.Status == TaskEventEnum.DataReceived)
                        if (args.DateReceived?.Data == "Hello World!")
                            testSuccess = true;
                };


                var assemblyToRun = result.PrepareFolderToExecute();

                using (ProcessCommandService service = new LocalProcessCommandService()
                    .Intercept(log)
                    )
                {

                    var cmd = service.RunAndGet(
                        c =>
                        {
                            c.SetWorkingDirectory(assemblyToRun.Directory)
                                  .CommandWithArgumentList("dotnet.exe", assemblyToRun.FullName)
                                  .UseShellExecute(false)
                                  ;
                        }
                        )
                        .Wait()
                        ;

                }

                var list = result.ResolveDependencies(builder.References, true);

                var assembly = result.LoadAssembly();
                var types = assembly.GetExportedTypes();
                //var instance = Activator.CreateInstance(types[0]);
                //Assert.NotNull(instance);
            }
            else
            {
                Assert.Fail();

            }

            Assert.True(testSuccess);

        }


        [Fact]
        public void TestProject()
        {


            var projects = _directoryProject.GetFiles("*.csproj", SearchOption.AllDirectories);


            foreach (var item in projects)
            {

                var builder = item.CreateCsharpBuild(true)
                                  .ResetSdk()
                                  ;

                var result = builder.Build();

                if (result != null && result.Success)
                {

                    var list = result.ResolveDependencies(builder.References, true);

                    //var assembly = result.LoadAssembly();
                    //var types = assembly.GetExportedTypes();
                    //var instance = Activator.CreateInstance(types[0]);
                    //Assert.NotNull(instance);
                }
                else
                {
                    Assert.Fail();

                }
            }

        }


        [Fact]
        public void TestDownload()
        {

            var dir = Path.Combine(Environment.CurrentDirectory, Path.GetRandomFileName());
            var controller = new NugetController().AddFolder(dir, NugetController.HostNugetOrg);

            // new Version("1.0.48")

            var result = controller.Resolve("Black.Beard.Componentmodel");
            if (result == null || result.Any())
            {
                var test = controller.TryToDownload("Black.Beard.Componentmodel", null);
                Assert.True(test);
            }

            result = controller.Resolve("Black.Beard.Componentmodel");
            LocalFileNugetVersion version = result.Last();
            Assert.True(version != null);

            var n = version.Nuspec;
            Assert.True(n != null);

            n.Dependencies("").ToList();

        }


        [Fact]
        public void StartBeforeTest1()
        {

            var left = TextLocation.Create(1);
            var right = TextLocation.Create(10);

            Assert.True(left.StartBefore(right));
            Assert.True(right.StartAfter(left));
            Assert.True(left.StartEndBefore(right));
            Assert.True(left.StopEndBefore(right));
            Assert.True(right.StartEndAfter(left));
            Assert.True(right.StopEndAfter(left));

        }


        [Fact]
        public void StartBeforeTest2()
        {

            var left = TextLocation.Create((1, 1));
            var right = TextLocation.Create(2, 1);

            Assert.True(left.StartBefore(right));
            Assert.True(right.StartAfter(left));
            Assert.True(left.StartEndBefore(right));
            Assert.True(right.StopEndAfter(left));
            Assert.True(left.StartEndBefore(right));
            Assert.True(right.StopEndAfter(left));
        }


        [Fact]
        public void StartBeforeTest3()
        {

            var left = TextLocation.Create(1, new LocationIndex(10));
            var right = TextLocation.Create(2);

            Assert.True(left.StartBefore(right));
            Assert.True(right.StartAfter(left));
            Assert.True(left.StartEndBefore(right));
            Assert.True(right.StopEndAfter(left));
            Assert.True(left.StartEndBefore(right));
            Assert.True(right.StopEndAfter(left));
        }


        [Fact]
        public void StartBeforeTest4()
        {

            var left = TextLocation.Create(1, new LocationIndex(10));
            var right = TextLocation.Create(2, new LocationIndex(10));

            Assert.True(left.StartBefore(right));
            Assert.True(right.StartAfter(left));
            Assert.True(left.StartEndBefore(right));
            Assert.True(right.StopEndAfter(left));
            Assert.True(left.StartEndBefore(right));
            Assert.True(right.StopEndAfter(left));
        }

        private readonly FileInfo _assemblyFile;
        private readonly DirectoryInfo? _directoryProject;

    }

    public class LocalProcessCommandService : ProcessCommandService
    {

        public LocalProcessCommandService()
        {
            Intercept(log);
            this.Datas = new List<string?>();
        }

        public TaskEventEnum Current { get; private set; }
        public List<string?> Datas { get; }

        private void log(object sender, TaskEventArgs args)
        {
            this.Current = args.Status;
            if (args.Status == TaskEventEnum.DataReceived)
                Datas.Add(args.DateReceived?.Data);
        }


    }


}