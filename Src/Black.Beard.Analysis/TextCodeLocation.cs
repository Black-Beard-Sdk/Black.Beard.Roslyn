
using System.Text;

namespace Bb.Analysis
{


    public class TextCodeLocation : TextLocation
    {

        /// <summary>
        /// The empty value
        /// </summary>
        public static new readonly TextLocation Empty = new TextCodeLocation(-1, -1);


        /// <summary>
        /// Initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        public TextCodeLocation()
        {
            base.Filename = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        public TextCodeLocation(string path, int index) : base(index)
        {
            this.Path = path;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        public TextCodeLocation(string path)
        {
            this.Path = path;
            base.Filename = string.Empty;
            this.Column = 0;
            this.Line = 0;
            this.Index = 0;
        }

        /// <summary>
        /// initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        /// <param name="index"></param>
        public TextCodeLocation(int index) : base(index)
        {

        }


        public TextCodeLocation(TextLocation source) : base(source.Index)
        {

            if (source is TextCodeLocation t)
            {
                this.Line = t.Line;
                this.Column = t.Column;
            }
            else if (source is SpanLocation tZ)
            {
                this.Line = tZ.Line;
                this.Column = tZ.Column;
            }
            else
            {
                this.Line = -1;
                this.Column = -1;
            }

            this.Index = source.Index;
            base.Filename = source.Filename;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        /// <param name="position">The position.</param>
        public TextCodeLocation((int, int) position, int index = -1) : base(index)
        {
            Line = position.Item1;
            Column = position.Item2;
            base.Filename = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="column">The column.</param>
        public TextCodeLocation(int line, int column, int index = -1)
        {
            Line = line;
            Column = column;
            this.Index = index;
            base.Filename = string.Empty;
        }


        public string Path { get; protected set; }

        /// <summary>
        /// Gets or sets the end line.
        /// </summary>
        /// <value>
        /// The end line.
        /// </value>
        public int Line { get; protected set; }

        /// <summary>
        /// Gets or sets the end column.
        /// </summary>
        /// <value>
        /// The end column.
        /// </value>
        public int Column { get; protected set; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public override object Clone()
        {

            if (this.Line == -1 && this.Column == -1 && this.Index == -1)
                return TextLocation.Empty;

            return new TextCodeLocation(this.Line, this.Column);

        }

        /// <summary>
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance match(this.Line == -1 && this.Column == -1 && this.Index == -1); otherwise, <c>false</c>.
        /// </value>
        public override bool IsEmpty => base.IsEmpty || (this.Line == -1 && this.Column == -1 && this.Index == -1);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            Write(sb);

            if (!string.IsNullOrEmpty(this.Filename))
            {
                if (sb.Length > 1)
                    sb.Append(" ");
                sb.Append("file:" + this.Filename);
            }

            return sb.ToString();

        }

        internal protected override void Write(StringBuilder sb)
        {

            sb.Append("(");
            int t = -1;

            if (!string.IsNullOrEmpty(this.Path))
            {
                sb.Append("path:" + this.Path);
                t = 0;
            }

            if (this.Line != t)
            {
                if (sb.Length > 1)
                    sb.Append(", ");
                sb.Append("line:" + this.Line);
            }

            if (this.Column != t)
            {
                if (sb.Length > 1)
                    sb.Append(", ");
                sb.Append("col:" + this.Column);
            }

            if (this.Index != t)
            {
                if (sb.Length > 1)
                    sb.Append(", ");
                sb.Append("index:" + this.Index);
            }


            sb.Append(")");

        }

    }


}
