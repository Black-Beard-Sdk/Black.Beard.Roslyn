using Newtonsoft.Json.Linq;

namespace Bb.Projects.Properties
{
    public class EnironmentVariablesBuilder : BuilderBase
    {

        public EnironmentVariablesBuilder Add(string name, string value)
        {
            base.Add(name, value);
            return this;
        }

        internal override JToken GetModel()
        {

            List<JToken> list = new List<JToken>();

            foreach (var item in base.GetItems())
                list.Add(new JProperty(item.Key, item.Value.GetModel()));

            return new JObject(list);

        }


    }


}
