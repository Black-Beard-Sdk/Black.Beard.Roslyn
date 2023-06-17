using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace Bb.Codings
{
    /// <summary>
    /// Class that represents reference to a named symbol, like a local variable or a field.
    /// Can be used for referencing such node after its creation.
    /// 
    /// Is implicitly convertible from types declaring those symbols and to <see cref="IdentifierNameSyntax"/>,
    /// that's be used to reference them.
    /// </summary>
    public class NamedNode
    {
        private readonly string m_name;

        private NamedNode(string name)
        {
            m_name = name;
        }

        public static implicit operator NamedNode(FieldDeclarationSyntax fieldDeclaration)
        {
            return new NamedNode(fieldDeclaration.GetName());
        }

        public static implicit operator NamedNode(PropertyDeclarationSyntax propertyDeclaration)
        {
            return new NamedNode(propertyDeclaration.GetName());
        }

        public static implicit operator NamedNode(ParameterSyntax parameter)
        {
            return new NamedNode(parameter.GetName());
        }

        public static implicit operator NamedNode(LocalDeclarationStatementSyntax localDeclarationStatement)
        {
            return new NamedNode(localDeclarationStatement.GetName());
        }

        public static implicit operator IdentifierNameSyntax(NamedNode namedNode)
        {
            return SyntaxFactory.IdentifierName(namedNode.Name);
        }

        public string Name
        {
            get
            {
                if (m_name == null)
                    throw new InvalidOperationException();
                return m_name;
            }
        }
    }

    }
