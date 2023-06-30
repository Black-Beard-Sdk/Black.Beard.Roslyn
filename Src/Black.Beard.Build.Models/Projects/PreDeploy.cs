using System.Xml.Linq;

namespace Bb.Projects
{
    public class PreDeploy : PropertyKey
    {

        public PreDeploy(string value) : base("PreDeploy", value)
        {
          
        }

        public override XObject Serialize()
        {
            var result = new XElement(KeyName,
                new XAttribute("Include", Value)
                );

            return result;

        }

    }


}
