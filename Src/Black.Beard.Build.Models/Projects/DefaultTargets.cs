using System.Xml.Linq;

namespace Bb.Projects
{
    public class DefaultTargets : PropertyKey
    {

        public DefaultTargets(string value) : base("DefaultTargets", value)
        {

        }               

        public override XObject Serialize()
        {
            return new XAttribute(Name, Value);
        }

    }

}
