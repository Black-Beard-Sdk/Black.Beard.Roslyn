using System.Text.RegularExpressions;

namespace Bb
{
    public class DacpacContext
    {

        public DacpacContext(Variables variables)
        {
            this._variables = variables;
        }

        public string ReplaceVariables(string initialValue)
        {

            var var1 = initialValue;

            var list = _variables.ResolveVariableKeys(var1);
            int count = 0;

            while (list.Count > 0 && count < 15)
            {

                foreach (var item in list)
                {

                    var v1 = item.Trim('$');

                    if (this._variables.TryGetValue(v1, out var value))
                        var1 = var1.Replace(item, value);

                    else
                        var1 = var1.Replace(v1, item);

                }

                list = _variables.ResolveVariableKeys(var1);
                count++;

            }

            return var1;

        }

        private readonly Variables _variables;

    }

    public class Variables : Dictionary<string, string>
    {

        public Variables()
        {

        }

        public Variables(params KeyValuePair<string, string>[] collection)
            : base(collection)
        {

        }

        public List<string> ResolveVariableKeys(string text)
        {

            var list = new List<string>();

            MatchCollection result = _reg.Matches(text);

            foreach (Match match in result)
                list.Add(match.Value);

            return list;

        }

        private Regex _reg = new Regex(pattern, RegexOptions.None);
        private const string pattern = "\\$[^$]*\\$";

    }

}