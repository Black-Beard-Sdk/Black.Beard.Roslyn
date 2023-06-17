using System.CodeDom;
using System.CodeDom.Compiler;
using System.ComponentModel;

namespace Bb.Generators.SqlServer
{
    public class LocalSqlServerCodeProvider : CodeDomProvider
    {

        private readonly LocalSqlServerCodeGenerator _generator;

        public LocalSqlServerCodeProvider()
        {
            _generator = new LocalSqlServerCodeGenerator();
        }

        public LocalSqlServerCodeProvider(IDictionary<string, string> providerOptions)
        {
            if (providerOptions == null)
            {
                throw new ArgumentNullException(nameof(providerOptions));
            }

            _generator = new LocalSqlServerCodeGenerator(providerOptions);
        }

        public override string FileExtension => "sql";
    
        [Obsolete("Callers should not use the ICodeGenerator interface and should instead use the methods directly on the CodeDomProvider class.")]
        public override ICodeGenerator CreateGenerator() => _generator;

        [Obsolete("Callers should not use the ICodeCompiler interface and should instead use the methods directly on the CodeDomProvider class.")]
        public override ICodeCompiler CreateCompiler() => throw new NotImplementedException(); // _generator;

        //public override TypeConverter GetConverter(Type type) =>
        //    type == typeof(MemberAttributes) ? CSharpMemberAttributeConverter.Default :
        //    type == typeof(TypeAttributes) ? CSharpTypeAttributeConverter.Default :
        //    base.GetConverter(type);

        //public override void GenerateCodeFromMember(CodeTypeMember member, TextWriter writer, CodeGeneratorOptions options) =>
        //    _generator.GenerateCodeFromMember(member, writer, options);

    }
}
