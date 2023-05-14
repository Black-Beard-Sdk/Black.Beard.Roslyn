namespace Bb.Projects
{

    public class TargetFramework : PropertyKey
    {

        public TargetFramework(string value) : base("TargetFramework", value)
        {

        }

        public static TargetFramework Net6 { get; } = new TargetFramework("net6.0");
        public static TargetFramework Netstandard20 { get; } = new TargetFramework("netstandard2.0");

        
    }

}
