using System.Xml.Linq;

namespace Bb.Projects
{
    public class PostDeploy : PropertyKey
    {

        public PostDeploy(string value) : base("PostDeploy", value)
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
