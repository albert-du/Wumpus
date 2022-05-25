using System;

namespace WumpusJones
{
    public class GameEndEventArgs : EventArgs
    {
        public bool Won { get; set; }
        public string Message { get; set; }
    }
}