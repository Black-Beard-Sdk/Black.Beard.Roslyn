using System.Xml.Linq;

namespace Bb.Build
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
