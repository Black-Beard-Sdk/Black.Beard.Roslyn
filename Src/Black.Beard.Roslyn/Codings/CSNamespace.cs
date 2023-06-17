using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Codings
{

    public class CSNamespace : CSMemberDeclaration
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CSNamespace"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public CSNamespace(string name)
            : base(name)
        {

        }
       

        /// <summary>
        /// create a class with specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public CSNamespace Class(string name, Action<CsClassDeclaration> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            action(Class(name));
            return this;
        }

        /// <summary>
        /// create a class with specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public CsClassDeclaration Class(string name)
        {
            return Add(new CsClassDeclaration(name));
        }

        internal override SyntaxNode Build()
        {

            NamespaceDeclarationSyntax ns = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(Name));

            if (_warnings.Count > 0)
            ns = ns.PragmaWarning(false, _warnings.ToArray());

            #region attributes

            var attr = GetAttributes();
            foreach (var attribute in attr)
                ns = ns.AddAttributeLists(attribute);

            #endregion attributes

            foreach (var member in Members)
            {

                var r = member.Build();
                if (r != null)
                {
                    if (r is MemberDeclarationSyntax m)
                        ns = ns.AddMembers(m);

                    else
                    {
                        Stop();
                    }
                }

            }

            ns = ApplyXmlDocumentation(ns);

            return ns.NormalizeWhitespace();
        }

    }

}
