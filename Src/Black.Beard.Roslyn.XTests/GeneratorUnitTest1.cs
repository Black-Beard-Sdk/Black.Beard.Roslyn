using Bb.Analysis;
using Bb.Analysis.DiagTraces;
using Bb.Builds;
using Bb.Codings;
using Bb.Nugets;
using Bb.Process;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using System.Diagnostics;

namespace Bb.Roslyn.XTests
{

    public class GeneratorUnitTest : IDisposable
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
                    switch (args.Status)
                    {
                        case TaskEventEnum.Started:
                            break;
                        case TaskEventEnum.FailedToStart:
                            break;
                        case TaskEventEnum.ErrorReceived:
                            break;
                        case TaskEventEnum.DataReceived:
                            if (args.DateReceived?.Data == "Hello World!")
                                testSuccess = true; 
                            break;
                        
                        case TaskEventEnum.RanWithException:
                            break;
                        case TaskEventEnum.RanCanceled:
                            break;
                        case TaskEventEnum.FailedToCancel:
                            break;
                        case TaskEventEnum.Releasing:
                            break;
                        case TaskEventEnum.Disposing:
                            break;

                        case TaskEventEnum.Completed:
                        default:
                            break;
                    }

                };


                var path = result.Sdk.Directory;

                var assemblyToRun = result.PrepareFolderToExecute();

                using (ProcessCommandService service = new LocalProcessCommandService().Intercept(log))
                {

                    var cmd = service.RunAndGet(
                        c =>
                        {

                            c.SetWorkingDirectory(path)
                                  .CommandWithArgumentList("dotnet.exe", assemblyToRun.FullName)
                                  .UseShellExecute(false)
                                  ;
                        }
                        )
                        .Wait()
                        ;

                }

                var list = result.ResolveDependencies(builder.References);

            }
            else
                Assert.Fail();
            
            

            Assert.True(testSuccess);

        }

        [Fact]
        public void TestProject()
        {


            var dir = Path.Combine(Environment.CurrentDirectory, Path.GetRandomFileName());
            var controller = new NugetController()
                .AddFolder(dir, NugetController.HostNugetOrg)
                .WithFilter((n, v) =>
                {
                    return true;
                });


            var projects = _directoryProject.GetFiles("*.csproj", SearchOption.AllDirectories);


            foreach (var item in projects)
            {

                var builder = item.CreateCsharpBuild(true)
                    .SetNugetController(controller)
                    .AddReferences(typeof(System.Text.Json.JsonDocument))
                    .AddReferences(typeof(Trace))
                    .ResetSdk()
                    ;

                var result = builder.Build();

                if (result != null && result.Success)
                {

                    var list = result.ResolveDependencies(builder.References);

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

            var sdk = FrameworkVersion.CurrentVersion;

            var dir = Path.Combine(Environment.CurrentDirectory, Path.GetRandomFileName());
            var controller = new NugetController()
                .AddFolder(dir, NugetController.HostNugetOrg)
                .WithFilter((n, v) =>
                {
                    return true;
                });

            var result = controller.Resolve("Black.Beard.Componentmodel");
            if (result == null || result.Any())
            {
                var test = controller.TryToDownload(sdk, "Black.Beard.Componentmodel", null);
                Assert.True(test);
            }

            result = controller.Resolve("Black.Beard.Componentmodel");
            LocalFileNugetVersion version = result.Last();
            Assert.True(version != null);

            var n = version.Metadata;
            Assert.True(n != null);

            n.GroupDependencies("").ToList();

        }

        [Fact]
        public void TestReferencePackage()
        {

            //var names = DiagnosticProviderExtensions.GetActivityNames().ToList();
            //using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            //    //.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("MySample"))
            //    .AddSource(names.Select(c => c.Item2).ToArray())
            //    .Build();


            string payload = @"

public class Program
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine(""Hello World!"");
    }
}
";


            var path = Path.Combine(Environment.CurrentDirectory, Path.GetRandomFileName());
            var dir = Path.Combine(Environment.CurrentDirectory, Path.GetRandomFileName());
            var controller = new NugetController().AddFolder(dir, NugetController.HostNugetOrg);


            // Build assembly
            BuildCSharp builder = new BuildCSharp()
            {
                OutputPath = path,
            }
            .SetNugetController(controller)
            .AddSource("noname", payload)
            //.AddReferences(
            //      typeof(LocationDefault)
            //    , typeof(LocalMethodCompiler)
            //    )
            .AddPackage("Microsoft.CodeAnalysis.CSharp.Workspaces")
            ;

            var build = builder.Build();

        }

        [Fact]
        public void Start_Not_Null_When_ActivityListener_Added_And_ShouldListenTo_Explicitly_Defined_Activity()
        {
            var activitySource = new ActivitySource("ActivitySourceName");
            var activityListener = new ActivityListener
            {
                ShouldListenTo = s => true
            };
            ActivitySource.AddActivityListener(activityListener);

            using var activity = activitySource.StartActivity($"MethodType:/Path");

            //Assert.Is(activity);
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

        public void Dispose()
        {
            //_tracerProvider.Dispose();
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