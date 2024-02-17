namespace Refs
{
    public class ExternalAssembly : ILib
    {


        public ExternalAssembly(string assemblyName)
        {
            this.Name = assemblyName;
        }

        public string Name { get; }
        public string File => Name + ".dll";
        public string Sdk { get; } = String.Empty;

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { };

        public string[] Namespaces => new string[] { };

    }


}
