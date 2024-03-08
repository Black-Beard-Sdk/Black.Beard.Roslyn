
namespace Bb.Builds
{
    public interface IAssemblyReferenceResolver
    {

        // append next resolver
        void Next(IAssemblyReferenceResolver next);
        
        // method to resolve assembly name
        Reference ResolveAssemblyName(string assemblyName, FrameworkVersion framework, Func<ReferenceType, List<Reference>, Reference> func);
        
    }



}
