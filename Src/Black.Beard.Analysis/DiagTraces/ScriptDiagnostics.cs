
using System.Collections;
using System.Collections.Specialized;

namespace Bb.Analysis.DiagTraces
{

    public class ScriptDiagnostics : IList<ScriptDiagnostic>, INotifyCollectionChanged
    {

        #region Add

        /// <summary>
        /// Creates & adds a new diagnostic and return the diagnostic
        /// </summary>
        /// <param name="severityEnum">The severity enum.</param>
        /// <param name="location">The location.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public ScriptDiagnostic AddError(TextLocation location, string text, string message)
        {

            var severityEnum = SeverityEnum.Error;

            var d = new ScriptDiagnostic(location)
            {
                Text = text,
                Message = message,
                Severity = severityEnum.ToString(),
                SeverityLevel = (int)severityEnum,
                IsSeverityAsError = true,
            };
            Add(d);
            return d;
        }

        /// <summary>
        /// Creates & adds a new diagnostic and return the diagnostic
        /// </summary>
        /// <param name="severityEnum">The severity enum.</param>
        /// <param name="location">The location.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public ScriptDiagnostic AddWarning(TextLocation location, string text, string message)
        {

            var severityEnum = SeverityEnum.Warning;

            var d = new ScriptDiagnostic(location)
            {
                Text = text,
                Message = message,
                Severity = severityEnum.ToString(),
                SeverityLevel = (int)severityEnum,
                IsSeverityAsError = false,
            };
            Add(d);
            return d;
        }

        /// <summary>
        /// Creates & adds a new diagnostic and return the diagnostic
        /// </summary>
        /// <param name="severityEnum">The severity enum.</param>
        /// <param name="location">The location.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public ScriptDiagnostic AddInformation(TextLocation location, string text, string message)
        {

            var severityEnum = SeverityEnum.Information;

            var d = new ScriptDiagnostic(location)
            {
                Text = text,
                Message = message,
                Severity = severityEnum.ToString(),
                SeverityLevel = (int)severityEnum,
                IsSeverityAsError = severityEnum == SeverityEnum.Information,
            };
            Add(d);
            return d;
        }

        /// <summary>
        /// Creates & adds a new diagnostic and return the diagnostic
        /// </summary>
        /// <param name="severityEnum">The severity enum.</param>
        /// <param name="location">The location.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public ScriptDiagnostic AddOther(TextLocation location, string text, string message)
        {

            var severityEnum = SeverityEnum.Other;

            var d = new ScriptDiagnostic(location)
            {
                Text = text,
                Message = message,
                Severity = severityEnum.ToString(),
                SeverityLevel = (int)severityEnum,
                IsSeverityAsError = severityEnum == SeverityEnum.Information,
            };
            Add(d);
            return d;
        }

        /// <summary>
        /// Creates & adds a new diagnostic and return the diagnostic
        /// </summary>
        /// <param name="severityEnum">The severity enum.</param>
        /// <param name="location">The location.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public ScriptDiagnostic Add(SeverityEnum severityEnum, TextLocation location, string text, string message)
        {
            var d = new ScriptDiagnostic(location)
            {
                Text = text,
                Message = message,
                Severity = severityEnum.ToString(),
                SeverityLevel = (int)severityEnum,
                IsSeverityAsError = severityEnum == SeverityEnum.Error,
            };
            Add(d);
            return d;
        }

        public ScriptDiagnostic Add<T>(SeverityEnum severityEnum, TextLocation<T> location, string text, string message)
            where T : ILocation
        {
            var d = new ScriptDiagnostic(location)
            {
                Text = text,
                Message = message,
                Severity = severityEnum.ToString(),
                SeverityLevel = (int)severityEnum,
                IsSeverityAsError = severityEnum == SeverityEnum.Error,
            };
            Add(d);
            return d;
        }

        public ScriptDiagnostic Add<T, U>(SeverityEnum severityEnum, SpanLocation<T, U> location, string text, string message)
            where T : ILocation
            where U : ILocation
        {
            var d = new ScriptDiagnostic(location)
            {
                Text = text,
                Message = message,
                Severity = severityEnum.ToString(),
                SeverityLevel = (int)severityEnum,
                IsSeverityAsError = severityEnum == SeverityEnum.Error,
            };
            Add(d);
            return d;
        }

        #endregion Add

        #region Implement IList  

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<ScriptDiagnostic> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1" />.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1" />.</param>
        /// <returns>
        /// The index of <paramref name="item" /> if found in the list; otherwise, -1.
        /// </returns>
        public int IndexOf(ScriptDiagnostic item)
        {
            return _list.IndexOf(item);
        }
        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1" /> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
        /// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1" />.</param>
        public void Insert(int index, ScriptDiagnostic item)
        {
            _list.Insert(index, item);
        }
        /// <summary>
        /// Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }
        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        public void Add(ScriptDiagnostic item)
        {
            if (item != null)
            {
                _list.Add(item);
                if (CollectionChanged != null)
                {
                    var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add);
                    args.NewItems.Add(item);
                    CollectionChanged(this, args);
                }
            }
        }
        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }
        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, <see langword="false" />.
        /// </returns>
        public bool Contains(ScriptDiagnostic item)
        {
            return _list.Contains(item);
        }
        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        public void CopyTo(ScriptDiagnostic[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, <see langword="false" />. This method also returns <see langword="false" /> if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public bool Remove(ScriptDiagnostic item)
        {
            return _list.Remove(item);
        }

        #endregion Implement IList        

        /// <summary>
        /// Gets the errors diagnostic items.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IEnumerable<ScriptDiagnostic> Errors { get => _list.Where(c => c.IsSeverityAsError).ToList(); }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ScriptDiagnostics"/> is success. then the list of diagnostic don't contains error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get => !Errors.Any(); }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ScriptDiagnostics"/> is in error. then the list of diagnostic contains error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool InError { get => Errors.Any(); }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets or sets the <see cref="ScriptDiagnostic"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="ScriptDiagnostic"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public ScriptDiagnostic this[int index] { get => _list[index]; set => _list[index] = value; }

        /// <summary>
        /// Occurs when the collection changes.
        /// </summary>
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        private List<ScriptDiagnostic> _list = new List<ScriptDiagnostic>();

    }

}
