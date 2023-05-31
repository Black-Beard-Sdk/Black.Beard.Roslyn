namespace Bb.Process
{

    /// <summary>
    /// container for responsability chain
    /// </summary>
    public class TraceContainer
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TraceContainer"/> class.
        /// </summary>
        /// <param name="task">The task.</param>
        public TraceContainer(Action<DataReceiverEventArgs> task)
        {
            this._task = task;
        }

        /// <summary>
        /// Appends the specified task.
        /// </summary>
        /// <param name="task">The task.</param>
        public void Append(TraceContainer task)
        {

            if (this.Next == null)
                this.Next = task;
            else
                this.Next.Append(task);

        }

        /// <summary>
        /// Appends the specified task.
        /// </summary>
        /// <param name="task">The task.</param>
        public void Append(Action<DataReceiverEventArgs> task)
        {

            if (this.Next == null)
                this.Next = new TraceContainer(task);
            else
                this.Next.Append(task);

        }

        internal void Output(DataReceiverEventArgs args)
        {
            this._task(args);
            this.Next?.Output(args);
        }

        private readonly Action<DataReceiverEventArgs> _task;
        private TraceContainer Next;
    }

}