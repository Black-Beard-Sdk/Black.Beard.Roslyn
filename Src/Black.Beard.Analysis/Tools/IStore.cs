namespace Bb.Analysis.Tools
{
    public interface IStore : IDisposable
    {

        void AddInStorage(string key, object value);


        bool TryGetInStorage(string key, out object value);


        bool ContainsInStorage(string key);

    }

}
