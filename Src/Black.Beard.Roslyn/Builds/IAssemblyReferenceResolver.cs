﻿
namespace Bb.Builds
{
    public interface IAssemblyReferenceResolver
    {

        // append next resolver
        void Next(IAssemblyReferenceResolver next);
        
        // method to resolve assembly name
        string ResolveAssemblyName(string assemblyName, Version version, FrameworkVersion framework, bool download);
        
    }



}
