using System.Xml.Linq;

namespace Bb.Projects
{
    public class Group
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Group"/> class.
        /// </summary>
        /// <param name="key">The name.</param>
        /// <param name="duplicateMode">if set to <c>true</c> [duplicate mode].</param>
        /// <exception cref="System.ArgumentNullException">name</exception>
        public Group(string key, bool duplicateMode)
        {

            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key);

            this.KeyName = key;

            this.DuplicateMode = duplicateMode;

            this._keys = new List<PropertyKey>();
            this._subs = new List<Group>();
            this._attributes = new Dictionary<string, XAttribute>();

        }

        /// <summary>
        /// Adds a new property key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The uri value.</param>
        /// <returns></returns>
        public Group Add(string key, Uri value)
        {
            Add(new PropertyKey(key, value.ToString()));
            return this;
        }

        /// <summary>
        /// Adds a new property key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Group Add(string key, Guid value)
        {
            Add(new PropertyKeyGuid(key, value));
            return this;
        }

        /// <summary>
        /// Adds a new property key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Group Add(string key, string value)
        {
            Add(new PropertyKey(key, value));
            return this;
        }

        /// <summary>
        /// Adds a new property key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds a new property key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value version.</param>
        /// <returns></returns>
        public Group Add(string key, Version value)
        {
            Add(new PropertyKeyVersion(key, value));
            return this;
        }

        /// <summary>
        /// Adds the specified group.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Group Add(Group value)
        {
            this._subs.Add(value);
            return this;
        }

        /// <summary>
        /// Adds the specified property key.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Group Add(PropertyKey value)
        {
            if (!DuplicateMode)
            {
                var items = this._keys.Where(c => c.KeyName == value.KeyName).ToList();
                foreach (var item in items)
                    this._keys.Remove(item);
            }
            this._keys.Add(value);
            return this;
        }


        /// <summary>
        /// Adds the specified attribute.
        /// </summary>
        /// <param name="value">The value is <see cref="T:XAttribute"/>.</param>
        /// <returns></returns>
        public Group Add(XAttribute value)
        {
            this._attributes.Add(value.Name.LocalName, value);
            return this;
        }

        /// <summary>
        /// Adds a new attribute.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Group AddAttribute(string key, string value)
        {
            Add(new XAttribute(key, value));
            return this;
        }

        public virtual XObject Serialize()
        {
            var child = new XElement(KeyName);
            Map(child);
            return child;
        }

        public virtual void Serialize(XElement parent)
        {
            var child = new XElement(KeyName);
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

        public string KeyName { get; }

        public bool DuplicateMode { get; }

        private readonly Dictionary<string, XAttribute> _attributes;
        private readonly List<PropertyKey> _keys;
        private readonly List<Group> _subs;

    }

}
