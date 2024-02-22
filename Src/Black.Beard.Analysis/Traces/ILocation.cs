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

}
