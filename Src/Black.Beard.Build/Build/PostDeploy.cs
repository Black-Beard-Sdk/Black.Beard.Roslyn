using System;
using System.Xml.Linq;

namespace Bb.Build
{
    public class PostDeploy : PropertyKey
    {

        public PostDeploy(string value) : base("PostDeploy", value)
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
