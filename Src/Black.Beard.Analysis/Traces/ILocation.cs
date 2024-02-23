using System.Text;

namespace Bb.Analysis.Traces
{

    public interface ILocation : ICloneable
    {

        /// <summary>
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        bool IsEmpty { get; }

        bool CanBeCompare(ILocation location);

        bool StartAfter(ILocation location);

        bool EndBefore(ILocation location);

        bool EndAfter(ILocation location);

        bool StartBefore(ILocation location);

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
