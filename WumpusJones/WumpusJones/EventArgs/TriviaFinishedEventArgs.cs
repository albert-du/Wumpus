using System;

namespace WumpusJones
{
    public class TriviaFinishedEventArgs : EventArgs
    {
        public int Correct { get; init; }
        public int Incorrect { get; init; }
    }
}