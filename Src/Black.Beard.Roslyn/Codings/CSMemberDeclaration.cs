using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Xml.Linq;
using System.Collections.Generic;
using System;
using System.Linq;
using Bb.Compilers;

namespace Bb.Codings
{

    public abstract class CSMemberDeclaration : CSharpNode
    {

        public CSMemberDeclaration(string name)
            : base()
        {
            _isPublic = true;
            Name = name?.EnsureLiteralName();
            _attributes = new List<CsAttributeDeclaration>();
            _members = new List<CSMemberDeclaration>();
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

        public T Add<T>(T member)
            where T : CSMemberDeclaration
        {

            if (member is CsAttributeDeclaration a)
                Add(a);

            else
                _members.Add(member);

            return member;

        }


        public CSMemberDeclaration Field(string fieldName, string type, Action<CsFieldDeclaration> action)
        {
            var field = Field(fieldName, type);
            action(field);
            _members.Add(field);
            return this;
        }

        public CsFieldDeclaration Field(string fieldName, string type)
        {
            return Add(new CsFieldDeclaration(fieldName, type));
        }        

        protected T ApplyXmlDocumentation<T>(T node) where T : SyntaxNode
        {
            if (_doc != null)
                return _doc.Apply(node);

            return node;

        }


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
