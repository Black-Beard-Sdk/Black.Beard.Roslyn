
namespace Bb.Analysis
{
    public class CodePositionLocation : CodeLocation
    {

        /// <summary>
        /// The empty value
        /// </summary>
        public static new readonly CodeLocation Empty = new CodePositionLocation(-1, -1);

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeLocation"/> struct.
        /// </summary>
        /// <param name="position">The position.</param>
        public CodePositionLocation((int, int) position, int index = -1)
        {
            Line = position.Item1;
            Column = position.Item2;
            this.Index = index;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeLocation"/> struct.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="column">The column.</param>
        public CodePositionLocation(int line, int column, int index = -1)
        {
            Line = line;
            Column = column;
            this.Index = index;
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Index { get; }

        /// <summary>
        /// Gets or sets the end line.
        /// </summary>
        /// <value>
        /// The end line.
        /// </value>
        public int Line { get; }

        /// <summary>
        /// Gets or sets the end column.
        /// </summary>
        /// <value>
        /// The end column.
        /// </value>
        public int Column { get; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public override object Clone()
        {

            if (this.Line == -1 && this.Column == -1 && this.Index == -1)
                return CodeLocation.Empty;

            return new CodePositionLocation(this.Line, this.Column);
        
        }

        /// <summary>
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance match(this.Line == -1 && this.Column == -1 && this.Index == -1); otherwise, <c>false</c>.
        /// </value>
        public override bool IsEmpty => base.IsEmpty || (this.Line == -1 && this.Column == -1 && this.Index == -1);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"(line {this.Line}, column {this.Column})";
        }

    }


}
