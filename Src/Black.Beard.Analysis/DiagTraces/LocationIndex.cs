using System.Text;

namespace Bb.Analysis.DiagTraces
{

    public class LocationIndex : ILocationIndex
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationIndex"/> struct.
        /// </summary>
        /// <param name="index"></param>
        public LocationIndex(int index)
        {
            Index = index;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        public bool IsEmpty => Object.Equals(LocationDefault.Empty, this);

        /// <summary>
        /// index position
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new LocationIndex(Index);
        }

        /// <summary>
        /// Writes message to specified <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb"></param>
        public void WriteTo(StringBuilder sb)
        {
            sb.Append("index:" + Index);
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

        /// <summary>
        /// return true if the current location can be compared with another location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool CanBeCompare(ILocation location)
        {
            return location is ILocationIndex;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="int"/> to <see cref="LocationIndex"/>.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator LocationIndex(int position)
        {
            return new LocationIndex(position);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="LocationIndex"/> to <see cref="TextLocation"/>.
        /// </summary>
        /// <param name="position"></param>
        public static implicit operator TextLocation(LocationIndex position)
        {
            return new TextLocation<LocationIndex>(position);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="LocationIndex"/> to <see cref="TextLocation<IndexLocation>"/>.
        /// </summary>
        /// <param name="position"></param>
        public static implicit operator TextLocation<LocationIndex>(LocationIndex position)
        {
            return new TextLocation<LocationIndex>(position);
        }

    }

}
