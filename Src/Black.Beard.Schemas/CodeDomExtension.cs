using Bb.Schemas;
using Bb.Schemas.CodeDom;
using NJsonSchema;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace Bb
{

    public static class CodeDomExtension
    {



        public static string FormatNameForField(this string txt)
        {
            
            var fieldName = "_"
                + txt.Substring(0, 1).ToLower()
                + txt.Substring(1, txt.Length - 1)
                ;

            return fieldName;

        }


        public static CodeAttributeDeclaration ToAttribute(this Type self, params CodeExpression[] arguments)
        {

            List< CodeAttributeArgument > _args = new List<CodeAttributeArgument>(arguments.Length);

            foreach (var item in arguments)
                _args.Add(new CodeAttributeArgument(item));

            return new CodeAttributeDeclaration(self.ToReference(), _args.ToArray());

        }

        public static CodePrimitiveExpression ToConstant(this object self)
        {
            return new CodePrimitiveExpression(self);
        }

        public static CodeTypeReference ToReference(this Type self)
        {
            return new CodeTypeReference(self);
        }

        public static CodeTypeReference ToReference(this string self)
        {
            return new CodeTypeReference(self);
        }

        public static CodeNamespace ToNamespace(this string self)
        {
            return new CodeNamespace(self);
        }

        public static CodeNamespace Import(this CodeNamespace self, params string[] usings)
        {

            foreach (var item in usings)
                self.Imports.Add(new CodeNamespaceImport(item));

            return self;

        }

        public static CodeStatementCollection Return(this CodeStatementCollection self, CodeExpression code)
        {
            self.Add(new CodeMethodReturnStatement(code));
            return self;
        }

        public static CodeMemberField Initialize(this CodeMemberField left, CodeExpression right)
        {
            left.InitExpression = right;
            return left;
        }

        public static CodeAssignStatement Assign(this CodeExpression left, CodeExpression right)
        {
            return new CodeAssignStatement(left, right);
        }

        public static CodeStatementCollection Set(this CodeStatementCollection self, CodeExpression left, CodeExpression right)
        {
            self.Add(new CodeAssignStatement(left, right));
            return self;
        }

        public static CodeStatementCollection SetFromValue(this CodeStatementCollection self, CodeExpression left)
        {
            self.Add(new CodeAssignStatement(left, new CodePropertySetValueReferenceExpression()));
            return self;
        }

        public static CodeFieldReferenceExpression HasField(this string self)
        {
            return new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), self);
        }

        public static CodeFieldReferenceExpression HasField(this CodeExpression self, string fieldName)
        {
            return new CodeFieldReferenceExpression(self, fieldName);
        }

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

        public static FileInfo ToCSharp(this CodeNamespace self, string fileTarget)
        {

            if (string.IsNullOrEmpty(fileTarget))
                throw new ArgumentNullException(nameof(fileTarget));

            var file = new FileInfo(fileTarget);

            if (!file.Directory.Exists)
                file.Directory.Create();

            else if (file.Exists)
                file.Delete();

            using (StreamWriter sourceWriter = new StreamWriter(file.FullName))
            {
                self.ToCSharp(sourceWriter);
            }

            return file;

        }

        public static void ToCSharp(this CodeNamespace self, TextWriter sourceWriter)
        {

            var targetUnit = new CodeCompileUnit();

            targetUnit.Namespaces.Add(self);

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions()
            {
                BracingStyle = "C"
            };

            provider.GenerateCodeFromCompileUnit(targetUnit, sourceWriter, options);

        }


    }

}
