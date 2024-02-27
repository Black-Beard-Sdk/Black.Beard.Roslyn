﻿using Bb.Analysis.DiagTraces;
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

            PortableExecutableReference result = _assemblies.ResolveAssemblyNameAndAddIfMissing(referenceIdentity.Name);

            if (result == null)
            {

                _diagnostics.Warning(referenceIdentity.Name, $"assembly {referenceIdentity.Name} not resolved");

                //var assembly = TypeDiscovery.Instance.GetAssemblies().FirstOrDefault(c => c.GetName().Name == referenceIdentity.Name);
                //if (assembly != null)
                //{
                //    var _reference = new Reference(assembly);
                //    result = _reference.GetPortableExecutableReference();
                //}

            }

            return result;

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
