using System.Diagnostics;

namespace Bb.Process
{


    /// <summary>
    /// Screen event handler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="DataReceiverEventArgs"/> instance containing the event data.</param>
    public delegate void ScreenEventHandler(object sender, DataReceiverEventArgs e);


    /// <summary>
    /// EventArgs for wrap data receiving
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class DataReceiverEventArgs : EventArgs
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DataReceiverEventArgs"/> class.
        /// </summary>
        /// <param name="track">The track.</param>
        /// <param name="command">The command.</param>
        /// <param name="datas">The <see cref="DataReceivedEventArgs"/> instance containing the event data.</param>
        /// <param name="sender">The sender.</param>
        public DataReceiverEventArgs(string track, ProcessCommand command, DataReceivedEventArgs datas, object sender)
        {
            this.ReceivedDtm = DateTime.Now; 
            this.Track = track;
            this._datas = datas;
            this.Command = command;
            this.Sender = sender;
        }

        /// <summary>
        /// Gets the received DTM.
        /// </summary>
        /// <value>
        /// The received DTM.
        /// </value>
        public DateTime ReceivedDtm { get; }

        /// <summary>
        /// Gets the track.
        /// </summary>
        /// <value>
        /// The track.
        /// </value>
        public string Track { get; }

        /// <summary>
        /// Gets the datas.
        /// </summary>
        /// <value>
        /// The datas.
        /// </value>
        public string? Datas { get => _datas.Data; }


        /// <summary>
        /// Gets the command that push datas on the canal.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public ProcessCommand Command { get; }

        /// <summary>
        /// Gets the sender. (external process)
        /// </summary>
        /// <value>
        /// The sender.
        /// </value>
        public object Sender { get; }
    
        private readonly DataReceivedEventArgs _datas;

    }

}