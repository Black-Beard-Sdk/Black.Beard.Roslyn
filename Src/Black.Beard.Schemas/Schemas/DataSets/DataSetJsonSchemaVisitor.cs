using NJsonSchema;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Bb.Schemas.DataSets
{


    public class DataSetJsonSchemaVisitor : JsonSchemaVisitor<CodeObject>
    {

        public DataSetJsonSchemaVisitor()
        {
            
        }

        protected override void AppendProperty(CodeObject parent, CodeObject child)
        {

            if (parent is CodeTypeDeclaration type)
            {

                if (child is CodeTypeMember member)
                {

                    type.Members.Add(member);

                    foreach (var item in this.GetMembers<CodeTypeMember>())
                        type.Members.Add(item);

                    this.ClearMember();

                }

                else
                {
                    Stop();
                }

            }
            else
            {
                Stop();
            }

        }

        protected override CodeObject VisitProperty(JsonSchemaProperty schema)
        {

            var result = new System.CodeDom.CodeMemberProperty()
            {
                Name = schema.Name,
                Type = GetType(schema),
                Attributes = MemberAttributes.Public,
            };

            var fieldName = schema.Name.FormatNameForField();

            AddMemberModels(new CodeMemberField(result.Type, fieldName));

            result.HasGet = true;
            result.HasSet = true;
            result.GetStatements.Return(fieldName.HasField());
            result.SetStatements.SetFromValue(fieldName.HasField());

            if (schema.IsReadOnly)
            {
                result.HasSet = false;
                result.SetStatements.Clear();
            }
            else if (schema.IsWriteOnly)
            {
                result.HasGet = false;
                result.GetStatements.Clear();
            }


            if (schema.MinLength.HasValue && schema.MinLength.Value > 0)
                if (!(schema.MinLength.Value == 1 && schema.IsRequired))
                    result.CustomAttributes.Add(typeof(MinLengthAttribute).ToAttribute(schema.MinLength.Value.ToConstant()));

            if (schema.MaxLength.HasValue && schema.MaxLength.Value > 0)
                result.CustomAttributes.Add(typeof(MaxLengthAttribute).ToAttribute(schema.MaxLength.Value.ToConstant()));

            if (schema.IsRequired)
                result.CustomAttributes.Add(typeof(RequiredAttribute).ToAttribute());


            if (schema.IsNullableRaw != null)
            {
                Stop();
            }

            if (schema.IsAbstract)
            {
                Stop();
            }

            if (schema.IsArray)
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

            var items = schema.Items.ToList();
            for (var i = 0; i < items.Count; i++)
            {
                Stop();
                var index = i;
                Visit(items[i], null);
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

            if (schema.Item != null)
            {
                Stop();
                Visit(schema.Item, null);
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

            if (schema.Description != null)
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

            return result;

        }

        private CodeTypeReference GetType(JsonSchema schema)
        {
            if (schema.Type != JsonObjectType.None)
            {
                switch (schema.Type)
                {

                    case JsonObjectType.Boolean:
                        return typeof(bool).ToReference();

                    case JsonObjectType.Integer:

                        if (schema.IsEnumeration)
                            return typeof(Int32).ToReference();

                        if (schema.Format != null)
                        {
                            switch (schema.Format)
                            {

                                case "int32":
                                    return typeof(Int32).ToReference();

                                default:
                                    Stop();
                                    break;
                            }

                            return typeof(Int64).ToReference();

                        }
                        return typeof(Int64).ToReference();

                    case JsonObjectType.Number:
                        return typeof(decimal).ToReference();

                    case JsonObjectType.String:
                        return typeof(string).ToReference();

                    case JsonObjectType.File:
                        Stop();
                        break;

                    case JsonObjectType.Array:
                        Stop();
                        break;

                    case JsonObjectType.Null:
                        Stop();
                        break;

                    case JsonObjectType.Object:
                        return typeof(object).ToReference();

                    case JsonObjectType.None:
                    default:
                        break;
                }
            }
            else if (schema.Reference != null)
            {
                var name = GetName(schema.Reference);
                if (!string.IsNullOrEmpty(name))
                    return name.ToReference();
            }
            //else if (schema.InheritedSchema != null)
            //{

            //    var o = schema.Definitions.FirstOrDefault(c => c.Value == schema.InheritedSchema);

            //    if (!string.IsNullOrEmpty(o.Key))
            //        return o.Key.ToReference();

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

        protected override CodeObject CreateModel(JsonSchema schema, string name)
        {

            var result = new CodeTypeDeclaration(name)
            {
                IsClass = true,
            };

            var type = GetType(schema);
            if (type != null)
                result.BaseTypes.Add(type);
     
            if (schema.Enumeration != null && schema.Enumeration.Any())
            {

                result.IsEnum = true;

                if (schema.EnumerationNames != null && schema.EnumerationNames.Any())
                {

                    var values = schema.Enumeration.ToArray();
                    for (int i = 0; i < schema.Enumeration.Count; i++)
                    {
                        var enumValue = values[i];
                        var enumName = schema.EnumerationNames[i];
                        result.Members.Add(new CodeMemberField(name, enumName).Initialize(enumValue.ToConstant()));
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
            else
            {
                result.IsClass = true;
            }


            if (schema.Reference != null)
            {
                Stop();
                Visit(schema.Reference, null);
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

            if (!string.IsNullOrEmpty(schema.Description))
                result.CustomAttributes.Add(typeof(DescriptionAttribute).ToAttribute(schema.Description.ToConstant()));

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

            return result;

        }


    }

}
