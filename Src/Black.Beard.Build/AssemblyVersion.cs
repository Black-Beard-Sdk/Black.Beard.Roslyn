using System;
using System.Xml.Linq;

namespace Bb.Build
{
    public class AssemblyVersion : PropertyKey
    {

        public AssemblyVersion(Version value) : base("AssemblyVersion", value.ToString())
        {

        }

        public override XObject Serialize()
        {
            return new XElement(Name, Value);
        }

    }

}
