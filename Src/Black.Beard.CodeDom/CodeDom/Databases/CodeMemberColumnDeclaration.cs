using Bb.Generators.SqlServer;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Schemas.Database.CodeDom
{

    public class CodeMemberColumnDeclaration : CodeTypeMember
    {

        public CodeMemberColumnDeclaration(string name)
        {
            base.Name = name;
        }

        public bool IsUnique { get; set; }

        public bool AllowDBNull { get; set; }

        public CodeTypeReference Type
        {
            get
            {
                return _type ?? (_type = new CodeTypeReference(""));
            }
            set
            {
                _type = value;
            }
        }

        public string Description { get; set; }

        public bool IsPrimaryKey { get; internal set; }

        private CodeTypeReference _type;

    }


}
