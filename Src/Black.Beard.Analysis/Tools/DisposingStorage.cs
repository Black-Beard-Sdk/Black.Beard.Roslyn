using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Refs.Microsoft.Extensions.Identity;

namespace Bb.Analysis.Tools
{


    /// <summary>
    /// Object for storing data in processing visitor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DisposingStorage : IStore
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposingStorage{T}"/> class.
        /// </summary>
        /// <param name="document"></param>
        public DisposingStorage(IStoreSource document)
        {
            this._dic = new Dictionary<string, object>();
            _documentRoot = document;
            _documentRoot.StorePush(this);
        }

        #region Storing

        public void AddInStorage(string key, object value)
        {
            if (_dic.ContainsKey(key))
                _dic[key] = value;
            else
                _dic.Add(key, value);
        }

        public bool TryGetInStorage(string key, out object? value)
        {
            return _dic.TryGetValue(key, out value);
        }

        public bool ContainsInStorage(string key)
        {
            return _dic.ContainsKey(key);
        }

        public void Dispose()
        {
            _documentRoot.StorePop();
        }

        #endregion Storing

        private readonly IStoreSource _documentRoot;
        private readonly Dictionary<string, object> _dic;
    }

}
