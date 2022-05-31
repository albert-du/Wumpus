using System;

namespace WumpusJones
{
    public class TextChangeEventArgs : EventArgs
    {
        public string Text { get; set; }
        public bool IncludeRoom { get; set; } = true;
    }
}