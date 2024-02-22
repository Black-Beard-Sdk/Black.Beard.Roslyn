using System.Text;

namespace Bb.Analysis.Traces
{


    public class LocationLine : ILocation
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationIndex"/> struct.
        /// </summary>
        /// <param name="position"> (line, column)</param>
        public LocationLine((int, int) position)
        {
            Line = position.Item1;
            Column = position.Item2;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="LocationIndex"/> struct.
        /// </summary>
        /// <param name="line"></param>
        public LocationLine(int line, int column)
        {
            Line = line;
            Column = column;
        }


        /// <summary>
        /// Line position
        /// </summary>
        public int Line { get; }


        /// <summary>
        /// Line position
        /// </summary>
        public int Column { get; }


        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new LocationLine(Line, Column);
        }


        /// <summary>
        /// Writes message to specified <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb"></param>
        public void WriteTo(StringBuilder sb)
        {
            sb.Append("Line:" + Line);
            sb.Append(", col:" + Column);
        }

        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            WriteTo(sb);
            return sb.ToString();
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="ValueTuple{int, int}"/> to <see cref="LocationIndex"/>.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator LocationLine((int, int) position)
        {
            return new LocationLine(position.Item1, position.Item2);
        }


        /// <summary>
        /// Performs an implicit conversion from <see cref="LocationLine"/> to <see cref="TextLocation"/>.
        /// </summary>
        /// <param name="position"></param>
        public static implicit operator TextLocation(LocationLine position)
        {
            return new TextLocation<LocationLine>(position);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="LocationLine"/> to <see cref="TextLocation<LineLocation>"/>.
        /// </summary>
        /// <param name="position"></param>
        public static implicit operator TextLocation<LocationLine>(LocationLine position)
        {
            return new TextLocation<LocationLine>(position);
        }

    }

}
