using NJsonSchema;
using System.Data;

namespace Bb.Schemas
{


    public abstract class JsonSchemaVisitor<T>
    {

        protected void ReleaseMe(JsonSchemaVisitor<T>.Context context)
        {



        }

        public JsonSchemaVisitor()
        {

        }

        public T Visit(JsonSchema schema, string name)
        {

            if (schema.Definitions != null)
                foreach (var p in schema.Definitions.ToArray())
                {
                    var u = Visit(p.Value, p.Key);
                }

            T result;

            if (schema is JsonSchemaProperty property)
                result = VisitProperty(property);
            else
                result = VisitModel(schema, name);

            return result;

        }

        protected virtual T VisitModel(JsonSchema schema, string name)
        {

            if (string.IsNullOrEmpty(name))
                name = EvaluateModelName(schema);

            var result = AddOutputModels(schema, name, CreateModel(schema, name));

            ParseProperties(schema, result);

            return result;

        }

        protected List<Object> ParseProperties(JsonSchema schema, T result)
        {

            if (result == null)
                throw new ArgumentNullException(nameof(result));

            List<Object> properties = new List<Object>();
            foreach (var item in schema.Properties)
            {
                T resultProperty = Visit(item.Value, String.Empty);
                AppendProperty(result, resultProperty);
                properties.Add(resultProperty);
            }

            return properties;

        }

        protected abstract void AppendProperty(T parent, T child);

        protected abstract T VisitProperty(JsonSchemaProperty property);

        protected abstract T CreateModel(JsonSchema schema, string name);

        protected virtual string EvaluateModelName(JsonSchema schema)
        {
            if (schema.HasTypeNameTitle)
                return schema.Title;

            Stop();
            return null;

        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Diagnostics.DebuggerStepThrough]
        protected static void Stop()
        {

            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();

        }

        public IEnumerable<T1> GetModels<T1>()
            where T1 : T
        {
            foreach (T1 item in _objects.Values)
                yield return item;
        }

        protected T AddOutputModels(JsonSchema schema, string name, T item)
        {

            if (!_schemas.TryGetValue(schema, out var result))
                _schemas.Add(schema, name);

            if (!_objects.ContainsKey(name))
                _objects.Add(name, item);

            return item;

        }

        protected T AddMemberModels(T item)
        {
            _members.Add(item);
            return item;
        }

        protected string GetName(JsonSchema schema)
        {

            if (_schemas.TryGetValue(schema, out var result))
                return result;

            Stop();

            return null;

        }

        protected IEnumerable<T1> GetMembers<T1>()
            where T1 : T
        {
            foreach (T1 item in _members)
                yield return item;
        }

        protected void ClearMember()
        {
            _members.Clear();
        }

        private Dictionary<JsonSchema, string> _schemas = new Dictionary<JsonSchema, string>();
        private Dictionary<string, T> _objects = new Dictionary<string, T>();
        private List<T> _members = new List<T>();

        private Stack<Context> _stack = new Stack<Context>();

        protected Context CurrentContext()
        {
            if (this._stack.Count > 0)
                return this._stack.Peek();
            return null;
        }

        protected Context ChildContext()
        {
            return new Context(this, CurrentContext());
        }


        protected class Context : IDisposable
        {

            public Context(JsonSchemaVisitor<T> parent, Context contextParent)
            {
                this._parent = parent;
                this._contextParent = contextParent;
                _parent._stack.Push(this);
                this._dic = new Dictionary<string, object>();
            }

            public Context Parent { get { return _contextParent; } }

            public object this[string key]
            {
                get { return _dic[key]; }
                set { _dic[key] = value; }
            }

            public void Dispose()
            {

                var o = _parent._stack.Pop();

                if (o != this)
                    throw new InvalidOperationException("context not expected");

                _parent.ReleaseMe(this);

            }

            private readonly JsonSchemaVisitor<T> _parent;
            private readonly JsonSchemaVisitor<T>.Context _contextParent;
            private readonly Dictionary<string, object> _dic;

        }


    }


}