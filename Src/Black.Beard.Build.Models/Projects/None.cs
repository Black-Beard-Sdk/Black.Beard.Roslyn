using System.Xml.Linq;

namespace Bb.Projects
{

    public class None : Group
    {

        public None(string filename) : base("None", true)
        {
            Add("Update", filename);
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

    }

}
