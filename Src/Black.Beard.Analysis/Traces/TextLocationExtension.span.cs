using System;
using System.Data.Common;
using Bb.Analysis.Traces;

namespace Bb.Analysis.Traces
{

    public static partial class TextLocationExtension
    {


        /// <summary>
        /// convert location of type <see cref="TextLocation<LocationLineAndIndex>"/> in <see cref="SpanLocation<LocationLineAndIndex, U>"/>"/>
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationLineAndIndex, U>"/></param>
        /// <param name="right">source to convert in <see cref="T:U"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationLineAndIndex, U>"/></param>
        /// <returns></returns>
        public static SpanLocation<LocationLineAndIndex, U> AsSpan<U>(this (int, int, int) location, U right, Action<SpanLocation<LocationLineAndIndex, U>> initializer = null)
            where U : ILocation
        {
            var result = new SpanLocation<LocationLineAndIndex, U>(location, right);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location of type <see cref="TextLocation<LocationLine>"/> in <see cref="SpanLocation<LocationLine, U>"/>"/>
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationLine, U>"/></param>
        /// <param name="right">source to convert in <see cref="T:U"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationLine, U>"/></param>
        /// <returns></returns>
        public static SpanLocation<LocationLine, U> AsSpan<U>(this (int, int) location, U right, Action<SpanLocation<LocationLine, U>> initializer = null)
            where U : ILocation
        {
            var result = new SpanLocation<LocationLine, U>(location, right);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location of type <see cref="TextLocation<LocationIndex>"/> in <see cref="SpanLocation<LocationIndex, U>"/>"/>
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationIndex, U>"/></param>
        /// <param name="right">source to convert in <see cref="T:U"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationIndex, U>"/></param>
        /// <returns></returns>
        public static SpanLocation<LocationIndex, U> AsSpan<U>(this int location, U right, Action<SpanLocation<LocationIndex, U>> initializer = null)
            where U : ILocation
        {
            var result = new SpanLocation<LocationIndex, U>(location, right);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location of type <see cref="TextLocation<LocationPath>"/> in <see cref="SpanLocation<LocationPath, U>"/>"/>
        /// </summary>
        /// <param name="path">source to convert in <see cref="TextLocation<LocationPath, U>"/></param>
        /// <param name="right">source to convert in <see cref="T:U"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationPath, U>"/></param>
        /// <returns></returns>
        public static SpanLocation<LocationPath, U> AsSpan<U>(this string path, U right, Action<SpanLocation<LocationPath, U>> initializer = null)
            where U : ILocation
        {
            var result = new SpanLocation<LocationPath, U>(path, right);
            if (initializer != null)
                initializer(result);
            return result;
        }

    }

}
