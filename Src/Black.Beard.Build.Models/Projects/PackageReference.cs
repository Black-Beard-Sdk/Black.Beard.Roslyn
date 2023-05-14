using System.Xml.Linq;

namespace Bb.Projects
{

    public class PackageReference : PropertyKey
    {

        public PackageReference(string value, Version version) : base("PackageReference", value)
        {
            this._version = version;
        }

        public override XObject Serialize()
        {
            var result = new XElement(Name,
                new XAttribute("Include", Value), 
                new XAttribute("Version", _version)
                );


            return result;

        }

        private readonly Version _version;

    }

}
