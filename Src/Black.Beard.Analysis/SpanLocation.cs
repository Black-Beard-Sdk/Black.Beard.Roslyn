
namespace Bb.Analysis
{
    public class SpanLocation : ICloneable
    {

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation(CodeLocation locationStart)
        {
            this.Start = locationStart;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation(CodeLocation locationStart, CodeLocation locationEnd)
        {
            this.Start = locationStart;
            this.End = locationEnd;
        }

        #endregion Ctors

        public CodeLocation Start { get; }

        public CodeLocation End { get; }


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            
            if (this.End.IsEmpty)
                return $"line {this.Start.Line}, column {this.Start.Column})";

            return $"line {this.Start.Line}, column {this.Start.Column}) to (line {this.End.Line}, column {this.End.Column}";

        }

        public virtual object Clone()
        {
            return new SpanLocation((CodeLocation)Start.Clone(), (CodeLocation)End.Clone());

        }

    }


}
