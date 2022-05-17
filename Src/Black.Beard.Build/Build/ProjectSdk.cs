using System.Xml.Linq;

namespace Bb.Build
{
    public class ProjectSdk : PropertyKey
    {

        public ProjectSdk(string value) : base("Sdk", value)
        {

        }

        public static ProjectSdk MicrosoftNETSdk { get; } = new ProjectSdk("Microsoft.NET.Sdk");
        public static ProjectSdk MSBuildSdkSqlProj110 { get; } = new ProjectSdk("MSBuild.Sdk.SqlProj/1.1.0");

        public override XObject Serialize()
        {
            return new XAttribute(Name, Value);
        }

    }

}
