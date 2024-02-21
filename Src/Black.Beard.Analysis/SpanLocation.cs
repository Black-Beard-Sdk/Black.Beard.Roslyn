
using System.Text;

namespace Bb.Analysis
{
    public class SpanLocation : TextCodeLocation
    {

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation()
        {
            base.Filename = string.Empty;
            this.Stop = TextLocation.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation((int, int) start)
            : base(start)
        {
            this.Line = start.Item1;
            this.Column = start.Item2;
            this.Stop = TextLocation.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation(TextLocation start)
            : base(start)
        {
            this.Stop = TextLocation.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation(int startIndex, int startLine, int startColumn) : base(startIndex)
        {
            this.Line = startLine;
            this.Column = startColumn;
            this.Stop = TextLocation.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation(int startIndex, int startLine, int startColumn, int stopIndex, int stoptLine, int stopColumn) : base(startIndex)
        {
            this.Line = startLine;
            this.Column = startColumn;
            this.Stop = new SpanLocation(stopIndex, stoptLine, stopColumn);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation(int startIndex, int startLine, int startColumn, SpanLocation stop) : base(startIndex)
        {
            this.Line = startLine;
            this.Column = startColumn;
            this.Stop = stop;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation(string path) : base(path)
        {
            this.Stop = TextLocation.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLocation"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="locationStart">The location start.</param>
        public SpanLocation(TextLocation locationStart, TextLocation locationEnd) : this(locationStart)
        {
            this.Stop = locationEnd ?? TextLocation.Empty;
        }

        #endregion Ctors


        public static readonly SpanLocation Empty = new SpanLocation(-1, -1, -1);


        public TextLocation Stop { get; protected set; }


        public bool IsEmpty =>
            (this.Line == -1 && this.Column == -1 && this.Index == -1)
            && (Stop == null || Stop.IsEmpty);


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

            if (this.Stop != null && !this.Stop.IsEmpty)
            {
                sb.Append(" - ");
                this.Stop.Write(sb);
            }

            if (!string.IsNullOrEmpty(this.Filename))
            {
                if (sb.Length > 1)
                    sb.Append(" ");
                sb.Append("file:" + this.Filename);
            }
            return sb.ToString();

        }

        public virtual object Clone()
        {
            return new SpanLocation(this, (TextLocation)Stop.Clone()) { Path = this.Path, Filename = this.Filename };
        }

    }


}
