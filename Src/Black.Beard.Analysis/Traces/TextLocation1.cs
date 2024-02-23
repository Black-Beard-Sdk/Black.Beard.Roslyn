using System.Text;

namespace Bb.Analysis.Traces
{

    public class TextLocation<T> : TextLocation
        where T : ILocation
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        /// <param name="start">The position.</param>
        protected TextLocation(T start, ILocation stop) : base(start, stop)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        /// <param name="start">The position.</param>
        public TextLocation(T start) : base(start, start)
        {
         
        }


        /// <summary>
        /// Gets the left location.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public new T Start { get => (T)base.Start; }


        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public override object Clone()
        {
            return new TextLocation<T>((T)Start.Clone())
            {
                Filename = Filename
            }.Add(this.Datas);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="ValueTuple{int, int}"/> to <see cref="TextLocation"/>.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator TextLocation<T>(T position)
        {
            return new TextLocation<T>(position);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            WriteTo(sb);
            return sb.ToString();
        }



        internal override void WriteTo(StringBuilder sb)
        {
            sb.Append("(");
            Start.WriteTo(sb);
            sb.Append(")");
            if (!string.IsNullOrEmpty(Filename))
                sb.Append(" in ").Append(Filename);
        }


    }

}
