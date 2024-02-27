using System.Text;

namespace Bb.Analysis.DiagTraces
{
    public class LocationLineAndIndex : ILocationIndex
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationIndex"/> struct.
        /// </summary>
        /// <param name="position"> (line, column)</param>
        /// <param name="index">index</param>
        public LocationLineAndIndex((int, int) position, int index)
        {
            Line = position.Item1;
            Column = position.Item2;
            Index = index;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="LocationIndex"/> struct.
        /// </summary>
        /// <param name="position"> (line, column, index)</param>
        public LocationLineAndIndex((int, int, int) position)
        {
            Line = position.Item1;
            Column = position.Item2;
            Index = position.Item3;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="LocationIndex"/> struct.
        /// </summary>
        /// <param name="index"></param>
        public LocationLineAndIndex(int line, int column, int index)
        {
            Line = line;
            Column = column;
            Index = index;
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
        /// Line position
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// return true if the current position start before the specified location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        public bool StartAfter(ILocation location)
        {
            var l = location as ILocationIndex;
            if (l != null)
                return Index > l.Index;
            return false;
        }

        /// <summary>
        /// return true if the current location start before the compared with another location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        public bool StartBefore(ILocation location)
        {
            var l = location as ILocationIndex;
            if (l != null)
                return Index < l.Index;
            return false;
        }

        /// <summary>
        /// return true if the current location end before the compared with another location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        public bool EndBefore(ILocation location)
        {
            var l = location as ILocationIndex;
            if (l != null)
                return l.Index > Index;
            return false;
        }

        /// <summary>
        /// return true if the current location end after the compared with another location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        public bool EndAfter(ILocation location)
        {
            var l = location as ILocationIndex;
            if (l != null)
                return l.Index < Index;
            return false;
        }

        public bool CanBeCompare(ILocation location)
        {
            return location is ILocationIndex;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new LocationLineAndIndex(Line, Column, Index);
        }

        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            WriteTo(sb);
            return sb.ToString();
        }

        /// <summary>
        /// Writes message to specified <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb"></param>
        public void WriteTo(StringBuilder sb)
        {
            sb.Append("Line:" + Line);
            sb.Append(", col:" + Column);
            sb.Append(", index:" + Index);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="ValueTuple{int, int}"/> to <see cref="LocationIndex"/>.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator LocationLineAndIndex((int, int, int) position)
        {
            return new LocationLineAndIndex(position.Item1, position.Item2, position.Item3);
        }


        /// <summary>
        /// Performs an implicit conversion from <see cref="LocationLineAndIndex"/> to <see cref="TextLocation"/>.
        /// </summary>
        /// <param name="position"></param>
        public static implicit operator TextLocation(LocationLineAndIndex position)
        {
            return new TextLocation<LocationLineAndIndex>(position);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="LocationLineAndIndex"/> to <see cref="TextLocation<LocationLineAndIndex>"/>.
        /// </summary>
        /// <param name="position"></param>
        public static implicit operator TextLocation<LocationLineAndIndex>(LocationLineAndIndex position)
        {
            return new TextLocation<LocationLineAndIndex>(position);
        }

        public override int GetHashCode()
        {
            return Line.GetHashCode() ^Column.GetHashCode() ^Index.GetHashCode();
        }

    }

}
