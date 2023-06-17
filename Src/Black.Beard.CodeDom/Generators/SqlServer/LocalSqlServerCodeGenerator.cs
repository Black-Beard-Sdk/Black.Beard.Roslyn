using Bb.Generators.Csharp;
using Bb.Schemas.Database.CodeDom;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Generators.SqlServer
{

    internal partial class LocalSqlServerCodeGenerator : SgbdCodeGenerator
    {

        public LocalSqlServerCodeGenerator(IDictionary<string, string> providerOptions = null)
            :base(typeof(LocalSqlServerCodeGenerator), providerOptions)
        {
            
            AddTypeMap("system.timespan", "TIME");
            AddTypeMap("system.byte[]", "BINARY");
            AddTypeMap("system.datetime", "DATETIME");
            AddTypeMap("system.datetimeoffset", "");
            AddTypeMap("system.string", "VARCHAR");
            AddTypeMap("system.guid", "UNIQUEIDENTIFIER");
            AddTypeMap("system.int16", "SMALLINT");
            AddTypeMap("system.int32", "INT");
            AddTypeMap("system.int64", "BIGINT");
            AddTypeMap("system.boolean", "BIT");
            AddTypeMap("system.char", "VARCHAR");
            AddTypeMap("system.byte", "TINYINT");
            AddTypeMap("system.uint16", "INT");
            AddTypeMap("system.single", "REAL");
            AddTypeMap("system.double", "FLOAT");
            AddTypeMap("system.decimal", "DECIMAL");

        }

        protected override void NotAccepted(string key, object item)
        {
            Stop();
        }


        //private bool GetUserData(CodeObject e, string property, bool defaultValue)
        //{
        //    object o = e.UserData[property];
        //    if (o != null && o is bool)
        //    {
        //        return (bool)o;
        //    }
        //    return defaultValue;
        //}


        //private void OutputType(CodeTypeReference typeRef) => Output.Write(GetTypeOutput(typeRef));              

        //private void GenerateMember(CodeMemberProperty e, CodeTypeDeclaration c)
        //{

        //    OutputType(e.Type);
        //    Output.Write(' ');

        //    OutputIdentifier(e.Name);

        //    OutputStartingBrace();
        //    Indent++;

        //    Indent--;
        //    Output.WriteLine('}');
        //}


    }
}
