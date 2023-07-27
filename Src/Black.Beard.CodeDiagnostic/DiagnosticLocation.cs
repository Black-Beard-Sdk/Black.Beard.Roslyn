
namespace Bb.Compilers
{

    public class DiagnosticLocation
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        public DiagnosticLocation()
        {

        }

        public DiagnosticLocation(string filename)
        {
            this.Filename = filename;
        }

        public DiagnosticLocation(string filename, int startIndex, int startline = -1, int startColumn = -1) : this(filename)
        {
            this.StartIndex = startIndex;
            this.StartLine = startline;
            this.StartColumn = startColumn;
        }

        public DiagnosticLocation(string filename, TokenLocation location) : this(filename)
        {
            Filename = filename;
            StartLine = location.Line;
            StartIndex = location.StartIndex;
            StartColumn = location.Column;
        }


        public string Filename { get; set; }


        public int StartIndex { get; set; }
        public int StartColumn { get; set; }
        public int StartLine { get; set; }



        public int EndIndex { get; set; }
        public int EndColumn { get; set; }
        public int EndLine { get; set; }



        public override string ToString()
        {
            var file = this.Filename ?? string.Empty;
            return $"{file} from (line {this.StartLine}, column {this.StartColumn}) to (line {this.EndLine}, column {this.EndColumn})";
        }

    }


    public enum SeverityEnum
    {
        Information = 0,
        Warning = 1,
        Error = 2,
    }


}
