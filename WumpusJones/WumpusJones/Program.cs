using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace WumpusJones
{
    internal static class Program
    {

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private static readonly PrivateFontCollection fonts = new();

        public static Font CustomFont;

        private static void InitFont()
        {
            var fontData = Properties.Resource1.SF_Fedora;
            var fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            var dummy = 0u;
            fonts.AddMemoryFont(fontPtr, Properties.Resource1.SF_Fedora.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resource1.SF_Fedora.Length, IntPtr.Zero, ref dummy);
            Marshal.FreeCoTaskMem(fontPtr);
            CustomFont = new Font(fonts.Families[0], 16.0F);
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            InitFont();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartupForm startup = new();
            startup.ShowDialog();
            Application.Run(new Form1(startup.PlayerName, startup.Cave, startup.ActiveWumpus));
        }
    }
}

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class IsExternalInit { }
}