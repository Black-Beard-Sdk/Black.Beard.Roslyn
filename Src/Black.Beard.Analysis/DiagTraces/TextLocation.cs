using System.Text;

namespace Bb.Analysis.DiagTraces
{


    public partial class TextLocation : ICloneable
    {

        /// <summary>
        /// The empty value
        /// </summary>
        public static readonly TextLocation Empty = new TextLocation(LocationDefault.Empty, LocationDefault.Empty);

        /// <summary>
        /// Initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        /// <param name="position">The position.</param>
        public TextLocation(ILocation start, ILocation stop)
        {
            Filename = string.Empty;
            Datas = new Dictionary<string, object>();
            this._start = start ?? throw new ArgumentNullException(nameof(start));
            this._stop = stop ?? Start;
        }

        /// <summary>
        /// get the left location
        /// </summary>
        public ILocation Start
        {
            get => _start; 
            
        }

        /// <summary>
        /// Gets the right location
        /// </summary>
        public ILocation Stop { get => _stop; }


        public virtual bool StartBefore(TextLocation location)
        {
            return Start.StartBefore(location.Start);
        }

        public virtual bool StartAfter(TextLocation location)
        {
            return Start.StartAfter(location.Start);
        }
             
        public virtual bool StartEndBefore(TextLocation location)
        {
            return Start.EndBefore(location.Start);
        }

        public virtual bool StartEndAfter(TextLocation location)
        {
            return Start.EndAfter(location.Start);
        }

        public virtual bool StopEndBefore(TextLocation location)
        {
            return Stop.EndBefore(location.Start);
        }

        public virtual bool StopEndAfter(TextLocation location)
        {
            return Stop.EndAfter(location.Start);
        }

        //public virtual bool Intersect(TextLocation location)
        //{
        //    if (Start.StartBefore(location.Start))
        //    {
        //        return Stop.EndBefore(location.Stop);
        //    }
        //    else if (Start.StartBefore(location.Stop))
        //    {
        //        return Stop.StartBefore(location.Stop);
        //    }
        //    else if (Stop.StartBefore(location.Start))
        //    {
        //    }
        //    else if (Stop.StartBefore(location.Stop))
        //    {
        //    }
        //    return false;
        //}

        /// <summary>
        /// Filename document
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Datas dictionary
        /// </summary>
        public Dictionary<string, object> Datas { get; }


        /// <summary>
        /// get a value from the dictionary
        /// </summary>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            _ = Datas.TryGetValue(key, out var value);
            return value;
        }


        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public virtual object Clone()
        {
            return new TextLocation((ILocation)Start.Clone(), (ILocation)Stop.Clone())
            {
                Filename = Filename
            }.Add(this.Datas);
        }

        /// <summary>
        /// Add dictionary items
        /// </summary>
        /// <param name="datas"></param>
        public TextLocation Add(Dictionary<string, object> datas)
        {
            foreach (var item in datas)
                Add(item);

            return this;

        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="item"></param>
        public void Add(KeyValuePair<string, object> item)
        {
            if (Datas.TryGetValue(item.Key, out var value))
                Datas.Add(item.Key, value);
            else
                Datas[item.Key] = item.Value;
        }


        /// <summary>
        /// Gets a value indicating whether this instance is the empty instance.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance match(this.Line == -1 && this.Column == -1 && this.Index == -1); otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsEmpty => Equals(this, Empty);


        ///// <summary>
        ///// Performs an implicit conversion from <see cref="System.ValueTuple{System.Int32, System.Int32}"/> to <see cref="TextLocation"/>.
        ///// </summary>
        ///// <param name="position">The position.</param>
        ///// <returns>
        ///// The result of the conversion.
        ///// </returns>
        //public static implicit operator TextLocation((int, int, int) position)
        //{
        //    return new TextLocation<LocationLineAndIndex>(position);
        //}

        //public static implicit operator TextLocation(LocationLineAndIndex position)
        //{
        //    return new TextLocation<LocationLineAndIndex>(position);
        //}


        internal virtual void WriteTo(StringBuilder sb)
        {

        }

        private ILocation _start = LocationDefault.Empty;

        private ILocation _stop = LocationDefault.Empty;

    }

}
