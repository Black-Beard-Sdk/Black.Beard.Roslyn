
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

            if (_sources.ContainsKey(filename))
                _sources.Remove(filename);

            var code = SourceCode.GetFromFile(filename);

            _sources.Add(filename, code);

            return code;

        }

        public SourceCode Add(string documentName, string payload)
        {

            if (!_sources.TryGetValue(documentName, out SourceCode code))
                _sources.Add(documentName, SourceCode.GetFromText(payload, documentName));
            else
                code.Source = payload;

            return code;

        }

        public IEnumerable<SourceCode> Documents => _sources.Values;

        /// <summary>
        /// Ensure all sources are uptodated
        /// </summary>
        public bool EnsureUptodated()
        {
            bool changed = false;
            foreach (var item in _sources)
                if (item.Value.HasUpdated())
                {
                    if (item.Value.IsDeleted)
                    {
                        changed = true;
                        _sources.Remove(item.Key);
                    }
                    else
                        item.Value.Reload();
                }

            return changed;

        }

        /// <summary>
        /// A hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            uint key = 0;
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
