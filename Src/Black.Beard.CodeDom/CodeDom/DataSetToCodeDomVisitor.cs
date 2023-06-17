
using Bb.Schemas.Database.CodeDom;
using System.CodeDom;
using System.Data;

namespace Bb.Schemas.Database
{

    public class DataSetToCodeDomVisitor
    {

        public DataSetToCodeDomVisitor(DataSetToCodeDomOption options = null)
        {

            if (options == null)
                options = new DataSetToCodeDomOption();

            this._options = options;

            _targetServer = options.TargetServer;
            _targetServer.Apply();

            CodeCompileUnit = new CodeCompileUnit();

        }

        public CodeCompileUnit CodeCompileUnit { get; }

        public List<CodeNamespace> Visit(DataSet node)
        {

            List<CodeNamespace> _documents = new List<CodeNamespace>();

            foreach (DataTable item in node.Tables)
            {

                var code = new CodeNamespace(item.TableName);
                code.UserData["kind"] = "table";
                code.UserData["name"] = item.TableName;

                _documents.Add(code);

                var result = Visit(item);
                code.Types.Add(result);

                CodeCompileUnit.Namespaces.Add(code);

            }

            foreach (DataRelation item in node.Relations)
            {

                var code = new CodeNamespace(item.RelationName);
                code.UserData["kind"] = "relationship";
                code.UserData["name"] = item.RelationName;

                _documents.Add(code);

                var relationship = Visit(item);
                code.Types.Add(relationship);

                CodeCompileUnit.Namespaces.Add(code);

            }

            CodeCompileUnit.Namespaces.AddRange(_documents.ToArray());

            return _documents;

        }

        public CreateTableTypeDeclaration Visit(DataTable node)
        {

            var table = new CreateTableTypeDeclaration(node.CreateTableReference());

            _targetServer.InitializeTable(table);

            foreach (DataColumn item in node.Columns)
            {
                var column = Visit(item);
                table.Members.Add(column);
            }

            if (!_options.PrimaryKeyInline || node.PrimaryKey.Length > 1)
            {

                CodeMemberColumnPrimaryDeclarationCollection keys = new CodeMemberColumnPrimaryDeclarationCollection();
                table.Members.Add(keys);
                foreach (DataColumn item in node.PrimaryKey)
                {

                    foreach (var item2 in table.Members)
                    {
                        if (item2 is CodeMemberColumnDeclaration c)
                        {

                            var key = new CodeMemberColumnPrimaryDeclaration(c)
                            {
                                Asc = true
                            };

                            keys.Keys.Add(key);
                            break;

                        }
                    }

                }
                _targetServer.ApplyPrimaryKeys(keys, table, node);
            }

            _targetServer.ApplyTable(table);

            return table;

        }

        public CodeMemberColumnDeclaration Visit(DataColumn node)
        {


            var field = new CodeMemberColumnDeclaration(node.ColumnName)
            {
                Type = node.DataType.ToReference(),
                AllowDBNull = node.AllowDBNull,
                Description = node.Caption,
            };


            if (_options.PrimaryKeyInline)
            {
                if (node.Table.PrimaryKey.Count() == 1 && node.Table.PrimaryKey.Contains(node))
                    field.IsPrimaryKey = true;
            }
            else if (node.Unique)
            {
                field.IsUnique = true;
            }

            if (node.DateTimeMode != DataSetDateTime.Unspecified && node.DateTimeMode != DataSetDateTime.UnspecifiedLocal)
            {

                Stop();

                switch (node.DateTimeMode)
                {
                    case DataSetDateTime.Local:
                        break;
                    case DataSetDateTime.Unspecified:
                        break;
                    case DataSetDateTime.UnspecifiedLocal:
                        break;
                    case DataSetDateTime.Utc:
                        break;
                    default:
                        break;
                }

            }

            if (node.DefaultValue != null && node.DefaultValue != DBNull.Value)
            {
                Stop();
            }

            if (!string.IsNullOrEmpty(node.Expression))
            {
                Stop();
            }

            if (node.MaxLength > 0)
            {
                Stop();
            }

            if (!string.IsNullOrEmpty(node.Namespace))
            {
                Stop();

            }

            if (!string.IsNullOrEmpty(node.Prefix))
            {
                Stop();
            }



            if (node.AutoIncrement)
            {
                Stop();
            }

            return field;

        }

        private CodeTypeDeclaration Visit(DataRelation node)
        {

            var tableReference = node.ParentTable.CreateReference();
            var tableToAlter = new AlterTableTypeDeclaration(tableReference);
            var contraint = new CodeContraintDeclaration(node.RelationName)
            {
            };

            foreach (var item in node.ParentColumns)
                contraint.LocalColumns.Add(item.ColumnName.CreateColumnReference());

            DataTable remoteTable = node.ChildTable;
            foreach (var item in node.ChildColumns)
            {
                contraint.RemoteColumns.Add(item.ColumnName.CreateColumnReference());
            }

            contraint.RemoteTable = remoteTable.CreateTableReference();

            tableToAlter.Members.Add(contraint);

            return tableToAlter;

        }

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

        protected void ReleaseMe(DataSetToCodeDomVisitor.Context context)
        {


        }

        protected class Context : IDisposable
        {

            public Context(DataSetToCodeDomVisitor parent, Context contextParent)
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

            private readonly DataSetToCodeDomVisitor _parent;
            private readonly DataSetToCodeDomVisitor.Context _contextParent;
            private readonly Dictionary<string, object> _dic;

        }

        private Stack<Context> _stack = new Stack<Context>();
        private readonly CodeCompileUnit _codeCompileUnit;
        private readonly DataSetToCodeDomOption _options;
        private readonly TargetServer _targetServer;

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Diagnostics.DebuggerStepThrough]
        protected static void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }

    }

}
