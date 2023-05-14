using System.Xml.Linq;

namespace Bb.Projects
{
    public class InitialTargets : PropertyKey
    {

        public InitialTargets(string value) : base("InitialTargets", value)
        {

        }
       
        public override XObject Serialize()
        {
            return new XAttribute(Name, Value);
        }

    }

}
