using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Bb.Process
{



    /// <summary>
    /// class for manage lifecycle of the <see cref="Task" /> what wraps external process
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ProcessCommand : IDisposable
    {

        /// <summary>
        /// Initializes the <see cref="ProcessCommand"/> class.
        /// </summary>
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

        public class ProcessInfo
        {

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

                StandardOutputEncoding = encoding,
                StandardErrorEncoding = encoding,

                WindowStyle = ProcessWindowStyle.Hidden,

                //ErrorDialog = true,
                //ErrorDialogParentHandle = IntPtr.Zero,
                //StandardInputEncoding = encoding,

            };

        }

        #region parameters

        /// <summary>
        /// the batch on 'cmd.exe'.
        /// </summary>
        /// <returns></returns>
        public ProcessCommand CommandWindowsBatch()
        {

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new InvalidOperationException($"command invalid on {RuntimeInformation.OSDescription}");

            return Command("cmd.exe");

        }

        /// <summary>
        /// set the Commands to run with the argument's line.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        public ProcessCommand Command(string command, string arguments = null)
        {
            this._processStartInfo.FileName = command;
            if (!string.IsNullOrEmpty(arguments))
                this._processStartInfo.Arguments = arguments;
            return this;
        }

        /// <summary>
        /// set the Commands to run with the list of argument
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        public ProcessCommand CommandWithArgumentList(string command, params string[] arguments)
        {
            this._processStartInfo.FileName = command;
            if (arguments.Length > 0)
                ArgumentList(arguments);
            return this;
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the Windows user profile is to be loaded from the registry.
        /// </summary>
        /// <returns>true if the Windows user profile should be loaded; otherwise, false. The default is false.</returns>
        /// <remarks>
        /// This property is referenced if the process is being started by using the user name, password, and domain.
        /// If the value is true, the user's profile in the HKEY_USERS registry key is loaded. Loading the profile can be time-consuming. Therefore, it is best to use this value only if you must access the information in the HKEY_CURRENT_USER registry key.
        /// In Windows Server 2003 and Windows 2000, the profile is unloaded after the new process has been terminated, regardless of whether the process has created child processes.
        /// In Windows XP, the profile is unloaded after the new process and all child processes it has created have been terminated.
        /// </remarks>
        public bool LoadUserProfile
        {
            get => this._processStartInfo.LoadUserProfile;
            set => this._processStartInfo.LoadUserProfile = value;
        }

        /// <summary>
        /// Sets a value that indicates whether the Windows user profile is to be loaded from the registry.
        /// </summary>
        /// <param name="use">true if the Windows user profile should be loaded; otherwise, false. The default is false.</param>
        /// <returns><see cref="T:ProcessCommand"/>fluent command method</returns>
        /// <remarks>
        /// This property is referenced if the process is being started by using the user name, password, and domain.
        /// If the value is true, the user's profile in the HKEY_USERS registry key is loaded. Loading the profile can be time-consuming. Therefore, it is best to use this value only if you must access the information in the HKEY_CURRENT_USER registry key.
        /// In Windows Server 2003 and Windows 2000, the profile is unloaded after the new process has been terminated, regardless of whether the process has created child processes.
        /// In Windows XP, the profile is unloaded after the new process and all child processes it has created have been terminated.
        /// </remarks>
        public ProcessCommand UseShellExecute(bool use = true)
        {
            this._processStartInfo.UseShellExecute = use;
            return this;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the operating system shell to start the process.
        /// </summary>
        /// <returns>true if the shell should be used when starting the process; false if the process should be created directly from the executable file. The default is true on .NET Framework apps and false on .NET Core apps.</returns>
        public bool ShellExecute
        {
            get => this._processStartInfo.UseShellExecute;
            set => this._processStartInfo.UseShellExecute = value;
        }

        //this._processStartInfo.PasswordInClearText = "*";
        //this._processStartInfo.Verb = "";

        /// <summary>
        /// Sets the credentials for specified user name.
        /// note : Setting the Domain, UserName, and the Password properties in a ProcessStartInfo object is the recommended practice for starting a process with user credentials.
        /// </summary>
        /// <param name="userName">Sets the user name to use when starting the process. If you use the UPN format, user@DNS_domain_name, the Domain property must be null..</param>
        /// <param name="password">Sets a secure string that contains the user password to use when starting the process.</param>
        /// <returns><see cref="T:ProcessCommand"/>fluent command method</returns>
        /// <remarks>
        /// The WorkingDirectory property must be set if UserName and Password are provided. If the property is not set, the default working directory is %SYSTEMROOT%\system32.
        /// </remarks>
        public ProcessCommand Credentials(string userName, SecureString password)
        {
            this._processStartInfo.UserName = userName;
            this._processStartInfo.Password = password;
            return this;
        }

        /// <summary>
        /// Sets the credentials for specified user name.
        /// note : Setting the Domain, UserName, and the Password properties in a ProcessStartInfo object is the recommended practice for starting a process with user credentials.
        /// </summary>
        /// <param name="userName">Sets the user name to use when starting the process. If you use the UPN format, user@DNS_domain_name, the Domain property must be null..</param>
        /// <param name="password">Sets a string that contains the user password to use when starting the process.</param>
        /// <returns><see cref="T:ProcessCommand"/>fluent command method</returns>
        public ProcessCommand Credentials(string userName, string password)
        {
            this._processStartInfo.UserName = userName;
            this._processStartInfo.Password = ConvertToSecureString(password);
            return this;
        }

        /// <summary>
        /// specify the argument's line.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        public ProcessCommand Arguments(string arguments)
        {
            this._processStartInfo.Arguments = arguments;
            return this;
        }

        /// <summary>
        /// Gets the argument text line.
        /// </summary>
        /// <value>
        /// The argument text.
        /// </value>
        public string ArgumentText => this._processStartInfo.Arguments;

        /// <summary>
        /// Gets the filename to execute.
        /// </summary>
        /// <value>
        /// The file name text.
        /// </value>
        public string FileNameText => this._processStartInfo.FileName;

        /// <summary>
        /// Gets or sets the window state to use when the process is started.
        /// </summary>
        /// <returns>One of the enumeration values that indicates whether the process is started in a window that is maximized, minimized, normal (neither maximized nor minimized), or not visible. The default is Normal.</returns>
        public ProcessWindowStyle WindowStyle
        {
            get => this._processStartInfo.WindowStyle;
            set => this._processStartInfo.WindowStyle = value;
        }

        /// <summary>
        /// Sets the window state to use when the process is started.
        /// </summary>
        /// <param name="use">One of the enumeration values that indicates whether the process is started in a window that is maximized, minimized, normal (neither maximized nor minimized), or not visible. The default is Normal.</param>
        /// <returns><see cref="T:ProcessCommand"/>fluent command method</returns>
        public ProcessCommand SetWindowStyle(ProcessWindowStyle use)
        {
            this._processStartInfo.WindowStyle = use;
            return this;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to start the process in a new window..
        /// </summary>
        /// <returns>true if the process should be started without creating a new window to contain it; otherwise, false. The default is false.</returns>
        public bool CreateNoWindow
        {
            get => this._processStartInfo.CreateNoWindow;
            set => this._processStartInfo.CreateNoWindow = value;
        }

        /// <summary>
        /// sets a value indicating whether to use the operating system shell to start the process.
        /// </summary>
        /// <param name="use">false if the process should be started without creating a new window to contain it; otherwise, true. The default is false..</param>
        /// <returns><see cref="T:ProcessCommand"/>fluent command method</returns>
        public ProcessCommand CreateWindow(bool use = false)
        {
            this._processStartInfo.CreateNoWindow = !use;
            return this;
        }

        /// <summary>
        /// Adds the specified variable in the environment.
        /// </summary>
        /// <param name="variableName">Name of the variable.</param>
        /// <param name="variableValue">The variable value.</param>
        /// <returns></returns>
        public ProcessCommand AddVariable(string variableName, string variableValue)
        {
            _processStartInfo.EnvironmentVariables.Add(variableName, variableValue);
            return this;
        }

        /// <summary>
        /// add the argument's list.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public ProcessCommand ArgumentList(params string[] args)
        {
            foreach (string arg in args)
                _processStartInfo.ArgumentList.Add(arg);
            return this;
        }

        /// <summary>
        /// Sets the working directory.
        /// </summary>
        /// <param name="WorkingDirectory">The working directory.</param>
        /// <returns></returns>
        public ProcessCommand SetWorkingDirectory(string WorkingDirectory)
        {
            _processStartInfo.WorkingDirectory = WorkingDirectory;
            return this;
        }

        /// <summary>
        /// Writes the command in the input stream.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public ProcessCommand WriteInput(string command)
        {

            if (_process == null)
            {
                var i = DateTime.Now.AddMinutes(1);
                while (this._cancellation != null && i > DateTime.Now)
                {
                    Thread.Sleep(1);
                }

                if (_process == null)
                    throw new ExecutionEngineException("process not initialized");

            }

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
        public ProcessCommand Cancel(int wait = 5000)
        {

            if (this.Cancelling)
                return this;

            if (_process != null && _task != null)
                try
                {

                    this.Cancelling = true;

                    _process.Kill();

                    if (_cancellation != null && !_cancellation.IsCancellationRequested)
                    {

                        _task?.Wait(50);

                        _cancellation?.Cancel();
                        Trace.WriteLine("Task was canceled.");

                        var timeout = DateTime.Now.AddMilliseconds(wait);
                        while (_cancellation != null && DateTime.Now < timeout && _task != null)
                            _task?.Wait(5);

                    }

                }
                catch (Exception ex)
                {
                    TaskEventHandler?.Invoke(this, new TaskEventArgs(this, TaskEventEnum.FailedToCancel, null) { Exception = ex });
                }

            if (_task == null)
            {
                this.Canceled = true;
                this.Cancelling = false;
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
                _task?.Wait();

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

            _task?.Wait(millisecondsTimeout);

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
                throw new ExecutionEngineException("Process already started");

            this._cancellation = new CancellationTokenSource();
            var token = _cancellation.Token;

            if (!string.IsNullOrEmpty(_processStartInfo.UserName))
                _processStartInfo.UseShellExecute = false;

            this._task = Task.Run(() =>
            {
                Task<int?>? t = default;
                try
                {

                    t = Start();

                    t.Wait();
                    this.ExitCode = t.Result;

                    if (this.ExitCode != null)
                        this.PushTaskEvent(t, TaskEventEnum.Completed);

                }
                finally
                {
                    this._cancellation = null;
                    this.PushTaskEvent(t, TaskEventEnum.Releasing);
                    this._task = null;

                }

            });

        }

        private async Task<int?> Start()
        {

            int? exitCode = default;

            using (this._process = new System.Diagnostics.Process() { StartInfo = _processStartInfo })
            {

                // attach the event handler for OutputDataReceived and ErrorDataReceived before starting the process
                _process.OutputDataReceived += new DataReceivedEventHandler(OutputDataReceived);
                _process.ErrorDataReceived += new DataReceivedEventHandler(ErrorDataReceived);

                bool listen = false;

                try
                {



                    var started = _process.Start();                                 // start the process
                    if (started)
                    {
                        listen = true;
                        _process.BeginOutputReadLine();                             // then begin asynchronously reading the output
                        _process.BeginErrorReadLine();                              // then begin asynchronously reading the output

                        this.PushTaskEvent(this, TaskEventEnum.Started);

                        await _process.WaitForExitAsync(this._cancellation.Token);  // then wait for the process to exit
                        exitCode = _process.ExitCode;
                    }

                }
                catch (TaskCanceledException ex)
                {

                    if (TaskEventHandler != null)
                        TaskEventHandler?.Invoke(this, new TaskEventArgs(this, TaskEventEnum.RanCanceled, null) { Exception = ex });

                }
                catch (Exception ex)
                {

                    if (!listen)
                        this.PushTaskEvent(this, TaskEventEnum.FailedToStart);

                    else if (TaskEventHandler != null)
                        TaskEventHandler?.Invoke(this, new TaskEventArgs(this, TaskEventEnum.RanWithException, null) { Exception = ex });

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

            }

            return exitCode;

        }

        #endregion Process

        #region Interceptors

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

        /// <summary>
        /// Raise the task event.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="status">The status.</param>
        private void PushTaskEvent(object task, TaskEventEnum status)
        {
            if (TaskEventHandler != null)
                TaskEventHandler?.Invoke(task, new TaskEventArgs(this, status, null));
        }

        /// <summary>
        /// add a new subscription
        /// </summary>
        /// <param name="interceptor">The interceptor.</param>
        /// <returns></returns>
        public ProcessCommand Intercept(TaskEventHandler interceptor)
        {
            this._interceptors.Add(interceptor);
            TaskEventHandler += interceptor;
            return this;
        }

        /// <summary>
        /// Removes the subscription
        /// </summary>
        /// <param name="interceptor">The interceptor.</param>
        /// <returns></returns>
        public ProcessCommand RemoveIntercept(TaskEventHandler interceptor)
        {
            if (this._interceptors.Contains(interceptor))
            {
                this._interceptors.Remove(interceptor);
                TaskEventHandler -= interceptor;
            }
            return this;
        }

        private event TaskEventHandler TaskEventHandler;

        #endregion Interceptors

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                    if (_task != null)
                        Cancel();

                    if (TaskEventHandler != null)
                        TaskEventHandler?.Invoke(this, new TaskEventArgs(this, TaskEventEnum.Disposing, null));

                    foreach (var toRemove in _interceptors)
                        TaskEventHandler -= toRemove;

                    _interceptors.Clear();

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

        public bool Canceled { get; private set; }

        public bool Cancelling { get; private set; }

        public int? ExitCode { get; private set; }


        private SecureString ConvertToSecureString(string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            var securePassword = new SecureString();

            foreach (char c in password)
                securePassword.AppendChar(c);

            securePassword.MakeReadOnly();
            return securePassword;
        }

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