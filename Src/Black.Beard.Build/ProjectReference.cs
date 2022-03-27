using System.Xml.Linq;

namespace Bb.Build
{
    public class ProjectReference : PropertyKey
    {

        public ProjectReference(string value) : base("ProjectReference", value)
        {
            
        }

        public override XObject Serialize()
        {
            var result = new XElement(Name,
                new XAttribute("Include", Value)               
                );


            return result;

        }
     

    }

}
