using System.Text;

namespace Bb.Analysis.Traces
{
    public class LocationPath : ILocationPath
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationPath"/> struct.
        /// </summary>
        /// <param name="index"></param>
        public LocationPath(string path)
        {
            Path = path;
        }

        /// <summary>
        /// index position
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new LocationPath(Path);
        }


        /// <summary>
        /// Writes message to specified <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb"></param>
        public void WriteTo(StringBuilder sb)
        {

            sb.Append("path:" + Path);

        }

        /// <summary>
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        public bool IsEmpty => Object.Equals(LocationDefault.Empty, this);

        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            WriteTo(sb);
            return sb.ToString();
        }

        public bool CanBeCompare(ILocation location)
        {
            throw new NotImplementedException();
        }

        public bool StartAfter(ILocation location)
        {
            throw new NotImplementedException();
        }

        public bool EndBefore(ILocation location)
        {
            throw new NotImplementedException();
        }

        public bool EndAfter(ILocation location)
        {
            throw new NotImplementedException();
        }

        public bool StartBefore(ILocation location)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="string"/> to <see cref="LocationPath"/>.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator LocationPath(string path)
        {
            return new LocationPath(path);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="LocationPath"/> to <see cref="TextLocation"/>.
        /// </summary>
        /// <param name="path"></param>
        public static implicit operator TextLocation(LocationPath path)
        {
            return new TextLocation<LocationPath>(path);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="LocationPath"/> to <see cref="TextLocation<LocationPath>"/>.
        /// </summary>
        /// <param name="position"></param>
        public static implicit operator TextLocation<LocationPath>(LocationPath position)
        {
            return new TextLocation<LocationPath>(position);
        }

        public override int GetHashCode()
        {
            return Path.GetHashCode();
        }

    }

}
