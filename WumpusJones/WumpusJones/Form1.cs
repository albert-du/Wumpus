using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WumpusJones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Windowless dragging
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                _ = SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool ReleaseCapture();
        #endregion

        private void buttonExit_Click(object sender, EventArgs e) =>
            Application.Exit();

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private Point[] RegularHexagonCoordinates(int length, Point center)
        {
            var hlen = length / 2;
            var a = (int)(Math.Sqrt(3) * (float)hlen);
            return new[] 
            { 
                new Point(-length, 0),
                new Point(-hlen, a),
                new Point(hlen, a),
                new Point(length, 0), 
                new Point(hlen, -a),
                new Point(-hlen, -a),
            }.Select(p => new Point(p.X + center.X, p.Y + center.Y)).ToArray();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Test implementation of drawing a minimal hexagonal grid.
            const int size = 120;
            var width = panel1.Width;
            var height = panel1.Height;

            var g = e.Graphics;
            Font font = new("Times New Roman", 40);

            var dx = (int)(size * 1.5);
            var dy = (int)(Math.Sqrt(3) * size / 2);
            DrawHex(0, 0, Color.White, "");
            DrawHex(0, 2 * dy, Color.CornflowerBlue, "7");
            DrawHex(0, -2 * dy, Color.CornflowerBlue, "1");
            DrawHex(dx, dy, Color.CornflowerBlue, "2");
            DrawHex(dx, -dy, Color.CornflowerBlue, "4");
            DrawHex(-dx, dy, Color.CornflowerBlue, "5");
            DrawHex(-dx, -dy, Color.CornflowerBlue, "6");

            void DrawHex(int dx, int dy, Color color, string text)
            {
                var p = new Point(width / 2 + dx, height / 2 + dy);
                var points = RegularHexagonCoordinates(size, p);
                g.FillPolygon(new SolidBrush(Color.Black), points);
                points = RegularHexagonCoordinates(size - 2, p);
                g.FillPolygon(new SolidBrush(color), points);
                g.DrawString(text, font, Brushes.Black, p + new Size(-20, -20));
            }
        }
    }
}
