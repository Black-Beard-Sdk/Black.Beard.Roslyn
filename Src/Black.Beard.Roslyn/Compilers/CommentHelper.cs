﻿using System.Text;
using System.Text.RegularExpressions;

namespace Bb.Compilers
{


    public static class CommentHelper
    {


        public static List<CommentBlock> ResolveComments(string payload)
        {

            List<CommentBlock> result = new List<CommentBlock>();

            var reg = new Regex(@"\/\*|\*\/", RegexOptions.Multiline);

            MatchCollection matches = reg.Matches(payload);
            CommentBlock current = null;
            Token statut = Token.None;
            foreach (Match item in matches)
            {

                switch (statut)
                {
                    case Token.None:
                        if (item.Value == start)
                        {
                            statut = Token.Start;
                            if (current != null)
                            {

                            }
                            current = new CommentBlock()
                            {
                                Start = item.Index,
                            };
                            result.Add(current);
                        }
                        else
                        {

                        }
                        break;

                    case Token.Start:
                        if (current != null)
                        {
                            if (item.Value == end)
                            {
                                current.End = item.Index + item.Length;
                                current.Text = payload.Substring(current.Start, current.Lenght);
                                statut = Token.None;
                                current = null;
                            }
                            else if (item.Value == start)
                            {

                            }
                        }
                        break;

                    case Token.End:
                        break;
                    default:
                        break;
                }

            }

            return result;

        }

        public class CommentBlock
        {
            public int Start { get; internal set; }

            public int End { get; internal set; }

            public int Lenght { get => End - Start; }

            public string Text { get; internal set; }

            public string GetTrimmedPayload()
            {

                var lines = Text.Split(Environment.NewLine);
                StringBuilder sb = new StringBuilder();

                foreach (var line in lines)
                {
                    var l = CleanLine(line);
                    if (!string.IsNullOrEmpty(l))
                        sb.AppendLine(l);
                }
                return sb.ToString();

            }

            private string CleanLine(string line)
            {

                var text = line;
                int lastlenght = Text.Length;
                bool test = true;

                while (test)
                {
                    text = text.Trim();
                    text = text.Trim('/', '*');
                    test = lastlenght == text.Length;
                    lastlenght = text.Length;
                }

                return text.Trim();

            }
        }

        private enum Token
        {
            None,
            Start,
            End
        }


        public static string EnsureLiteralName(this string self)
        {

            if (_cscharpReservedKeyword.Contains(self))
                return "@" + self;

            return self;

        }


        private static HashSet<string> _cscharpReservedKeyword = new HashSet<string>()
        {
            "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default",
            "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto",
            "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override",
            "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string",
            "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile",
            "while", "add", "and", "alias", "ascending", "args", "async", "await", "by", "descending", "dynamic", "equals", "file", "from", "get", "global",
            "group", "init", "into", "join", "let", "managed", "nameof", "nint", "not", "notnull", "nuint", "on", "or", "orderby", "partial", "record", "remove",
            "required", "scoped", "select", "set", "unmanaged", "value", "var", "when", "where", "with", "yield"
        };


        private const string start = @"/*";
        private const string end = @"*/";

    }


}
