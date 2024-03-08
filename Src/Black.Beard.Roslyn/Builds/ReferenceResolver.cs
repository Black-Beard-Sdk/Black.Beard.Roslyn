using Bb.Analysis.DiagTraces;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Bb.Builds
{
    public class ReferenceResolver : MetadataReferenceResolver
    {

        /// <summary>
        /// Create a new instance of <see cref="ReferenceResolver"/>
        /// </summary>
        /// <param name="assemblies"></param>
        public ReferenceResolver(AssemblyReferences assemblies, ScriptDiagnostics diagnostics)
        {
            this._assemblies = assemblies;
            this._diagnostics = diagnostics;
        }

        /// <summary>
        /// Determines whether the specified object instances are considered equal.
        /// </summary>
        /// <param name="other"> The object to compare</param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            return object.Equals(this, other);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 0;
        }

        /// <summary>
        /// return state if the instance resolve missing assemblies
        /// </summary>
        public override bool ResolveMissingAssemblies => true;

        public Activity Activity { get; internal set; }

        public override PortableExecutableReference ResolveMissingAssembly(MetadataReference definition, AssemblyIdentity referenceIdentity)
        {

            var result = _assemblies.ResolveAssemblyName(referenceIdentity.Name, (f, list) =>
            {

                var reference = list.OrderByDescending(c => c.Version).ToList();

                if (referenceIdentity.Version != null && referenceIdentity.Version == new Version(0,0,0,0))
                    reference = list.Where(c => c.Version >= referenceIdentity.Version).ToList();

                if (list.Count() > 1)
                    _diagnostics.Warning(referenceIdentity.Name, $"assembly {referenceIdentity.Name} has multiple versions");

                return list.FirstOrDefault();

            }); 

            if (result != null)
                return result.ExecutableReference;

            _diagnostics.Warning(referenceIdentity.Name, $"assembly {referenceIdentity.Name} not resolved");

            return default;

        }


        public override ImmutableArray<PortableExecutableReference> ResolveReference(string reference, string baseFilePath, MetadataReferenceProperties properties)
        {
            throw new System.NotImplementedException();
        }

        private readonly string[] _trustedAssembliesPaths;
        private readonly AssemblyReferences _assemblies;
        private readonly ScriptDiagnostics _diagnostics;
    }



}
