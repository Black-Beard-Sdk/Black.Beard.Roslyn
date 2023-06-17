using System.Data;

namespace Bb.Schemas.Database
{


    public class CreateDatasetOptions
    {

        public CreateDatasetOptions()
        {
            
        }

        public bool MergeObjectByDefault { get; set; } = true;


        /// <summary>
        /// If the strategy of merge is activated, Specyfiy the limit of column by table.
        /// </summary>
        public int MaxColumns { get; set; } = 300;


        public CreateDatasetOptions CustomiseTable(string key, object value)
        {

            if (_tableProperties.ContainsKey(key))
                _tableProperties.Remove(key);

            _tableProperties.Add(key, value);

            return this;

        }

        public CreateDatasetOptions CustomiseTable(ExtendedProperties value)
        {

            if (_tableProperties.ContainsKey(value.Name))
                _tableProperties.Remove(value.Name);

            _tableProperties.Add(value.Name, value);

            return this;

        }

        public void AddExtendedProperties(DataTable table)
        {

            foreach (var item in _tableProperties)
                table.ExtendedProperties.Add(item.Key, item.Value);

        }

        private Dictionary<string, object> _tableProperties = new Dictionary<string, object>();

    }

}
