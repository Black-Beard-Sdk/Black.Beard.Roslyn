using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Process
{
    public class Command
    {

        public Command()
        {

            this._processStartInfo = new ProcessStartInfo()
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,

                UseShellExecute = false,

                //ErrorDialog = true,
                //ErrorDialogParentHandle = IntPtr.Zero,
                //StandardErrorEncoding = null,
                //StandardInputEncoding = null,
                //StandardOutputEncoding = null,

                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden

            };

        }

        public Command AddVariable(string variableName, string variableValue)
        {
            _processStartInfo.EnvironmentVariables.Add(variableName, variableValue);
            return this;
        }

        public Command AddArgument(params string[] args)
        {
            foreach (string arg in args)
                _processStartInfo.ArgumentList.Add(arg);
            return this;
        }

        public Command SetWorkingDirectory(string WorkingDirectory)
        {
            _processStartInfo.WorkingDirectory = WorkingDirectory;
            return this;
        }



        public void Run()
        {

            //processStartInfo.UserName = null;
            //processStartInfo.LoadUserProfile = true;
            //processStartInfo.Password = null;
            //processStartInfo.PasswordInClearText = null;

            _processStartInfo.FileName = "cmd exe";
            _processStartInfo.Arguments = "<insert command line arguments here>";
            //processStartInfo.Verb = "";


            this._process = new System.Diagnostics.Process()
            {
                StartInfo = _processStartInfo,
            };

            // attach the event handler for OutputDataReceived and ErrorDataReceived before starting the process
            _process.OutputDataReceived += new DataReceivedEventHandler(OutputDataReceived);
            _process.ErrorDataReceived += new DataReceivedEventHandler(ErrorDataReceived);

            bool listen = false;

            try
            {
                _process.Start();                    // start the process
                _process.BeginOutputReadLine();      // then begin asynchronously reading the output
                listen = true;

                _process.WaitForExit();              // then wait for the process to exit

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (listen)
                    _process.CancelOutputRead();     // then cancel asynchronously reading the output

                _process.OutputDataReceived -= new DataReceivedEventHandler(OutputDataReceived);
                _process.ErrorDataReceived -= new DataReceivedEventHandler(ErrorDataReceived);

            }

            _process.Dispose();
            _process = null;

        }

        private void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {


        }

        private void ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {


        }

        private ProcessStartInfo _processStartInfo;
        private System.Diagnostics.Process _process;
    }
}