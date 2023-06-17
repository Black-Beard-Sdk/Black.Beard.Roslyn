using Bb.DacPacs;
using Bb.Sql;
using Bb.StarteKit.Components.Sql;
using System.Data;
using System.Xml.Linq;

namespace Bb
{

    public class ConvertStructureToDacPac
    {

        public ConvertStructureToDacPac(string dacpacName, DatabaseStructure db, DacpacContext ctx)
        {

            if (string.IsNullOrEmpty(dacpacName))
                throw new ArgumentNullException("dacpacName");

            _db = db;
            _pack = new DacPackage()
            {
                Name = dacpacName,
            };
            _model = _pack.Schema;
            _ctx = ctx;
        }

        public DacPackage GenerateDacpac()
        {

            foreach (var table in _db.Tables)
                VisitKeys(table);

            foreach (var table in _db.Tables)
            {

                _model.Table(table.Schema, _ctx.ReplaceVariables(table.Name), table.PartitionSchemeName, t =>
                {

                    foreach (var column in table.Columns)
                    {
                        VisitColumn(table, column, t);
                    }

                });

            }

            foreach (var table in _db.Tables)
                VisitIndexes(table);


            foreach (var table in _db.Tables)
            {

                foreach (var foreignKeys in table.ForeignKeys)
                {
                    var remote = foreignKeys.RemoteColumns;
                    Visit(
                        table.Schema, foreignKeys.Name, 
                        table.Name, foreignKeys.LocalColumns.Select(c => c.Name).ToArray(), 
                        remote.TableName, remote.Select(c => c.Name).ToArray()
                    );
                }

            }

            VisitFilegroups();

            VisitSchemas();

            return _pack;

        }

        private void VisitFilegroups()
        {
            HashSet<string> keys = new HashSet<string>();
            foreach (var table in _db.Tables)
            {

                keys.Add(table.PartitionSchemeName);

                foreach (var key in table.Keys)
                    keys.Add(key.PartitionSchemeName);

                foreach (var index in table.Indexes)
                    keys.Add(index.PartitionSchemeName);

            }

            foreach (var item in keys)
                _pack.Schema.FileGroup(item);
        }

        private void VisitSchemas()
        {

            HashSet<string> schemas = new HashSet<string>();

            foreach (var table in _db.Tables)
                schemas.Add(table.Schema);

            foreach (var schema in schemas)
                _db.Schemas.AddSchemaIfNotExists(schema, string.Empty);

            foreach (var item in _db.Schemas)
                _pack.Schema.Schema(item.Name, item.Parent);

        }

        private void VisitKeys(TableDescriptor table)
        {

            foreach (var key in table.Keys)
            {

                var columns = key.Select(c => (c.Name, c.Sort)).ToArray();

                if (columns.Length > 0)
                    _pack.Schema.PrimaryKey(table.Schema, table.Name, table.PartitionSchemeName, key.Clustered, columns, key.Properties);

            }

        }

        private void VisitIndexes(TableDescriptor table)
        {

            string onpartitionSchemeName = table.PartitionSchemeName;

            foreach (var index in table.Indexes)
            {

                var columns = index.Select(c => (c.Name, c.Sort)).ToArray();

                if (columns.Length > 0)
                    _pack.Schema.Index(index.Name, table.Schema, table.Name, onpartitionSchemeName, index.Clustered, index.Unique, columns, index.Properties);
            }

        }

        private void VisitColumn(TableDescriptor currentTable, ColumnDescriptor column, DacRelationship tableSource)
        {

            string tableName = currentTable.Name;
            string @namespace = currentTable.Schema;
            var allowNull = column.AllowNull;
            string columnName = _ctx.ReplaceVariables(column.Name);

            Action<DacSqlSimpleColumn> action = c =>
            {

                if (!string.IsNullOrEmpty(column.Caption))
                {
                    _pack.Schema.Model.SqlDescription(@namespace, tableName, columnName, column.Caption); ;
                }

                //if (node.Unique && !currentTable.Keys.Any(c => c.Name == node.Name))
                //{
                //    //field.IsUnique = true;
                //    Stop();
                //}

                if (column.DefaultValue != null && column.DefaultValue != DBNull.Value)
                {
                    Stop();
                }

                //if (!string.IsNullOrEmpty(node.Expression))
                //{
                //    Stop();
                //}

                //if (!string.IsNullOrEmpty(node.Prefix))
                //{
                //    Stop();
                //}

                //if (node.AutoIncrement)
                //{
                //    Stop();
                //}

            };

            var t = column.Type;
            var typename = t.Type.SqlLabel.ToUpper();
            SqlTypeWithPrecisionDescriptor type;

            switch (typename)
            {


                case SqlServer._BINARY:
                    type = t as SqlTypeWithPrecisionDescriptor ?? throw new Exception("Invalid type");
                    tableSource.ColumnBinary(@namespace, tableName, columnName, allowNull, type.Argument1, action);
                    break;

                case SqlServer._DATETIME:
                    tableSource.ColumnDatetime(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._DATETIMEOFFSET:
                    tableSource.ColumnDatetimeoffset(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._VARCHAR:
                    type = t as SqlTypeWithPrecisionDescriptor ?? throw new Exception("Invalid type");
                    tableSource.ColumnVarchar(@namespace, tableName, columnName, allowNull, type.Argument1, action);
                    break;

                case SqlServer._UNIQUEIDENTIFIER:
                    tableSource.ColumnUniqueIdentifier(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._SMALLINT:
                    tableSource.ColumnSmallInt(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._INT:
                    tableSource.ColumnInt(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._TINYINT:
                    tableSource.ColumnTinyInt(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._BIGINT:
                    tableSource.ColumnBigInt(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._BIT:
                    tableSource.ColumnBit(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._NVARCHAR:
                    type = t as SqlTypeWithPrecisionDescriptor ?? throw new Exception("Invalid type");
                    tableSource.ColumnNVarchar(@namespace, tableName, columnName, allowNull, type.Argument1, action);
                    break;

                case SqlServer._NCHAR:
                    type = t as SqlTypeWithPrecisionDescriptor ?? throw new Exception("Invalid type");
                    tableSource.ColumnNChar(@namespace, tableName, columnName, allowNull, type.Argument1, action);
                    break;

                case SqlServer._CHAR:
                    type = t as SqlTypeWithPrecisionDescriptor ?? throw new Exception("Invalid type");
                    tableSource.ColumnChar(@namespace, tableName, columnName, allowNull, type.Argument1, action);
                    break;

                case SqlServer._REAL:
                    tableSource.ColumnReal(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._FLOAT:
                    tableSource.ColumnFloat(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._DECIMAL:
                    tableSource.ColumnNumeric(@namespace, tableName, columnName, allowNull, 13, 2, action);
                    break;

                case SqlServer._NUMERIC:
                    tableSource.ColumnNumeric(@namespace, tableName, columnName, allowNull, 13, 2, action);
                    break;

                case SqlServer._SMALLMONEY:
                    tableSource.ColumnSmallMoney(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._MONEY:
                    tableSource.ColumnMoney(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._DATE:
                    tableSource.ColumnDate(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._DATETIME2:
                    tableSource.ColumnDatetime2(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._SMALLDATETIME:
                    tableSource.ColumnSmallDatetime(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._TIME:
                    tableSource.ColumnTime(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._TIMESTAMP:
                    tableSource.ColumnTimestamp(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._TEXT:
                    tableSource.ColumnText(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._NTEXT:
                    tableSource.ColumnNText(@namespace, tableName, columnName, allowNull, action);
                    break;

                case SqlServer._VARBINARY:
                    type = t as SqlTypeWithPrecisionDescriptor ?? throw new Exception("Invalid type");
                    tableSource.ColumnVarBinary(@namespace, tableName, columnName, allowNull, type.Argument1, action);
                    break;

                case SqlServer._IMAGE:
                    type = t as SqlTypeWithPrecisionDescriptor ?? throw new Exception("Invalid type");
                    tableSource.ColumnImage(@namespace, tableName, columnName, allowNull, type.Argument1, action);
                    break;

                //case SqlServer._ROWVERSION:
                //    tableSource.ColumnNumeric(@namespace, tableName, columnName, allowNull, 13, 2, action);
                //    break;

                //case SqlServer._SQL_VARIANT:
                //    tableSource.ColumnNumeric(@namespace, tableName, columnName, allowNull, 13, 2, action);
                //    break;

                //case SqlServer._XML:
                //    tableSource.ColumnNumeric(@namespace, tableName, columnName, allowNull, 13, 2, action);
                //    break;

                //case SqlServer._GEOMETRY:
                //    tableSource.ColumnNumeric(@namespace, tableName, columnName, allowNull, 13, 2, action);
                //    break;

                //case SqlServer._GEOGRAPHY:
                //    tableSource.ColumnNumeric(@namespace, tableName, columnName, allowNull, 13, 2, action);
                //    break;

                //    switch (node.DateTimeMode)
                //    {
                //case DataSetDateTime.Local:
                //            Stop();
                //            t.ColumnDatetime(@namespace, name, node.Name, allowNull, action);
                //            break;
                //        case DataSetDateTime.Unspecified:
                //            Stop();
                //            break;
                //        case DataSetDateTime.UnspecifiedLocal:
                //            Stop();
                //            break;
                //        case DataSetDateTime.Utc:
                //            Stop();
                //            break;
                //        default:
                //            Stop();
                //            break;
                //    }

                //case SqlServer._FILESTREAM:
                //    tableSource.ColumnStream(@namespace, tableName, columnName, allowNull, action);
                //    break;

                default:
                    Stop();
                    break;
            }

        }

        private void Visit(string schema, string relationName, string parentTableName, string[] parentColumns, string childTableName, string[] childColumns)
        {

            _pack.Schema.ForeignKey(
                  schema, relationName
                , parentTableName, parentColumns
                , childTableName, childColumns
            );

        }


        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Diagnostics.DebuggerStepThrough]
        protected static void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }

        private readonly DatabaseStructure _db;
        private readonly DacDataSchemaModel _model;
        private readonly DacPackage _pack;
        private readonly DacpacContext _ctx;

    }



}