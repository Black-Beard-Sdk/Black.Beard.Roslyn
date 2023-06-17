using System.IO;
using System.Xml.Linq;

namespace Bb.Projects
{
    public class ItemGroup : Group
    {

        public ItemGroup(bool duplicateMode = true) : base("ItemGroup", duplicateMode)
        {
        }

        public new ItemGroup None(string filename, Action<None> initializer)
        {
            
            var none = new None(filename);

            if (initializer != null)
                initializer(none);

            Add(none);

            return this;

        }

        public ItemGroup Content(Action<Content> initializer)
        {

            var content = new Content();

            if (initializer != null)
                initializer(content);

            Add(content);

            return this;

        }

    }

}
