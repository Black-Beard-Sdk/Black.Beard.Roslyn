using Bb.Generators.Csharp;
using Bb.Generators.SqlServer;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;

namespace Bb.Generators
{

    public static partial class LocalCodeGenerator
    {

        public static StringBuilder GenerateCode(CodeDomProvider provider, CodeCompileUnit codeCompileUnit)
        {

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (var txt = new System.IO.StringWriter())
            using (IndentedTextWriter tw = new IndentedTextWriter(txt))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromCompileUnit(codeCompileUnit, tw, new CodeGeneratorOptions());
                // Close the output file.
                tw.Close();

                return txt.GetStringBuilder();

            }

        }

        public static StringBuilder GenerateCode(CodeDomProvider provider, CodeExpression expression)
        {

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (var txt = new System.IO.StringWriter())
            using (IndentedTextWriter tw = new IndentedTextWriter(txt))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromExpression(expression, tw, new CodeGeneratorOptions());
                // Close the output file.
                tw.Close();

                return txt.GetStringBuilder();

            }
        }

        public static StringBuilder GenerateCode(CodeDomProvider provider, CodeTypeDeclaration declaration)
        {

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (var txt = new System.IO.StringWriter())
            using (IndentedTextWriter tw = new IndentedTextWriter(txt))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromType(declaration, tw, new CodeGeneratorOptions());
                // Close the output file.
                tw.Close();

                return txt.GetStringBuilder();

            }
        }

        public static StringBuilder GenerateCode(CodeDomProvider provider, CodeNamespace @namespace)
        {

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (var txt = new System.IO.StringWriter())
            using (IndentedTextWriter tw = new IndentedTextWriter(txt))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromNamespace(@namespace, tw, new CodeGeneratorOptions());
                // Close the output file.
                tw.Close();

                return txt.GetStringBuilder();

            }
        }

        public static StringBuilder GenerateCode(CodeDomProvider provider, CodeTypeMember member)
        {

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (var txt = new System.IO.StringWriter())
            using (IndentedTextWriter tw = new IndentedTextWriter(txt))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromMember(member, tw, new CodeGeneratorOptions());
                // Close the output file.
                tw.Close();

                return txt.GetStringBuilder();

            }
        }

        public static StringBuilder GenerateCode(CodeDomProvider provider, CodeStatement statement)
        {

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (var txt = new System.IO.StringWriter())
            using (IndentedTextWriter tw = new IndentedTextWriter(txt))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromStatement(statement, tw, new CodeGeneratorOptions());
                // Close the output file.
                tw.Close();

                return txt.GetStringBuilder();

            }
        }        

    }

}
