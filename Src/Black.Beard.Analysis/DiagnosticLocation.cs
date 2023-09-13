
namespace Bb.Analysis
{


    public class DiagnosticLocation : SpanLocation
    {

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public DiagnosticLocation(string filename = null) 
            : base()
        {
            this.Filename = filename ?? string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="startLine">The start line.</param>
        /// <param name="startColumn">The start column.</param>
        public DiagnosticLocation(string filename, int startIndex, int startLine, int startColumn)
            : base(new CodePositionLocation(startLine, startColumn, startIndex), CodeLocation.Empty)
        {
            this.Filename = filename ?? string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="path">The path.</param>
        public DiagnosticLocation(string filename, string path) 
            : base(new CodePathLocation(path), CodeLocation.Empty)
        {
            this.Filename = filename ?? string.Empty;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="span">The span.</param>
        public DiagnosticLocation(SpanLocation span) 
            : this(string.Empty, (CodeLocation)span.Start.Clone(), (CodeLocation)span.End.Clone())
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

            var file = this.Filename ?? "unknown file";

            if (this.End != null && !this.End.IsEmpty)
                return $"{file} at {this.Start} to {this.End}";

            if (this.Start != null)
                return $"{file} at {this.Start}";

            return $"{file} at unknown location";

        }

        public override object Clone()
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
