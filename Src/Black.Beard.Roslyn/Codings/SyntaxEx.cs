using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Codings
{
    /// <summary>
    /// Contains methods for easy creating of Roslyn syntax trees.
    /// </summary>
    public static class SyntaxEx
    {


        public static TypeParameterSyntax TypeParameter(string typeParameterName)
        {
            return SyntaxFactory.TypeParameter(SyntaxFactory.Identifier(typeParameterName));
        }

        //public static EnumDeclarationSyntax EnumDeclaration(string enumName, IEnumerable<string> members)
        //{
        //    return EnumDeclaration(enumName, members.Select(m => EnumMemberDeclaration(m)));
        //}
        //public static EnumMemberDeclarationSyntax EnumMemberDeclaration(string name, long? value = null, bool useHex = true)
        //{
        //    var valueClause = value == null ? null : SyntaxFactory.EqualsValueClause(Literal(value.Value, useHex));
        //    return SyntaxFactory.EnumMemberDeclaration(name).WithEqualsValue(valueClause);
        //}

        //public static EnumDeclarationSyntax EnumDeclaration(string enumName, IEnumerable<EnumMemberDeclarationSyntax> members, SyntaxKind? baseType = null)
        //{
        //    return SyntaxFactory.EnumDeclaration(enumName)
        //        .WithModifiers(TokenList(SyntaxKind.PublicKeyword))
        //        .WithBaseList(
        //            baseType == null
        //                ? null
        //                : SyntaxFactory.BaseList(
                                                                                                                                                         
        //                    new TypeSyntax[] { SyntaxFactory.PredefinedType(SyntaxFactory.Token(baseType.Value)) }
        //                        .ToSeparatedList()))
        //        .WithMembers(members.ToSeparatedList());
        //}

        

        










        //public static NamespaceDeclarationSyntax NamespaceDeclaration(
        //    string name, params MemberDeclarationSyntax[] members)
        //{
        //    return SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(name))
        //        .WithMembers(members.Where(m => m != null).ToSyntaxList());
        //}

        //public static CompilationUnitSyntax CompilationUnit(NamespaceDeclarationSyntax member, params string[] usings)
        //{
        //    return SyntaxFactory.CompilationUnit()
        //        .WithUsings(usings.Select(u => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(u))).ToSyntaxList())
        //        .WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>(member));
        //}

        //public static PropertyDeclarationSyntax AutoPropertyDeclaration(
        //    IEnumerable<SyntaxKind> modifiers, string typeName, string propertyName,
        //    SyntaxKind? setModifier = null, SyntaxKind? getModifier = null, bool isAbstract = false)
        //{
        //    return AutoPropertyDeclaration(
        //        modifiers, SyntaxFactory.ParseTypeName(typeName), propertyName, setModifier, getModifier, isAbstract);
        //}

        //public static PropertyDeclarationSyntax AutoPropertyDeclaration(
        //    IEnumerable<SyntaxKind> modifiers, TypeSyntax type, string propertyName,
        //    SyntaxKind? setModifier = null, SyntaxKind? getModifier = null, bool isAbstract = false)
        //{
        //    var accesors = new List<AccessorDeclarationSyntax>();
        //    if (!(isAbstract && getModifier == SyntaxKind.PrivateKeyword))
        //        accesors.Add(
        //            SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
        //            .WithModifiers(TokenList(getModifier))
        //            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));
        //    if (!(isAbstract && setModifier == SyntaxKind.PrivateKeyword))
        //        accesors.Add(
        //            SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
        //                .WithModifiers(TokenList(setModifier))
        //                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));

        //    return SyntaxFactory.PropertyDeclaration(type, propertyName)
        //        .WithModifiers(TokenList(modifiers))
        //        .WithAccessorList(SyntaxFactory.AccessorList(accesors.ToSyntaxList()));
        //}

        //public static PropertyDeclarationSyntax PropertyDeclaration(
        //    IEnumerable<SyntaxKind> modifiers, TypeSyntax type, string propertyName,
        //    IEnumerable<StatementSyntax> getStatements, SyntaxKind? getModifier = null,
        //    IEnumerable<StatementSyntax> setStatements = null, SyntaxKind? setModifier = null)
        //{
        //    var accessors = new List<AccessorDeclarationSyntax>();

        //    accessors.Add(
        //        SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
        //            .WithModifiers(TokenList(getModifier))
        //            .WithBody(SyntaxFactory.Block(getStatements.ToSyntaxList())));

        //    if (setStatements != null)
        //        accessors.Add(
        //            SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
        //            .WithModifiers(TokenList(setModifier))
        //            .WithBody(SyntaxFactory.Block(setStatements.ToSyntaxList())));

        //    return SyntaxFactory.PropertyDeclaration(type, propertyName)
        //        .WithModifiers(TokenList(modifiers))
        //        .WithAccessorList(SyntaxFactory.AccessorList(accessors.ToSyntaxList()));
        //}

        //public static MethodDeclarationSyntax MethodDeclaration(
        //    IEnumerable<SyntaxKind> modifiers, string returnTypeName, string methodName,
        //    IEnumerable<ParameterSyntax> parameters, params StatementSyntax[] statements)
        //{
        //    return MethodDeclaration(
        //        modifiers, returnTypeName, methodName, parameters, (IEnumerable<StatementSyntax>)statements);
        //}

        //public static MethodDeclarationSyntax MethodDeclaration(
        //    IEnumerable<SyntaxKind> modifiers, string returnTypeName, string methodName,
        //    IEnumerable<ParameterSyntax> parameters, IEnumerable<StatementSyntax> statements)
        //{
        //    return MethodDeclaration(
        //        modifiers, SyntaxFactory.ParseTypeName(returnTypeName), methodName, parameters, statements);
        //}

        //public static MethodDeclarationSyntax MethodDeclaration(
        //    IEnumerable<SyntaxKind> modifiers, TypeSyntax returnType, string methodName,
        //    IEnumerable<ParameterSyntax> parameters, params StatementSyntax[] statements)
        //{
        //    return MethodDeclaration(modifiers, returnType, methodName, null, parameters, statements);
        //}

        //public static MethodDeclarationSyntax MethodDeclaration(
        //    IEnumerable<SyntaxKind> modifiers, TypeSyntax returnType, string methodName,
        //    IEnumerable<TypeParameterSyntax> typeParameters, IEnumerable<ParameterSyntax> parameters,
        //    params StatementSyntax[] statements)
        //{
        //    return MethodDeclaration(
        //        modifiers, returnType, methodName, typeParameters, parameters, (IEnumerable<StatementSyntax>)statements);
        //}

        //public static MethodDeclarationSyntax MethodDeclaration(
        //    IEnumerable<SyntaxKind> modifiers, TypeSyntax returnType, string methodName,
        //    IEnumerable<ParameterSyntax> parameters, IEnumerable<StatementSyntax> statements)
        //{
        //    return MethodDeclaration(modifiers, returnType, methodName, null, parameters, statements);
        //}

        //public static MethodDeclarationSyntax MethodDeclaration(
        //    IEnumerable<SyntaxKind> modifiers, TypeSyntax returnType, string methodName,
        //    IEnumerable<TypeParameterSyntax> typeParameters, IEnumerable<ParameterSyntax> parameters,
        //    IEnumerable<StatementSyntax> statements)
        //{
        //    var typeParameterListSyntax =
        //        typeParameters == null
        //            ? null
        //            : SyntaxFactory.TypeParameterList(typeParameters.ToSeparatedList());
        //    var statmentsSyntax = statements == null ? null : SyntaxFactory.Block(statements.ToSyntaxList());
        //    var semicolonToken = statements == null ? SyntaxFactory.Token(SyntaxKind.SemicolonToken) : default(SyntaxToken);

        //    return SyntaxFactory.MethodDeclaration(returnType, methodName)
        //        .WithModifiers(TokenList(modifiers))
        //        .WithTypeParameterList(typeParameterListSyntax)
        //        .WithParameterList(SyntaxFactory.ParameterList(parameters.ToSeparatedList()))
        //        .WithBody(statmentsSyntax)
        //        .WithSemicolonToken(semicolonToken);
        //}

        //private static ExpressionSyntax ToInitializer(IEnumerable<ExpressionSyntax> expressions)
        //{
        //    var expressionsArray = expressions.ToArray();

        //    if (expressionsArray.Length == 1)
        //        return expressionsArray[0];

        //    return SyntaxFactory.InitializerExpression(
        //        SyntaxKind.ObjectInitializerExpression, expressionsArray.ToSeparatedList());
        //}

        //public static LocalDeclarationStatementSyntax LocalDeclaration(
        //    string type, string localName, ExpressionSyntax value)
        //{
        //    return SyntaxFactory.LocalDeclarationStatement(
        //        SyntaxFactory.VariableDeclaration(
        //            SyntaxFactory.ParseTypeName(type),
        //            SyntaxFactory.SeparatedList(
        //                SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(localName))
        //                    .WithInitializer(SyntaxFactory.EqualsValueClause(value)))));
        //}




        //public static GenericNameSyntax GenericName(string name, params string[] typeArgumentNames)
        //{
        //    return GenericName(name, (IEnumerable<string>)typeArgumentNames);
        //}

        //public static GenericNameSyntax GenericName(string name, IEnumerable<string> typeArgumentNames)
        //{
        //    return GenericName(name, typeArgumentNames.Select(SyntaxFactory.IdentifierName));
        //}

        //public static GenericNameSyntax GenericName(string name, params TypeSyntax[] typeArguments)
        //{
        //    return GenericName(name, (IEnumerable<TypeSyntax>)typeArguments);
        //}

        //public static GenericNameSyntax GenericName(string name, IEnumerable<TypeSyntax> typeArguments)
        //{
        //    return SyntaxFactory.GenericName(
        //        SyntaxFactory.Identifier(name), SyntaxFactory.TypeArgumentList(typeArguments.ToSeparatedList()));
        //}

        //public static SimpleLambdaExpressionSyntax LambdaExpression(string parameterName, SyntaxNode body)
        //{
        //    return SyntaxFactory.SimpleLambdaExpression(
        //        SyntaxFactory.Parameter(SyntaxFactory.Identifier(parameterName)), body);
        //}

    }

}
