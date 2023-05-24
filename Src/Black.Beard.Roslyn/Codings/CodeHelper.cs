using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Bb.Codings
{

    public static class CodeHelper
    {


        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        public static void Stop(Func<bool> test = null)
        {
            if (System.Diagnostics.Debugger.IsAttached)
                if (test == null || test())
                    System.Diagnostics.Debugger.Break();
        }


        public static ElementAccessExpressionSyntax ElementAccess(ExpressionSyntax expression, params ExpressionSyntax[] arguments)
        {
            return SyntaxFactory.ElementAccessExpression(
                expression,
                SyntaxFactory.BracketedArgumentList(arguments.Select(SyntaxFactory.Argument).ToSeparatedList()));
        }

        #region MemberAccess

        public static MemberAccessExpressionSyntax MemberAccess(this string name, string memberName)
        {
            return MemberAccess(SyntaxFactory.ParseExpression(name), memberName);
        }

        public static MemberAccessExpressionSyntax MemberAccess(this NamedNode namedNode, string memberName)
        {
            return MemberAccess((ExpressionSyntax)namedNode, memberName);
        }

        public static MemberAccessExpressionSyntax MemberAccess(this ExpressionSyntax expression, string memberName)
        {
            return MemberAccess(expression, (SimpleNameSyntax)SyntaxFactory.ParseName(memberName));
        }

        public static MemberAccessExpressionSyntax MemberAccess(this string name, SimpleNameSyntax memberName)
        {
            return MemberAccess(SyntaxFactory.ParseExpression(name), memberName);
        }

        public static MemberAccessExpressionSyntax MemberAccess(this ExpressionSyntax expression, SimpleNameSyntax memberName)
        {
            return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expression, memberName);
        }

        #endregion MemberAccess

        #region Sets

        public static AssignmentExpressionSyntax Set(this NamedNode left, NamedNode right)
        {
            return Set(SyntaxFactory.IdentifierName(left.Name), SyntaxFactory.IdentifierName(right.Name));
        }

        public static AssignmentExpressionSyntax Set(this NamedNode left, ExpressionSyntax right)
        {
            return Set(SyntaxFactory.IdentifierName(left.Name), right);
        }

        public static AssignmentExpressionSyntax Set(this ExpressionSyntax left, ExpressionSyntax right)
        {
            return SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, left, right);

        }

        #endregion Sets

        public static ThrowStatementSyntax Thrown(this ExpressionSyntax exception)
        {
            // return SyntaxFactory.ThrowStatement(expression);
            return SyntaxFactory.ThrowStatement(exception);
        }

        #region calls

        public static InvocationExpressionSyntax Call(this ExpressionSyntax target, string methodName, params ExpressionSyntax[] arguments)
        {
            return Call(target, methodName, (IEnumerable<ExpressionSyntax>)arguments);
        }

        public static InvocationExpressionSyntax Call(this ExpressionSyntax target, string methodName, IEnumerable<ExpressionSyntax> arguments)
        {


            var invokation = SyntaxFactory.InvocationExpression
            (
                SyntaxFactory.MemberAccessExpression
                (
                    SyntaxKind.SimpleMemberAccessExpression,
                    target,
                    SyntaxFactory.IdentifierName(methodName)
                )
            );

            if (arguments != null)
                invokation = invokation.WithArgumentList(SyntaxFactory.ArgumentList(arguments.Select(SyntaxFactory.Argument).ToSeparatedList()));

            return invokation;

        }

        #endregion calls

        public static ReturnStatementSyntax Return(this NamedNode namedNode)
        {
            return SyntaxFactory.ReturnStatement(namedNode);
        }

        public static ReturnStatementSyntax Return(this ExpressionSyntax expression)
        {
            return SyntaxFactory.ReturnStatement(expression);
        }

        public static BlockSyntax ToBlock(this StatementList self)
        {
            return SyntaxFactory.Block(self);
        }

        public static CatchClauseSyntax Catch(this TypeSyntax exceptionType, string exceptionVariableName, Action<StatementList> action)
        {

            var list = new StatementList();
            action(list);

            var c = SyntaxFactory.CatchClause().WithDeclaration
            (

                SyntaxFactory.CatchDeclaration(exceptionType)
                    .WithIdentifier(SyntaxFactory.Identifier(exceptionVariableName))

            ).WithBlock(list.ToBlock());

            return c;

        }

        public static TryStatementSyntax TryCatchs(BlockSyntax @try, params CatchClauseSyntax[] catchs)
        {
            return SyntaxFactory.TryStatement(@try, catchs.ToSyntaxList(), null);
        }

        public static TryStatementSyntax TryCatchs(BlockSyntax @try, FinallyClauseSyntax @finally, params CatchClauseSyntax[] catchs)
        {
            return SyntaxFactory.TryStatement(@try, catchs.ToSyntaxList(), @finally);
        }

        public static IfStatementSyntax If(ExpressionSyntax condition, Func<StatementSyntax> _true, Func<StatementSyntax> _false = null)
        {

            if (_false == null)
                return SyntaxFactory.IfStatement(condition, _true());

            return SyntaxFactory.IfStatement(condition, _true(), SyntaxFactory.ElseClause(_false()));

        }

        public static ForEachVariableStatementSyntax Foreach(ExpressionSyntax variable, ExpressionSyntax inVariable, Func<StatementSyntax> block)
        {
            return SyntaxFactory.ForEachVariableStatement(variable, inVariable, block());
        }


        #region Operators

        public static BinaryExpressionSyntax Equals(ExpressionSyntax left, ExpressionSyntax right)
        {
            return SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, left, right);
        }

        public static BinaryExpressionSyntax NotEquals(ExpressionSyntax left, ExpressionSyntax right)
        {
            return SyntaxFactory.BinaryExpression(SyntaxKind.NotEqualsExpression, left, right);
        }

        public static BinaryExpressionSyntax And(ExpressionSyntax left, ExpressionSyntax right)
        {
            return SyntaxFactory.BinaryExpression(SyntaxKind.LogicalAndExpression, left, right);
        }

        public static PrefixUnaryExpressionSyntax Not(ExpressionSyntax operand)
        {
            return SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, operand);
        }

        public static TypeOfExpressionSyntax TypeOf(TypeSyntax type)
        {
            return SyntaxFactory.TypeOfExpression(type);
        }

        public static TypeOfExpressionSyntax TypeOf(string typeName)
        {
            return SyntaxFactory.TypeOfExpression(SyntaxFactory.ParseTypeName(typeName));
        }

        public static CastExpressionSyntax Cast(string typeName, ExpressionSyntax expression)
        {
            return SyntaxFactory.CastExpression(SyntaxFactory.ParseTypeName(typeName), expression);
        }

        #endregion Operators


        #region literal


        public static LiteralExpressionSyntax Literal(this object self)
        {

            if (self == null)
                throw new ArgumentNullException(nameof(self));

            if (self is int s1)
                return s1.Literal();

            if (self is string s2)
                return s2.Literal();

            if (self is uint s3)
                return s3.Literal();

            if (self is long s4)
                return s4.Literal();

            if (self is ulong s5)
                return s5.Literal();

            if (self is float s6)
                return s6.Literal();

            if (self is double s7)
                return s7.Literal();

            if (self is decimal s8)
                return s8.Literal();

            if (self is char s9)
                return s9.Literal();

            throw new NotImplementedException(self.ToString());

        }

        public static LiteralExpressionSyntax Literal(this string self, object value)
        {

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (value is int s1)
                return self.Literal(s1);

            if (value is string s2)
                return self.Literal(s2);

            if (value is uint s3)
                return self.Literal(s3);

            if (value is long s4)
                return self.Literal(s4);

            if (value is ulong s5)
                return self.Literal(s5);

            if (value is float s6)
                return self.Literal(s6);

            if (value is double s7)
                return self.Literal(s7);

            if (value is decimal s8)
                return self.Literal(s8);

            if (value is char s9)
                return self.Literal(s9);

            throw new NotImplementedException(self.ToString());

        }

        public static LiteralExpressionSyntax Literal(this int self)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this string self, int value)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this uint self)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this string self, uint value)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this long self)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this string self, long value)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this ulong self)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this string self, ulong value)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this float self)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this string self, float value)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this double self)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this string self, double value)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this decimal self)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this string self, decimal value)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this string self, string value)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this char self)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.CharacterLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static LiteralExpressionSyntax Literal(this string self, char value)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(self));
        }

        public static ThisExpressionSyntax This()
        {
            return SyntaxFactory.ThisExpression(SyntaxKind.ThisExpression.ToToken());
        }

        public static LiteralExpressionSyntax Literal(this bool value)
        {
            return SyntaxFactory.LiteralExpression(
                value ? SyntaxKind.TrueLiteralExpression : SyntaxKind.FalseLiteralExpression);
        }

        public static LiteralExpressionSyntax Literal(long value, bool useHex = false)
        {
            return SyntaxFactory.LiteralExpression(
                SyntaxKind.NumericLiteralExpression,
                SyntaxFactory.Literal(
                    string.Format(System.Globalization.CultureInfo.InvariantCulture, useHex ? "0x{0:X}" : "{0}", value),
                    value));
        }

        public static LiteralExpressionSyntax Literal(this string self)
        {

            // TODO: escaping
            //return SyntaxFactory.LiteralExpression(
            //    SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal('"' + self + '"' /*, value*/));

            return SyntaxFactory.LiteralExpression(
                SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(self));

        }

        public static LiteralExpressionSyntax NullLiteral()
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression);
        }

        #endregion literal


        #region switch

        public static StatementSyntax ToStatement(this ExpressionSyntax self)
        {
            return SyntaxFactory.ExpressionStatement(self);
        }

        #region SwitchLabel

        public static SwitchLabelSyntax Label(this int self)
        {
            return SyntaxFactory.CaseSwitchLabel(self.Literal());
        }

        public static SwitchLabelSyntax Label(this uint self)
        {
            return SyntaxFactory.CaseSwitchLabel(self.Literal());
        }

        public static SwitchLabelSyntax Label(this long self)
        {
            return SyntaxFactory.CaseSwitchLabel(self.Literal());
        }

        public static SwitchLabelSyntax Label(this ulong self)
        {
            return SyntaxFactory.CaseSwitchLabel(self.Literal());
        }

        public static SwitchLabelSyntax Label(this float self)
        {
            return SyntaxFactory.CaseSwitchLabel(self.Literal());
        }

        public static SwitchLabelSyntax Label(this double self)
        {
            return SyntaxFactory.CaseSwitchLabel(self.Literal());
        }

        public static SwitchLabelSyntax Label(this decimal self)
        {
            return SyntaxFactory.CaseSwitchLabel(self.Literal());
        }

        public static SwitchLabelSyntax Label(this char self)
        {
            return SyntaxFactory.CaseSwitchLabel(self.Literal());
        }

        public static SwitchLabelSyntax Label(this string self)
        {
            return SyntaxFactory.CaseSwitchLabel(self.Literal());
        }

        #endregion SwitchLabel

        public static SwitchSectionSyntax Case(SwitchLabelSyntax labelCase, params StatementSyntax[] items)
        {

            var list = new SyntaxList<SwitchLabelSyntax>(labelCase);
            return SyntaxFactory.SwitchSection(list, new SyntaxList<StatementSyntax>(items));
        }

        public static SwitchSectionSyntax Case(SyntaxList<SwitchLabelSyntax> labels, params StatementSyntax[] items)
        {
            return SyntaxFactory.SwitchSection(labels, new SyntaxList<StatementSyntax>(items));
        }

        public static SwitchStatementSyntax Switch(ExpressionSyntax condition, params SwitchSectionSyntax[] items)
        {
            var list = new SyntaxList<SwitchSectionSyntax>(items);
            return SyntaxFactory.SwitchStatement(condition, list);
        }

        #endregion switch


        #region Create

        public static ExpressionSyntax NewArray(string typeName, IEnumerable<ExpressionSyntax> expressions)
        {
            var initializer = SyntaxFactory.InitializerExpression(
                SyntaxKind.ArrayInitializerExpression, expressions.ToSeparatedList());

            if (string.IsNullOrEmpty(typeName))
                return SyntaxFactory.ImplicitArrayCreationExpression(initializer);

            var list = new SyntaxList<ArrayRankSpecifierSyntax>(SyntaxFactory.ArrayRankSpecifier());

            return SyntaxFactory.ArrayCreationExpression(SyntaxFactory.ArrayType(SyntaxFactory.ParseTypeName(typeName), list),
                initializer);
        }

        public static ObjectCreationExpressionSyntax NewObject
        (
            this string typeName,
            IEnumerable<ExpressionSyntax> arguments,
            IEnumerable<IEnumerable<ExpressionSyntax>> initializers = null
            )
        {
            return NewObject(SyntaxFactory.ParseTypeName(typeName), arguments, initializers);
        }

        public static ObjectCreationExpressionSyntax NewObject
        (
            this string typeName,
            params ExpressionSyntax[] arguments)
        {
            return NewObject(typeName, (IEnumerable<ExpressionSyntax>)arguments);
        }

        public static ObjectCreationExpressionSyntax NewObject
        (
            this TypeSyntax type,
            params ExpressionSyntax[] arguments
            )
        {
            return NewObject(type, (IEnumerable<ExpressionSyntax>)arguments);
        }

        public static ObjectCreationExpressionSyntax NewObject
        (
            this TypeSyntax type,
            IEnumerable<ExpressionSyntax> arguments,
            IEnumerable<ExpressionSyntax> initializers)
        {
            return NewObject(type, arguments, initializers.Select(i => new[] { i }));
        }

        public static ObjectCreationExpressionSyntax NewObject
        (
            TypeSyntax type, IEnumerable<ExpressionSyntax> arguments,
            IEnumerable<IEnumerable<ExpressionSyntax>> initializers = null)
        {

            var argumentsArray = arguments == null ? new ExpressionSyntax[0] : arguments.ToArray();
            var argumentList =
                argumentsArray.Length == 0
                    ? SyntaxFactory.ArgumentList()
                    : SyntaxFactory.ArgumentList(argumentsArray.Select(SyntaxFactory.Argument).ToSeparatedList());

            InitializerExpressionSyntax initializer =
                initializers == null
                    ? null
                    : SyntaxFactory.InitializerExpression(
                        SyntaxKind.CollectionInitializerExpression, initializers.Select(ToInitializer).ToSeparatedList());

            return SyntaxFactory.ObjectCreationExpression(type, argumentList, initializer);

        }

        private static ExpressionSyntax ToInitializer(IEnumerable<ExpressionSyntax> expressions)
        {
            var expressionsArray = expressions.ToArray();

            if (expressionsArray.Length == 1)
                return expressionsArray[0];

            return SyntaxFactory.InitializerExpression(
                SyntaxKind.ObjectInitializerExpression, expressionsArray.ToSeparatedList());
        }

        #endregion

        public static ExpressionSyntax Coalesce(ExpressionSyntax left, ExpressionSyntax right)
        {
            return SyntaxFactory.BinaryExpression(SyntaxKind.CoalesceExpression, left, right);
        }

        #region Types

        public static TypeSyntax AsType(this Type self, params object[] genericArguments)
        {

            if (self == typeof(int))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.IntKeyword));

            if (self == typeof(string))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.StringKeyword));

            if (self == typeof(double))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.DoubleKeyword));

            if (self == typeof(float))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.FloatKeyword));

            if (self == typeof(decimal))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.DecimalKeyword));

            if (self == typeof(long))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.LongKeyword));

            if (self == typeof(ulong))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.ULongKeyword));

            if (self == typeof(uint))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.UIntKeyword));

            if (self == typeof(char))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.CharKeyword));

            if (self == typeof(bool))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.BoolKeyword));

            if (self == typeof(byte))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.ByteKeyword));

            if (self == typeof(sbyte))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.SByteKeyword));

            if (self == typeof(short))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.ShortKeyword));

            if (self == typeof(ushort))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.UShortKeyword));

            if (self == typeof(void))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword));

            if (self == typeof(object))
                return SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.ObjectKeyword));

            StringBuilder sb = self.Name.BuildTypename(genericArguments);

            return SyntaxFactory.ParseTypeName(sb.ToString());

        }

        public static TypeSyntax AsType(this string self, params object[] genericArguments)
        {
            StringBuilder sb = self.BuildTypename(genericArguments);
            return SyntaxFactory.ParseTypeName(sb.ToString());
        }

        public static TypeSyntax AsType(this Type self)
        {
            return SyntaxFactory.ParseTypeName(self.Name);
        }

        public static StringBuilder BuildTypename(this Type self)
        {

            StringBuilder sb = new StringBuilder();

            if (self.IsGenericType)
            {

                var _base = self.GetGenericTypeDefinition();
                var n = self.Name.Substring(0, _base.Name.IndexOf('`'));
                sb.Append(n);

                var args = self.GetGenericArguments().ToArray();
                sb.Append("<");

                string comma = string.Empty;
                foreach (var item in args)
                {
                    var a = item.BuildTypename();
                    sb.Append(comma);
                    sb.Append(a);

                    comma = ", ";
                }

                sb.Append(">");

            }
            else
            {
                sb.Append(self.Name);
            }


            return sb;
        }

        public static StringBuilder BuildTypename(this string self, params object[] genericArguments)
        {
            StringBuilder sb = new StringBuilder(self);
            if (genericArguments != null && genericArguments.Length > 0)
            {

                sb.Append("<");

                var g = genericArguments[0];
                if (g is string s1)
                    sb.Append(s1);
                else
                    if (g is Type t1)
                    sb.Append(t1.Name);
                else
                {

                }

                for (int i = 1; i < genericArguments.Length; i++)
                {
                    sb.Append(", ");
                    g = genericArguments[i];
                    if (g is string s2)
                        sb.Append(s2);
                    else
                    if (g is Type t2)
                        sb.Append(t2.Name);
                    else
                    {

                    }
                }
                sb.Append(">");
            }

            return sb;
        }

        public static StringBuilder BuildTypename(this string self, params string[] genericArguments)
        {
            StringBuilder sb = new StringBuilder(self);
            if (genericArguments != null && genericArguments.Length > 0)
            {

                sb.Append("<");

                var g = genericArguments[0];
                sb.Append(g);

                for (int i = 1; i < genericArguments.Length; i++)
                {
                    sb.Append(", ");
                    g = genericArguments[i];
                    sb.Append(g);
                }
                sb.Append(">");
            }

            return sb;
        }


        #endregion Types

        public static LocalDeclarationStatementSyntax DeclareLocalVar(this VariableDeclarationSyntax variableDeclaration)
        {
            var localDeclaration = SyntaxFactory.LocalDeclarationStatement(variableDeclaration);
            return localDeclaration;
        }

        public static VariableDeclarationSyntax DeclareVar(this string name, TypeSyntax type)
        {

            var variableDeclaration = SyntaxFactory.VariableDeclaration(type)
                .WithVariables
                (
                    SyntaxFactory.SingletonSeparatedList(SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(name)))
                );


            return variableDeclaration;

        }

        public static VariableDeclarationSyntax DeclareVar(this string name, TypeSyntax type, ExpressionSyntax initializer)
        {

            var variableDeclaration = SyntaxFactory.VariableDeclaration(type)
                .WithVariables
                (
                    SyntaxFactory.SingletonSeparatedList
                    (
                        SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(name))
                        .WithInitializer(SyntaxFactory.EqualsValueClause(initializer))
                    )
                );

            return variableDeclaration;

        }

        public static LocalDeclarationStatementSyntax DeclareLocalVar(this string name, TypeSyntax type)
        {

            var variableDeclaration = SyntaxFactory.VariableDeclaration(type)
                .WithVariables
                (
                    SyntaxFactory.SingletonSeparatedList(SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(name)))
                );


            return SyntaxFactory.LocalDeclarationStatement(variableDeclaration);

        }

        public static LocalDeclarationStatementSyntax DeclareLocalVar(this string name, TypeSyntax type, ExpressionSyntax initializer)
        {

            var variableDeclaration = SyntaxFactory.VariableDeclaration(type)
                .WithVariables
                (
                    SyntaxFactory.SingletonSeparatedList
                    (
                        SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(name))
                        .WithInitializer(SyntaxFactory.EqualsValueClause(initializer))
                    )
                );

            return SyntaxFactory.LocalDeclarationStatement(variableDeclaration);

        }

        public static SyntaxNodeOrToken[] ToListSaparated(this IEnumerable<SyntaxNode> self, SyntaxKind separator)
        {
            var lst = new List<SyntaxNodeOrToken>(self.Count() * 2);

            var l = self.ToArray();

            lst.Add(l[0]);

            for (var i = 1; i < l.Length; i++)
            {
                SyntaxFactory.Token(separator);
                lst.Add(l[i]);
            }

            return lst.ToArray();

        }

        public static IdentifierNameSyntax Identifier(this string self)
        {
            return SyntaxFactory.IdentifierName(self);
        }

        public static BlockSyntax ToBlock(this SyntaxList<StatementSyntax> self)
        {
            return SyntaxFactory.Block(self);
        }

        public static SyntaxToken ToToken(this SyntaxKind self)
        {
            return SyntaxFactory.Token(self);
        }

        public static SyntaxTokenList TokenList(IEnumerable<SyntaxKind> modifiers)
        {
            return SyntaxFactory.TokenList(modifiers.Select(SyntaxFactory.Token));
        }

        public static SyntaxTokenList TokenList(SyntaxKind? modifier)
        {
            return modifier == null ? SyntaxFactory.TokenList() : SyntaxFactory.TokenList(SyntaxFactory.Token(modifier.Value));
        }

        public static ConstructorDeclarationSyntax ConstructorDeclaration
        (
            IEnumerable<SyntaxKind> modifiers, string className, IEnumerable<ParameterSyntax> parameters = null,
            IEnumerable<StatementSyntax> statements = null, ConstructorInitializerSyntax constructorInitializer = null)
        {
            return SyntaxFactory.ConstructorDeclaration(className)
                .WithModifiers(TokenList(modifiers))
                .WithParameterList(SyntaxFactory.ParameterList(parameters.ToSeparatedList()))
                .WithBody(SyntaxFactory.Block(statements.ToSyntaxList()))
                .WithInitializer(constructorInitializer);
        }

        public static OperatorDeclarationSyntax OperatorDeclaration(TypeSyntax returnType, SyntaxKind operatorToken, IEnumerable<ParameterSyntax> parameters, IEnumerable<StatementSyntax> statements = null)
        {
            return SyntaxFactory.OperatorDeclaration(returnType, SyntaxFactory.Token(operatorToken))
                         .WithModifiers(TokenList(new[] { SyntaxKind.PublicKeyword, SyntaxKind.StaticKeyword }))
                         .WithParameterList(SyntaxFactory.ParameterList(parameters.ToSeparatedList()))
                         .WithBody(SyntaxFactory.Block(statements.ToSyntaxList()));
        }

        public static ConstructorInitializerSyntax ThisConstructorInitializer(params ExpressionSyntax[] arguments)
        {
            return ConstructorInitializer(SyntaxKind.ThisConstructorInitializer, arguments);
        }

        public static ConstructorInitializerSyntax BaseConstructorInitializer(params ExpressionSyntax[] arguments)
        {
            return ConstructorInitializer(SyntaxKind.BaseConstructorInitializer, arguments);
        }

        private static ConstructorInitializerSyntax ConstructorInitializer(SyntaxKind kind, IEnumerable<ExpressionSyntax> arguments)
        {
            return SyntaxFactory.ConstructorInitializer(
                kind, SyntaxFactory.ArgumentList(arguments.Select(SyntaxFactory.Argument).ToSeparatedList()));
        }

        public static ParameterSyntax Parameter(string typeName, string name, ExpressionSyntax defaultValue = null, IEnumerable<SyntaxKind> modifiers = null)
        {
            return Parameter(SyntaxFactory.ParseTypeName(typeName), name, defaultValue, modifiers);
        }

        public static ParameterSyntax Parameter(TypeSyntax type, string name, ExpressionSyntax defaultValue = null, IEnumerable<SyntaxKind> modifiers = null)
        {
            return SyntaxFactory.Parameter(SyntaxFactory.Identifier(name))
                .WithType(type)
                .WithDefault(defaultValue == null ? null : SyntaxFactory.EqualsValueClause(defaultValue))
                .WithModifiers(modifiers == null ? default(SyntaxTokenList) : TokenList(modifiers));
        }

    }

}
