using System.Xml.Linq;

namespace Bb.Build
{
    public class SqlCmdVariable : PropertyKey
    {

        public SqlCmdVariable(string value) : base("SqlCmdVariable", value)
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
