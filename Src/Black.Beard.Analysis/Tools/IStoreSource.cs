namespace Bb.Analysis.Tools
{

    public interface IStoreSource

    {
        void StorePop();

        void StorePush(object toDispose);

    }

}
