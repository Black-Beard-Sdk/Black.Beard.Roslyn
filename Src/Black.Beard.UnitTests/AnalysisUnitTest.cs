using Bb.Analysis;
using Bb.Process;
using System.Diagnostics;
using System.IO;

namespace Black.Beard.UnitTests
{
    public class AnalysisUnitTest
    {


        [Fact]
        public void SerializeDiagnosticLocation1()
        {
            var loc = new SpanLocation(1, 1, 1) { Filename = "filename" };
            var txt = loc.ToString();
            Assert.Equal("(line:1, col:1, index:1) file:filename", txt);
        }

        [Fact]
        public void SerializeDiagnosticLocation2()
        {
            var loc = new SpanLocation("path") { Filename = "filename" };
            var txt = loc.ToString();
            Assert.Equal("(path:path) file:filename", txt);
        }

        [Fact]
        public void SerializeDiagnosticReport1()
        {
            var d = new Diagnostic(new SpanLocation("path") { Filename = "filename" })
            {
                Text = "text",
                Message = "Message",
            };
            var txt = d.ToString();
            Assert.Equal("[Other] (path:path) file:filename 'text' 'Message'", txt);
        }

        [Fact]
        public void SerializeDiagnosticReport2()
        {
            var d = new Diagnostic(new SpanLocation(1, 1, 1) { Filename = "filename" })
            {
                Text = "text",
                Message = "Message",
            };
            var txt = d.ToString();
            Assert.Equal("[Other] (line:1, col:1, index:1) file:filename 'text' 'Message'", txt);
        }

        [Fact]
        public void SerializeDiagnostics()
        {
            var diag = new Diagnostics();
            var txt = diag.AddError("filename", 1, 1, 1, "text", "message").ToString();
            Assert.Equal("[Error] (line:1, col:1, index:1) file:filename 'text' 'message'", txt);
        }

    }
}