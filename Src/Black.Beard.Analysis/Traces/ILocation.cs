using System.Text;

namespace Bb.Analysis.Traces
{

    public interface ILocation : ICloneable
    {

        /// <summary>
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// return true if the current location can be compared with another location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        bool CanBeCompare(ILocation location);

        /// <summary>
        /// return true if the current position start before the specified location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        bool StartAfter(ILocation location);

        /// <summary>
        /// return true if the current location end before the compared with another location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        bool EndBefore(ILocation location);

        /// <summary>
        /// return true if the current location end after the compared with another location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        bool EndAfter(ILocation location);

        /// <summary>
        /// return true if the current location start before the compared with another location
        /// </summary>
        /// <param name="location">the location to compare</param>
        /// <returns></returns>
        bool StartBefore(ILocation location);

        /// <summary>
        /// Writes message to specified <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb"></param>
        void WriteTo(StringBuilder sb);

    }

}
