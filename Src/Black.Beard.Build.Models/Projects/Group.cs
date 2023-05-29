using System.Xml.Linq;

namespace Bb.Projects
{
    public class Group
    {

        public Group(string name, bool duplicateMode)
        {
            this.Name = name;
            this._duplicateMode = duplicateMode;
            this._keys = new List<PropertyKey>();
            this._subs = new List<Group>();
            this._attributes = new Dictionary<string, XAttribute>();
        }

        public Group Add(XAttribute value)
        {
            this._attributes.Add(value.Name.LocalName, value);
            return this;
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

        public Group AddAttribute(string key, string value)
        {
            Add(new XAttribute(key, value));
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

        public virtual XObject Serialize()
        {
            var child = new XElement(Name);
            Map(child);
            return child;
        }

        public virtual void Serialize(XElement parent)
        {
            var child = new XElement(Name);
            Map(child);
            parent.Add(child);
        }

        protected void Map(XElement parent)
        {

            foreach (var child in this._attributes)
                parent.Add(child.Value);

            foreach (var item in _keys)
                item.Serialize(parent);

            foreach (Group group in _subs)
                group.Serialize(parent);

        }

        public string Name { get; }
        public bool _duplicateMode { get; }

        private readonly Dictionary<string, XAttribute> _attributes;
        private readonly List<PropertyKey> _keys;
        private readonly List<Group> _subs;

    }

}
