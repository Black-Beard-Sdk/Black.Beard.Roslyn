using System.Xml.Linq;

namespace Bb.Build
{
    public class Reference : PropertyKey
    {

        public Reference(string value, string path) : base("Reference", value)
        {
            this._path = path;
        }

        public override XObject Serialize()
        {

            var result = new XElement(Name,
                new XAttribute("Include", Value),
                new XElement("HintPath", _path)
                );

            return result;

        }

        private readonly string _path;

    }

}
