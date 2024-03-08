using Bb.Analysis.DiagTraces;
using Bb.Compilers.Exceptions;
using Microsoft.CodeAnalysis;

namespace Bb.Compilers
{

    public static class GeneratorExtension
    {

        /// <summary>
        /// Maps the specified self.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns></returns>
        public static Analysis.DiagTraces.ScriptDiagnostic Map(this Diagnostic self)
        {

            var locations = GetLocations(self);

            var result = new ScriptDiagnostic(locations)
            {
                Id = self.Id,
                Message = self.GetMessage(),
                IsSeverityAsError = self.IsWarningAsError || self.Severity == DiagnosticSeverity.Error,
                Severity = self.Severity.ToString(),
                SeverityLevel = self.IsWarningAsError ? (int)SeverityEnum.Error : (int)self.Severity,
            };

            return result;

        }

        private static TextLocation[] GetLocations(Diagnostic self)
        {

            List<TextLocation> result = new List<TextLocation>(self.AdditionalLocations.Count + 1)
            {
                Map(self.Location)
            };

            foreach (var item in self.AdditionalLocations)
                result.Add(Map(item));

            return result.ToArray();

        }

        /// <summary>
        /// Maps the specified location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        private static TextLocation Map(Location location)
        {

            FileLinePositionSpan lineSpan = location.GetLineSpan();

            var index1 = location?.SourceSpan.Start ?? 0;
            var line1 = lineSpan.StartLinePosition.Line + 1;
            var col1 = lineSpan.StartLinePosition.Character;

            var index2 = location?.SourceSpan.End ?? 0;
            var line2 = lineSpan.EndLinePosition.Line + 1;
            var col2 = lineSpan.EndLinePosition.Character;

            return new SpanLocation<LocationLineAndIndex, LocationLineAndIndex>
            (
                (line1, col1, index1), 
                (line2, col2, index2)
            )
            {
                Filename = location?.SourceTree?.FilePath ?? string.Empty,

            };

        }


        /// <summary>
        /// emit the compilation result into a byte array 
        /// </summary>
        /// <param name="compilation"></param>
        /// <returns></returns>
        /// <exception cref="CompilerException">throw an exception with corresponding message if there are errors</exception>
        public static byte[] EmitToArray(this Compilation compilation, DiagnosticSeverity severity, out CompilerException exception)
        {

            using (var stream = new MemoryStream())
            {
                // emit result into a stream
                var emitResult = compilation.Emit(stream);

                if (emitResult.Diagnostics.Any())
                {

                    exception = new CompilerException(emitResult.Diagnostics.ToArray());
                    System.Diagnostics.Trace.WriteLine(exception, System.Diagnostics.TraceLevel.Warning.ToString());

                    switch (severity)
                    {

                        case DiagnosticSeverity.Info:
                            if (exception.HaveInfo)
                                throw exception;
                            break;

                        case DiagnosticSeverity.Warning:
                            if (exception.HaveWarning)
                                throw exception;
                            break;

                        case DiagnosticSeverity.Error:
                            if (exception.HaveError)
                                throw exception;
                            break;

                        case DiagnosticSeverity.Hidden:
                        default:
                            break;

                    }
                }
                else
                    exception = null;

                // get the byte array from a stream
                return stream.ToArray();

            }
        }


    }

}
