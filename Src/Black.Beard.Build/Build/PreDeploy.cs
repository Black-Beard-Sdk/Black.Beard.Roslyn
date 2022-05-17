using System;
using System.Xml.Linq;

namespace Bb.Build
{
    public class PreDeploy : PropertyKey
    {

        public PreDeploy(string value) : base("PreDeploy", value)
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
