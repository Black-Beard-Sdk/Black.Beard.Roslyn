
namespace Bb.Analysis
{
    public struct TextLocation : ICloneable
    {

        /// <summary>
        /// The empty value
        /// </summary>
        public static readonly TextLocation Empty = new TextLocation(-1, -1);

        /// <summary>
        /// Initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        /// <param name="position">The position.</param>
        public TextLocation((int, int) position, int index = -1)
        {
            Line = position.Item1;
            Column = position.Item2;
            this.Index = index;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="column">The column.</param>
        public TextLocation(int line, int column, int index = -1)
        {
            Line = line;
            Column = column;
            this.Index = index;
        }               

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
        public object Clone()
        {

            if (this.Line == -1 && this.Column == -1 && this.Index == -1)
                return TextLocation.Empty;

            return new TextLocation(this.Line, this.Column);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.ValueTuple{System.Int32, System.Int32}"/> to <see cref="TextLocation"/>.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator TextLocation((int, int) position)
        {
            return new TextLocation(position);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.ValueTuple{System.Int32, System.Int32, System.Int32}"/> to <see cref="TextLocation"/>.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator TextLocation((int, int, int) position)
        {
            return new TextLocation(position.Item1, position.Item2, position.Item3);
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Index { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance match(this.Line == -1 && this.Column == -1 && this.Index == -1); otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty => this.Line == -1 && this.Column == -1 && this.Index == -1;
    }


}
