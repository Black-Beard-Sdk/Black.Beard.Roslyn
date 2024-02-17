

namespace Bb.Process
{

    /// <summary>
    /// class for manage life cycle of the <see cref="ProcessCommand"/>
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
            this._indexPrepare = new Dictionary<Guid, List<TaskEventHandler>>();
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
        /// Create and Runs a command. Method fluent
        /// </summary>
        /// <param name="actionToConfigure">The action to configure.</param>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public ProcessCommandService Run(Guid id, Action<ProcessCommand> actionToConfigure, object tag = null)
        {
            RunAndGet(id, actionToConfigure, tag);
            return this;
        }

        /// <summary>
        /// Create and Runs a command
        /// </summary>
        /// <param name="actionToConfigure">The action to configure.</param>
        /// <returns></returns>
        public ProcessCommand RunAndGet(Action<ProcessCommand> actionToConfigure)
        {
            return Add(new ProcessCommand(), actionToConfigure).Run();
        }

        /// <summary>
        /// Create and Runs a command.
        /// </summary>
        /// <param name="tag">The tag. for identified the process.</param>
        /// <param name="actionToConfigure">The action to configure the command process.</param>
        /// <returns></returns>
        public ProcessCommand RunAndGet(Guid id, Action<ProcessCommand> actionToConfigure, object tag = null)
        {
            return Add(new ProcessCommand(id, tag), actionToConfigure).Run();
        }

        /// <summary>
        /// Create and Runs a command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="tag">The tag. for identified the process.</param>
        /// <param name="actionToConfigure">The action to configure the command process.</param>
        /// <returns></returns>
        public T RunAndGet<T>(T command, Action<T> actionToConfigure)
            where T : ProcessCommand
        {
            Add(command, actionToConfigure);
            command.Run();
            return command;
        }

        /// <summary>
        /// Adds the specified command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns></returns>
        public T Add<T>(T cmd, Action<T> actionToConfigure = null)
            where T : ProcessCommand
        {

            if (actionToConfigure != null)
                cmd.Configure(actionToConfigure);

            AppendIntercept(cmd, Guid.Empty);
            AppendIntercept(cmd, cmd.Id);

            cmd.Intercept((c, d) =>
            {
                if (d.Closed)
                    lock (_lock)
                    {
                        if (this._index.ContainsKey(cmd.Id))
                        {
                            _items.Remove(d.Process);
                            _index.Remove(d.Process.Id);
                            _indexByTag = null;
                        }
                    }
            });

            lock (_lock)
            {
                _items.Add(cmd);
                _index.Add(cmd.Id, cmd);
                _indexByTag = null;
            }

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

        #region Cancels

        /// <summary>
        /// Cancel all commands process.
        /// </summary>
        /// <param name="wait">if set to <c>true</c> [wait].</param>
        public ProcessCommandService Cancel(int wait = 5000)
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

            return this;

        }

        /// <summary>
        /// Cancels the command process specified by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="wait">if set to <c>true</c> [wait].</param>
        public ProcessCommand? Cancel(Guid id, int wait = 5000)
        {
            if (_index.TryGetValue((Guid)id, out var item))
                item.Cancel(wait);

            return item;
        }

        /// <summary>
        /// Cancels the commands process specified by tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="wait">if set to <c>true</c> [wait].</param>
        public IEnumerable<ProcessCommand>? CancelByTag(object tag, int wait = 5000)
        {

            var items = GetTaskByTag(tag).ToList();
            if (items != null)
                for (int i = 0; i < items.Count; i++)
                    items[i].Cancel(wait);

            return items;

        }

        #endregion Cancels

        #region IDisposable

        // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
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

        #endregion IDisposable

        #region Intercept

        /// <summary>
        /// append a new subscription on the output.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public ProcessCommandService Intercept(Guid id, TaskEventHandler action)
        {

            if (!_indexPrepare.TryGetValue(id, out var list))
                _indexPrepare.Add(id, list = new List<TaskEventHandler>());

            if (!list.Contains(action))
                list.Add(action);

            return this;

        }

        /// <summary>
        /// append a new subscription on the output
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public ProcessCommandService Intercept(TaskEventHandler action)
        {
            Intercept(Guid.Empty, action);
            return this;
        }

        private void AppendIntercept(ProcessCommand cmd, Guid id)
        {
            if (_indexPrepare.TryGetValue(id, out var list))
            {

                foreach (var item in list)
                    cmd.Intercept(item);

                if (id != Guid.Empty)
                    _indexPrepare.Remove(id);

            }
        }

        #endregion Intercept

        /// <summary>
        /// Waits the specified test return <see cref="ProcessCommandService"/>
        /// </summary>
        /// <param name="test">The test.</param>
        public ProcessCommandService Wait(Action<ProcessCommandService> test)
        {
            test(this);
            return this;
        }

        /// <summary>
        /// Waits the specified time return <see cref="ProcessCommandService"/>.
        /// </summary>
        /// <param name="test">The test.</param>
        public ProcessCommandService Wait(int wait = 5000)
        {
            Thread.Sleep(wait);
            return this;
        }

        /// <summary>
        /// Waits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the process command.</param>
        /// <param name="wait">The time to wait.</param>
        /// <returns>return the <see cref="ProcessCommand"/> specified by id</returns>
        public ProcessCommand? Wait(Guid id, int wait = 5000)
        {

            if (_index.TryGetValue(id, out var index))
                index.Wait(wait);

            return null;

        }
        
        /// <summary>
        /// Gets the count of command process.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count => _items.Count;

        private bool disposedValue;
        private ILookup<object, ProcessCommand> _indexByTag;
        private volatile object _lock = new object();
        private List<ProcessCommand> _items;
        private Dictionary<Guid, ProcessCommand> _index;
        private Dictionary<Guid, List<TaskEventHandler>> _indexPrepare;

    }



}