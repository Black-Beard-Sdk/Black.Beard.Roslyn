using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Schemas.Database
{

    public class CreateDataSet
    {

        public CreateDataSet(CreateDatasetOptions options = null)
        {
            this._options = options ?? new CreateDatasetOptions();
            this._dataset = new DataSet();
            this._parser = new ParserModel() { Kind = ParserModelEnum.Root };
        }


        public DataSet DataSet { get { return this._dataset; } }


        public ParserModel Parser { get { return this._parser; } }


        public DataTable Visit(JArray node, string tablename, ParserModel parserParent = null)
        {

            if (parserParent == null)
                parserParent = this._parser;

            using (var ctxChild = ChildContext())
            {

                var parserArray = new ParserModel() { Kind = ParserModelEnum.ParseArray };
                parserParent.Add(parserArray);

                var currentParser = new ParserModel();

                DataTable table = null;
                if (_dataset.Tables.Contains(tablename))
                    table = _dataset.Tables[tablename];

                else
                {
                    table = CreateTable(tablename);
                    table.ExtendedProperties.Add("Caption", $"path : {node.Path}");
                }

                JTokenType type = JTokenType.Undefined;
                Type typeValue = null;
                foreach (var item in node)
                {
                    if (item is JObject o)
                    {
                        currentParser.Kind = ParserModelEnum.Object;
                        if (type != JTokenType.Undefined && type != o.Type)
                        {
                            Stop();
                        }
                        VisitTable(o, table, currentParser);
                        type = item.Type;
                    }
                    else if (item is JValue v)
                    {
                        currentParser.Kind = ParserModelEnum.Value;
                        var typeValueN = v.Value?.GetType();
                        var notExists = !table.Columns.Contains("value");
                        if (type != JTokenType.Undefined && type != v.Type)
                        {
                            Stop();
                        }
                        else if (typeValue != null && typeValueN != null && typeValueN != v.Value.GetType())
                        {
                            Stop();
                        }
                        else if (notExists)
                        {
                            DataColumn column = new DataColumn("value", typeValueN);
                            column.AllowDBNull = true;
                            table.Columns.Add(column);
                            currentParser.Add(new ParserModel() { Kind = ParserModelEnum.Object, TargetPath = column });
                            typeValue = typeValueN;
                        }

                    }
                    else if (item is JArray a2)
                    {
                        Stop();
                    }
                    else
                    {
                        Stop();
                    }
                }

                parserArray.Add(currentParser);

                return table;

            }

        }

        protected void VisitTable(JObject node, DataTable table, ParserModel parser, string suffix = "")
        {

            List<KeyValuePair<JProperty, JObject>> list = new List<KeyValuePair<JProperty, JObject>>();

            foreach (var property in node.Properties())
            {

                var name = suffix + property.Name;
                if (table.Columns.Contains(name))
                {

                    var column = table.Columns[name];
                    if (property.Value is JValue v)
                    {

                        var type = v.Value?.GetType() ?? typeof(object);
                        if (column.DataType != type)
                        {

                            Stop();

                        }
                    }

                    else if (property.Value is JObject o)
                    {
                        Stop();

                    }

                    else if (property.Value is JArray a)
                    {
                        Stop();

                    }
                    else
                    {
                        Stop();
                    }

                }
                else
                {

                    var parserProperty = new ParserModel() { Kind = ParserModelEnum.Property, SourcePath = property.Name };

                    if (property.Value is JValue v)
                    {
                        parser.Add(parserProperty);
                        parserProperty.TargetPath = table.CreateColumn(name, v.Value?.GetType() ?? typeof(object), $"path : {property.Path}", false);
                    }

                    else if (property.Value is JObject o)
                        list.Add(new KeyValuePair<JProperty, JObject>(property, o));

                    else if (property.Value is JArray a)
                    {
                        var colName = $"{table.TableName}_$id";
                        var exists = _dataset.Tables.Contains(name);
                        parser.Add(parserProperty);
                        var tableSub = Visit(a, name, parserProperty);
                        if (!exists)
                        {
                            var column = tableSub.CreateColumn(colName, typeof(Guid), $"path : {property.Path}", true, 1);
                            _dataset.Relations.Add(new DataRelation($"rel_{table.TableName}_to{tableSub.TableName}", column, table.PrimaryKey[0]));
                        }
                    }
                    else
                    {
                        Stop();
                    }

                }
            }

            foreach (KeyValuePair<JProperty, JObject> item in list)
            {

                var parserProperty = new ParserModel() { Kind = ParserModelEnum.Property, SourcePath = item.Key.Name };
                parser.Add(parserProperty);

                if (_options.MergeObjectByDefault && _options.MaxColumns > (table.Columns.Count + item.Value.Properties().Count()))
                {
                    using (var ctx2 = ChildContext()) // Object simple. on projet dans l'object courrant les propriété de l'objet du dessus.
                    {
                        VisitTable(item.Value, table, parserProperty, item.Key.Name + "_");
                    }
                }
                else // Create sub table
                {
                    Stop();
                    var tableSub = CreateTable(item.Key.Name);
                    VisitTable(item.Value, tableSub, parserProperty, item.Key.Name + "_");
                    var column = tableSub.CreateColumn($"{table.TableName}_$id", typeof(Guid), $"auto generated primary key", true);
                    _dataset.Relations.Add(new DataRelation($"rel_{table.TableName}_to{tableSub.TableName}", column, table.PrimaryKey[0]));
                }

            }

        }

        private DataTable CreateTable(string tablename)
        {

            try
            {

                var table = new DataTable(tablename);
                DataColumn column1 = new("_$id", typeof(Guid));
                table.Columns.Add(column1);
                table.PrimaryKey = new DataColumn[] { column1 };
                this._dataset.Tables.Add(table);
                this._options.AddExtendedProperties(table);

                return table;

            }
            catch (Exception ex)
            {
                Stop();
                throw;
            }

        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Diagnostics.DebuggerStepThrough]
        protected static void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }

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

            public Context(CreateDataSet parent, Context contextParent)
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

            private readonly CreateDataSet _parent;
            private readonly Context _contextParent;
            private readonly Dictionary<string, object> _dic;

        }

        private void ReleaseMe(Context context)
        {

        }

        private readonly CreateDatasetOptions _options;
        private DataSet _dataset;
        private readonly ParserModel _parser;

    }

    public enum ParserModelEnum
    {
        ParseArray,
        Root,
        Property,
        Object,
        Value
    }


}
