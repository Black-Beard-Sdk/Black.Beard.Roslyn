namespace Bb.Process
{
    public static class ArgumentHelper
    {

        /// <summary>
        /// adds quotes on beginning and ending to the string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="quote"></param>
        /// <returns></returns>
        public static string Quoted(this string value , string quote = "\"")
        {
            return quote + value + quote;
        }

        /// <summary>
        /// adds quotes on beginning and ending to the file path
        /// </summary>
        /// <param name="file"></param>
        /// <param name="quote"></param>
        /// <returns></returns>
        public static string Quoted(this FileInfo file, string quote = "\"")
        {
            return quote + file.FullName + quote;
        }

    }

}