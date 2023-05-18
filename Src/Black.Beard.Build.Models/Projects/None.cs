using System.Xml.Linq;

namespace Bb.Projects
{
    public class None : Group
    {

        public None(string filename) : base(true)
        {
            this.Update = filename;
        }

        public string Update { get; }

        public None Pack(bool value = true)
        {
            Add("Pack", value);
            return this;
        }

        public None PackaPath(string value)
        {
            Add("PackaPath", value);
            return this;
        }

        public XElement Serialize()
        {
            var result = new XElement("None");
            result.Add(new XAttribute("Update", this.Update));
            Serialize(result);
            return result;
        }

    }

}
