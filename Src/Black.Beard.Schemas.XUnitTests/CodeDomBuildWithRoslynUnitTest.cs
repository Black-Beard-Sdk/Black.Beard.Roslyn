using Bb;
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

    public class CodeDomBuildWithRoslynUnitTest
    {

        public CodeDomBuildWithRoslynUnitTest()
        {
            var ass = System.Reflection.Assembly.GetExecutingAssembly();
            this._dir = new System.IO.FileInfo(ass.Location).Directory;
        }


        [Fact]
        public void TestSample1()
        {

            JsonSchema schema = JsonSchema.FromType(typeof(Sample1));

            var samples = "CodeDOMSample".ToNamespace()
                    .Import("System")
                    .AppendPoco(schema)

                    .ToCSharp(Path.Combine(_dir.FullName, "class1.cs"))
                ;


            AssemblyResult assembly = GetCsharpBuilder(samples.FullName);

            if (assembly.Success)
            {
                var ass = assembly.LoadAssembly();
                var type = ass.GetTypes().First(c => c.Name == "Sample1");
                Assert.NotNull(type);

                var property = type.GetProperties().FirstOrDefault(c => nameof(Sample1.Name) == c.Name);
                Assert.NotNull(property);

            }
            else
            {
                var payload = File.ReadAllText(samples.FullName);
                throw new Exception();
            }
        }

        [Fact]
        public void TestSample2()
        {

            JsonSchema schema = JsonSchema.FromType(typeof(Sample2));

            var payload = schema.ToJson();

            var samples = "CodeDOMSample".ToNamespace()
                    .Import("System")
                    .AppendPoco(schema)
                    .ToCSharp(Path.Combine(_dir.FullName, "class2.cs"))
                ;

            AssemblyResult assembly = GetCsharpBuilder(samples.FullName);

            if (assembly.Success)
            {
                var ass = assembly.LoadAssembly();
                var type = ass.GetTypes().First(c => c.Name == "Sample2");
                Assert.NotNull(type);

                var property = type.GetProperties().FirstOrDefault(c => nameof(Sample2.Name) == c.Name);
                Assert.NotNull(property);

            }
            else
            {
                //var payload = File.ReadAllText(samples.FullName);
                throw new Exception();
            }
        }

        [Fact]
        public void TestSample3()
        {

            JsonSchema schema = JsonSchema.FromType(typeof(Sample3));

            var payload = schema.ToJson();

            var samples = "CodeDOMSample".ToNamespace()
                    .Import("System")
                    .AppendPoco(schema)
                    .ToCSharp(Path.Combine(_dir.FullName, "class3.cs"))
                ;

            var payloadCode = File.ReadAllText(samples.FullName);

            AssemblyResult assembly = GetCsharpBuilder(samples.FullName);

            if (assembly.Success)
            {
                var ass = assembly.LoadAssembly();
                var type = ass.GetTypes().First(c => c.Name == "Sample3");
                Assert.NotNull(type);

                var property1 = type.GetProperties().FirstOrDefault(c => nameof(Sample3.ValueEnum) == c.Name);
                Assert.NotNull(property1);

                var property2 = type.GetProperties().FirstOrDefault(c => nameof(Sample3.ValueInt) == c.Name);
                Assert.NotNull(property2);

            }
            else
            {
                throw new Exception();
            }
        }

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




        //var template = GetProvider(new JObject().ToString(Newtonsoft.Json.Formatting.Indented));
        //var ctx = template.GetContext(null);
        //ctx.TokenResult = new JObject();
        //Bb.Jslt.Output.StoreSql.Outputs.ExecuteToSqlServer(ctx, "cnx");

        private static Bb.Compilers.AssemblyResult GetCsharpBuilder(string filepathCode)
        {

            var fileInfo = new FileInfo(filepathCode);

            // Build assembly

            Action<CSharpCompilationOptions> action = (r) =>
            {

            };

            BuildCSharp builder = new BuildCSharp()
            {
                ResolveAssembliesInCode = true,
                Debug = true,
                LanguageVersion = LanguageVersion.CSharp7,
            }
            .AddSource(fileInfo)
            .Suppress("CS1702", "CS1998")
            ;

            // System.Collections
            builder.References.AddRange(
                typeof(object),
                typeof(RequiredAttribute)
            );

            var assembly = builder.Build();
            return assembly;

        }        

        private readonly System.IO.DirectoryInfo? _dir;

    }



}