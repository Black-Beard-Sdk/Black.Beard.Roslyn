//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Bb.Codings
//{

//    public static class RoslynHelper
//    {


//        public static string GetName(this string self, params string[] items)
//        {

//            List<IdentifierNameSyntax> _items = new List<IdentifierNameSyntax>();

//            foreach (var item in items)
//            {
//                _items.Add(SyntaxFactory.IdentifierName(item));
//            }


//            SyntaxFactory.MemberAccessExpression
//                (
//                    SyntaxKind.SimpleMemberAccessExpression,
//                        SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("StatusCodes"), SyntaxFactory.IdentifierName("Status100Continue")),
//                        SyntaxFactory.IdentifierName("Toto")
//                );


//            SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("StatusCodes"), code)

//        }


//    }


//}
