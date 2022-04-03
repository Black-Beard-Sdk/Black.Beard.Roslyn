using Bb;
using Bb.Build;
using Bb.Builds;
using Bb.Compilers;
using Microsoft.CodeAnalysis.CSharp;
using NJsonSchema;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;


namespace Black.Beard.Jslt.Output.StoreSql.XUnitTests
{

    public class CodeDomBuildWithMsMbuildUnitTest
    {

        public CodeDomBuildWithMsMbuildUnitTest()
        {
            var ass = System.Reflection.Assembly.GetExecutingAssembly();
            this._dir = new System.IO.FileInfo(ass.Location).Directory;
        }


        [Fact]
        public void TestSample1()
        {

            MsCsProject project = GetProject();

            JsonSchema schema = JsonSchema.FromType(typeof(Sample1));
            var samples = "CodeDOMSample"
                            .ToNamespace()
                            .Import("System")
                            .AppendPoco(schema)
                            .ToCSharp(Path.Combine(project.Directory.FullName, "class1.cs"))
                            ;

            var result = project.Build();

            Assert.True(result);
          
        }

        private MsCsProject GetProject()
        {

            string name = GetAssemblyName();
            var dir = new DirectoryInfo(Path.Combine(this._dir.FullName, name));

            var project = new MsCsProject(name, dir)

                .Sdk(ProjectSdk.MicrosoftNETSdk)

                .SetPropertyGroup(c =>
                {
                    c.TargetFramework(TargetFramework.Net6)
                    .ImplicitUsings(true)
                    
                    .RootNamespace("Bb")
                    .Description("My description")
                    .RepositoryUrl(new System.Uri("http://github.com"))
                    ;
                })

                ;

            return project;
        }

        private static string GetAssemblyName()
        {
            var p = Guid.NewGuid().ToString("N").Substring(7);
            var name = "Black.Beard._" + p;
            return name;
        }

        //[Fact]
        //public void TestSample2()
        //{

        //    JsonSchema schema = JsonSchema.FromType(typeof(Sample2));

        //    var payload = schema.ToJson();

        //    var samples = "CodeDOMSample".ToNamespace()
        //            .Import("System")
        //            .AppendPoco(schema)
        //            .ToCSharp(Path.Combine(_dir.FullName, "class2.cs"))
        //        ;

        //    AssemblyResult assembly = GetCsharpBuilder(samples.FullName);

        //    if (assembly.Success)
        //    {
        //        var ass = assembly.LoadAssembly();
        //        var type = ass.GetTypes().First(c => c.Name == "Sample2");
        //        Assert.NotNull(type);

        //        var property = type.GetProperties().FirstOrDefault(c => nameof(Sample2.Name) == c.Name);
        //        Assert.NotNull(property);

        //    }
        //    else
        //    {
        //        //var payload = File.ReadAllText(samples.FullName);
        //        throw new Exception();
        //    }
        //}

        //[Fact]
        //public void TestSample3()
        //{

        //    JsonSchema schema = JsonSchema.FromType(typeof(Sample3));

        //    var payload = schema.ToJson();

        //    var samples = "CodeDOMSample".ToNamespace()
        //            .Import("System")
        //            .AppendPoco(schema)
        //            .ToCSharp(Path.Combine(_dir.FullName, "class3.cs"))
        //        ;

        //    var payloadCode = File.ReadAllText(samples.FullName);

        //    AssemblyResult assembly = GetCsharpBuilder(samples.FullName);

        //    if (assembly.Success)
        //    {
        //        var ass = assembly.LoadAssembly();
        //        var type = ass.GetTypes().First(c => c.Name == "Sample3");
        //        Assert.NotNull(type);

        //        var property1 = type.GetProperties().FirstOrDefault(c => nameof(Sample3.ValueEnum) == c.Name);
        //        Assert.NotNull(property1);

        //        var property2 = type.GetProperties().FirstOrDefault(c => nameof(Sample3.ValueInt) == c.Name);
        //        Assert.NotNull(property2);

        //    }
        //    else
        //    {
        //        throw new Exception();
        //    }
        //}

        public class Sample1
        {

            [Required]
            public string Name { get; set; }

        }

        public class Sample2 : Sample1
        {


        }

        public class Sample3
        {

            public int ValueInt { get; set; }

            public Enum1 ValueEnum { get; set; }

        }

        public enum Enum1
        {
            Item1,
            Item2,
        }




        private readonly System.IO.DirectoryInfo? _dir;

    }



}