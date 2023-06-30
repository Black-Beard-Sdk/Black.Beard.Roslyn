using System.Xml.Linq;

namespace Bb.Projects
{
    public class Reference : PropertyKey
    {

        public Reference(string value, string path) : base("Reference", value)
        {
            this._path = path;
        }

        public override XObject Serialize()
        {

            var result = new XElement(KeyName,
                new XAttribute("Include", Value),
                new XElement("HintPath", _path)
                );

            return result;

        }

        private readonly string _path;

    }

}
