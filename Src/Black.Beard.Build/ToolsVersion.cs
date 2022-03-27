using System;
using System.Xml.Linq;

namespace Bb.Build
{
    public class ToolsVersion : PropertyKey
    {

        public ToolsVersion(Version value) : base("ToolsVersion", value.ToString())
        {

        }

        public override XObject Serialize()
        {
            return new XAttribute(Name, Value);
        }

    }

}
