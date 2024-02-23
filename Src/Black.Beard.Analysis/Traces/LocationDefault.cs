using System.Text;

namespace Bb.Analysis.Traces
{

    public class LocationDefault : ILocation
    {


        public static ILocation Empty = new LocationDefault();

        /// <summary>
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        public bool IsEmpty => Object.Equals(Empty, this);


        private LocationDefault()
        {
            this._g = new Guid().ToString().GetHashCode();
        }

        public object Clone()
        {
            return this;
        }

        public bool EndAfter(ILocation location)
        {
            return false;
        }

        public bool EndBefore(ILocation location)
        {
            return false;
        }

        public bool Intersect(ILocation location)
        {
            return false;
        }

        public bool StartBefore(ILocation location)
        {
            return false;
        }

        public bool StartAfter(ILocation location)
        {
            return false;
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("default");
        }

        public bool CanBeCompare(ILocation location)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return _g;
        }

        private int _g;

    }


}
