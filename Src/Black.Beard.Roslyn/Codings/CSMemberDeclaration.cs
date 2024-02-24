using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Bb.Compilers;
using System.Diagnostics;

namespace Bb.Codings
{

    [DebuggerDisplay("{Name}")]
    public abstract class CSMemberDeclaration : CSharpNode
    {

        public CSMemberDeclaration()
            : base()
        {
            _isPublic = true;
            _attributes = new List<CsAttributeDeclaration>();
            _members = new List<CSMemberDeclaration>();
        }

        public CSMemberDeclaration(string name)
            : this()
        {
            Name = name?.EnsureLiteralName();
        }

        internal void ResetName(string name) => Name = name;

        public string Name { get; private set; }

        public CsAttributeDeclaration Add(CsAttributeDeclaration attribute)
        {
            _attributes.Add(attribute);
            return attribute;
        }

        public CSDocumentationDeclaration Documentation => _doc ??= new CSDocumentationDeclaration();


        #region attributes

        public CsAttributeDeclaration Attribute(Type type)
        {
            return Add(new CsAttributeDeclaration(type));
        }

        public CsAttributeDeclaration Attribute(string attributeName)
        {
            return Add(new CsAttributeDeclaration(attributeName));
        }

        protected List<AttributeListSyntax> GetAttributes()
        {

            List<AttributeListSyntax> attributes = new List<AttributeListSyntax>();
            if (_attributes.Count > 0)
            {

                for (int i = 0; i < _attributes.Count; i++)
                {
                    var lst = new List<AttributeSyntax>
                    {
                        (AttributeSyntax)_attributes[i].Build()
                    };
                    AttributeListSyntax result = SyntaxFactory.AttributeList(SyntaxFactory.SeparatedList(lst.ToArray()));

                    attributes.Add(result);

                }


            }

            return attributes;

        }

        #endregion attributes

        #region Modifiers
               
        protected List<SyntaxNodeOrToken> GetParameters()
        {

            var m = Members.ToList();

            var lst = new List<SyntaxNodeOrToken>(m.Count);

            if (m.Count > 0)
            {

                var p = m[0];

                var p2 = (ParameterSyntax)p.Build();
                if (p2 != null)
                    lst.Add(p2);

                for (int i = 1; i < m.Count; i++)
                {
                    var p3 = m[i];
                    var p4 = (ParameterSyntax)p3.Build();
                    if (p4 != null)
                    {
                        lst.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
                        lst.Add(p4);
                    }
                }

            }

            return lst;
        }

        internal bool _isStatic;
        internal bool _isPublic;
        internal bool _isPrivate;
        internal bool _isInternal;
        internal bool _isProtected;

        #endregion Modifiers

        /// <summary>
        /// Generic method for add member
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <returns></returns>
        public T Add<T>(T member)
            where T : CSMemberDeclaration
        {

            if (member is CsAttributeDeclaration a)
                Add(a);

            else
                _members.Add(member);

            return member;

        }

        /// <summary>
        /// Add a new field
        /// </summary>
        /// <param name="fieldName">name of the field</param>
        /// <param name="type">Type of the field</param>
        /// <param name="action">Action for manipulate the field</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">fieldName can't be null.</exception>
        /// <exception cref="InvalidOperationException">the field can't named like the class</exception>
        public CSMemberDeclaration Field(string fieldName, string type, Action<CsFieldDeclaration> action)
        {
            var field = Field(fieldName, type);
            action(field);
            _members.Add(field);
            return this;
        }

        /// <summary>
        /// Add a new field
        /// </summary>
        /// <param name="fieldName">name of the field</param>
        /// <param name="type">Type of the field</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">fieldName can't be null.</exception>
        /// <exception cref="InvalidOperationException">the field can't named like the class</exception>
        public CsFieldDeclaration Field(string fieldName, string type)
        {

            if (fieldName == null)
                throw new ArgumentNullException(nameof(fieldName));

            if (fieldName == this.Name)
                throw new InvalidOperationException($"the field {nameof(fieldName)} can't named like the class");

            return Add(new CsFieldDeclaration(fieldName, type));
        }        

        protected T ApplyXmlDocumentation<T>(T node) where T : SyntaxNode
        {
            if (_doc != null)
                return _doc.Apply(node);

            return node;

        }

        /// <summary>
        /// Iterator on the members
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> Items<T>()
            where T : CSMemberDeclaration
        {
            foreach (var item in Members.OfType<T>())
                yield return item;
        }

        protected IEnumerable<CSMemberDeclaration> Members => _members;

        private readonly List<CsAttributeDeclaration> _attributes;
        private List<CSMemberDeclaration> _members;
        private CSDocumentationDeclaration _doc;
        internal HashSet<string> _warnings = new HashSet<string>();


    }


}
