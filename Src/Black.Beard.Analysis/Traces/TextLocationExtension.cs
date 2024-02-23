using System;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace Bb.Analysis.Traces
{

    public static partial class TextLocationExtension
    {


        /// <summary>
        /// Copy the location and set the document name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public static T InDocument<T>(T self, string documentName)
            where T : TextLocation
        {
            var location = (T)self.Clone();
            location.Filename = documentName;
            return location;
        }


        /// <summary>
        /// Copy the location. helper for the clone method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static T Copy<T>(T self)
            where T : TextLocation
        {
            var location = (T)self.Clone();
            return location;
        }


        /// <summary>
        /// Add a value to the dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Add<T>(this T self, string key, object value) => self.Add(key, value);


        /// <summary>
        /// get a value to the dictionary
        /// </summary>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(this TextLocation self, string key)
        {
            self.Datas.TryGetValue(key, out object value);
            return value;
        }


    }

}
