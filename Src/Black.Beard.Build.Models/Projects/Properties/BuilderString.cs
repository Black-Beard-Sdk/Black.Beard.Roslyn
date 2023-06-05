using Newtonsoft.Json.Linq;

namespace Bb.Projects.Properties
{
    public class BuilderString : BuilderBase
    {

        public BuilderString(string value)
        {
            Value = value;
        }

        public string Value { get; }

        internal override JToken GetModel()
        {
            return new JValue(Value);
        }

    }


}
