using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Codings
{

    public class CSDocumentationDeclaration
    {
        public CSDocumentationDeclaration()
        {
            _comments = new Dictionary<string, DocumentationItem>();
        }


        public void Summary(Func<string> value)
        {
            Append(_summary, value);
        }

        public void Remark(Func<string> value)
        {
            Append(_remarks, value);
        }

        public void Returns(Func<string> value)
        {
            Append(_returns, value);
        }

        private void Append(string key, Func<string> value)
        {

            if (!_comments.TryGetValue(key, out DocumentationItem list))
                _comments.Add(key, list = new DocumentationItem());

            list.Add(value);

        }

        internal T Apply<T>(T node) where T : SyntaxNode
        {

            foreach (var item in _comments)
            {

                var v = item.Value;

                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item2 in v.Generate())
                {
                    stringBuilder.AppendLine(item2);
                }

                node = node.WithDocumentationSummary(stringBuilder.ToString());

            }


            return node;

        }

        private const string _summary = "summary";
        private const string _remarks = "remarks";
        private const string _returns = "returns";

        // exception cref
        // param name
        private Dictionary<string, DocumentationItem> _comments { get; set; }


        private class DocumentationItem
        {

            public DocumentationItem()
            {
                _list = new List<(Func<string>, Func<string>)>();
            }

            internal void Add(Func<string> action1, Func<string> action2)
            {
                _list.Add((action1, action2));
            }

            internal void Add(Func<string> action)
            {
                _list.Add((null, action));
            }

            internal List<string> Generate()
            {

                List<string> comments = new List<string>();

                //if (string.IsNullOrEmpty(subKey))
                //{

                foreach (var comment in _list)
                {
                    var txt = comment.Item2();
                    foreach (var item in txt.Split('\r'))
                        if (!string.IsNullOrEmpty(item.Trim()) && !string.IsNullOrEmpty(item.Trim()))
                            comments.Add(item);
                }

                //foreach (var item in comments)
                //    if (!string.IsNullOrEmpty(item.Trim()) && !string.IsNullOrEmpty(item.Trim()))
                //        comments.Add(item.Trim('\n'));

                //}
                //else
                //{

                //foreach (var comment in _list)
                //{
                //    List<string> comments = new List<string>();
                //    var txt1 = comment.Item1();
                //    var txt2 = comment.Item2();
                //    foreach (var item in txt2.Split('\r'))
                //        if (!string.IsNullOrEmpty(item.Trim()) && !string.IsNullOrEmpty(item.Trim()))
                //            comments.Add(item);
                //    member.Comments.Add(new CodeCommentStatement($"<{key} {subKey}=\"{txt1}\">", true));
                //    foreach (var item in comments)
                //        if (!string.IsNullOrEmpty(item.Trim()) && !string.IsNullOrEmpty(item.Trim()))
                //            member.Comments.Add(new CodeCommentStatement(item.Trim('\n'), true));
                //    member.Comments.Add(new CodeCommentStatement("</" + key + ">", true));
                //}

                //}

                return comments;


            }

            private readonly List<(Func<string>, Func<string>)> _list;

        }

    }

}