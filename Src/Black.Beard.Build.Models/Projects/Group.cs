using System.Xml.Linq;

namespace Bb.Projects
{
    public class Group
    {

        public Group(bool duplicateMode)
        {
            this._duplicateMode = duplicateMode;
            this._keys = new List<PropertyKey>();
            this._subs = new List<Group>();
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

        public Group Add(string key, Uri value)
        {
            Add(new PropertyKey(key, value.ToString()));
            return this;
        }

        public Group Add(string key, Guid value)
        {
            Add(new PropertyKeyGuid(key, value));
            return this;
        }

        public Group Add(string key, string value)
        {
            Add(new PropertyKey(key, value));
            return this;
        }

        public Group Add(string key, bool value)
        {
            Add(new PropertyKeyBool(key, value));
            return this;
        }

        public Group AddVersion(string key, string value)
        {
            Add(new PropertyKeyVersion(key, new Version(value)));
            return this;
        }

        public Group Add(string key, Version value)
        {
            Add(new PropertyKeyVersion(key, value));
            return this;
        }

        public Group Add(Group value)
        {
            this._subs.Add(value);
            return this;
        }

        public virtual void Serialize(XElement parent)
        {

            foreach (var item in _keys)
            {
                var xml = item.Serialize();
                parent.Add(xml);
            }

            foreach (var item in _subs)
            {
                var xml = item.Serialize();
                parent.Add(xml);
            }

        }

        public bool _duplicateMode { get; }

        private readonly List<PropertyKey> _keys;
        private readonly List<Group> _subs;

    }

}
