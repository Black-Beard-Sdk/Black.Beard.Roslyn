using System.Xml.Linq;

namespace Bb.Build
{
    public class ItemGroup : Group
    {

        public ItemGroup() : base(true)
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
