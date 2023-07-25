using Bb.Builds;
using Bb.Codings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;

namespace Bb.Beard.Roslyn.XTests
{
    public class GeneratorUnitTest
    {

        public GeneratorUnitTest()
        {

            this._assemblyFile = new FileInfo(typeof(GeneratorUnitTest).Assembly.Location);

        }

        [Fact]
        public void TestReseverdNames()
        {

            var artifact = new CSharpArtifact("test1")
                .Namespace("namespace", ns =>
                {
                    ns.Class("class", cls =>
                    {
                        cls.Property("get", "string", property =>
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


        private readonly FileInfo _assemblyFile;

    }
}