namespace Refs
{
    public interface ILib
    {
        string Name { get; }

        string File { get; }

        string Sdk { get; }

        Version[] Versions { get; }

        ILib[] References { get; }

        string[] Namespaces { get; }

    }


}
