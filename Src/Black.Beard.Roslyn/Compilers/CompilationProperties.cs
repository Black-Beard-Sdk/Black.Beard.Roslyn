using Bb.Json.Jslt.Builds;
using System.Collections.Generic;
using System.Reflection;

namespace Bb.Compilers
{
    public class CompilationProperties
    {

        public CompilationProperties()
        {
            this._assemblies = new Dictionary<string, Assembly>();
        }

        public void AddAssembly(Assembly assembly)
        {
            if (!this._assemblies.ContainsKey(assembly.FullName))
                this._assemblies.Add(assembly.FullName, assembly);
        }

        private readonly Dictionary<string, Assembly> _assemblies;

        internal void Apply(BuildCSharp builder)
        {

            ApplyReferencedAssemblies(builder);

        }

        private void ApplyReferencedAssemblies(BuildCSharp builder)
        {
            foreach (var item in this._assemblies)
                builder.References.Add(item.Value);
        }
    }


}
