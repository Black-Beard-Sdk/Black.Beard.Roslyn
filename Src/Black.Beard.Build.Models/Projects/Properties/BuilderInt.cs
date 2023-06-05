using Newtonsoft.Json.Linq;

namespace Bb.Projects.Properties
{
    public class BuilderInt : BuilderBase
    {

        public BuilderInt(int value)
        {
            Value = value;
        }

        public int Value { get; }

        internal override JToken GetModel()
        {
            return new JValue(Value);
        }

    }


}
