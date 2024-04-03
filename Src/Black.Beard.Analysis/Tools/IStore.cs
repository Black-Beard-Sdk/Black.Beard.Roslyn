namespace Bb.Analysis.Tools
{

    public interface IStore : IDisposable
    {

        /// <summary>
        /// Add or replace the value in the storage
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddInStorage(string key, object value);


        /// <summary>
        /// Return true if the storage contains the specified key. The value is returned in the out value way
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool TryGetInStorage(string key, out object value);

        /// <summary>
        /// Return true if the storage contains the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool ContainsInStorage(string key);

    }

}
