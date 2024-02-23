using System.Text;

namespace Bb.Analysis.Traces
{
    public class LocationDefault : ILocation
    {


        public static ILocation Empty = new LocationDefault();


        private LocationDefault()
        {
                
        }


        public object Clone()
        {
            return this;
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("default");
        }


    }

}
