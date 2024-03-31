namespace Bb.Analysis.Tools
{
    public interface IStoreSource : IDisposable
    {
        void StorePop();

        void StorePush<T>(DisposingStorage<T> disposeStoringClass) where T : IStoreSource;

    }

}
