
namespace Bb.Analysis.DiagTraces
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
        public static T InDocument<T>(this T self, string documentName)
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
        public static T Copy<T>(this T self)
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
        public static T Add<T>(this T self, string key, object value)
        where T : TextLocation
        {
            if (self.Datas.ContainsKey(key))
                self.Datas[key] = value;
            else
                self.Datas.Add(key, value);
            return self;
        }

    }

}
