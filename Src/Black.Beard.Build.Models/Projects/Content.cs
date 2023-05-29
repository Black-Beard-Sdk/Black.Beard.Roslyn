using System.Xml.Linq;

namespace Bb.Projects
{

    public class Content : Group
    {

        public Content() : base("Content", true)
        {
            
        }

        public Content Update(string value)
        {
            AddAttribute("Update", value);
            return this;
        }

        public Content Include(string value)
        {
            AddAttribute("Include", value);
            return this;
        }

        public Content CopyToOutputDirectory(StrategyCopyEnum strategyCopy)
        {
            Add(new PropertyKey("CopyToOutputDirectory", strategyCopy.ToString()));
            return this;
        }

        public Content CopyToPublishDirectory(StrategyCopyEnum strategyCopy)
        {
            Add(new PropertyKey("CopyToPublishDirectory", strategyCopy.ToString()));
            return this;
        }

    }

    public enum StrategyCopyEnum
    {
        Never,
        Always,
        PreserveNewest
    }


}
