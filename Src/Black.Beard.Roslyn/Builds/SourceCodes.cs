
namespace Bb.Builds
{


    public class SourceCodes
    {

        public SourceCodes()
        {
            _sources = new Dictionary<string, SourceCode>();
        }


        public SourceCode Add(string filename)
        {

            if (!_sources.TryGetValue(filename, out SourceCode code))
                _sources.Add(filename, SourceCode.GetFromFile(filename));

            return code;

        }

        public IEnumerable<SourceCode> Documents => _sources.Values;

        /// <summary>
        /// Ensure all sources are uptodated
        /// </summary>
        public void EnsureUptodated()
        {

            foreach (var item in _sources)
                if (item.Value.HasUpdated())
                {
                    if (item.Value.IsDeleted)
                        _sources.Remove(item.Key);
                    else
                        item.Value.Reload();
                }
         
        }

        /// <summary>
        /// A hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            uint key = 0;
            this.EnsureUptodated();
            foreach (var item in _sources.OrderBy(c => c.Key))
            {
                key ^= item.Value.Name.CalculateCrc32();
                key ^= item.Value.Source.CalculateCrc32();
            }
            return (int)key;
        }

        public Func<SourceCode, bool> Filter { get; internal set; }


        private readonly Dictionary<string, SourceCode> _sources;

    }



}
