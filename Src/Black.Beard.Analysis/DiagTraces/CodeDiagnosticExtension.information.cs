
namespace Bb.Analysis.DiagTraces
{

    public static partial class CodeDiagnosticExtension
    {


        /// <summary>
        /// Adds the information diagnostic.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public static ScriptDiagnostic Information(this ScriptDiagnostics self, string text, string message)
        {
            return self.Add(SeverityEnum.Information, TextLocation.Empty, text, message);
        }


        /// <summary>
        /// Adds the information diagnostic.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public static ScriptDiagnostic Information(this ScriptDiagnostics self, string filename, string text, string message)
        {
            return self.Add(SeverityEnum.Information,
            new TextLocation<LocationLine>(new LocationLine(0, 0))
            {
                Filename = filename
            }, text, message);
        }

        /// <summary>
        /// Adds the information diagnostic.
        /// </summary>
        /// <param name="filename">The filename of the file.</param>
        /// <param name="path">The index where the text start.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public static ScriptDiagnostic Information(this ScriptDiagnostics self, string filename, string path, string text, string message)
        {
            return self.Add(SeverityEnum.Information,
                new TextLocation<LocationPath>(new LocationPath(path))
                {
                    Filename = filename
                }, text, message);
        }


        /// <summary>
        /// Adds the information diagnostic.
        /// </summary>
        /// <param name="filename">The filename of the file.</param>
        /// <param name="path">The index where the text start.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public static ScriptDiagnostic Information(this ScriptDiagnostics self, string filename, int index, string text, string message)
        {
            return self.Add(SeverityEnum.Information,
                new TextLocation<LocationIndex>(new LocationIndex(index))
                {
                    Filename = filename
                }, text, message);
        }


        /// <summary>
        /// Adds the information diagnostic.
        /// </summary>
        /// <param name="filename">The filename of the file.</param>
        /// <param name="line">The line.</param>
        /// <param name="column">The column.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public static ScriptDiagnostic Information(this ScriptDiagnostics self, string filename, int line, int column, string text, string message)
        {
            return self.Add(SeverityEnum.Information,
                new TextLocation<LocationLine>(new LocationLine(line, column))
                {
                    Filename = filename
                }, text, message);
        }


        /// <summary>
        /// Adds the information diagnostic.
        /// </summary>
        /// <param name="filename">The filename of the file.</param>
        /// <param name="line">The line.</param>
        /// <param name="column">The column.</param>
        /// <param name="index">The start index.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public static ScriptDiagnostic Information(this ScriptDiagnostics self, string filename, int line, int column, int index, string text, string message)
        {
            return self.Add(SeverityEnum.Information,
                new TextLocation<LocationLineAndIndex>(new LocationLineAndIndex(line, column, index))
                {
                    Filename = filename
                }, text, message);
        }


        /// <summary>
        /// Adds the information diagnostic.
        /// </summary>
        /// <param name="filename">The filename of the file.</param>
        /// <param name="startLine">The start line.</param>
        /// <param name="startColumn">The start column.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="stopLine">The stop line.</param>
        /// <param name="stopColumn">The stop column.</param>
        /// <param name="stopIndex">The stop index.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public static ScriptDiagnostic Information(this ScriptDiagnostics self, string filename, 
            int startLine, int startColumn, int startIndex,
            int stopLine, int StopColumn, int StopIndex,
            string text, string message)
        {
            return self.Add(SeverityEnum.Information,
                new SpanLocation<LocationLineAndIndex, LocationLineAndIndex>(
                    new LocationLineAndIndex(startLine, startColumn, startIndex),
                    new LocationLineAndIndex(stopLine, StopColumn, StopIndex))
                {
                    Filename = filename
                }, text, message);
        }


        /// <summary>
        /// Adds the information diagnostic.
        /// </summary>
        /// <param name="filename">The filename of the file.</param>
        /// <param name="startLine">The start line.</param>
        /// <param name="startColumn">The start column.</param>
        /// <param name="stopLine">The stop line.</param>
        /// <param name="stopColumn">The stop column.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public static ScriptDiagnostic Information(this ScriptDiagnostics self, string filename,
            int startLine, int startColumn,
            int stopLine, int StopColumn,
            string text, string message)
        {
            return self.Add(SeverityEnum.Information,
                new SpanLocation<LocationLine, LocationLine>(
                    new LocationLine(startLine, startColumn),
                    new LocationLine(stopLine, StopColumn))
                {
                    Filename = filename
                }, text, message);
        }

    }

}
