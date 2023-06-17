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


        public static void GenerateCsharpCode(this CodeCompileUnit compileunit, string outputfile)
        {
            GenerateCode(new LocalCSharpCodeProvider(), compileunit, outputfile);
        }

        public static void GenerateCsharpCode(this CodeNamespace @namespace, string outputfile)
        {
            GenerateCode(new LocalCSharpCodeProvider(), @namespace, outputfile);
        }

        public static void GenerateCsharpCode(this CodeExpression expression, string outputfile)
        {
            GenerateCode(new LocalCSharpCodeProvider(), expression, outputfile);
        }

        public static void GenerateCsharpCode(this CodeTypeDeclaration typeDeclaration, string outputfile)
        {
            GenerateCode(new LocalCSharpCodeProvider(), typeDeclaration, outputfile);
        }

        public static void GenerateCsharpCode(this CodeTypeMember typeMember, string outputfile)
        {
            GenerateCode(new LocalCSharpCodeProvider(), typeMember, outputfile);
        }

        public static void GenerateCsharpCode(this CodeStatement statement, string outputfile)
        {
            GenerateCode(new LocalCSharpCodeProvider(), statement, outputfile);
        }




        public static StringBuilder GenerateCsharpCode(this CodeExpression expression)
        {
            return GenerateCode(new LocalCSharpCodeProvider(), expression);
        }

        public static StringBuilder GenerateCsharpCode(this CodeCompileUnit compileunit)
        {
            return GenerateCode(new LocalCSharpCodeProvider(), compileunit);
        }

        public static StringBuilder GenerateCsharpCode(this CodeNamespace @namespace)
        {
            return GenerateCode(new LocalCSharpCodeProvider(), @namespace);
        }

        public static StringBuilder GenerateCsharpCode(this CodeTypeDeclaration typeDeclaration)
        {
            return GenerateCode(new LocalCSharpCodeProvider(), typeDeclaration);
        }

        public static StringBuilder GenerateCsharpCode(this CodeTypeMember typeMember)
        {
            return GenerateCode(new LocalCSharpCodeProvider(), typeMember);
        }

        public static StringBuilder GenerateCsharpCode(this CodeStatement statement)
        {
            return GenerateCode(new LocalCSharpCodeProvider(), statement);
        }




        public static List<string> GenerateSqlServerCodeToDirectory(this CodeCompileUnit compileunit, string outputDirectory)
        {

            List<string> outputFiles = new List<string>();

            var dir = new DirectoryInfo(outputDirectory);
            
            if (!dir.Exists)
                dir.Create();

            foreach (CodeNamespace item in compileunit.Namespaces)
            {

                var file = dir.FullName;
                
                if (item.UserData.Contains("kind"))
                {
                    var k = item.UserData["kind"]?.ToString();
                    if (!string.IsNullOrEmpty(k))
                        file = Path.Combine(file, k);
                }

                file = Path.Combine(file, item.Name + ".sql");
                var fileInfo = new FileInfo(file);

                outputFiles.Add(file);

                if (!fileInfo.Directory.Exists)
                    fileInfo.Directory.Create();

                GenerateCode(new LocalSqlServerCodeProvider(), item, file);

            }

            return outputFiles;

        }

        public static void GenerateSqlServerCode(this CodeCompileUnit compileunit, string outputfile)
        {
            GenerateCode(new LocalSqlServerCodeProvider(), compileunit, outputfile);
        }

        public static void GenerateSqlServerCode(this CodeNamespace @namespace, string outputfile)
        {
            GenerateCode(new LocalSqlServerCodeProvider(), @namespace, outputfile);
        }

        public static void GenerateSqlServerCode(this CodeExpression expression, string outputfile)
        {
            GenerateCode(new LocalSqlServerCodeProvider(), expression, outputfile);
        }

        public static void GenerateSqlServerCode(this CodeTypeDeclaration typeDeclaration, string outputfile)
        {
            GenerateCode(new LocalSqlServerCodeProvider(), typeDeclaration, outputfile);
        }

        public static void GenerateSqlServerCode(this CodeTypeMember typeMember, string outputfile)
        {
            GenerateCode(new LocalSqlServerCodeProvider(), typeMember, outputfile);
        }

        public static void GenerateSqlServerCode(this CodeStatement statement, string outputfile)
        {
            GenerateCode(new LocalSqlServerCodeProvider(), statement, outputfile);
        }




        public static StringBuilder GenerateSqlServerCode(this CodeExpression expression)
        {
            return GenerateCode(new LocalSqlServerCodeProvider(), expression);
        }

        public static StringBuilder GenerateSqlServerCode(this CodeCompileUnit compileunit)
        {
            return GenerateCode(new LocalSqlServerCodeProvider(), compileunit);
        }

        public static StringBuilder GenerateSqlServerCode(this CodeNamespace @namespace)
        {
            return GenerateCode(new LocalSqlServerCodeProvider(), @namespace);
        }

        public static StringBuilder GenerateSqlServerCode(this CodeTypeDeclaration typeDeclaration)
        {
            return GenerateCode(new LocalSqlServerCodeProvider(), typeDeclaration);
        }

        public static StringBuilder GenerateSqlServerCode(this CodeTypeMember typeMember)
        {
            return GenerateCode(new LocalSqlServerCodeProvider(), typeMember);
        }

        public static StringBuilder GenerateSqlServerCode(this CodeStatement statement)
        {
            return GenerateCode(new LocalSqlServerCodeProvider(), statement);
        }




    }

}
