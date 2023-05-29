using System.Xml.Linq;

namespace Bb.Projects
{


    public class ProjectReference : Group
    {

        public ProjectReference(string value) : base("ProjectReference", true)
        {
            AddAttribute("Include", value);   
        }

    }

}
