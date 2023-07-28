
namespace Bb.Analysis
{


    public class DiagnosticLocation : SpanLocation
    {

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public DiagnosticLocation(string filename, int startIndex, int startLine, int startColumn) : base(new TextLocation(startLine, startColumn, startIndex), TextLocation.Empty)
        {
            this.Filename = filename ?? string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public DiagnosticLocation(string filename) : base(TextLocation.Empty, TextLocation.Empty)
        {
            this.Filename = filename ?? string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public DiagnosticLocation(string filename, TextLocation locationStart) : base(locationStart, TextLocation.Empty)
        {
            this.Filename = filename ?? string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public DiagnosticLocation(string filename, TextLocation locationStart, TextLocation locationEnd) : base(locationStart, TextLocation.Empty)
        {
            this.Filename = filename ?? string.Empty;
        }

        #endregion Ctors

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
            return new DiagnosticLocation(this.Filename, (TextLocation)Start.Clone(), (TextLocation)End.Clone());
            
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
