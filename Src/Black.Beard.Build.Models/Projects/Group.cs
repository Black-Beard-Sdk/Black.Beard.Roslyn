using System.Xml.Linq;

namespace Bb.Projects
{
    public class Group
    {

        public Group(bool duplicateMode)
        {
            this._duplicateMode = duplicateMode;
            this._keys = new List<PropertyKey>();
        }

        public Group Add(PropertyKey value)
        {
            if (!_duplicateMode)
            {
                var items = this._keys.Where(c => c.Name == value.Name).ToList();
                foreach (var item in items)
                    this._keys.Remove(item);
            }
            this._keys.Add(value);
            return this;
        }

        public Group Add(string key, string value)
        {
            Add(new PropertyKey(key, value));
            return this;
        }

        public virtual void Serialize(XElement parent)
        {

            foreach (var item in _keys)
            {
                var xml = item.Serialize();
                parent.Add(xml);
            }

        }

        public bool _duplicateMode { get; }

        private readonly List<PropertyKey> _keys;


    }

}
