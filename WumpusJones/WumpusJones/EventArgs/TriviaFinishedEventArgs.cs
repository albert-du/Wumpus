using System;

namespace WumpusJones
{
    public class TriviaFinishedEventArgs : EventArgs
    {
        public int Correct { get; set; }
        public int Incorrect { get; set; }
    }
}