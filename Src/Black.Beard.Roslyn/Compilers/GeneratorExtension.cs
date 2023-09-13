using Bb.Analysis;
using Bb.Compilers.Exceptions;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bb.Compilers
{

    public static class GeneratorExtension
    {

        /// <summary>
        /// Maps the specified self.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns></returns>
        public static DiagnosticReport Map(this Diagnostic self)
        {

            var locations = GetLocations(self);

            return new DiagnosticReport(locations)
            {                   
                Id = self.Id,
                Message = self.GetMessage(),
                IsSeverityAsError = self.IsWarningAsError,
                Severity = self.Severity.ToString(),
                SeverityLevel = self.WarningLevel,
            };
            
        }

        private static SpanLocation[] GetLocations(Diagnostic self)
        {

            List<SpanLocation> result = new List<SpanLocation>(self.AdditionalLocations.Count + 1)
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
        private static DiagnosticLocation Map(Location location)
        {

            var lineSpan = location.GetLineSpan();
            return new DiagnosticLocation
             (
            
                location?.SourceTree?.FilePath ?? string.Empty,

                new CodePositionLocation(
                    lineSpan.StartLinePosition.Line + 1,
                    lineSpan.StartLinePosition.Character,
                    location?.SourceSpan.Start ?? 0
                 ),
                
                new CodePositionLocation(
                 lineSpan.EndLinePosition.Line + 1,
                 lineSpan.EndLinePosition.Character,
                 location?.SourceSpan.End ?? 0
                )                               

            );

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
