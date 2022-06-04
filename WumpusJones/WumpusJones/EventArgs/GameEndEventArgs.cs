using System;

namespace WumpusJones
{
    public class GameEndEventArgs : EventArgs
    {
        public bool Won { get; init; }
        public string Message { get; init; }
    }
}