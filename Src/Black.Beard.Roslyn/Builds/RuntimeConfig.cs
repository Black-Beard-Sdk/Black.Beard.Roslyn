using System.Text.Json.Nodes;

namespace Bb.Builds
{
    public class RuntimeConfig
    {

        public RuntimeConfig()
        {
            int numberOfProcessors = Environment.ProcessorCount * 2;
            _properties.Add(_systemGCConcurrent, JsonValue.Create(false));
            _properties.Add(_systemThreadingThreadPoolMinThreads, JsonValue.Create(4));
            _properties.Add(_systemThreadingThreadPoolMaxThreads, JsonValue.Create(numberOfProcessors));
        }

        public void Set(string key, object rawValue)
        {

            var value = JsonValue.Create(rawValue);

            if (_properties.ContainsKey(key))
                _properties[key] = value;

            else
                _properties.Add(key, value);

        }

        public T Get<T>(string key)
        {

            if (_properties.TryGetValue(key, out JsonValue value))
                return value.GetValue<T>();

            return default(T);

        }


        public bool GCConcurrent
        {
            get => Get<bool>(_systemGCConcurrent);
            set => Set(_systemGCConcurrent, value);
        }


        public int MinThreads
        {
            get => Get<int>(_systemThreadingThreadPoolMinThreads);
            set => Set(_systemThreadingThreadPoolMinThreads, value);
        }


        public int MaxThreads
        {
            get => Get<int>(_systemThreadingThreadPoolMaxThreads);
            set => Set(_systemThreadingThreadPoolMaxThreads, value);
        }


        public void SetFramework(FrameworkVersion framework)
        {

            this.runtimeOptions = new JsonObject()
            {
                ["tfm"] = framework.Key.Name,
                ["framework"] = new JsonObject()
                {
                    ["name"] = framework.Type.Name,
                    ["version"] = framework.Version.ToString(),
                },
            };

        }


        public override string ToString()
        {

            var prop = new JsonObject();
            foreach (var item in _properties)
                prop.Add(item.Key, item.Value);

            var result = new JsonObject()
            {
                [_runtimeOptions] = this.runtimeOptions,
                [_configProperties] = prop
            };

            return result.ToJsonString(new System.Text.Json.JsonSerializerOptions() { WriteIndented = true });

        }

        private const string _runtimeOptions = "runtimeOptions";
        private const string _configProperties = "configProperties";

        private const string _systemGCConcurrent = "System.GC.Concurrent";
        private const string _systemThreadingThreadPoolMinThreads = "System.Threading.ThreadPool.MinThreads";
        private const string _systemThreadingThreadPoolMaxThreads = "System.Threading.ThreadPool.MaxThreads";

        private Dictionary<string, JsonValue> _properties = new Dictionary<string, JsonValue>();
        private JsonObject runtimeOptions;

    }


    /*

{
    "runtimeOptions": {
        "tfm": "net6.0",
        "framework": {
            "name": "Microsoft.NETCore.App",
            "version": "6.0.27"
        },
        "configProperties": {
            "System.GC.Concurrent": false,
            "System.Threading.ThreadPool.MinThreads": 4,
            "System.Threading.ThreadPool.MaxThreads": 25
        }
    }
}


<PropertyGroup>
    <ConcurrentGarbageCollection>false</ConcurrentGarbageCollection>
    <ThreadPoolMinThreads>4</ThreadPoolMinThreads>
    <ThreadPoolMaxThreads>25</ThreadPoolMaxThreads>
</PropertyGroup>



 */


}
