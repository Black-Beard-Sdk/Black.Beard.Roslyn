using Bb.Schemas;
using Bb.Schemas.CodeDom;
using NJsonSchema;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace Bb
{

    public static class CodeDomExtension2
    {

        public static CodeNamespace AppendType(this CodeNamespace self, JsonSchema schema, JsonSchemaVisitor<CodeObject> visitor)
        {

            visitor.Visit(schema, null);
            var items = visitor.GetModels<CodeTypeDeclaration>().ToList();

            foreach (var item in items)
                self.Types.Add(item);

            return self;

        }

        public static CodeNamespace AppendPoco(this CodeNamespace self, JsonSchema schema)
        {
            var visitor = new CodeDomJsonSchemaVisitor();
            self.AppendType(schema, visitor);
            return self;
        }


    }

}
