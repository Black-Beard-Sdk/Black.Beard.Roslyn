using System.Text;

namespace Bb.Codings
{
    public static class CodeNameHelper
    {


        public static string ConvertToCharpName(this string text)
        {

            StringBuilder sb = new StringBuilder(text?.Length ?? 0);

            if (text != null)
            {

                char last = '\0';
                for (int i = 0; i < text.Length; i++)
                {
                    var s = text[i];

                    if (!char.IsLetterOrDigit(s))
                        s = '.';

                    if (sb.Length == 0)
                        s = char.ToUpper(s);

                    else if (s == '.')
                    {
                        last = s;
                        continue;
                    }

                    else if (last == '.')
                        s = char.ToUpper(s);

                    else
                        s = char.ToLower(s);

                    sb.Append(s);
                    last = s;

                }

            }

            return sb.ToString().Trim();


        }

        public static string ConvertToNamespace(this string text)
        {

            StringBuilder sb = new StringBuilder(text?.Length ?? 0);

            if (text != null)
            {

                char last = '\0';
                for (int i = 0; i < text.Length; i++)
                {
                    var s = text[i];

                    if (!char.IsLetterOrDigit(s))
                        s = '.';

                    if (sb.Length == 0)
                        s = char.ToUpper(s);

                    else if (s == '.')
                    {
                        if (last == '.')
                            continue;
                    }

                    else if (last == '.')
                        s = char.ToUpper(s);

                    else
                        s = char.ToLower(s);

                    sb.Append(s);
                    last = s;

                }

            }

            return sb.ToString().Trim();


        }




    }

}
