﻿namespace Bb.Analysis.Traces
{
    public interface ILocationPath : ILocation
    {

        /// <summary>
        /// Path position
        /// </summary>
        string Path { get; }

    }

}
