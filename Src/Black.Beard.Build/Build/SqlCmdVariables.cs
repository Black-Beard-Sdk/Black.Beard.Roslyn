using System;
using System.Xml.Linq;

namespace Bb.Build
{
    public class SqlCmdVariables : ItemGroup
    {


        public SqlCmdVariables()
        {

        }

        public SqlCmdVariables SqlCmdVariable(string variableName, Action<SqlCmdVariable> initializer = null)
        {

            if (string.IsNullOrEmpty(variableName))
                throw new ArgumentNullException(nameof(variableName));


            var sqlCmdVariable = new SqlCmdVariable(variableName);
            if (initializer != null)
                initializer(sqlCmdVariable);

            Add(sqlCmdVariable);

            return this;

        }

        public XElement Serialize()
        {
            var result = new XElement("ItemGroup");
            Serialize(result);
            return result;
        }


    }


}
