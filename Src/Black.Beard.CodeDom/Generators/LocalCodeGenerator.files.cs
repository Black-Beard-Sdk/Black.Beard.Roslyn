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
    
        public static void GenerateCode(CodeDomProvider provider, CodeCompileUnit compileunit, string outputfile)
        {

            if (File.Exists(outputfile))
                File.Delete(outputfile);

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(outputfile, false), "\t"))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromCompileUnit(compileunit, tw, new CodeGeneratorOptions()
                {
                    
                });
                // Close the output file.
                tw.Close();
            }
        }

        public static void GenerateCode(CodeDomProvider provider, CodeNamespace @namespace, string outputfile)
        {

            if (File.Exists(outputfile))
                File.Delete(outputfile);

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(outputfile, false), "\t"))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromNamespace(@namespace, tw, new CodeGeneratorOptions()
                {

                });
                // Close the output file.
                tw.Close();
            }

        }

        public static void GenerateCode(CodeDomProvider provider, CodeExpression expression, string outputfile)
        {

            if (File.Exists(outputfile))
                File.Delete(outputfile);

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(outputfile, false), "\t"))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromExpression(expression, tw, new CodeGeneratorOptions()
                {

                });
                // Close the output file.
                tw.Close();
            }

        }

        public static void GenerateCode(CodeDomProvider provider, CodeTypeDeclaration typeDeclaration, string outputfile)
        {

            if (File.Exists(outputfile))
                File.Delete(outputfile);

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(outputfile, false), "\t"))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromType(typeDeclaration, tw, new CodeGeneratorOptions()
                {

                });
                // Close the output file.
                tw.Close();
            }

        }

        public static void GenerateCode(CodeDomProvider provider, CodeTypeMember member, string outputfile)
        {

            if (File.Exists(outputfile))
                File.Delete(outputfile);

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(outputfile, false), "\t"))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromMember(member, tw, new CodeGeneratorOptions()
                {

                });
                // Close the output file.
                tw.Close();
            }

        }

        public static void GenerateCode(CodeDomProvider provider, CodeStatement statement, string outputfile)
        {

            if (File.Exists(outputfile))
                File.Delete(outputfile);

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(outputfile, false), "\t"))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromStatement(statement, tw, new CodeGeneratorOptions()
                {

                });
                // Close the output file.
                tw.Close();
            }

        }


    }

}
