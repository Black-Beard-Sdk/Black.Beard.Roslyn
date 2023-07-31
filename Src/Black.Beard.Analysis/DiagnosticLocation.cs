
namespace Bb.Analysis
{


    public class DiagnosticLocation : SpanLocation
    {

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public DiagnosticLocation(string filename, int startIndex, int startLine, int startColumn) : base(new CodeLocation(startLine, startColumn, startIndex), CodeLocation.Empty)
        {
            this.Filename = filename ?? string.Empty;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="span">The span.</param>
        public DiagnosticLocation(SpanLocation span) : this(string.Empty, (CodeLocation)span.Start.Clone(), (CodeLocation)span.End.Clone())
        {
            
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="diag">The span.</param>
        public DiagnosticLocation(DiagnosticLocation diag) : this(diag.Filename, (CodeLocation)diag.Start.Clone(), (CodeLocation)diag.End.Clone())
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public DiagnosticLocation(string filename) : base(CodeLocation.Empty, CodeLocation.Empty)
        {
            this.Filename = filename ?? string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public DiagnosticLocation(string filename, CodeLocation locationStart) : base(locationStart, CodeLocation.Empty)
        {
            this.Filename = filename ?? string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public DiagnosticLocation(string filename, CodeLocation locationStart, CodeLocation locationEnd) : base(locationStart, CodeLocation.Empty)
        {
            this.Filename = filename ?? string.Empty;
        }

        #endregion Ctors

        public static DiagnosticLocation Empty = new DiagnosticLocation(string.Empty);

        /// <summary>
        /// Gets or sets the filename of the diagnostic.
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        public string Filename { get; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var file = this.Filename ?? string.Empty;

            if (this.End.IsEmpty)
                return $"{file} at (line {this.Start.Line}, column {this.Start.Column}) to (line {this.End.Line}, column {this.End.Column})";

            return $"{file} at (line {this.Start.Line}, column {this.Start.Column})";


        }

        public object Clone()
        {
            return new DiagnosticLocation(this.Filename, (CodeLocation)Start.Clone(), (CodeLocation)End.Clone());

        }

    }

    public enum SeverityEnum
    {
        Verbose = -1,
        Information = 0,
        Warning = 1,
        Error = 2,
        Other = 3
    }


}
