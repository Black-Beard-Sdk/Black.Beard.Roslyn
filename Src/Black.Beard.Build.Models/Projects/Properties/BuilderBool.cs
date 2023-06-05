using Newtonsoft.Json.Linq;

namespace Bb.Projects.Properties
{
    public class BuilderBool : BuilderBase
    {

        public BuilderBool(bool value)
        {
            Value = value;
        }

        public bool Value { get; }

        internal override JToken GetModel()
        {
            return new JValue(Value);
        }

    }


}
