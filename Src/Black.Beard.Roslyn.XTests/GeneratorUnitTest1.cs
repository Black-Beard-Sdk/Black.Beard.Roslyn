using Bb.Builds;
using Bb.Codings;
using Black.Beard.Roslyn.BuildProjects;
using System;
using System.IO;
using System.Linq;
using Xunit;

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
        public void TestReseverdNames()
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
            Assert.True(code.Contains("public string @get { get; set; }"));

        }


        [Fact]
        public void InitializeFrameworks()
        {


            var resolver = new ComponentModel.AssemblyDirectoryResolver();
            var tt2 = resolver.GetSystemDirectories().ToList();
            var lst2 = tt2.Where(c => c.Contains("\\dotnet\\shared\\")).FirstOrDefault();
            var dirSystem = new DirectoryInfo(lst2).Parent.Parent;
            FrameworkVersion.Initialize(dirSystem);

            var version = FrameworkVersion.Resolve("6.0", "net");
            var references = version.GetReferences();

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

                if (result.Success)
                {

                    var assembly = result.LoadAssembly();
                    var types = assembly.GetExportedTypes();

                    var instance = Activator.CreateInstance(types[0]);

                    Assert.NotNull(instance);
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
            var controller = new NugetController().AddFolder(dir, NugetController.NugetOrgHost);

            // new Version("1.0.48")
            var test = controller.TryToDownload("Black.Beard.Componentmodel", null);

            Assert.True(test);

        }


        //[Fact]
        //public void GetAllReferences()
        //{


        //    var dic = new Dictionary<string, assembly>();

        //    HashSet<string> references = new HashSet<string>();

        //    var p = "C:\\Program Files\\dotnet\\shared\\";
        //    var dir1 = new DirectoryInfo(Path.Combine(p, "Microsoft.NETCore.App"));
        //    var dir2 = new DirectoryInfo(Path.Combine(p, "Microsoft.AspNetCore.App"));
        //    var dir3 = new DirectoryInfo(Path.Combine(p, "Microsoft.WindowsDesktop.App"));
        //    Make(dic, dir1, references);
        //    Make(dic, dir2, references);
        //    Make(dic, dir3, references);

        //    Dictionary<string, tree> keyValuePairs = new Dictionary<string, tree>();
        //    foreach (var item in dic.OrderBy(c => c.Key))
        //    {
        //        var v = item.Value;

        //        var names = v.Path;
        //        if (!keyValuePairs.TryGetValue(names[0], out var tree))
        //        {
        //            tree = new tree(names, 0, v);
        //            keyValuePairs.Add(names[0], tree);
        //        }
        //        else
        //            tree.Add(names, 1, v);

        //    }

        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
        //    foreach (var item in keyValuePairs.OrderBy(c => c.Key))
        //        item.Value.Write(sb, sb2);

        //    "d:\\test2.csv".Save(sb.ToString());

        //}

        //private static void Make(Dictionary<string, assembly> dic, DirectoryInfo dir1, HashSet<string> references)
        //{
        //    foreach (var version in dir1.GetDirectories())
        //    {

        //        var dll = version.GetFiles("*.dll");
        //        var v = new Version(version.Name);
        //        v = new Version(v.Major, v.Minor);

        //        foreach (var item in dll)
        //        {

        //            if (references.Contains(item.Name))
        //                continue;

        //            if (!dic.TryGetValue(item.Name, out var ass))
        //            {

        //                try
        //                {

        //                    PEFile pe = new PEFile(item.FullName);
        //                    //list.Add((dir1.Name, version.Name, pe.Name, item.Name));
        //                    ass = new assembly()
        //                    {
        //                        Filename = item.Name,
        //                        AssemblyName = pe.Name,
        //                        Sdk = dir1.Name,
        //                    };

        //                    foreach (var refe in pe.AssemblyReferences)
        //                        ass.AddReference(refe.Name, refe.Version);

        //                    var ns = new HashSet<string>();
        //                    foreach (var type in pe.Module.TypeDefinitions)
        //                        if (!string.IsNullOrEmpty(type.Namespace))
        //                            ns.Add(type.Namespace);
        //                    ass.Namespaces = ns;


        //                    dic.Add(item.Name, ass);

        //                }
        //                catch (Exception)
        //                {
        //                    references.Add(item.Name);
        //                }


        //            }

        //            if (ass != null)
        //            {
        //                ass.Versions.Add($"{v.Major}.{v.Minor}");
        //            }


        //        }

        //    }
        //}

        private readonly FileInfo _assemblyFile;
        private readonly DirectoryInfo? _directoryProject;

    }

    //public class tree
    //{

    //    public tree(string[] names, int index, assembly ass)
    //    {
    //        _children = new Dictionary<string, tree>();
    //        this.Name = names[index];
    //        Add(names, index + 1, ass);
    //    }

    //    public void Add(string[] names, int index, assembly ass)
    //    {
    //        if (index < names.Length)
    //        {
    //            var n = names[index];
    //            if (!_children.TryGetValue(n, out var tree))
    //            {
    //                tree = new tree(names, index, ass);
    //                _children.Add(n, tree);
    //            }
    //            else
    //            {
    //                tree.Add(names, index + 1, ass);
    //            }

    //        }
    //        else
    //            Assembly = ass;




    //    }

    //    internal void Write(StringBuilder sb, StringBuilder sb2)
    //    {

    //        sb.Append("public class " + this.Name.Replace("-", "_"));

    //        if (this.Assembly != null)
    //            sb.AppendLine(" : ILib");
    //        else
    //            sb.AppendLine("");

    //        sb.AppendLine("{");

    //        if (this.Assembly != null)
    //        {
    //            sb.AppendLine("");
    //            WriteAssembly(sb, sb2);
    //            sb.AppendLine("");

    //        }
    //        sb.AppendLine("");

    //        foreach (var item in _children)
    //            item.Value.Write(sb, sb2);

    //        sb.AppendLine("}");
    //        sb.AppendLine("");

    //    }

    //    private void WriteAssembly(StringBuilder sb, StringBuilder sb2)
    //    {

    //        sb2.AppendLine($"yield return {this.Assembly.AssemblyName.Replace("-", "_")}.Default;");

    //        sb.AppendLine($"public static {this.Name.Replace("-", "_")} Default {{ get; }}  = new {this.Name.Replace("-", "_")}();");
    //        sb.AppendLine($"public string Name  => AssemblyName;");
    //        sb.AppendLine($"public string File => AssemblyFile;");
    //        sb.AppendLine($"public string Sdk {{ get; }} = \"{this.Assembly.Sdk}\";");
    //        sb.AppendLine("");


    //        sb.Append($"public Version[] Versions {{ get; }} = new Version[]");
    //        sb.Append("{");
    //        foreach (var version in this.Assembly.Versions.OrderBy(c => c))
    //            sb.Append($"Libs.Version{version.Replace(".", "")},");

    //        sb.AppendLine("};");


    //        sb.AppendLine("");
    //        sb.Append("public ILib[] References { get; } = new ILib[] {");
    //        foreach (var item in this.Assembly.References)
    //            sb.Append($"{item.Item1.Replace("-", "_")}.Default,");
    //        sb.AppendLine("};");

    //        sb.AppendLine("");
    //        sb.Append("public string[] Namspaces { get; } = new string[] {");
    //        foreach (var item in this.Assembly.Namespaces)
    //            sb.Append($"\"{item}\",");
    //        sb.AppendLine("};");

    //        sb.AppendLine("");
    //        sb.AppendLine($"public static string AssemblyName = \"{this.Assembly.AssemblyName}\";");
    //        sb.AppendLine($"public static string AssemblyFile = \"{this.Assembly.Filename}\";");

    //    }

    //    private Dictionary<string, tree> _children;

    //    public string Name { get; }
    //    public assembly Assembly { get; private set; }
    //}

    //public class assembly
    //{

    //    public assembly()
    //    {
    //        Versions = new HashSet<string>();

    //        References = new List<(string, Version)>();

    //    }

    //    public string Filename { get; internal set; }
    //    public string AssemblyName { get; internal set; }

    //    public string[] Path => AssemblyName.Split('.');


    //    public string Sdk { get; internal set; }
    //    public HashSet<string> Versions { get; }
    //    public List<(string, Version)> References { get; }
    //    public HashSet<string> Namespaces { get; internal set; }

    //    internal void AddReference(string name, Version version)
    //    {
    //        References.Add((name, version));
    //    }


    //}

}