
namespace Bb.Analysis
{
    public class CodePathLocation : CodeLocation
    {

        /// <summary>
        /// The empty value
        /// </summary>
        public static new readonly CodeLocation Empty = new CodePathLocation(string.Empty);

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeLocation"/> struct.
        /// </summary>
        /// <param name="position">The position.</param>
        public CodePathLocation(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public string Path { get; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public override object Clone()
        {

            if (string.IsNullOrEmpty(this.Path))
                return CodeLocation.Empty;

            return new CodePathLocation(this.Path);

        }

        /// <summary>
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance match(this.Line == -1 && this.Column == -1 && this.Index == -1); otherwise, <c>false</c>.
        /// </value>
        public override bool IsEmpty => base.IsEmpty || string.IsNullOrEmpty(this.Path);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"(path {this.Path})";
        }

    }


}
