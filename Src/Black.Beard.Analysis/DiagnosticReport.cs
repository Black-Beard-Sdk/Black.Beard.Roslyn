using System.Text;

namespace Bb.Analysis
{


    [System.Diagnostics.DebuggerDisplay("[{Severity}] {Message}")]
    public class DiagnosticReport
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticReport"/> class.
        /// </summary>
        /// <param name="locations">The list of locations.</param>
        public DiagnosticReport(params SpanLocation[] locations) : this()
        {
            if (locations.Length > 0)
                this.Locations.AddRange(locations);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticReport"/> class.
        /// </summary>
        public DiagnosticReport()
        {

            Id = Guid.NewGuid().ToString("N");

            SetSeverity(SeverityEnum.Other);

            Message = string.Empty;
            Text = string.Empty;

            Locations = new List<SpanLocation>();

        }

        /// <summary>
        /// Gets the filename of the first Diagnostic location
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        public string? Filename => (Location as DiagnosticLocation)?.Filename ?? string.Empty;

        /// <summary>
        /// Gets the start index of the first Diagnostic location
        /// </summary>
        /// <value>
        /// The start index.
        /// </value>
        public int? StartIndex => (Location?.Start as CodePositionLocation)?.Index;

        /// <summary>
        /// Gets the start column of the first Diagnostic location
        /// </summary>
        /// <value>
        /// The start column.
        /// </value>
        public int? StartColumn => (Location?.Start as CodePositionLocation)?.Column;

        /// <summary>
        /// Gets the start line of the first Diagnostic location
        /// </summary>
        /// <value>
        /// The start line.
        /// </value>
        public int? StartLine => (Location?.Start as CodePositionLocation)?.Line;

        /// <summary>
        /// Gets the path
        /// </summary>
        /// <value>
        /// The path location.
        /// </value>
        public string Path => (Location?.Start as CodePathLocation)?.Path ?? string.Empty;

        /// <summary>
        /// Gets or sets the locations items.
        /// </summary>
        /// <value>
        /// The locations.
        /// </value>
        // public List<DiagnosticLocation> Locations { get; set; }

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
        public string? Severity { get; set; }

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

            return SeverityEnum.Other;

        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is severity as error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is severity as error; otherwise, <c>false</c>.
        /// </value>
        public bool IsSeverityAsError { get; set; }

        public string Id { get; set; }

        public List<SpanLocation> Locations { get; }

        public SpanLocation Location => Locations.Count > 0 ? Locations[0] : SpanLocation.Empty;


        // public string Location => $"({StartLine}, {StartColumn})";

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder(Message.Length * 2);
            sb.Append("[");
            sb.Append(Severity);
            sb.Append("] ");

            if (!this.Location.IsEmpty)
                foreach (SpanLocation location in Locations)
                {
                    sb.Append(location.ToString());
                    sb.Append(" ");
                }

            sb.Append("'");
            sb.Append(Text);
            sb.Append("'");

            sb.Append(" '");
            sb.Append(Message);
            sb.Append("'");

            return sb.ToString();
        }

    }


}
