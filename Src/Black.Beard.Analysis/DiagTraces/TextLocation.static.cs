using System.Text;

namespace Bb.Analysis.DiagTraces
{

    public partial class TextLocation
    {



        /// <summary>
        /// convert location 
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="location"></param>
        /// <param name="right"></param>
        /// <param name="initializer"></param>
        /// <returns></returns>
        public static SpanLocation<LocationLineAndIndex, U> Create<U>((int, int, int) location, U right, Action<SpanLocation<LocationLineAndIndex, U>> initializer = null)
            where U : ILocation
        {
            var result = new SpanLocation<LocationLineAndIndex, U>(location, right);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="initializer"></param>
        /// <returns></returns>
        public static TextLocation<LocationLineAndIndex> Create((int, int, int) location, Action<TextLocation<LocationLineAndIndex>> initializer = null)
        {
            var result = new TextLocation<LocationLineAndIndex>(location);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location 
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationLine, U>"/></param>
        /// <param name="right">source to convert in <see cref="T:U"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationLine, U>"/></param>
        /// <returns></returns>
        public static SpanLocation<LocationLine, U> Create<U>((int, int) location, U right, Action<SpanLocation<LocationLine, U>> initializer = null)
            where U : ILocation
        {
            var result = new SpanLocation<LocationLine, U>(location, right);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location 
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationLine, U>"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationLine, U>"/></param>
        /// <returns></returns>
        public static TextLocation<LocationLine> Create((int, int) location, Action<TextLocation<LocationLine>> initializer = null)
        {
            var result = new TextLocation<LocationLine>(location);
            if (initializer != null)
                initializer(result);
            return result;
        }


        /// <summary>
        /// convert location 
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationLine, U>"/></param>
        /// <param name="right">source to convert in <see cref="T:U"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationLine, U>"/></param>
        /// <returns></returns>
        public static SpanLocation<LocationLine, U> Create<U>(int line, int col, U right, Action<SpanLocation<LocationLine, U>> initializer = null)
            where U : ILocation
        {
            var result = new SpanLocation<LocationLine, U>((line, col), right);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location 
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationLine, U>"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationLine, U>"/></param>
        /// <returns></returns>
        public static TextLocation<LocationLine> Create(int line, int col, Action<TextLocation<LocationLine>> initializer = null)
        {
            var result = new TextLocation<LocationLine>((line, col));
            if (initializer != null)
                initializer(result);
            return result;
        }


        /// <summary>
        /// convert location 
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationLine, U>"/></param>
        /// <param name="right">source to convert in <see cref="T:U"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationLine, U>"/></param>
        /// <returns></returns>
        public static SpanLocation<LocationIndex, U> Create<U>(int index, U right, Action<SpanLocation<LocationIndex, U>> initializer = null)
            where U : ILocation
        {
            var result = new SpanLocation<LocationIndex, U>(index, right);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location 
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationLine, U>"/></param>
        /// <param name="right">source to convert in <see cref="T:U"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationLine, U>"/></param>
        /// <returns></returns>
        public static TextLocation<LocationIndex> Create(int index, Action<TextLocation<LocationIndex>> initializer = null)
        {
            var result = new TextLocation<LocationIndex>(index);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location 
        /// </summary>
        /// <param name="location">source to convert in <see cref="TextLocation<LocationLine, U>"/></param>
        /// <param name="right">source to convert in <see cref="T:U"/></param>
        /// <param name="initializer">initialize <see cref="TextLocation<LocationLine, U>"/></param>
        /// <returns></returns>
        public static SpanLocation<LocationPath, U> Create<U>(string path, U right, Action<SpanLocation<LocationPath, U>> initializer = null)
            where U : ILocation
        {
            var result = new SpanLocation<LocationPath, U>(path, right);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="right"></param>
        /// <param name="initializer"></param>
        /// <returns></returns>
        public static SpanLocation<LocationLineAndIndex, LocationIndex> Create((int, int, int) location, int right, Action<SpanLocation<LocationLineAndIndex, LocationIndex>> initializer = null)
        {
            var result = new SpanLocation<LocationLineAndIndex, LocationIndex>(location, right);
            if (initializer != null)
                initializer(result);
            return result;
        }

        /// <summary>
        /// convert location 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="right"></param>
        /// <param name="initializer"></param>
        /// <returns></returns>
        public static SpanLocation<LocationLineAndIndex, LocationLineAndIndex> Create((int, int, int) location, (int, int, int) right, Action<SpanLocation<LocationLineAndIndex, LocationLineAndIndex>> initializer = null)
        {
            var result = new SpanLocation<LocationLineAndIndex, LocationLineAndIndex>(location, right);
            if (initializer != null)
                initializer(result);
            return result;
        }

    }

}
