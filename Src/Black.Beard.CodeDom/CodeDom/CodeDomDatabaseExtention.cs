using System.CodeDom;
using System.Data;

namespace Bb.Schemas.Database
{

    public static class CodeDomDatabaseExtention
    {


        public static CodeTypeReference CreateReference(this DataTable self)
        {
            if (!string.IsNullOrEmpty(self.Namespace))
            {

                return new CodeTypeReference($"{self.Namespace}.{self.TableName}");

            }

            return new CodeTypeReference(self.TableName);

        }

        public static CodePropertyReferenceExpression CreateTableReference(this DataTable self)
        {
            var n = string.IsNullOrEmpty(self.Namespace) ? null : self.Namespace.CreateColumnReference();
            return new CodePropertyReferenceExpression(n, self.TableName);
        }

        public static CodePropertyReferenceExpression CreateColumnReference(this DataColumn self)
        {
            var table = self.Table?.CreateTableReference() ?? null;
            return new CodePropertyReferenceExpression(table, self.ColumnName);
        }

        public static CodePropertyReferenceExpression CreateColumnReference(this string self)
        {
            return new CodePropertyReferenceExpression(null, self);
        }

    }

}
