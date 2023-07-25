﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;

namespace Bb.Codings
{


    public class CsClassDeclaration : CsTypeDeclaration
    {

        public CsClassDeclaration(string name)
           : base(name)
        {
            _baseNames = new HashSet<string>();
        }

        /// <summary>
        /// add Bases types
        /// </summary>
        /// <param name="baseNames">The base type names.</param>
        /// <returns></returns>
        public CsClassDeclaration Base(params string[] baseNames)
        {
            foreach (var baseName in baseNames)
                _baseNames.Add(baseName);
            return this;
        }


        #region Members

        public CsCtorDeclaration Ctor()
        {
            return Add(new CsCtorDeclaration(Name));
        }

        public CsClassDeclaration Ctor(Action<CsCtorDeclaration> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            action(Ctor());

            return this;
        }



        public new CsClassDeclaration Field(string fieldName, string type, Action<CsFieldDeclaration> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            action(Field(fieldName, type));
            return this;
        }



        public CsClassDeclaration Property(string methodName, string type, Action<CsPropertyDeclaration> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            action(Property(methodName, type));
            return this;
        }

        public CsPropertyDeclaration Property(string methodName, string type)
        {
            return Add(new CsPropertyDeclaration(methodName, type));
        }

        #endregion Members

        internal override SyntaxNode Build()
        {

            ClassDeclarationSyntax classDeclaration = SyntaxFactory.ClassDeclaration(Name);


            #region attributes

            var attr = GetAttributes();
            foreach (var attribute in attr)
                classDeclaration = classDeclaration.AddAttributeLists(attribute);

            #endregion attributes


            #region Modifiers

            if (_isPublic)
                classDeclaration = classDeclaration.AddModifiers(SyntaxKind.PublicKeyword.ToToken());

            else if (_isPrivate)
                classDeclaration = classDeclaration.AddModifiers(SyntaxKind.PrivateKeyword.ToToken());

            if (_isInternal)
                classDeclaration = classDeclaration.AddModifiers(SyntaxKind.InternalKeyword.ToToken());

            if (_isProtected)
                classDeclaration = classDeclaration.AddModifiers(SyntaxKind.ProtectedKeyword.ToToken());

            if (_isStatic)
                classDeclaration = classDeclaration.AddModifiers(SyntaxKind.StaticKeyword.ToToken());

            if (_isPartial)
                classDeclaration = classDeclaration.AddModifiers(SyntaxKind.PartialKeyword.ToToken());

            if (_isSealed)
                classDeclaration = classDeclaration.AddModifiers(SyntaxKind.SealedKeyword.ToToken());

            #endregion Modifiers


            #region base

            foreach (var item in _baseNames)
                classDeclaration = classDeclaration.AddBaseListTypes(SyntaxFactory.SimpleBaseType(item.AsType()));

            #endregion base


            #region members

            foreach (var item in Members)
            {
                var member = item.Build();
                if (member != null)
                {
                    if (member is MemberDeclarationSyntax b)
                        classDeclaration = classDeclaration.AddMembers(b);

                    else
                        Stop();

                    classDeclaration = classDeclaration.WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed);

                }
            }

            #endregion members

            classDeclaration = ApplyXmlDocumentation(classDeclaration);

            return classDeclaration;

        }

        private readonly HashSet<string> _baseNames;

    }

}