using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Process
{



    /// <summary>
    /// class for manage lifecycle of the <see cref="Task" /> what wraps external process
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ProcessCommand : IDisposable
    {

        static ProcessCommand()
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessCommand"/> class.
        /// </summary>
        /// <param name="tag">The tag.</param>
        public ProcessCommand(Guid id, object tag) : this()
        {
            this.Id = id;
            this.Tag = tag;
            this._interceptors = new List<TaskEventHandler>();
            CreateProcessInfo();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessCommand"/> class.
        /// </summary>
        public ProcessCommand()
        {
            this.Id = Guid.NewGuid();
            this._interceptors = new List<TaskEventHandler>();
            CreateProcessInfo();
        }

        private void CreateProcessInfo()
        {

            var codePage = CultureInfo.CurrentCulture.TextInfo.OEMCodePage;
            var encoding = Encoding.GetEncoding(codePage);

            this._processStartInfo = new ProcessStartInfo()
            {

                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,


                //ErrorDialog = true,
                //ErrorDialogParentHandle = IntPtr.Zero,
                StandardOutputEncoding = encoding,
                StandardErrorEncoding = encoding,

                //StandardInputEncoding = null,

                //UseShellExecute = true,
                //CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden

                //WindowStyle = ProcessWindowStyle.Normal

            };
        }

        #region parameters

        public ProcessCommand CommandBatch()
        {
            return Command("cmd.exe");
        }

        public ProcessCommand Command(string command, string arguments = null)
        {
            this._processStartInfo.FileName = command;
            if (!string.IsNullOrEmpty(arguments))
                this._processStartInfo.Arguments = arguments;
            return this;
        }

        public ProcessCommand CommandWithArgumentList(string command, params string[] arguments)
        {
            this._processStartInfo.FileName = command;
            if (arguments.Length > 0)
                ArgumentList(arguments);
            return this;
        }

        public ProcessCommand Arguments(string arguments)
        {
            this._processStartInfo.Arguments = arguments;
            return this;
        }

        public ProcessCommand AddVariable(string variableName, string variableValue)
        {
            _processStartInfo.EnvironmentVariables.Add(variableName, variableValue);
            return this;
        }

        public ProcessCommand ArgumentList(params string[] args)
        {
            foreach (string arg in args)
                _processStartInfo.ArgumentList.Add(arg);
            return this;
        }

        public ProcessCommand SetWorkingDirectory(string WorkingDirectory)
        {
            _processStartInfo.WorkingDirectory = WorkingDirectory;
            return this;
        }

        public ProcessCommand WriteInput(string command)
        {
            _process.StandardInput.WriteLine(command);
            _process.StandardInput.WriteLine("ECHO \"" + delimiterString + "\"");
            return this;
        }

        #endregion parameters

        /// <summary>
        /// Cancels the current running task and wait specified time.
        /// </summary>
        /// <param name="wait">if set to <c>true</c> [wait].</param>
        /// <returns></returns>
        public ProcessCommand Cancel(bool wait = false)
        {

            if (this.Cancelling)
                return this;

            this.Cancelling = true;

            if (_process != null)
                _process.Kill();

            if (_cancellation != null && !_cancellation.IsCancellationRequested)
            {

                _task?.Wait(50);

                _cancellation?.Cancel();
                Trace.WriteLine("Task was canceled.");

                if (wait)
                    while (_cancellation != null)
                    {
                        if (_task != null)
                            _task?.Wait(500);
                        else
                            return this;
                    }

            }

            return this;
        }

        /// <summary>
        /// Waits the specified milliseconds timeout.
        /// </summary>
        /// <param name="millisecondsTimeout">The milliseconds timeout.</param>
        /// <returns></returns>
        public ProcessCommand Wait(int millisecondsTimeout)
        {
            if (_task != null)
                _task?.Wait(millisecondsTimeout);
            return this;
        }

        /// <summary>
        /// Waits the task finish
        /// </summary>
        /// <returns></returns>
        public ProcessCommand Wait()
        {
            if (_task != null)
                _task?.Wait();
            return this;
        }

        /// <summary>
        /// Waits the specified timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public ProcessCommand Wait(TimeSpan timeout)
        {
            if (_task != null)
                _task?.Wait(timeout);
            return this;
        }

        ///// <summary>
        ///// Waits the specified output line.
        ///// </summary>
        ///// <param name="output">The output.</param>
        ///// <returns></returns>
        //public ProcessCommand Wait(string output)
        //{
        //    if (_task != null)
        //    {
        //        int last = 0;
        //        while (true)
        //        {
        //            for (int i = last; i < _outputs.Count; i++)
        //            {
        //                if (output.Equals(_outputs[i].Datas))
        //                    return this;
        //                last = i;
        //            }
        //            if (_task != null)
        //                _task.Wait(500);
        //            else
        //                return this;
        //        }
        //    }
        //    return this;
        //}

        #region Process

        /// <summary>
        /// Runs the task and wait the process is done.
        /// </summary>
        /// <param name="wait">if set to <c>true</c> [wait].</param>
        /// <returns></returns>
        public ProcessCommand Run(bool wait = false)
        {

            Start_Impl();

            if (wait)
                _task.Wait();

            return this;

        }

        /// <summary>
        ///  Runs the task and wait the specified milliseconds timeout.
        /// </summary>
        /// <param name="millisecondsTimeout">The milliseconds timeout.</param>
        /// <returns></returns>
        public ProcessCommand Run(int millisecondsTimeout)
        {

            Start_Impl();

            _task.Wait(millisecondsTimeout);

            Cancel();

            return this;

        }

        /// <summary>
        ///  Runs the task and wait the specified timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public ProcessCommand Run(TimeSpan timeout)
        {

            Start_Impl();

            _task.Wait(timeout);

            Cancel();

            return this;

        }

        private void Start_Impl()
        {

            if (this._cancellation != null)
                throw new ExecutionEngineException("Process allready started");

            this._cancellation = new CancellationTokenSource();
            var token = _cancellation.Token;

            this._task = Task.Run(() =>
            {
                Task? t = default;
                try
                {
                    t = Start();
                    this.PushTaskEvent(t, TaskEventEnum.Started);
                    t.Wait();
                    this.PushTaskEvent(t, TaskEventEnum.Completed);
                }
                catch (Exception ex)
                {
                    if (t != null)
                        this.PushTaskEvent(t, TaskEventEnum.CompletedWithException);
                }
                finally
                {
                    this._cancellation = null;
                    this._task = null;
                }

            });

        }

        private async Task Start()
        {

            //processStartInfo.UserName = null;
            //processStartInfo.LoadUserProfile = true;
            //processStartInfo.Password = null;
            //processStartInfo.PasswordInClearText = null;
            //processStartInfo.Verb = "";


            using (this._process = new System.Diagnostics.Process() { StartInfo = _processStartInfo })
            {

                // attach the event handler for OutputDataReceived and ErrorDataReceived before starting the process
                _process.OutputDataReceived += new DataReceivedEventHandler(OutputDataReceived);
                _process.ErrorDataReceived += new DataReceivedEventHandler(ErrorDataReceived);

                bool listen = false;

                try
                {
                    _process.Start();                                           // start the process
                    _process.BeginOutputReadLine();                             // then begin asynchronously reading the output
                    _process.BeginErrorReadLine();                              // then begin asynchronously reading the output
                    listen = true;

                    await _process.WaitForExitAsync(this._cancellation.Token);       // then wait for the process to exit

                }
                catch (TaskCanceledException)
                {

                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
                finally
                {

                    _process.OutputDataReceived -= new DataReceivedEventHandler(OutputDataReceived);
                    _process.ErrorDataReceived -= new DataReceivedEventHandler(ErrorDataReceived);

                    if (listen)
                    {

                        _process.CancelOutputRead();     // then cancel asynchronously reading the output
                        _process.CancelErrorRead();
                    }


                }

                _process.Dispose();

            }

            _process = null;

        }

        #endregion Process

        #region Output

        public ProcessCommand WaitPrompt()
        {

            if (_task != null)
            {
                _waitingInPrompt = true;
                while (_waitingInPrompt)
                    _task?.Wait(1);
                _waitingOutOfPrompt = false;
            }

            return this;

        }

        private void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                if (e.Data == @"""--> waiting""")
                {

                    this._waitingOutOfPrompt = true;

                    if (_waitingInPrompt)
                        _waitingInPrompt = false;

                    while (_waitingOutOfPrompt)
                        _task?.Wait(1);

                }
                else
                {
                    if (TaskEventHandler != null)
                        TaskEventHandler?.Invoke(sender, new TaskEventArgs(this, TaskEventEnum.DataReceived, e));
                }
            }
        }

        private void ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data) && TaskEventHandler != null)
                TaskEventHandler?.Invoke(sender, new TaskEventArgs(this, TaskEventEnum.ErrorReceived, e));
        }    

        public void PushTaskEvent(Task task, TaskEventEnum status)
        {
            if (TaskEventHandler != null)
                TaskEventHandler?.Invoke(task, new TaskEventArgs(this, status, null));
        }
       
        public ProcessCommand Intercept(TaskEventHandler append)
        {
            this._interceptors.Add(append);
            TaskEventHandler += append;
            return this;
        }

        private event TaskEventHandler TaskEventHandler;

        #endregion Output

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                    foreach (var append in _interceptors)
                        TaskEventHandler -= append;



                }

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null

                disposedValue = true;
            }
        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        // ~ProcessCommand()
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


        public Guid Id { get; }
        public object Tag { get; }
        public bool Cancelling { get; private set; }

        private ProcessStartInfo _processStartInfo;
        private System.Diagnostics.Process _process;
        private CancellationTokenSource _cancellation;
        private Task _task;
        private bool disposedValue;
        private string delimiterString = "--> waiting";
        private bool _waitingInPrompt;
        private bool _waitingOutOfPrompt;
        private List<TaskEventHandler> _interceptors;
    }

}