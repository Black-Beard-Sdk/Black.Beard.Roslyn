﻿
namespace Bb.Analysis
{
    [System.Diagnostics.DebuggerDisplay("{StartIndex}, {StopIndex} : ({Line},{Column})")]
    public class TokenLocation
    {

        public TokenLocation()
        {

        }

        public TokenLocation(int start, int end)
        {
            this.StartIndex = start;
            this.StopIndex = end;
        }

        public TokenLocation(int start, int end, int line, int column)
        {
            this.StartIndex = start;
            this.StopIndex = end;
            this.Line = line;
            this.Column = column;
        }


        public TokenLocation(DiagnosticLocation location)
        {
            this.Line = location.StartLine;
            this.Column = location.StartColumn;
            this.StartIndex = location.StartIndex;
            this.StopIndex = location.EndIndex;
        }

        public int Line { get; set; }

        public int Column { get; set; }

        public int StartIndex { get; set; }

        public int StopIndex { get; set; }

        public string Function { get; set; }

        public string ScriptFile { get; set; }

        public TokenLocation Clone()
        {
            return new TokenLocation(this.StartIndex, this.StopIndex, this.Line, this.Column) { Function = this.Function };
        }

    }


}
