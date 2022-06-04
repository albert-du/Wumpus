using System;

namespace WumpusJones
{
    public class TextChangeEventArgs : EventArgs
    {
        public string Text { get; init; }
        public bool IncludeRoom { get; init; } = true;
    }
}