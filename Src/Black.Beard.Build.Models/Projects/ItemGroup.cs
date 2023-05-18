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

        public new ItemGroup None(string filename, Action<None> initializer)
        {
            
            var none = new None(filename);

            if (initializer != null)
                initializer(none);

            Add(none);

            return this;

        }

    }

}
