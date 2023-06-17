using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Codings
{
    /// <summary>
    /// Extension methods that help with creating of Roslyn syntax trees.
    /// </summary>
    public static class RoslynExtensions
    {

        public static string GetName(this FieldDeclarationSyntax fieldDeclaration)
        {
            return fieldDeclaration.Declaration.Variables.Single().Identifier.ValueText;
        }

        public static string GetName(this PropertyDeclarationSyntax propertyDeclaration)
        {
            return propertyDeclaration.Identifier.ValueText;
        }

        public static string GetName(this ParameterSyntax parameter)
        {
            return parameter.Identifier.ValueText;
        }

        public static string GetName(this LocalDeclarationStatementSyntax localDeclarationStatement)
        {
            return localDeclarationStatement.Declaration.Variables.Single().Identifier.ValueText;
        }

        public static SyntaxList<T> ToSyntaxList<T>(this IEnumerable<T> nodes) where T : SyntaxNode
        {
            return SyntaxFactory.List(nodes);
        }

        public static SeparatedSyntaxList<T> ToSeparatedList<T>(this IEnumerable<T> nodes, SyntaxKind separator = SyntaxKind.CommaToken)
            where T : SyntaxNode
        {
            var nodesArray = nodes == null ? new T[0] : nodes.ToArray();
            return SyntaxFactory.SeparatedList(
                nodesArray, Enumerable.Repeat(SyntaxFactory.Token(separator), Math.Max(nodesArray.Length - 1, 0)));
        }

        public static TNode WithDocumentationSummary<TNode>(this TNode node, string valueText) where TNode : SyntaxNode
        {
            return node.WithLeadingTrivia(SyntaxFactory.Trivia(DocXml.DocumentationComment(DocXml.DocumentationSummary(valueText))));
        }

        public static TNode WithDocumentationRemarks<TNode>(this TNode node, string valueText) where TNode : SyntaxNode
        {
            return node.WithLeadingTrivia(SyntaxFactory.Trivia(DocXml.DocumentationComment(DocXml.DocumentationRemarks(valueText))));
        }

        public static TNode WithDocumentationReturns<TNode>(this TNode node, string valueText) where TNode : SyntaxNode
        {
            return node.WithLeadingTrivia(SyntaxFactory.Trivia(DocXml.DocumentationComment(DocXml.DocumentationReturns(valueText))));
        }

        public static TNode WithDocumentationExample<TNode>(this TNode node, string valueText) where TNode : SyntaxNode
        {
            return node.WithLeadingTrivia(SyntaxFactory.Trivia(DocXml.DocumentationComment(DocXml.DocumentationExample(valueText))));
        }

        public static TNode WithDocumentationParameter<TNode>(this TNode node, string parameterName, string valueText) where TNode : SyntaxNode
        {
            if (parameterName is null)
                throw new ArgumentNullException(nameof(parameterName));

            return node.WithLeadingTrivia(SyntaxFactory.Trivia(DocXml.DocumentationComment(DocXml.DocumentationParameter(parameterName, valueText))));
        }

        public static TNode WithDocumentationInclude<TNode>(this TNode node, string file, string path) where TNode : SyntaxNode
        {
            if (file is null)
                throw new ArgumentNullException(nameof(file));

            if (path is null)            
                throw new ArgumentNullException(nameof(path));

            return node.WithLeadingTrivia(SyntaxFactory.Trivia(DocXml.DocumentationComment(DocXml.DocumentationInclude(file, path))));
        }

        public static TNode WithDocumentationInheritdoc<TNode>(this TNode node, string cref) where TNode : SyntaxNode
        {
            if (cref is null)
                throw new ArgumentNullException(nameof(cref));

            return node.WithLeadingTrivia(SyntaxFactory.Trivia(DocXml.DocumentationComment(DocXml.DocumentationInheritdoc(cref))));
        }

        public static TNode WithDocumentationPermission<TNode>(this TNode node, string cref, string textValue) where TNode : SyntaxNode
        {
            if (cref is null)
                throw new ArgumentNullException(nameof(cref));

            return node.WithLeadingTrivia(SyntaxFactory.Trivia(DocXml.DocumentationComment(DocXml.DocumentationPermission(cref, textValue))));
        }

        public static TNode WithDocumentationException<TNode>(this TNode node, string cref, string textValue) where TNode : SyntaxNode
        {
            if (cref is null)
                throw new ArgumentNullException(nameof(cref));

            return node.WithLeadingTrivia(SyntaxFactory.Trivia(DocXml.DocumentationComment(DocXml.DocumentationException(cref, textValue))));
        }

        public static TNode WithDocumentationCompletionlist<TNode>(this TNode node, string cref, string textValue) where TNode : SyntaxNode
        {
            if (cref is null)
                throw new ArgumentNullException(nameof(cref));

            return node.WithLeadingTrivia(SyntaxFactory.Trivia(DocXml.DocumentationComment(DocXml.DocumentationCompletionlist(cref, textValue))));
        }

        public static T SingleDescendant<T>(this SyntaxNode node) where T : SyntaxNode
        {
            return node.DescendantNodes().OfType<T>().Single();
        }

        /// <summary>
        /// Returns a collection that has
        /// the given object added after each item in the original collection.
        /// </summary>
        public static IEnumerable<T> AddAfterEach<T>(this IEnumerable<T> collection, T added)
        {
            foreach (var item in collection)
            {
                yield return item;
                yield return added;
            }
        }


    }

}
