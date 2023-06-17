using System.Diagnostics;

namespace Bb.Process
{

    /// <summary>
    /// Task event handler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="TaskEventArgs"/> instance containing the event data.</param>
    public delegate void TaskEventHandler(object sender, TaskEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class TaskEventArgs : EventArgs
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskEventArgs"/> class.
        /// </summary>
        /// <param name="process">The process.</param>
        /// <param name="status">The status.</param>
        public TaskEventArgs(ProcessCommand process, TaskEventEnum status, DataReceivedEventArgs datas)
        {
            this.ReceivedDtm = DateTime.Now;
            this.Status = status;
            this.Process  = process;
            this.DateReceived = datas;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="TaskEventArgs"/> is closing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if closing; otherwise, <c>false</c>.
        /// </value>
        public bool Closing => Status == TaskEventEnum.Completed || Status == TaskEventEnum.CompletedWithException;

        /// <summary>
        /// Gets the received DTM.
        /// </summary>
        /// <value>
        /// The received DTM.
        /// </value>
        public DateTime ReceivedDtm { get; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public TaskEventEnum Status { get; }

        /// <summary>
        /// Gets the process.
        /// </summary>
        /// <value>
        /// The process.
        /// </value>
        public ProcessCommand Process { get ; }

        /// <summary>
        /// Gets the date received.
        /// </summary>
        /// <value>
        /// The date received.
        /// </value>
        public DataReceivedEventArgs DateReceived { get; }
    }

    /// <summary>
    /// Task event status
    /// </summary>
    public enum TaskEventEnum
    {
        Started,
        ErrorReceived,
        DataReceived,
        Completed,
        CompletedWithException,
    }


}