using Bb.Database;
using NJsonSchema;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;

namespace Bb.Schemas.DataSets
{


    public class DataSetJsonSchemaVisitor : JsonSchemaVisitor<object>
    {


        public DataSetJsonSchemaVisitor(TableKey[] keys)
        {
            this._dataSet = new DataSet();
            this._dic = new Dictionary<object, object>();
            this._keys = new Dictionary<string, TableKey>();

            if (keys != null)
                foreach (TableKey key in keys)
                    if (!this._keys.ContainsKey(key.Name))
                        this._keys.Add(key.Name, key);

        }

        public DataSet Model { get => this._dataSet; }


        protected override void AppendProperty(object parent, object child)
        {

            //if (parent is CodeTypeDeclaration type)
            //{

            //    if (child is CodeTypeMember member)
            //    {

            //        type.Members.Add(member);

            //        foreach (var item in this.GetMembers<CodeTypeMember>())
            //            type.Members.Add(item);

            //        this.ClearMember();

            //    }

            //    else
            //    {
            //        Stop();
            //    }

            //}
            //else
            //{
            //    Stop();
            //}

        }

        protected override object VisitProperty(JsonSchemaProperty schema)
        {

            var ctxParent = CurrentContext();

            using (var ctx = ChildContext())
            {

                if (!schema.IsWriteOnly)
                {

                    var fieldName = schema.Name.FormatNameForField();
                    Type type = GetType(schema);
                    if (type == null)
                    {
                        Stop();
                    }

                    var table = ctxParent[Keytable] as DataTable;
                    DataColumn column = new(fieldName, type);
                    table.Columns.Add(column);
                    ctx[Keycolumn] = column;
                    column.AllowDBNull = true;

                    if (schema.IsRequired || schema.MinLength.HasValue && schema.MinLength.Value > 0)
                        column.AllowDBNull = false;

                    if (schema.MaxLength.HasValue && schema.MaxLength.Value > 0)
                        column.MaxLength = schema.MaxLength.Value;

                    if (schema.Description != null)
                        column.ExtendedProperties.Add(KeyDescription, null);

                    if (schema.IsArray)
                    {

                        //var items = schema.Items.ToList();
                        //for (var i = 0; i < items.Count; i++)
                        //{
                        //    Stop();
                        //    var index = i;
                        //    Visit(items[i], null);
                        //}

                        if (schema.Item != null)
                        {
                            Stop();
                            var subTable = Visit(schema.Item, fieldName);
                        }

                        Stop();
                    }


                    if (schema.IsNullableRaw != null)
                    {
                        Stop();
                    }

                    if (schema.IsDictionary)
                    {
                        Stop();
                    }

                    if (schema.IsTuple)
                    {
                        Stop();
                    }

                    if (schema.IsAnyType)
                    {
                        Stop();
                    }

                    if (schema.InheritedTypeSchema != null)
                    {
                        Stop();
                    }

                    if (schema.MinProperties > 0)
                    {
                        Stop();
                    }

                    if (schema.MaxProperties > 0)
                    {
                        Stop();
                    }

                    if (schema.AdditionalItemsSchema != null)
                    {
                        Stop();
                        Visit(schema.AdditionalItemsSchema, null);
                    }

                    if (schema.AdditionalPropertiesSchema != null)
                    {
                        Stop();
                        Visit(schema.AdditionalPropertiesSchema, null);
                    }

                    var allOf = schema.AllOf.ToList();
                    for (var i = 0; i < allOf.Count; i++)
                    {
                        Stop();
                        var index = i;
                        Visit(allOf[i], null);
                    }

                    var anyOf = schema.AnyOf.ToList();
                    for (var i = 0; i < anyOf.Count; i++)
                    {
                        Stop();
                        var index = i;
                        Visit(anyOf[i], null);
                    }

                    if (schema.PatternProperties != null)
                    {
                        foreach (var p in schema.PatternProperties.ToArray())
                        {
                            Stop();
                            Visit(p.Value, null);
                        }
                    }

                    if (schema.DictionaryKey != null)
                    {
                        Stop();
                        Visit(schema.DictionaryKey, null);
                    }


                    var oneOf = schema.OneOf.ToList();
                    for (var i = 0; i < oneOf.Count; i++)
                    {
                        Stop();
                        var index = i;
                        Visit(oneOf[i], null);
                    }

                    if (schema.Not != null)
                    {
                        Stop();
                        Visit(schema.Not, null);
                    }

                    if (schema.ActualDiscriminator != null)
                    {
                        Stop();
                    }


                    if (schema.SchemaVersion != null)
                    {
                        Stop();
                    }

                    if (schema.ActualDiscriminatorObject != null)
                    {
                        Stop();
                    }

                    if (schema.InheritedSchema != null)
                    {
                        Stop();
                    }

                    if (schema.Default != null)
                    {
                        Stop();
                    }

                    if (schema.DeprecatedMessage != null)
                    {
                        Stop();
                    }

                    if (schema.Discriminator != null)
                    {
                        Stop();
                    }

                    if (schema.DiscriminatorObject != null)
                    {
                        Stop();
                    }

                    if (schema.DocumentPath != null)
                    {
                        Stop();
                    }

                    if (schema.ExclusiveMaximum != null)
                    {
                        Stop();
                    }

                    if (schema.ExclusiveMinimum != null)
                    {
                        Stop();
                    }

                    if (schema.ExtensionData != null)
                    {
                        Stop();
                    }

                    if (schema.Id != null)
                    {
                        Stop();
                    }

                    if (schema.MinItems > 0)
                    {
                        Stop();
                    }

                    if (schema.MaxItems > 0)
                    {
                        Stop();
                    }

                    if (schema.MultipleOf != null)
                    {
                        Stop();
                    }

                    if (schema.UniqueItems)
                    {
                        Stop();
                    }

                    return column;

                }

            }

            Stop();
            return null;

        }

        private Type GetType(JsonSchema schema)
        {

            if (schema.Type != JsonObjectType.None)
            {
                switch (schema.Type)
                {

                    case JsonObjectType.Boolean:
                        return typeof(bool);

                    case JsonObjectType.Integer:

                        if (schema.IsEnumeration)
                            return typeof(Int32);

                        if (schema.Format != null)
                        {
                            switch (schema.Format)
                            {

                                case "int32":
                                    return typeof(Int32);

                                default:
                                    Stop();
                                    break;
                            }

                            return typeof(Int64);

                        }
                        return typeof(Int64);

                    case JsonObjectType.Number:
                        return typeof(decimal);

                    case JsonObjectType.String:
                        return typeof(string);

                    case JsonObjectType.File:
                        Stop();
                        break;

                    case JsonObjectType.Array:
                        return typeof(object[]);
                        Stop();
                        break;

                    case JsonObjectType.Null:
                        Stop();
                        break;

                    case JsonObjectType.Object:
                        return typeof(object);

                    case JsonObjectType.None:
                    default:
                        break;
                }
            }
            else if (schema.Reference != null)
            {
                var result = GetType(schema.Reference);
                if (result != null)
                    return result;
                var name = GetName(schema.Reference);
                //if (!string.IsNullOrEmpty(name))
                //    return name;
                Stop();
            }
            //else if (schema.InheritedSchema != null)
            //{

            //    var o = schema.Definitions.FirstOrDefault(c => c.Value == schema.InheritedSchema);

            //    if (!string.IsNullOrEmpty(o.Key))
            //        return o.Key;

            //    else
            //    {
            //        Stop();
            //    }
            //}
            else
            {

                foreach (var item in schema.AllOf)
                {

                    var test = GetType(item);

                    if (test != null)
                        return test;

                }

            }

            Stop();

            throw new NotImplementedException();

        }

        protected override object CreateModel(JsonSchema schema, string name)
        {

            var result = ResolveFrom(schema);
            if (result != null)
                return result;

            using (var ctx = ChildContext())
            {

                var table = new DataTable(name);
                AppendSchema(schema, table);
                this._dataSet.Tables.Add(table);
                ctx[Keytable] = table;

                var itemProperties = ParseProperties(schema, table);

                List<DataColumn> keys = null;
                if (itemProperties.Count > 0)
                    keys = ResolveKeys(table);

                if (keys == null || keys.Count == 0)
                {
                    DataColumn column1 = new($"{name}_id", typeof(Guid));
                    table.Columns.Add(column1);
                    table.PrimaryKey = new DataColumn[] { column1 };
                }

                var type = GetType(schema);
                if (type != null && type != typeof(object))
                {
                    Stop();
                    if (itemProperties.Count == 0)
                    {
                        DataColumn column2 = new("Value", type);
                        table.Columns.Add(column2);
                    }
                }

                if (schema.Enumeration != null && schema.Enumeration.Any())
                {
                    Stop();
                    //result.IsEnum = true;

                    if (schema.EnumerationNames != null && schema.EnumerationNames.Any())
                    {

                        var values = schema.Enumeration.ToArray();
                        for (int i = 0; i < schema.Enumeration.Count; i++)
                        {
                            var enumValue = values[i];
                            var enumName = schema.EnumerationNames[i];
                            //result.Members.Add(new CodeMemberField(name, enumName).Initialize(enumValue.ToConstant()));
                        }

                    }
                    else
                    {
                        Stop();
                        for (int i = 0; i < schema.Enumeration.Count; i++)
                        {

                        }
                    }

                }

                if (schema.Reference != null)
                {
                    var _name = ((NJsonSchema.References.IJsonReferenceBase)schema.Reference).ReferencePath;
                    if (!string.IsNullOrEmpty(_name))
                    {
                        Stop();
                        Visit(schema.Reference, null);
                    }
                }

                if (schema.AdditionalItemsSchema != null)
                {
                    Stop();
                    Visit(schema.AdditionalItemsSchema, null);
                }

                if (schema.AdditionalPropertiesSchema != null)
                {
                    Stop();
                    Visit(schema.AdditionalPropertiesSchema, null);
                }

                if (schema.Item != null)
                {
                    Stop();
                    Visit(schema.Item, null);
                }

                var items = schema.Items.ToList();
                for (var i = 0; i < items.Count; i++)
                {
                    Stop();
                    var index = i;
                    Visit(items[i], null);
                }

                var anyOf = schema.AnyOf.ToList();
                for (var i = 0; i < anyOf.Count; i++)
                {
                    Stop();
                    var index = i;
                    Visit(anyOf[i], null);
                }

                var oneOf = schema.OneOf.ToList();
                for (var i = 0; i < oneOf.Count; i++)
                {
                    Stop();
                    var index = i;
                    Visit(oneOf[i], null);
                }

                if (schema.Not != null)
                {
                    Stop();
                    Visit(schema.Not, null);
                }

                if (schema.DictionaryKey != null)
                {
                    Stop();
                    Visit(schema.DictionaryKey, null);
                }

                foreach (var p in schema.PatternProperties.ToArray())
                {
                    Stop();
                    Visit(p.Value, null);
                }

                if (schema.ActualDiscriminator != null)
                {
                    Stop();
                }

                if (schema.SchemaVersion != null)
                {
                    Stop();
                }

                if (schema.ActualDiscriminatorObject != null)
                {
                    Stop();
                }

                if (schema.Default != null)
                {
                    Stop();
                }

                if (schema.DeprecatedMessage != null)
                {
                    Stop();
                }

                //if (!string.IsNullOrEmpty(schema.Description))
                //    result.CustomAttributes.Add(typeof(DescriptionAttribute).ToAttribute(schema.Description.ToConstant()));

                if (schema.Discriminator != null)
                {
                    Stop();
                }

                if (schema.DiscriminatorObject != null)
                {
                    Stop();
                }

                if (schema.DocumentPath != null)
                {
                    Stop();
                }

                if (schema.ExclusiveMaximum != null)
                {
                    Stop();
                }

                if (schema.ExclusiveMinimum != null)
                {
                    Stop();
                }

                if (schema.ExtensionData != null)
                {
                    Stop();
                }

                if (schema.Format != null)
                {
                    Stop();
                }

                if (schema.Id != null)
                {
                    Stop();
                }

                if (schema.MinItems > 0)
                {
                    Stop();
                }


                if (schema.MaxItems > 0)
                {
                    Stop();
                }

                if (schema.MinProperties > 0)
                {
                    Stop();
                }

                if (schema.MaxProperties > 0)
                {
                    Stop();
                }

                if (schema.MultipleOf != null)
                {
                    Stop();
                }

                if (schema.UniqueItems)
                {
                    Stop();
                }

                //return result;

                return table;

            }

        }

        private List<DataColumn> ResolveKeys(DataTable table)
        {
            List<DataColumn> result = new List<DataColumn>();

            if (this._keys.TryGetValue(table.TableName, out var items))
            {
                foreach (var columnName in items)
                {
                    try
                    {
                        var i = table.Columns[columnName];
                        result.Add(i);
                    }
                    catch (Exception)
                    {
                        Stop();
                        throw;
                    }
                }
            }

            DataColumn col = Search(table, "Id");
            if (col != null)
                result.Add(col);

            return result;

        }

        private static DataColumn Search(DataTable table, string key)
        {
            foreach (DataColumn item in table.Columns)
            {
                if (item.ColumnName == key)
                    return item;
            }

            return null;

        }

        private void AppendSchema(JsonSchema schema, object datas)
        {

            if (this._dic.ContainsKey(schema))
            {
                Stop();
            }

            this._dic.Add(schema, datas);

        }

        private object? ResolveFrom(JsonSchema schema)
        {
            this._dic.TryGetValue(schema, out var result);
            return result;
        }

        private Dictionary<object, object> _dic;
        private Dictionary<string, TableKey> _keys;
        private readonly DataSet _dataSet;
        private const string Keytable = "table";
        private const string Keycolumn = "column";
        private const string KeyDescription = "Description";
    }

}
