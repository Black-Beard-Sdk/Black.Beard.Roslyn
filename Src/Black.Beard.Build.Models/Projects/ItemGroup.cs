using System.IO;
using System.Xml.Linq;

namespace Bb.Projects
{
    public class ItemGroup : Group
    {

        public ItemGroup(bool duplicateMode = true) : base(duplicateMode)
        {
        }

        public XElement Serialize()
        {
            var result = new XElement("ItemGroup");
            Serialize(result);
            return result;
        }

        public new ItemGroup None(Action<None> initializer)
        {
            
            var none = new None();

            if (initializer != null)
                initializer(none);

            Add(none);

            return this;

        }

    }

    public class None : Group
    {

        public None(bool duplicateMode = true) : base(duplicateMode)
        {
        }

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
            Serialize(result);
            return result;
        }

    }

}
