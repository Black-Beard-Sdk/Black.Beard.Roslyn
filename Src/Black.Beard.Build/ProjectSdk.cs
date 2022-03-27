using System.Xml.Linq;

namespace Bb.Build
{
    public class ProjectSdk : PropertyKey
    {

        public ProjectSdk(string value) : base("Sdk", value)
        {

        }

        public static ProjectSdk MicrosoftNETSdk { get; } = new ProjectSdk("Microsoft.NET.Sdk");

        public override XObject Serialize()
        {
            return new XAttribute(Name, Value);
        }

    }

}
