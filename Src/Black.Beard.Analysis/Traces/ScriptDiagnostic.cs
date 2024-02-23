using System.Text;

namespace Bb.Analysis.Traces
{


    [System.Diagnostics.DebuggerDisplay("[{Severity}] {Message}")]
    public class ScriptDiagnostic
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptDiagnostic"/> class.
        /// </summary>
        /// <param name="locations">The list of locations.</param>
        public ScriptDiagnostic(params TextLocation[] locations) : this()
        {
            if (locations != null && locations.Length > 0)
                Locations.AddRange(locations);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptDiagnostic"/> class.
        /// </summary>
        public ScriptDiagnostic()
        {

            Id = Guid.NewGuid().ToString("N");

            SetSeverity(SeverityEnum.Other);

            Message = string.Empty;
            Text = string.Empty;

            Locations = new List<TextLocation>();

        }

        /// <summary>
        /// Gets the filename of the first Diagnostic location
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        public string? Filename => Location?.Filename ?? string.Empty;

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
        public ScriptDiagnostic SetSeverity(SeverityEnum severity)
        {
            Severity = severity.ToString();
            SeverityLevel = (int)severity;
            IsSeverityAsError = severity == SeverityEnum.Error;
            return this;
        }
        /// <summary>
        /// Gets the severity in <see cref="T:SeverityEnum"/>.
        /// </summary>
        /// <returns></returns>
        public SeverityEnum GetSeverity()
        {

            if (Enum.TryParse<SeverityEnum>(Severity, out var s))
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

        public List<TextLocation> Locations { get; }

        public TextLocation Location => Locations.Count > 0 ? Locations[0] : TextLocation.Empty;

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder(Message.Length * 2);
            sb.Append("[");
            sb.Append(Severity);
            sb.Append("] ");

            bool t = false;
            foreach (TextLocation location in Locations)
            {

                if (t)
                    sb.Append(", ");

                location.WriteTo(sb);
                sb.Append(" ");
                t = true;

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
