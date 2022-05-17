using Bb.Generators.Csharp;
using Bb.Schemas.Database.CodeDom;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Generators.SqlServer
{


    internal partial class LocalSqlServerCodeGenerator
    {


        public virtual void GenerateKeys(CodeMemberColumnPrimaryDeclarationCollection keys)
        {

            if (keys.PrimaryDeclaration != null)
                GenerateSnippetExpression(keys.PrimaryDeclaration);

            else
                Output.Write("PRIMARY KEY");

            Output.WriteLine();
            using (NewIndentParenth())
            {
                Output.WriteLine();
                var last = keys.Keys[keys.Keys.Count - 1];
                foreach (var item in keys.Keys)
                {
                    GenerateCodeMemberColumnPrimaryDeclaration(item);
                    if (item != last)
                        Output.WriteLine(", ");
                }

                Output.WriteLine();
            }

            Output.WriteLine();

        }

        public void GenerateCodeMemberColumnPrimaryDeclaration(CodeMemberColumnPrimaryDeclaration item)
        {

            OutputIdentifier(item.Column.Name);

            if (item.Asc)
                Output.Write(" ASC");

        }


        /*
         
          ADD CONSTRAINT FK_Child_Parent FOREIGN KEY (ParentId)     
            REFERENCES Parent (ParentId)
            ON DELETE NO ACTION    
            ON UPDATE NO ACTION;
        */
        public void GenerateConstraint(CodeContraintDeclaration co)
        {

            // ADD CONSTRAINT FK_Child_Parent FOREIGN KEY (ParentId)     
            Output.Write($"ADD CONSTRAINT{CreateEscapedIdentifier(co.Name)} FOREIGN KEY (");
            var last = co.LocalColumns[co.LocalColumns.Count() - 1];
            foreach (var item in co.LocalColumns)
            {
                GeneratePropertyReference(item);
                if (item != last)
                    Output.Write(", ");
            }
            Output.WriteLine(")");

            using (NewIndent())
            {

                Output.Write("REFERENCES ");
                GeneratePropertyReference(co.RemoteTable);
                Output.Write(" (");
                last = co.RemoteColumns[co.RemoteColumns.Count() - 1];
                foreach (var item in co.RemoteColumns)
                {
                    GeneratePropertyReference(item);
                    if (item != last)
                        Output.Write(", ");
                }
                Output.WriteLine(")");

                foreach (var item in co.OnRaises)
                {
                    Stop();
                }

            }

        }

        public void GenerateColumnMember(CodeMemberColumnDeclaration c)
        {

            this.OutputIdentifier(c.Name);

            Output.Write($" {GetTypeOutput(c.Type)}");

            if (c.IsPrimaryKey)
                Output.Write(" PRIMARY KEY");

            else if (!c.AllowDBNull)
                Output.Write(" NOT NULL");

        }

    }



}
