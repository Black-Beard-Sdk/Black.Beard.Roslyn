using Bb.Analysis;
using Bb.Analysis.DiagTraces;
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
            TextLocation loc = new LocationLineAndIndex((1, 1, 1)); //  { Filename = "filename" };
            var txt = loc.ToString();
            Assert.Equal("(Line:1, col:1, index:1)", txt);
        }

        [Fact]
        public void SerializeDiagnosticLocation2()
        {
            var loc = new LocationPath("path");
            var txt = loc.ToString();
            Assert.Equal("path:path", txt);
        }

        [Fact]
        public void SerializeDiagnosticReport1()
        {
            var d = new ScriptDiagnostic(("path".AsLocation(c => c.Filename = "filename" )))
            {
                Text = "text",
                Message = "Message",
            };
            var txt = d.ToString();
            Assert.Equal("[Other] (path:path) in filename 'text' 'Message'", txt);
        }

        [Fact]
        public void SerializeDiagnosticReport2()
        {

            var d = new ScriptDiagnostic((1, 1, 1).AsSpan((LocationIndex)1, c => c.Filename = "filename"))
            {
                Text = "text",
                Message = "Message",
            };
            var txt = d.ToString();
            Assert.Equal("[Other] (Line:1, col:1, index:1 - index:1) in filename 'text' 'Message'", txt);
        }

        [Fact]
        public void SerializeDiagnostics()
        {
            var diag = new ScriptDiagnostics();
            var txt = diag.Error("filename", 1, 1, 1, "text", "message").ToString();
            Assert.Equal("[Error] (Line:1, col:1, index:1) in filename 'text' 'message'", txt);
        }

    }
}