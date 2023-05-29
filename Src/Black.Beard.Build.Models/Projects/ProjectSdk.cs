using System.Xml.Linq;

namespace Bb.Projects
{
    public class ProjectSdk : PropertyKey
    {

        public ProjectSdk(string value) : base("Sdk", value)
        {
            Kind = PropertyKeyKind.XAttribute;
        }

        public static ProjectSdk Custom (string value) => new ProjectSdk(value);

        public static ProjectSdk MicrosoftNETSdkRazor { get; } = new ProjectSdk("Microsoft.NET.Sdk.Razor");
        public static ProjectSdk MicrosoftNETSdk { get; } = new ProjectSdk("Microsoft.NET.Sdk");
        public static ProjectSdk MicrosoftNETSdkWeb { get; } = new ProjectSdk("Microsoft.NET.Sdk.Web");              
        public static ProjectSdk MSBuildSdkSqlProj110 { get; } = new ProjectSdk("MSBuild.Sdk.SqlProj/1.1.0");

        public override XObject Serialize()
        {
            return new XAttribute(Name, Value);
        }

    }

}
