using System.Text;

namespace Bb.Analysis.DiagTraces
{

    public class LocationDefault : ILocation
    {


        public static ILocation Empty = new LocationDefault();

        /// <summary>
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        public bool IsEmpty => Object.Equals(Empty, this);


        /// <summary>
        /// Initializes a new instance of the <see cref="LocationDefault"/> class.
        /// </summary>
        private LocationDefault()
        {
            this._g = new Guid().ToString().GetHashCode();
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this;
        }

        /// <summary>
        /// return true if the current location end after the compared with another location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        public bool EndAfter(ILocation location)
        {
            return false;
        }

        /// <summary>
        /// return true if the current location end before the compared with another location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        public bool EndBefore(ILocation location)
        {
            return false;
        }

        /// <summary>
        /// return true if the current location start before the compared with another location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        public bool StartBefore(ILocation location)
        {
            return false;
        }

        /// <summary>
        /// return true if the current position start before the specified location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        public bool StartAfter(ILocation location)
        {
            return false;
        }

        /// <summary>
        /// Writes message to specified <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb"></param>
        public void WriteTo(StringBuilder sb)
        {
            sb.Append("default");
        }

        /// <summary>
        /// return true if the current location can be compared with another location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool CanBeCompare(ILocation location)
        {
            return true;
        }

        /// <summary>
        /// Gets a hash code for this string.  If strings A and B are such that A.Equals(B), then
        /// </summary>
        /// <returns>they will return the same hash code.</returns>
        public override int GetHashCode()
        {
            return _g;
        }

        private int _g;

    }


}
