using System.Xml.Linq;

namespace Bb.Projects
{
    public class SqlCmdVariable : PropertyKey
    {

        public SqlCmdVariable(string value) : base("SqlCmdVariable", value)
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
