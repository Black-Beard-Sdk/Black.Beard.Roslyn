using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Text;

namespace Bb
{

    public class DocumentationHelper
    {

        //public DocumentationHelper()
        //{

        //    _items = new List<FileCode>();
        //    LanguageVersion = LanguageVersion.Default;
        //}

        ///// <summary>
        ///// Append code int the parser
        ///// </summary>
        ///// <param name="codes"></param>
        ///// <returns></returns>
        //public DocumentationHelper WithCode(IEnumerable<FileCode> codes)
        //{
        //    _items.AddRange(codes);
        //    return this;

        //}

        /// <summary>
        /// Set language
        /// </summary>
        /// <param name="language"><see cref="LanguageVersion"></param>
        /// <returns></returns>
        public DocumentationHelper WithLanguage(LanguageVersion language)
        {
            LanguageVersion = language;
            return this;
        }



        private void Parse()
        {

            List<SyntaxTree> sources = new List<SyntaxTree>();

            CSharpParseOptions options = CSharpParseOptions.Default.WithLanguageVersion(this.LanguageVersion)
                                                                   .WithDocumentationMode(Microsoft.CodeAnalysis.DocumentationMode.Parse)
                                                                   ;

            foreach (var item in this._items)
            {

                var content = item.LoadFromFile();

                var stringText = Microsoft.CodeAnalysis.Text.SourceText.From(content, Encoding.UTF8);
                var tree = SyntaxFactory.ParseSyntaxTree(stringText, options, item.Name);
                sources.Add(tree);
            }


        }



        public LanguageVersion LanguageVersion { get; private set; }


        private readonly List<FileInfo> _items;


    }

}
