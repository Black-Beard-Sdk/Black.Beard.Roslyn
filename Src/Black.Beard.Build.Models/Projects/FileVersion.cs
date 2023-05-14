using System.Xml.Linq;

namespace Bb.Projects
{
    public class FileVersion : PropertyKey
    {

        public FileVersion(Version value) : base("FileVersion", value.ToString())
        {

        }

        public override XObject Serialize()
        {
            return new XElement(Name, Value);
        }


    }

}
