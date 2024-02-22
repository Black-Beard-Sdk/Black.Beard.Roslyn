using System.Text;

namespace Bb.Analysis.Traces
{
    public class LocationPath : ILocation
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

        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            WriteTo(sb);
            return sb.ToString();
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

    }

}
