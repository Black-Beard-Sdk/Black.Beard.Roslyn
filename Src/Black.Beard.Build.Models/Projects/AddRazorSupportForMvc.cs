using System.Xml.Linq;

namespace Bb.Projects
{
    public class AddRazorSupportForMvc : PropertyKey
    {

        public AddRazorSupportForMvc(bool value) : base("AddRazorSupportForMvc", value ? "true" : "false")
        {

        }

        public override XObject Serialize()
        {
            return new XElement(Name, Value);
        }

    }

}
