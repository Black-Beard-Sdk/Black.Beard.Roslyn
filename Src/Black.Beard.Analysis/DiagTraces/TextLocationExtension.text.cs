using System;
using System.Data.Common;
using Bb.Analysis.DiagTraces;

namespace Bb.Analysis.DiagTraces
{

    public static partial class TextLocationExtension
    {


        /// <summary>
        /// convert location of type <see cref="TextLocation<LocationLineAndIndex>"/> in <see cref="SpanLocation<LocationLineAndIndex, U>"/>"/>
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationLineAndIndex>"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationLineAndIndex>"/></param>
        /// <returns></returns>
        public static TextLocation<LocationLineAndIndex> AsLocation(this (int, int, int) location, Action<TextLocation<LocationLineAndIndex>> initializer = null)
        {
            var result = new TextLocation<LocationLineAndIndex>(location);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location of type <see cref="TextLocation<LocationLine>"/> in <see cref="TextLocation<LocationLine>"/>"/>
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationLine>"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationLine>"/></param>
        /// <returns></returns>
        public static TextLocation<LocationLine> AsLocation(this (int, int) location, Action<TextLocation<LocationLine>> initializer = null)
        {
            var result = new TextLocation<LocationLine>(location);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location of type <see cref="TextLocation<LocationIndex>"/> in <see cref="TextLocation<LocationIndex>"/></param>
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationIndex>"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationIndex>"/></param>
        /// <returns></returns>
        public static TextLocation<LocationIndex> AsLocation(this int location, Action<TextLocation<LocationIndex>> initializer = null)
        {
            var result = new TextLocation<LocationIndex>(location);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location of type <see cref="TextLocation<LocationPath>"/> in <see cref="TextLocation<LocationPath>"/></param>
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationPath>"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationPath>"/></param>
        /// <returns></returns>
        public static TextLocation<LocationPath> AsLocation(this string location, Action<TextLocation<LocationPath>> initializer = null)
        {
            var result = new TextLocation<LocationPath>(location);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location of type <see cref="TextLocation<T>"/> in <see cref="TextLocation<T>"/></param>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="location"></param>
        /// <param name="initializer"></param>
        /// <returns></returns>
        public static TextLocation<T> AsLocation<T>(this T location, Action<TextLocation<T>> initializer = null)
            where T : ILocation
        {
            var result = location;
            if (initializer != null)
                initializer(result);
            return result;
        }


    }

}
