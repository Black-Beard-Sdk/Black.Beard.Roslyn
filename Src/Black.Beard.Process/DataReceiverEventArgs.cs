using System.Diagnostics;

namespace Bb.Process
{


    public delegate void ScreenEventHandler(object sender, DataReceiverEventArgs e);


    public class DataReceiverEventArgs : EventArgs
    {

        public DataReceiverEventArgs(string track, DataReceivedEventArgs datas)
        {
            this.ReceivedDtm = DateTime.Now; 
            this.Track = track;
            this._datas = datas;
        }

        public DateTime ReceivedDtm { get; }

        public string Track { get; }

        public string? Datas { get => _datas.Data; }

        private readonly DataReceivedEventArgs _datas;

    }

}