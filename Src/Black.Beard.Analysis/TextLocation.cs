
using System.Text;

namespace Bb.Analysis
{

    public class TextLocation : ICloneable
    {

        /// <summary>
        /// The empty value
        /// </summary>
        public static readonly TextLocation Empty = new TextLocation();

        /// <summary>
        /// Initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        /// <param name="position">The position.</param>
        public TextLocation()
        {
            this.Filename = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        /// <param name="position">The position.</param>
        public TextLocation(int index)
        {
            this.Index = index;
            this.Filename = string.Empty;
        }

        public string Filename { get; set; }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Index { get; protected set; }


        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public virtual object Clone()
        {
            return new TextLocation(this.Index) { Filename = this.Filename };
        }

        /// <summary>
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance match(this.Line == -1 && this.Column == -1 && this.Index == -1); otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsEmpty => Equals(this, Empty);


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.ValueTuple{System.Int32, System.Int32}"/> to <see cref="TextLocation"/>.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator TextLocation(int position)
        {
            return new TextLocation(position);
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
            return new TextCodeLocation(position);
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
            return new TextCodeLocation(position.Item1, position.Item2, position.Item3);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Index.ToString();
        }

        internal protected virtual void Write(StringBuilder sb)
        {

            sb.Append("(");


            if (this.Index != -1)
            {
                sb.Append("index:" + this.Index);
            }


            sb.Append(")");

        }

    }

}
