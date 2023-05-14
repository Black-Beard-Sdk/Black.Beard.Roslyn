using System.Xml.Linq;

namespace Bb.Projects
{
    public class GenerateDocumentationFile : PropertyKey
    {

        public GenerateDocumentationFile(bool value) : base("GenerateDocumentationFile", value ? "true" : "false")
        {

        }

        public override XObject Serialize()
        {
            return new XElement(Name, Value);
        }

    }

}
