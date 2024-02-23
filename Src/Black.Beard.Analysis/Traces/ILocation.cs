using System.Text;

namespace Bb.Analysis.Traces
{

    public interface ILocation : ICloneable
    {

        /// <summary>
        /// Writes message to specified <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb"></param>
        void WriteTo(StringBuilder sb);

    }

    public interface ILocationIndex : ILocation
    {

        /// <summary>
        /// index position
        /// </summary>
        int Index { get; }

    }

    public interface ILocationPath : ILocation
    {

        /// <summary>
        /// Path position
        /// </summary>
        string Path { get; }

    }

}
