using Bb.ComponentModel;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Bb.Compilers
{


    public static class CommentHelper
    {

        public static void ResolveProperties(this string payloadCode, CompilationProperties compilationProperties)
        {

            var items = CommentHelper.ResolveComments(payloadCode);
            foreach (var item in items)
            {
                var payload = item.GetTrimmedPayload();
                var lines = payload.Split(Environment.NewLine).Where(c => c.StartsWith("@")).ToArray();
                foreach (var line in lines)
                {

                    var o = JObject.Parse(line.Trim('@'));

                    foreach (var property in o.Properties())
                    {
                        switch (property.Name.ToLower())
                        {

                            case "assemblies":
                                ParseAssemblies(property.Value, compilationProperties);
                                break;

                            default:
                                break;
                        }
                    }

                }
            }

        }

        private static void ParseAssemblies(JToken assemblies, CompilationProperties result)
        {

            if (assemblies is JArray array)
            {
                foreach (var item in array)
                    if (item is JValue v)
                    {

                        if (v.Value is string s)
                        {
                            //var assemblyName = AssemblyName.GetAssemblyName(s);
                            var assembly = TypeDiscovery.Instance.AddAssemblyname(s, true);
                            result.AddAssembly(assembly);
                        }

                    }
            }
            else
            {

            }

        }

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


        private const string start = @"/*";
        private const string end = @"*/";

    }


}
