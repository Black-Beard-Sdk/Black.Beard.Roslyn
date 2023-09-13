
namespace Bb.Analysis
{
    public class SpanLocation : ICloneable
    {

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation()
        {
            this.Start = CodeLocation.Empty;
            this.End = CodeLocation.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation(CodeLocation locationStart) : this()
        {
            this.Start = locationStart;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation(int startIndex, int startLine, int startColumn) : this(new CodePositionLocation(startLine, startColumn, startIndex))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation(string path) : this(new CodePathLocation(path))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation(CodeLocation locationStart, CodeLocation locationEnd) : this(locationStart)
        {
            this.End = locationEnd;
        }

        #endregion Ctors


        public static SpanLocation Empty = new SpanLocation(CodeLocation.Empty);

        public CodeLocation Start { get; }

        public CodeLocation End { get; }

        public bool IsEmpty => (Start == null || Start.IsEmpty) && (End == null || End.IsEmpty);


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {

            if (this.End != null && !this.End.IsEmpty)
                return $"{this.Start} to {this.End}";

            if (this.Start != null)
                return this.Start.ToString();

            return "unknown location";

        }

        public virtual object Clone()
        {
            return new SpanLocation((CodeLocation)Start.Clone(), (CodeLocation)End.Clone());
        }

    }


}
