﻿using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Bb.Process
{

    /// <summary>
    /// class for manage lifecycle of the <see cref="ProcessCommand"/>
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ProcessCommandService : IDisposable
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessCommandService"/> class.
        /// </summary>
        public ProcessCommandService()
        {
            this._index = new Dictionary<Guid, ProcessCommand>();
            this._items = new List<ProcessCommand>();
        }

        /// <summary>
        /// add a new action to execute when an output is detected.
        /// </summary>
        /// <param name="configureOutput">The configure output.</param>
        /// <returns></returns>
        public ProcessCommandService Output(Action<DataReceiverEventArgs> configureOutput)
        {

            if (this._actionScreen == null)
                this._actionScreen = new TraceContainer(configureOutput);

            else
                this._actionScreen.Append(configureOutput);

            return this;
        }

        /// <summary>
        /// Create and Runs a command. Method fluent
        /// </summary>
        /// <param name="actionToConfigure">The action to configure.</param>
        /// <returns></returns>
        public ProcessCommandService Run(Action<ProcessCommand> actionToConfigure)
        {
            RunAndGet(actionToConfigure);
            return this;
        }

        /// <summary>
        /// Create and Runs a command
        /// </summary>
        /// <param name="actionToConfigure">The action to configure.</param>
        /// <returns></returns>
        public ProcessCommand RunAndGet(Action<ProcessCommand> actionToConfigure)
        {

            var cmd = new ProcessCommand()
                    .Configure(actionToConfigure)
                    ;

            Add(cmd)
                .Run();

            return cmd;

        }

        /// <summary>
        /// Create and Runs a command. Method fluent
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="actionToConfigure">The action to configure.</param>
        /// <returns></returns>
        public ProcessCommandService Run(object tag, Action<ProcessCommand> actionToConfigure)
        {
            RunAndGet(tag, actionToConfigure);
            return this;
        }

        /// <summary>
        /// Create and Runs a command.
        /// </summary>
        /// <param name="tag">The tag. for identified the process.</param>
        /// <param name="actionToConfigure">The action to configure the command process.</param>
        /// <returns></returns>
        public ProcessCommand RunAndGet(object tag, Action<ProcessCommand> actionToConfigure)
        {

            var cmd = new ProcessCommand(tag)
                    .Configure(actionToConfigure)
                    ;

            Add(cmd)
                .Run();

            return cmd;

        }

        /// <summary>
        /// Adds the specified command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns></returns>
        public ProcessCommand Add(ProcessCommand cmd)
        {

            TraceContainer output = this._actionScreen ?? new TraceContainer(c => Trace.WriteLine(c.Datas));

            cmd.Output(output);

            lock (_lock)
            {
                this._items.Add(cmd);
                this._index.Add(cmd.Id, cmd);
                this._indexByTag = null;
            }

            cmd.TaskEvent(c =>
            {
                if (c.Closing)
                    lock (_lock)
                    {
                        this._items.Remove(c.Process);
                        this._index.Remove(c.Process.Id);
                        this._indexByTag = null;
                    }
            });

            return cmd;

        }

        /// <summary>
        /// Gets the task identified by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ProcessCommand? GetTask(Guid id)
        {

            if (_index.TryGetValue(id, out var index))
                return index;

            return null;

        }

        /// <summary>
        /// Gets the task identified by tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public IEnumerable<ProcessCommand> GetTaskByTag(object tag)
        {

            lock (_lock)
            {
                if (this._indexByTag == null)
                    this._indexByTag = this._items.ToLookup(c => c.Tag);

                var items = this._indexByTag[tag];

                return items;
            }

        }

        /// <summary>
        /// Gets the count of command process.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count => _items.Count;

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés)
                    Cancel();
                }

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null
                disposedValue = true;
            }
        }

        /// <summary>
        /// Cancel all command process.
        /// </summary>
        /// <param name="wait">if set to <c>true</c> [wait].</param>
        public void Cancel(bool wait = true)
        {

            int count = _items.Count;

            while (count > 0)
            {
                var p = _items[0];
                if (!p.Cancelling)
                    p.Cancel(wait);

                lock (_lock)
                    count = _items.Count;

            }

        }

        /// <summary>
        /// Cancels the command process specified by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="wait">if set to <c>true</c> [wait].</param>
        public void Cancel(Guid id, bool wait = true)
        {
            if (_index.TryGetValue((Guid)id, out var item))
                item.Cancel(wait);
        }

        /// <summary>
        /// Cancels the command process specified by tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="wait">if set to <c>true</c> [wait].</param>
        public void CancelByTag(object tag, bool wait = true)
        {

            var items = GetTaskByTag(tag).ToList();
            if (items != null)
                for (int i = 0; i < items.Count; i++)
                    items[i].Cancel(wait);

        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        // ~ProcessCommandService()
        // {
        //     // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable

        private bool disposedValue;
        private ILookup<object, ProcessCommand> _indexByTag;
        private volatile object _lock = new object();
        private List<ProcessCommand> _items;
        private Dictionary<Guid, ProcessCommand> _index;
        private TraceContainer _actionScreen;


    }



}