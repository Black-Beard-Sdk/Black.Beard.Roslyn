using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Process
{

    public class ProcessCommand : IDisposable
    {

        public ProcessCommand()
        {

            this._processStartInfo = new ProcessStartInfo()
            {

                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,


                //ErrorDialog = true,
                //ErrorDialogParentHandle = IntPtr.Zero,
                //StandardErrorEncoding = null,
                //StandardInputEncoding = null,
                //StandardOutputEncoding = null,

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

        public ProcessCommand Command(string command)
        {
            this._processStartInfo.FileName = command;
            return this;
        }

        public ProcessCommand AddVariable(string variableName, string variableValue)
        {
            _processStartInfo.EnvironmentVariables.Add(variableName, variableValue);
            return this;
        }

        public ProcessCommand AddArgument(params string[] args)
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

            if (_cancellation != null && !_cancellation.IsCancellationRequested)
            {
                _cancellation.Cancel();
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

        /// <summary>
        /// Waits the specified output line.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <returns></returns>
        public ProcessCommand Wait(string output)
        {
            if (_task != null)
            {
                int last = 0;
                while (true)
                {
                    for (int i = last; i < _outputs.Count; i++)
                    {
                        if (output.Equals(_outputs[i].Datas))
                            return this;
                        last = i;
                    }
                    if (_task != null)
                        _task.Wait(500);
                    else
                        return this;
                }
            }

            return this;

        }

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

                try
                {
                    var t = Start();
                    t.Wait();
                }
                //catch (Exception ex)
                //{

                //}
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
                    if (listen)
                    {
                        _process.CancelOutputRead();     // then cancel asynchronously reading the output
                        _process.CancelErrorRead();
                    }

                    _process.OutputDataReceived -= new DataReceivedEventHandler(OutputDataReceived);
                    _process.ErrorDataReceived -= new DataReceivedEventHandler(ErrorDataReceived);

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
                var arg = new DataReceiverEventArgs("output", e);
                this._outputs.Add(arg);
                ScreenEventHandler?.Invoke(this, arg);
                if (_outputs.Count > 1000)
                    _outputs.RemoveAt(0);
            }
        }

        private void ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            var arg = new DataReceiverEventArgs("error", e);
            this._outputs.Add(arg);
            ScreenEventHandler?.Invoke(this, arg);
            if (_outputs.Count > 1000)
                _outputs.RemoveAt(0);
        }

        public ProcessCommand Output(Action<DataReceiverEventArgs> action)
        {
            if (this._action == null)
                ScreenEventHandler += ProcessCommand_ScreenEventHandler;
            this._action = action;
            return this;
        }

        private void ProcessCommand_ScreenEventHandler(object sender, DataReceiverEventArgs e)
        {
            this._action(e);
        }


        public event ScreenEventHandler ScreenEventHandler;

        #endregion Output

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés)
                    if (this._action != null)
                        ScreenEventHandler -= ProcessCommand_ScreenEventHandler;

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

        public void Dispose()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable



        private List<DataReceiverEventArgs> _outputs = new List<DataReceiverEventArgs>();
        private ProcessStartInfo _processStartInfo;
        private System.Diagnostics.Process _process;
        private CancellationTokenSource _cancellation;
        private Action<DataReceiverEventArgs> _action;
        private Task _task;
        private bool disposedValue;
        private string delimiterString = "--> waiting";
        private bool _waitingInPrompt;
        private bool _waitingOutOfPrompt;
    }


}