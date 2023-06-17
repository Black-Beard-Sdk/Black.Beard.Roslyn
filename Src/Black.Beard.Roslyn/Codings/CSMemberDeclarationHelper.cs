using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;

namespace Bb.Codings
{


    public static class CSMemberDeclarationHelper
    {

        /// <summary>
        /// append pragma code for disable the warning.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <param name="codes">The codes.</param>
        /// <returns></returns>
        public static T DisableWarning<T>(this T self, params string[] codes) where T : CSMemberDeclaration
        {
            
            foreach (var code in codes)
                self._warnings.Add(code);

            return self;

        }

        #region attributes

        /// <summary>
        /// Add custom Attribute with the specified attribute type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <param name="attribute">The attribute.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">action</exception>
        public static T Attribute<T>(this T self, Type attribute, Action<CsAttributeDeclaration> action) where T : CSMemberDeclaration
        {

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            action(self.Attribute(attribute));
            
            return self;

        }

        /// <summary>
        /// Add custom Attribute with the specified attribute name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">action</exception>
        public static T Attribute<T>(this T self, string attributeName, Action<CsAttributeDeclaration> action) where T : CSMemberDeclaration
        {

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            action(self.Attribute(attributeName));

            return self;

        }

        #endregion attributes

        #region methods 

        /// <summary>
        /// Declare a new methods the specified method name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">action</exception>
        public static T Method<T>(this T self, string methodName, Action<CsMethodDeclaration> action) where T : CsTypeDeclaration
        {

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var method = self.Method(methodName);

            action(method);

            return self;

        }

        /// <summary>
        /// Declare a new methods the specified method name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="type">The type.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">action</exception>
        public static T Method<T>(this T self, string methodName, string type, Action<CsMethodDeclaration> action) where T : CsTypeDeclaration
        {

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var method = self.Method(methodName, type);

            action(method);

            return self;

        }

        /// <summary>
        /// Declare a new methods the specified method name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="type">The type.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">action</exception>
        public static T Method<T>(this T self, string methodName, Type type, Action<CsMethodDeclaration> action) where T : CsTypeDeclaration
        {

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var method = self.Method(methodName, type);

            action(method);

            return self;

        }

        /// <summary>
        /// Declare a new methods the specified method name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="type">The type.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">action</exception>
        public static T Method<T>(this T self, string methodName, TypeSyntax type, Action<CsMethodDeclaration> action) where T : CsTypeDeclaration
        {

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var method = self.Method(methodName, type);

            action(method);

            return self;

        }

        #endregion methods 

        #region modifiers

        public static T IsStatic<T>(this T self) where T : CSMemberDeclaration
        {
            self._isStatic = true;;
            return self;
        }

        public static T IsSealed<T>(this T self) where T : CsTypeDeclaration
        {
            self._isSealed = true;
            return self;
        }

        public static T IsPartial<T>(this T self) where T : CsTypeDeclaration
        {
            self._isPartial = true;
            return self;
        }

        public static T IsPublic<T>(this T self) where T : CSMemberDeclaration
        {
            self._isPublic = true;
            self._isPrivate = false;
            self._isInternal = false;
            self._isProtected = false;
            return self;
        }

        public static T IsPrivate<T>(this T self) where T : CSMemberDeclaration
        {
            self._isPrivate = true;
            self._isPublic = false;
            self._isInternal = false;
            self._isProtected = false;
            return self;
        }

        public static T IsInternal<T>(this T self) where T : CSMemberDeclaration
        {
            self._isInternal = true;
            self._isPublic = false;
            self._isPrivate = false;
            return self;
        }

        public static T IsProtected<T>(this T self) where T : CSMemberDeclaration
        {
            self._isProtected = true;
            self._isPublic = false;
            self._isPrivate = false;
            return self;
        }

        #endregion modifiers


    }


}
