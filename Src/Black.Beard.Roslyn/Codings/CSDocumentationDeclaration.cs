using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Security;
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
        public void Parameter(string name, Func<string> value)
        {
            Append(_parameter, name, value);
        }

        private void Append(string key, Func<string> value1)
        {

            if (!_comments.TryGetValue(key, out DocumentationItem list))
                _comments.Add(key, list = new DocumentationItem());

            list.Add(value1);

        }

        private void Append(string key,string key1, Func<string> value2)
        {

            if (!_comments.TryGetValue(key, out DocumentationItem list))
                _comments.Add(key, list = new DocumentationItem());

            list.Add(key1, value2);

        }

        private void Append(string key, string key1, string key2, Func<string> value2)
        {

            if (!_comments.TryGetValue(key, out DocumentationItem list))
                _comments.Add(key, list = new DocumentationItem());

            list.Add(key1, key2, value2);

        }

        internal T Apply<T>(T node) where T : SyntaxNode
        {

            foreach (var item in _comments)
            {
            

                switch (item.Key)
                {
                    case _parameter:
                        //foreach (var value in item.Value.Subs)
                        //    node = node.WithDocumentationParameter(value.Key, BuildText(value).ToString());
                        break;
                    case _include:
                        break;
                    case _inheritdoc:
                        break;
                    case _permission:
                        break;
                    case _exception:
                        break;
                    case _completionlist:
                        break;
                    case _remarks:
                        node = node.WithDocumentationRemarks(BuildText(item).ToString());
                        break;
                    case _example:
                        node = node.WithDocumentationExample(BuildText(item).ToString());
                        break;
                    case _returns:
                        node = node.WithDocumentationSummary(BuildText(item).ToString());
                        break;
                    case _summary:
                    default:
                        node = node.WithDocumentationSummary(BuildText(item).ToString());
                        break;

                }


            }

            return node;

        }

        private static StringBuilder BuildText(KeyValuePair<string, DocumentationItem> item)
        {
            var v = item.Value;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item2 in v.Generate())
                stringBuilder.AppendLine(item2);
            return stringBuilder;
        }

        private const string _parameter = "parameter";
        private const string _include = "include";
        private const string _inheritdoc = "inheritdoc";
        private const string _permission = "permission";
        private const string _exception = "exception";
        private const string _completionlist = "completionlist";
        private const string _summary = "summary";
        private const string _example = "example";
        private const string _remarks = "remarks";
        private const string _returns = "returns";

        // exception cref
        // param name
        private Dictionary<string, DocumentationItem> _comments { get; set; }


        private class DocumentationItem
        {

            public DocumentationItem()
            {
                _list = new List<Func<string>>();
                _list2 = new Dictionary<string, DocumentationItem>();
            }

            internal void Add(Func<string> action1)
            {
                _list.Add(action1);
            }

            internal void Add(string key, Func<string> action)
            {

                if (!_list2.TryGetValue(key, out DocumentationItem list))
                    _list2.Add(key, list = new DocumentationItem() { Key = key });
                
                list.Add(action);

            }

            internal void Add(string key, string key2, Func<string> action)
            {

                if (!_list2.TryGetValue(key, out DocumentationItem list))
                    _list2.Add(key, list = new DocumentationItem() { Key = key, Key2 = key2 });

                list.Add(action);

            }

            public Dictionary<string, DocumentationItem> Subs => _list2;

            public string Key2 { get; private set; }
            public string Key { get; private set; }

            internal List<string> Generate()
            {

                List<string> comments = new List<string>();

                foreach (var comment in _list)
                {
                    var txt = comment();
                    foreach (var item in txt.Split('\r'))
                        if (!string.IsNullOrEmpty(item.Trim()) && !string.IsNullOrEmpty(item.Trim()))
                            comments.Add(item);
                }

                return comments;


            }

            private readonly List<Func<string>> _list;
            private readonly Dictionary<string, DocumentationItem> _list2;

        }

    }

}