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

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticReport"/> class.
        /// </summary>
        public DiagnosticReport()
        {
            Locations = new List<DiagnosticLocation>();
        }

        /// <summary>
        /// Gets the filename of the first Diagnostic location
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        public string? Filename => Location?.Filename;

        /// <summary>
        /// Gets the start index of the first Diagnostic location
        /// </summary>
        /// <value>
        /// The start index.
        /// </value>
        public int? StartIndex => Location?.StartIndex;

        /// <summary>
        /// Gets the start column of the first Diagnostic location
        /// </summary>
        /// <value>
        /// The start column.
        /// </value>
        public int? StartColumn => Location?.StartColumn;

        /// <summary>
        /// Gets the start line of the first Diagnostic location
        /// </summary>
        /// <value>
        /// The start line.
        /// </value>
        public int? StartLine => Location?.StartLine;

        /// <summary>
        /// Gets the first location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public DiagnosticLocation? Location => Locations[0];

        /// <summary>
        /// Gets or sets the locations items.
        /// </summary>
        /// <value>
        /// The locations.
        /// </value>
        public List<DiagnosticLocation> Locations { get; set; }

        /// <summary>
        /// Gets or sets the text that causes the diagnostic item
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the message that explain the diagnostic
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the severity Name.
        /// </summary>
        /// <value>
        /// The severity.
        /// </value>
        public string Severity { get; set; }

        /// <summary>
        /// Gets or sets the severity level.
        /// </summary>
        /// <value>
        /// The severity level.
        /// </value>
        public int SeverityLevel { get; set; }

        /// <summary>
        /// Sets the severity.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <returns></returns>
        public DiagnosticReport SetSeverity(SeverityEnum severity)
        {
            this.Severity = severity.ToString();
            this.SeverityLevel = (int)severity;
            IsSeverityAsError = severity == SeverityEnum.Error;
            return this;
        }
        /// <summary>
        /// Gets the severity in <see cref="T:SeverityEnum"/>.
        /// </summary>
        /// <returns></returns>
        public SeverityEnum GetSeverity()
        {
            
            if (Enum.TryParse<SeverityEnum>(this.Severity, out var s))
                return s;
            
            return  SeverityEnum.Other;

        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is severity as error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is severity as error; otherwise, <c>false</c>.
        /// </value>
        public bool IsSeverityAsError { get; set; }

        public string Id { get;  set; }


        // public string Location => $"({StartLine}, {StartColumn})";

        public override string ToString()
        {
            return Message.ToString();
        }

    }


}
