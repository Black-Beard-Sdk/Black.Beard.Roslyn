namespace Bb.Process
{

    /// <summary>
    /// ProcessCommand extension
    /// </summary>
    public static class ProcessCommandExtension
    {

        /// <summary>
        /// Configures self with specified action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <param name="actionToConfigure">The action to configure.</param>
        /// <returns></returns>
        public static T Configure<T>(this T self, Action<T> actionToConfigure)
        {
            actionToConfigure(self);
            return self;
        }


    }



}