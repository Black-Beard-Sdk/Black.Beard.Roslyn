
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;


namespace Bb.Analysis
{
    public class Diagnostics : IList<DiagnosticReport>, System.Collections.Specialized.INotifyCollectionChanged
    {


        #region Add

        public void AddInformation(string filename, int line, int startIndex, int column, string text, string message)
        {
            this.Add(new DiagnosticReport(new DiagnosticLocation(filename, startIndex, line, column))
            {
                Text = text,
                Message = message,
                Severity = SeverityEnum.Information.ToString(),
                SeverityLevel = (int)SeverityEnum.Information,
            });

        }

        public void AddInformation(string filename, TokenLocation location, string text, string message)
        {
            this.Add(new DiagnosticReport(new DiagnosticLocation(filename, location))
            {
                Text = text,
                Message = message,
                Severity = SeverityEnum.Information.ToString(),
                SeverityLevel = (int)SeverityEnum.Information,
            });

        }

        public void AddWarning(string filename, int line, int startIndex, int column, string text, string message)
        {
            this.Add(new DiagnosticReport(new DiagnosticLocation(filename, startIndex, line, column))
            {
                Text = text,
                Message = message,
                Severity = SeverityEnum.Warning.ToString(),
                SeverityLevel = (int)SeverityEnum.Warning,
            });

        }

        public void AddWarning(string filename, TokenLocation location, string text, string message)
        {

            if (location == null)
                location = new TokenLocation();

            this.Add(new DiagnosticReport(new DiagnosticLocation(filename, location))
            {
                Text = text,
                Message = message,
                Severity = SeverityEnum.Warning.ToString(),
                SeverityLevel = (int)SeverityEnum.Warning,
            });

        }

        public void AddError(string filename, int line, int startIndex, int column, string text, string message)
        {
            this.Add(new DiagnosticReport(new DiagnosticLocation(filename, startIndex, line, column))
            {
                Text = text,
                Message = message,
                Severity = SeverityEnum.Error.ToString(),
                SeverityLevel = (int)SeverityEnum.Error,
                IsSeverityAsError = true
            });

        }

        public void AddError(string filename, TokenLocation location, string text, string message)
        {

            if (location == null)
                location = new TokenLocation();

            this.Add(new DiagnosticReport(new DiagnosticLocation(filename, location))
            {
                Text = text,
                Message = message,
                Severity = SeverityEnum.Error.ToString(),
                SeverityLevel = (int)SeverityEnum.Error,
                IsSeverityAsError = true
            });
        }

        public void AddDiagnostic(SeverityEnum severityEnum, string filename, int line, int startIndex, int column, string text, string message)
        {
            this.Add(new DiagnosticReport(new DiagnosticLocation(filename, startIndex, line, column))
            {
                Text = text,
                Message = message,
                Severity = severityEnum.ToString(),
                SeverityLevel = (int)severityEnum,
                IsSeverityAsError = severityEnum == SeverityEnum.Error,
            });
        }

        public void AddDiagnostic(SeverityEnum severityEnum, string filename, TokenLocation location, string text, string message)
        {

            if (location == null)
                location = new TokenLocation();

            this.Add(new DiagnosticReport(new DiagnosticLocation(filename, location))
            {
                Text = text,
                Message = message,
                Severity = severityEnum.ToString(),
                SeverityLevel = (int)severityEnum,
                IsSeverityAsError = severityEnum == SeverityEnum.Error,
            });
        }

        #endregion Add

        #region Implement IList

        public IEnumerator<DiagnosticReport> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        public int IndexOf(DiagnosticReport item)
        {
            return this._list.IndexOf(item);
        }

        public void Insert(int index, DiagnosticReport item)
        {
            this._list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this._list.RemoveAt(index);
        }

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

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(DiagnosticReport item)
        {
            return this._list.Contains(item);
        }

        public void CopyTo(DiagnosticReport[] array, int arrayIndex)
        {
            this._list.CopyTo(array, arrayIndex);
        }

        public bool Remove(DiagnosticReport item)
        {
            return this._list.Remove(item);
        }

        #endregion Implement IList

        public IEnumerable<DiagnosticReport> Errors { get => this._list.Where(c => c.SeverityLevel == (int)SeverityEnum.Error); }

        public bool Success { get => !this.Errors.Any(); }

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public DiagnosticReport this[int index] { get => _list[index]; set => _list[index] = value; }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private List<DiagnosticReport> _list = new List<DiagnosticReport>();

    }


}
