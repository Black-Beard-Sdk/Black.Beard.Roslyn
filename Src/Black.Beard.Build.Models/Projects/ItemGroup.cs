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

    }

}
