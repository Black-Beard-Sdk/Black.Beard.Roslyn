using System.Text;

namespace Bb.Analysis.DiagTraces
{
    public class SpanLocation<T, U> : TextLocation<T>
        where T : ILocation
        where U : ILocation
    {

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        public SpanLocation(T start, U stop) : base(start, stop)
        {
            Filename = string.Empty;
        }

        #endregion Ctors


        /// <summary>
        /// Gets the right location
        /// </summary>
        public new U Stop { get => (U)base.Stop; }


        internal override void WriteTo(StringBuilder sb)
        {
            sb.Append("(");
            Start.WriteTo(sb);
            sb.Append(" - ");
            Stop.WriteTo(sb);
            sb.Append(")");

            if (!string.IsNullOrEmpty(Filename))
                sb.Append(" in ").Append(Filename);

        }


        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public virtual object Clone() => new SpanLocation<T, U>((T)Start.Clone(), (U)Stop.Clone()) { Filename = Filename }.Add(Datas);



        /// <summary>
        /// Performs an implicit conversion from <see cref="ValueTuple{int, int}"/> to <see cref="TextLocation"/>.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator SpanLocation<T, U>((T, U) position)
        {
            return new SpanLocation<T, U>(position.Item1, position.Item2);
        }
             
        public virtual bool IsAfter(TextLocation location)
        {
            return location.Stop.StartAfter(location.Start);
        }

    }


}
