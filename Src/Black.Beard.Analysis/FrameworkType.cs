using System.Diagnostics;

namespace Bb.Analysis
{

    [DebuggerDisplay("{Name}")]
    public class FrameworkType
    {

        private FrameworkType(string name, string Key, string windowDirectory)
        {
            this.Name = name;
            this.ProjectKey = Key;
            this.WindowDirectory = windowDirectory;
        }


        public string Name { get; }
        

        public string ProjectKey { get; }

        public string WindowDirectory { get; }

        public static implicit operator FrameworkType(string name)
        {
            return FrameworkType.ResolveSdkName(name);
        }


        public static FrameworkType ResolveSdkName(string sdk)
        {

            switch (sdk)
            {

                case "Microsoft.NETCore.App":
                case "Microsoft.NET.Sdk":
                    return FrameworkType.NETCore;

                case "Microsoft.WindowsDesktop.App":
                case "Microsoft.NET.Sdk.WindowsDesktop":
                    return FrameworkType.WindowsDesktop;

                case "Microsoft.AspNetCore.App":
                case "Microsoft.NET.Sdk.Web":
                    return FrameworkType.AspNetCore;

                default:
                    break;

            }

            return FrameworkType.NETCore;

        }

        public static IEnumerable<FrameworkType> All()
        {
            yield return NETCore;
            yield return AspNetCore;
            yield return WindowsDesktop;
        }

        public static FrameworkType NETCore = new FrameworkType(".NETCore.App", "Microsoft.NET.Sdk", "Microsoft.NETCore.App");
        public static FrameworkType AspNetCore = new FrameworkType(".AspNetCore.App", "Microsoft.NET.Sdk.Web", "Microsoft.AspNetCore.App");
        public static FrameworkType WindowsDesktop = new FrameworkType(".WindowsDesktop.App", "Microsoft.NET.Sdk.WindowsDesktop", "Microsoft.WindowsDesktop.App");

    }

}
