
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Common;
using System.Linq;


namespace Bb.Analysis
{

    public class Diagnostics : IList<DiagnosticReport>, System.Collections.Specialized.INotifyCollectionChanged
    {

        #region Add

        /// <summary>
        /// Adds the information diagnostic.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="line">The line.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="column">The column.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public DiagnosticReport AddInformation(string filename, int line, int startIndex, int column, string text, string message)
        {
            return this.Add(SeverityEnum.Information, filename, line, startIndex, column, text, message);
        }               

        /// <summary>
        /// Adds the information diagnostic.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="location">The location.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public DiagnosticReport AddInformation(DiagnosticLocation location, string text, string message)
        {
            return this.Add(SeverityEnum.Information, location, text, message);
        }

        /// <summary>
        /// Adds the warning diagnostic.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="line">The line.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="column">The column.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public DiagnosticReport AddWarning(string filename, int line, int startIndex, int column, string text, string message)
        {
            return this.Add(SeverityEnum.Warning, filename, line, startIndex, column, text, message);
        }
                
        /// <summary>
        /// Adds the warning diagnostic.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="location">The location.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public DiagnosticReport AddWarning(DiagnosticLocation location, string text, string message)
        {
            return this.Add(SeverityEnum.Warning, location, text, message);
        }

        /// <summary>
        /// Adds the error diagnostic.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="line">The line.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="column">The column.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public DiagnosticReport AddError(string filename, int line, int startIndex, int column, string text, string message)
        {
            return this.Add(SeverityEnum.Error, filename, line, startIndex, column, text, message);
        }
                
        /// <summary>
        /// Adds the error diagnostic.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="location">The location.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public DiagnosticReport AddError(DiagnosticLocation location, string text, string message)
        {

            return this.Add(SeverityEnum.Error, location, text, message);

        }

        /// <summary>
        /// Creates & adds a new diagnostic and return the diagnostic
        /// </summary>
        /// <param name="severityEnum">The severity enum.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="line">The line.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="column">The column.</param>
        /// <param name="text">The text.</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="T:DiagnosticReport"></returns>
        public DiagnosticReport Add(SeverityEnum severityEnum, string filename, int line, int startIndex, int column, string text, string message)
        {
            var d = new DiagnosticReport(new DiagnosticLocation(filename, startIndex, line, column))
            {
                Text = text,
                Message = message,
                Severity = severityEnum.ToString(),
                SeverityLevel = (int)severityEnum,
                IsSeverityAsError = severityEnum == SeverityEnum.Error,
            };
            this.Add(d);
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
        public DiagnosticReport Add(SeverityEnum severityEnum, DiagnosticLocation location, string text, string message)
        {

            var d = new DiagnosticReport((DiagnosticLocation)location.Clone())
            {
                Text = text,
                Message = message,
                Severity = severityEnum.ToString(),
                SeverityLevel = (int)severityEnum,
                IsSeverityAsError = severityEnum == SeverityEnum.Error,
            };
            this.Add(d);
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
        public IEnumerator<DiagnosticReport> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }
        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1" />.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1" />.</param>
        /// <returns>
        /// The index of <paramref name="item" /> if found in the list; otherwise, -1.
        /// </returns>
        public int IndexOf(DiagnosticReport item)
        {
            return this._list.IndexOf(item);
        }
        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1" /> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
        /// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1" />.</param>
        public void Insert(int index, DiagnosticReport item)
        {
            this._list.Insert(index, item);
        }
        /// <summary>
        /// Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            this._list.RemoveAt(index);
        }
        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        public void Add(DiagnosticReport item)
        {
            if (item != null)
            {
                this._list.Add(item);
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
            this._list.Clear();
        }
        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, <see langword="false" />.
        /// </returns>
        public bool Contains(DiagnosticReport item)
        {
            return this._list.Contains(item);
        }
        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        public void CopyTo(DiagnosticReport[] array, int arrayIndex)
        {
            this._list.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, <see langword="false" />. This method also returns <see langword="false" /> if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public bool Remove(DiagnosticReport item)
        {
            return this._list.Remove(item);
        }

        #endregion Implement IList        

        /// <summary>
        /// Gets the errors diagnostic items.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IEnumerable<DiagnosticReport> Errors { get => this._list.Where(c => c.SeverityLevel == (int)SeverityEnum.Error); }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Diagnostics"/> is success. then the list of diagnostic don't contains error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get => !this.Errors.Any(); }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets or sets the <see cref="DiagnosticReport"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="DiagnosticReport"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public DiagnosticReport this[int index] { get => _list[index]; set => _list[index] = value; }

        /// <summary>
        /// Occurs when the collection changes.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private List<DiagnosticReport> _list = new List<DiagnosticReport>();

    }

}
