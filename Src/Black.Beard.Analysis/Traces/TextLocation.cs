
using System.Runtime.CompilerServices;
using System.Text;

namespace Bb.Analysis.Traces
{


    public class TextLocation : ICloneable
    {

        /// <summary>
        /// The empty value
        /// </summary>
        public static readonly TextLocation Empty = new TextLocation();

        /// <summary>
        /// Initializes a new instance of the <see cref="TextLocation"/> struct.
        /// </summary>
        /// <param name="position">The position.</param>
        public TextLocation()
        {
            Filename = string.Empty;
            Datas = new Dictionary<string, object>();
        }


        public string Filename { get; set; }


        public Dictionary<string, object> Datas { get; }


        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public virtual object Clone()
        {
            throw new NotImplementedException();
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

    }

}
