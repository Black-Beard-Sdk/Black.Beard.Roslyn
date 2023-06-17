using Newtonsoft.Json.Linq;

namespace Bb.Projects.Properties
{
    public abstract class BuilderBase
    {

        public BuilderBase()
        {
            _items = new List<KeyValuePair<string, BuilderBase>>();
        }

        protected void Add(string name, BuilderBase builder)
        {
            _items.Add(new KeyValuePair<string, BuilderBase>(name, builder));
        }

        protected void Add(string name, string value)
        {
            _items.Add(new KeyValuePair<string, BuilderBase>(name, new BuilderString(value)));
        }

        protected void Add(string name, int value)
        {
            _items.Add(new KeyValuePair<string, BuilderBase>(name, new BuilderInt(value)));
        }

        protected void Add(string name, Uri value)
        {
            _items.Add(new KeyValuePair<string, BuilderBase>(name, new BuilderUri(value)));
        }

        protected void Add(string name, params Uri[] values)
        {
            _items.Add(new KeyValuePair<string, BuilderBase>(name, new BuilderUriList(values)));
        }

        protected void Add(string name, bool value)
        {
            _items.Add(new KeyValuePair<string, BuilderBase>(name, new BuilderBool(value)));
        }

        protected IEnumerable<KeyValuePair<string, BuilderBase>> GetItems()
        {

            return _items;

        }

        internal abstract JToken GetModel();

        public override string ToString()
        {
            return GetModel().ToString(Newtonsoft.Json.Formatting.Indented);
        }

        private List<KeyValuePair<string, BuilderBase>> _items;

    }


}
