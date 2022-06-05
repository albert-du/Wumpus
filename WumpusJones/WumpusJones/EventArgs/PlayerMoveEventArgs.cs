using System;

namespace WumpusJones
{
    public class PlayerMoveEventArgs : EventArgs
    {
        public bool Snakes { get; init; }
    }
}