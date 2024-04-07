using Microsoft.CodeAnalysis;

namespace Bb.Compilers
{


    [Serializable]
    public class CompilerException : Exception
    {

        public CompilerException(Diagnostic[] diagnostics) : this(
               GetMessage(diagnostics, DiagnosticSeverity.Error)
            ?? GetMessage(diagnostics, DiagnosticSeverity.Warning)
            ?? GetMessage(diagnostics, DiagnosticSeverity.Info))
        {

            Diagnostics = diagnostics;

            Infos = diagnostics.Where(diag => diag.Severity == DiagnosticSeverity.Info).ToArray();
            Warnings = diagnostics.Where(diag => diag.Severity == DiagnosticSeverity.Warning).ToArray();
            Errors = diagnostics.Where(diag => diag.Severity == DiagnosticSeverity.Error).ToArray();

            HaveInfo = Infos.Any();
            HaveWarning = Warnings.Any();
            HaveError = Errors.Any();

        }

        private static string GetMessage(Diagnostic[] diagnostics, DiagnosticSeverity severity)
        {
            var diagnostic = diagnostics.FirstOrDefault(diag => diag.Severity == severity);
            return diagnostic?.GetMessage() ?? null;
        }

        public CompilerException(string message) : base(message) { }

        public Diagnostic[] Diagnostics { get; }
        public Diagnostic[] Infos { get; }
        public Diagnostic[] Warnings { get; }
        public Diagnostic[] Errors { get; }
        public bool HaveInfo { get; }
        public bool HaveWarning { get; }
        public bool HaveError { get; }

        protected CompilerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }

}
