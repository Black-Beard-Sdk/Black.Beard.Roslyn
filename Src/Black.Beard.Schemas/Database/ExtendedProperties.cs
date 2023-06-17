namespace Bb.Schemas.Database
{
    public class ExtendedProperties
    {

        public ExtendedProperties(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public ExtendedProperties Add(string key, object value)
        {

            if (_tableProperties.ContainsKey(key))
                _tableProperties.Remove(key);

            _tableProperties.Add(key, value);

            return this;

        }

        private Dictionary<string, object> _tableProperties = new Dictionary<string, object>();

    }

}
