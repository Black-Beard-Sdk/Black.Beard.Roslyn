namespace Bb.Build
{

    public class TargetFramework : PropertyKey
    {

        public TargetFramework(string value) : base("TargetFramework", value)
        {

        }

        public static TargetFramework Net6 { get; } = new TargetFramework("net6.0");

    }

}
