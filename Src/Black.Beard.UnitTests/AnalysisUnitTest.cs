using Bb.Analysis;
using Bb.Process;
using System.Diagnostics;

namespace Black.Beard.UnitTests
{
    public class AnalysisUnitTest
    {


        [Fact]
        public void SerializeDiagnosticLocation1()
        {
            var loc = new DiagnosticLocation("filename", 1, 1, 1);
            var txt = loc.ToString();
            Assert.Equal("filename at (line 1, column 1)", txt);
        }

        [Fact]
        public void SerializeDiagnosticLocation2()
        {
            var loc = new DiagnosticLocation("filename", "path");
            var txt = loc.ToString();
            Assert.Equal("filename at (path path)", txt);
        }

        [Fact]
        public void SerializeDiagnosticReport1()
        {
            var d = new DiagnosticReport(new DiagnosticLocation("filename", "path"))
            {
                Text = "text",
                Message = "Message",
            };
            var txt = d.ToString();
            Assert.Equal("[Other] filename at (path path) 'text' 'Message'", txt);
        }

        [Fact]
        public void SerializeDiagnosticReport2()
        {
            var d = new DiagnosticReport(new DiagnosticLocation("filename", 1, 1, 1))
            {
                Text = "text",
                Message = "Message",
            };
            var txt = d.ToString();
            Assert.Equal("[Other] filename at (line 1, column 1) 'text' 'Message'", txt);
        }

        [Fact]
        public void SerializeDiagnostics()
        {
            var diag = new Diagnostics();
            var txt = diag.AddError("filename", 1, 1, 1, "text", "message").ToString();
            Assert.Equal("[Error] filename at (line 1, column 1) 'text' 'message'", txt);
        }

    }
}