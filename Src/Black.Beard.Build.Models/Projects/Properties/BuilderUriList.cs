using Newtonsoft.Json.Linq;
using System.Text;

namespace Bb.Projects.Properties
{

    public class BuilderUriList : BuilderBase
    {

        public BuilderUriList()
        {
            Values = new List<BuilderUri>();
        }

        public BuilderUriList(params Uri[] values)
        {
            
            Values = new List<BuilderUri>();

            foreach (var item in values)
                Values.Add(new BuilderUri(item));

        }

        public List<BuilderUri> Values { get; }

        internal override JToken GetModel()
        {
            StringBuilder sb = new StringBuilder();

            string comma  = string.Empty;
            foreach (BuilderUri item in Values)
            {
                sb.Append(comma);
                sb.Append(item.ToString().Trim('"').Trim('/'));
                comma = ";";
            }
            return new JValue(sb.ToString());
        }

    }


}
