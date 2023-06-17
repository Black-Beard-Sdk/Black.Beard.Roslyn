using System.Data;

namespace Bb
{
    public static class DataSetExtension
    {

        public static DataColumn CreateColumn(this DataTable self, string name, Type type, string description, bool required = false, int ordinal = -1)
        {
            DataColumn column = new DataColumn(name, type)
            {
                Caption = description,
            };

            column.AllowDBNull = !required;
            self.Columns.Add(column);

            if (ordinal != -1)
                column.SetOrdinal(ordinal);

            return column;

        }

        public static DataColumn SetDefaultValue(this DataColumn self, object defaultValue)
        {
            self.DefaultValue = defaultValue;
            return self;
        }

        public static DataColumn SetMaxLength(this DataColumn self, int max)
        {
            self.MaxLength = max;
            return self;
        }

        public static DataColumn SetDescription(this DataColumn self, string caption)
        {
            self.Caption = caption;
            return self;
        }

        public static DataColumn SetNamespace(this DataColumn self, string @namespace)
        {
            self.Namespace = @namespace;
            return self;
        }

        public static DataColumn SetPrefix(this DataColumn self, string prefix)
        {
            self.Prefix = prefix;
            return self;
        }

        public static DataColumn SetAutoIncrement(this DataColumn self, int seed = 1, int step = 1)
        {
            self.AutoIncrement = true;
            self.AutoIncrementSeed = seed;
            self.AutoIncrementStep = step;
            return self;
        }

        public static DataColumn IsUnique(this DataColumn self, bool isUnique = true)
        {
            self.Unique = isUnique;
            return self;
        }

        public static DataColumn SetDateTimeMode(this DataColumn self, DataSetDateTime kind)
        {
            self.DateTimeMode = kind;
            return self;
        }

        public static DataColumn SetExpression(this DataColumn self, string expression)
        {
            self.Expression = expression;
            return self;
        }
       
    }


}
