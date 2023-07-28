
namespace Bb.Analysis
{

    public class DiagnosticLocation
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        public DiagnosticLocation()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public DiagnosticLocation(string filename)
        {
            this.Filename = filename;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="startline">The startline.</param>
        /// <param name="startColumn">The start column.</param>
        public DiagnosticLocation(string filename, int startIndex, int startline = -1, int startColumn = -1) : this(filename)
        {
            this.StartIndex = startIndex;
            this.StartLine = startline;
            this.StartColumn = startColumn;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="location">The location.</param>
        public DiagnosticLocation(string filename, TokenLocation location) : this(filename)
        {
            Filename = filename;
            StartLine = location.Line;
            StartIndex = location.StartIndex;
            StartColumn = location.Column;
        }

        /// <summary>
        /// Gets or sets the filename of the diagnostic.
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the start index.
        /// </summary>
        /// <value>
        /// The start index.
        /// </value>
        public int StartIndex { get; set; }

        /// <summary>
        /// Gets or sets the start column.
        /// </summary>
        /// <value>
        /// The start column.
        /// </value>
        public int StartColumn { get; set; }

        /// <summary>
        /// Gets or sets the start line.
        /// </summary>
        /// <value>
        /// The start line.
        /// </value>
        public int StartLine { get; set; }


        /// <summary>
        /// Gets or sets the end index.
        /// </summary>
        /// <value>
        /// The end index.
        /// </value>
        public int EndIndex { get; set; }

        /// <summary>
        /// Gets or sets the end column.
        /// </summary>
        /// <value>
        /// The end column.
        /// </value>
        public int EndColumn { get; set; }

        /// <summary>
        /// Gets or sets the end line.
        /// </summary>
        /// <value>
        /// The end line.
        /// </value>
        public int EndLine { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var file = this.Filename ?? string.Empty;
            return $"{file} from (line {this.StartLine}, column {this.StartColumn}) to (line {this.EndLine}, column {this.EndColumn})";
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
