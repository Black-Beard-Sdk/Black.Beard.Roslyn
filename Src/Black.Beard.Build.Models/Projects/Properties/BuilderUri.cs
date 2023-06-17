using Newtonsoft.Json.Linq;

namespace Bb.Projects.Properties
{
    public class BuilderUri : BuilderBase
    {

        public BuilderUri(Uri value)
        {
            Value = value;
        }

        public Uri Value { get; }

        internal override JToken GetModel()
        {
            return new JValue(Value.ToString());
        }

    }


}
