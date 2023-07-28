
namespace Bb.Analysis
{
    [System.Diagnostics.DebuggerDisplay("{StartIndex}, {StopIndex} : ({Line},{Column})")]
    public class TokenLocation : ICloneable
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenLocation"/> class.
        /// </summary>
        public TokenLocation()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenLocation"/> class.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public TokenLocation(int start, int end)
        {
            this.StartIndex = start;
            this.StopIndex = end;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenLocation"/> class.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="line">The line.</param>
        /// <param name="column">The column.</param>
        public TokenLocation(int start, int end, int line, int column)
        {
            this.StartIndex = start;
            this.StopIndex = end;
            this.Line = line;
            this.Column = column;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenLocation"/> class.
        /// </summary>
        /// <param name="location">The location.<see cref="T:DiagnosticLocation"/> </param>
        public TokenLocation(DiagnosticLocation location)
        {
            this.Line = location.StartLine;
            this.Column = location.StartColumn;
            this.StartIndex = location.StartIndex;
            this.StopIndex = location.EndIndex;
        }

        /// <summary>
        /// Gets or sets the line.
        /// </summary>
        /// <value>
        /// The line.
        /// </value>
        public int Line { get; set; }

        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        /// <value>
        /// The column.
        /// </value>
        public int Column { get; set; }

        /// <summary>
        /// Gets or sets the start index.
        /// </summary>
        /// <value>
        /// The start index.
        /// </value>
        public int StartIndex { get; set; }

        /// <summary>
        /// Gets or sets the index of the stop.
        /// </summary>
        /// <value>
        /// The index of the stop.
        /// </value>
        public int StopIndex { get; set; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return new TokenLocation(this.StartIndex, this.StopIndex, this.Line, this.Column) { };
        }

    }


}
