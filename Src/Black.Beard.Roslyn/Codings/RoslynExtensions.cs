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

        public static TNode WithDocumentationSummary<TNode>(this TNode node, string summary) where TNode : SyntaxNode
        {
            return node.WithLeadingTrivia(SyntaxFactory.Trivia(DocXml.DocumentationComment(DocXml.DocumentationSummary(summary))));
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
