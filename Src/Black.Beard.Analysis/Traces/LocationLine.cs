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
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        public bool IsEmpty => Object.Equals(LocationDefault.Empty, this);

        /// <summary>
        /// Line position
        /// </summary>
        public int Line { get; }


        /// <summary>
        /// Line position
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// return true if the current position start before the specified location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        public bool StartAfter(ILocation location)
        {
            var l = location as LocationLine;
            if (l != null)
            {
                if (Line > l.Line)
                    return true;
                else if (Line == l.Line)
                    return Column > l.Column;
            }
            
            return false;
        }

        /// <summary>
        /// return true if the current location start before the compared with another location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        public bool StartBefore(ILocation location)
        {
            var l = location as LocationLine;
            if (l != null)
            {
                if (Line < l.Line)
                    return true;
                else if (Line == l.Line)
                    return Column < l.Column;
            }
            
            return false;

        }

        /// <summary>
        /// return true if the current location end before the compared with another location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        public bool EndBefore(ILocation location)
        {
            var l = location as LocationLine;
            if (l != null)
            {
                if (l.Line > Line)
                    return true;
                else if (Line == l.Line)
                    return l.Column > Column;

            }
            
            return false;
        }

        /// <summary>
        /// return true if the current location end after the compared with another location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        public bool EndAfter(ILocation location)
        {
            var l = location as LocationLine;
            if (l != null)
            {
                if (l.Line < Line)
                    return true;
                else if (Line == l.Line)
                    return l.Column < Column;
            }
             
            return false;
        }

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

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            WriteTo(sb);
            return sb.ToString();
        }

        /// <summary>
        /// return true if the current location can be compared with another location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool CanBeCompare(ILocation location)
        {
            return location is LocationLine;
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

        public override int GetHashCode()
        {
            return Line.GetHashCode() ^Column.GetHashCode();
        }

    }

}
