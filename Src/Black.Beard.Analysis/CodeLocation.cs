
namespace Bb.Analysis
{

    public class CodeLocation : ICloneable
    {

        /// <summary>
        /// The empty value
        /// </summary>
        public static readonly CodeLocation Empty = new CodeLocation();

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeLocation"/> struct.
        /// </summary>
        /// <param name="position">The position.</param>
        public CodeLocation()
        {
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public virtual object Clone()
        {
            return new CodeLocation();
        }

        /// <summary>
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance match(this.Line == -1 && this.Column == -1 && this.Index == -1); otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsEmpty => Equals(this, Empty);


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.ValueTuple{System.Int32, System.Int32}"/> to <see cref="CodeLocation"/>.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator CodeLocation((int, int) position)
        {
            return new CodePositionLocation(position);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.ValueTuple{System.Int32, System.Int32, System.Int32}"/> to <see cref="CodeLocation"/>.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator CodeLocation((int, int, int) position)
        {
            return new CodePositionLocation(position.Item1, position.Item2, position.Item3);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "unknown location";
        }

    }


}
