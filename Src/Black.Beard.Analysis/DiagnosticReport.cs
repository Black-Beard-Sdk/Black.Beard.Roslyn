namespace Bb.Analysis
{


    [System.Diagnostics.DebuggerDisplay("[{Severity}] {Message}")]
    public class DiagnosticReport
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticReport"/> class.
        /// </summary>
        /// <param name="locations">The locations.</param>
        public DiagnosticReport(params DiagnosticLocation[] locations) : this()
        {
            Locations.AddRange(locations);
        }

        public DiagnosticReport()
        {
            Locations = new List<DiagnosticLocation>();
        }

        //public string Filename { get; set; }

        //public int StartIndex { get; set; }

        //public int StartColumn { get; set; }

        //public int StartLine { get; set; }


        public List<DiagnosticLocation> Locations { get; set; }


        public string Text { get; set; }

        public string Message { get; set; }

        public string Severity { get; set; }

        public int SeverityLevel { get; set; }

        public bool IsSeverityAsError { get;  set; }

        public string Id { get;  set; }


        // public string Location => $"({StartLine}, {StartColumn})";

        public override string ToString()
        {
            return Message.ToString();
        }

    }


}
