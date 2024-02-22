using System;
using System.Data.Common;

namespace Bb.Analysis.Traces
{

    public static partial class TextLocationExtension
    {


        /// <summary>
        /// Add a value to the dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Add<T>(this T self, string key, object value)
        {
            self.Add(key, value);
            return self;
        }

    }

}
