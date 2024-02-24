using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bb.Codings
{
    public static class DocXml
    {


        /// <summary>
        /// createan empty line.
        /// </summary>
        /// <value>
        /// The empty line.
        /// </value>
        public static SyntaxToken EmptyLine
            => SyntaxFactory.XmlTextNewLine(SyntaxFactory.TriviaList(), Environment.NewLine, Environment.NewLine, SyntaxFactory.TriviaList());


        public static XmlTextSyntax Text(this XmlTextSyntax self, params string[] texts)
        {

            foreach (var text in texts)
            {

                self = self.AddTextTokens
                (

                    DocXml.EmptyLine,
                    SyntaxFactory.XmlTextLiteral
                    (
                        SyntaxFactory.TriviaList(),
                        text,
                        text,
                        SyntaxFactory.TriviaList()
                    )
                    .WithLeadingTrivia(SyntaxFactory.DocumentationCommentExterior("/// "))

                );

            }

            return self;

        }


        public static XmlCrefAttributeSyntax CRefAttribute(this TypeSyntax typeCRef)
        {
            return SyntaxFactory.XmlCrefAttribute
            (
                SyntaxFactory.XmlName("cref"),
                SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken),
                SyntaxFactory.TypeCref(typeCRef),
                SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken)
            )
            .WithLeadingTrivia(SyntaxFactory.Whitespace(" "));
        }


        private static XmlNameSyntax XmlName(this string name) => SyntaxFactory.XmlName(SyntaxFactory.Identifier(name));


        public static XmlEmptyElementSyntax XmlNode(this string name, params XmlAttributeSyntax[] attributes)
        {

            var r = SyntaxFactory.XmlEmptyElement(name.XmlName());

            foreach (var attribute in attributes)
                r = r.AddAttributes(attribute);

            return r;

        }

        public static XmlElementSyntax DocumentationSummary(string summary)
        {
            return DocumentationElement("summary", summary);
        }

        public static XmlElementSyntax DocumentationRemarks(string remarks)
        {
            return DocumentationElement("remarks", remarks);
        }

        public static XmlElementSyntax DocumentationReturns(string returns)
        {
            return DocumentationElement("returns", returns);
        }

        public static XmlElementSyntax DocumentationExample(string example)
        {
            return DocumentationElement("example", example);
        }

        public static XmlElementSyntax DocumentationParameter(string name, string text)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            return DocumentationElement("param ", text, new List<Tuple<string, string>>
            {
                new Tuple<string, string>("name", name)
            });
        }

        public static XmlElementSyntax DocumentationInclude(string file, string path)
        {
            if (file is null)
                throw new ArgumentNullException(nameof(file));

            if (path is null)
                throw new ArgumentNullException(nameof(path));

            return DocumentationElement("include ", null, new List<Tuple<string, string>>
            {
                new Tuple<string, string>("file", file),
                new Tuple<string, string>("path", $"[@name=\"{path}\"]")
            });
        }

        public static XmlElementSyntax DocumentationInheritdoc(string cref)
        {
            if (cref is null)
                throw new ArgumentNullException(nameof(cref));

            return DocumentationElement("inheritdoc ", null, new List<Tuple<string, string>>
            {
                new Tuple<string, string>("cref", cref)
            });
        }

        public static XmlElementSyntax DocumentationPermission(string cref, string text)
        {

            if (cref is null)
                throw new ArgumentNullException(nameof(cref));

            return DocumentationElement("permission ", text, new List<Tuple<string, string>>
            {
                new Tuple<string, string>("cref", cref),
            });
        }

        public static XmlElementSyntax DocumentationException(string cref, string text)
        {

            if (cref is null)
                throw new ArgumentNullException(nameof(cref));

            return DocumentationElement("exception ", text, new List<Tuple<string, string>>
            {
                new Tuple<string, string>("cref", cref),
            });
        }

        public static XmlElementSyntax DocumentationCompletionlist(string cref, string text)
        {

            if (cref is null)
                throw new ArgumentNullException(nameof(cref));

            return DocumentationElement("completionlist ", text, new List<Tuple<string, string>>
            {
                new Tuple<string, string>("cref", cref),
            });
        }


        private static SyntaxToken XmlTextNewLine()
        {
            return SyntaxFactory.XmlTextNewLine(
                SyntaxFactory.TriviaList(), Environment.NewLine, Environment.NewLine, SyntaxFactory.TriviaList());
        }

        public static DocumentationCommentTriviaSyntax DocumentationComment(params XmlElementSyntax[] elements)
        {
            return DocumentationComment((IEnumerable<XmlElementSyntax>)elements);
        }

        public static DocumentationCommentTriviaSyntax DocumentationComment(IEnumerable<XmlElementSyntax> elements)
        {

            var separator = SyntaxFactory.XmlText(SyntaxFactory.TokenList(XmlTextNewLine()));

            var docComment = SyntaxFactory.DocumentationCommentTrivia
                (
                SyntaxKind.SingleLineDocumentationCommentTrivia)
                    .WithContent(new SyntaxList<XmlNodeSyntax>(elements.AddAfterEach<XmlNodeSyntax>(separator)
                    .ToSyntaxList())
                );

            return docComment;

        }

        private static XmlElementSyntax DocumentationElement(string elementName, string text, IEnumerable<Tuple<string, string>> attributes = null)
        {

            var exteriorTrivia = SyntaxFactory.DocumentationCommentExterior("///");

            string[] lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var tokens = new List<SyntaxToken>
            {
                XmlTextNewLine()
            };

            foreach (var line in lines)
            {
                var lineToken = XmlText(line)
                    .WithLeadingTrivia(exteriorTrivia);
                tokens.Add(lineToken);

                tokens.Add(XmlTextNewLine());
            }

            var attributeSyntaxes = new List<XmlAttributeSyntax>();

            if (attributes != null)
                foreach (var attribute in attributes)
                {

                    attributeSyntaxes.Add
                    (
                        SyntaxFactory.XmlNameAttribute
                        (
                            attribute.Item1.XmlName(),
                            SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken), SyntaxFactory.IdentifierName(attribute.Item2),
                            SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken)
                        )
                   );
                }
            
            return SyntaxFactory.XmlElement
            (
                SyntaxFactory.XmlElementStartTag(elementName.XmlName(), attributeSyntaxes.ToSyntaxList())
                    .WithLeadingTrivia(exteriorTrivia),
                new XmlNodeSyntax[]
                {
                    SyntaxFactory.XmlText(SyntaxFactory.TokenList(tokens))
                }.ToSyntaxList(),
                SyntaxFactory.XmlElementEndTag(elementName.XmlName()).WithLeadingTrivia(exteriorTrivia)
            );

        }

        private static SyntaxToken XmlText(string text)
        {
            return SyntaxFactory.XmlTextLiteral(new SyntaxTriviaList(), text, text, new SyntaxTriviaList());
        }



    }

}
