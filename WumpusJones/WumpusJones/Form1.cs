using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WumpusJones
{
    public partial class Form1 : Form
    {
        bool shooting;
        const int hexSize = 100;

        Point? mouseLocation = null;

        readonly IReadOnlyList<Point[]> hexagons;

        GameController _gameController;

        public Form1(string playerName)
        {
            _gameController = new(playerName, 1, Trivia);
            InitializeComponent();
            var dx = (int)(hexSize * 1.5);
            var dy = (int)(Math.Sqrt(3) * hexSize / 2);
            var center = new Size(pictureBox1.Size.Width / 2, pictureBox1.Size.Height / 2);
            hexagons = new[]
            {
                new Point(0, 0),
                new Point(0, -2 * dy),
                new Point(dx, -dy),
                new Point(dx, dy), 
                new Point(0, 2 * dy),
                new Point(-dx, dy),
                new Point(-dx, -dy)
            }.Select(p => RegularHexagonCoordinates(hexSize, p + center)).ToArray();
            label1.Font = Program.CustomFont;
            _gameController.OnMove += OnMove;
        }

        #region Borderless dragging
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

        private void Trivia(string title, Action<bool> callback)
        {
            void handler(object _, TriviaFinishedEventArgs args)
            {
                triviaControl1.TriviaFinished -= handler;
                callback(args.Correct >= 2);
            }
            triviaControl1.TriviaFinished += handler;
        }
        
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
                new Size(-length, 0),
                new Size(-hlen, a),
                new Size(hlen, a),
                new Size(length, 0),
                new Size(hlen, -a),
                new Size(-hlen, -a),
            }.Select(s => center + s).ToArray();
        }

        public static bool IsPointInPolygon(Point[] polygon, Point point)
        {
            Point p1, p2;
            bool inside = false;

            if (polygon.Length < 3) return inside;

            var oldPoint = new Point(polygon[polygon.Length - 1].X, polygon[polygon.Length - 1].Y);

            for (int i = 0; i < polygon.Length; i++)
            {
                var newPoint = new Point(polygon[i].X, polygon[i].Y);
                if (newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }

                if ((newPoint.X < point.X) == (point.X <= oldPoint.X)
                    && (point.Y - (long)p1.Y) * (p2.X - p1.X)
                    < (p2.Y - (long)p1.Y) * (point.X - p1.X))
                    inside = !inside;
                oldPoint = newPoint;
            }
            return inside;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            using Font font = new("Times New Roman", 45, FontStyle.Bold);
            using Pen border = new(Brushes.Black, 2);
            var i = 0;
            var neighbors = _gameController.PlayerLocation.Neighbors;
            
            foreach (var hex in hexagons.Skip(1))
            {
                var brush = Brushes.CornflowerBlue;
                if (neighbors[i] < 0)
                    brush = Brushes.DarkGray;
                else if (mouseLocation.HasValue && IsPointInPolygon(hex, mouseLocation.Value))
                    brush = shooting ? Brushes.Red : Brushes.SkyBlue;
                g.FillPolygon(brush, hex);
                g.DrawPolygon(border, hex);
                g.DrawString(Math.Abs(neighbors[i]).ToString(), font, Brushes.Black, hex[0] + new Size(hexSize / 2 + 15, -15));
                i++;
            }

            g.FillPolygon(Brushes.SkyBlue, hexagons[0]);
            g.DrawPolygon(border, hexagons[0]);
            g.DrawString(_gameController.PlayerLocation.Number.ToString(), font, Brushes.Black, hexagons[0][0] + new Size(hexSize / 2 + 15, -15));
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Invalidate();
            mouseLocation = e.Location;
        }

        private void buttonArrow_Click(object sender, EventArgs e)
        {
            shooting = !shooting;
            buttonArrow.Text = shooting ? "Cancel Shooting" : "Shoot Arrow";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Figure out click location
            var i = 0;
            foreach (var hex in hexagons.Skip(1))
            {
                var target = _gameController.PlayerLocation.Neighbors[i];
                if (target > 0 && mouseLocation.HasValue && IsPointInPolygon(hex, mouseLocation.Value))
                {
                    if (shooting)
                        _gameController.Shoot(_gameController.PlayerLocation.Neighbors[i]);
                    else
                        _gameController.Move(_gameController.PlayerLocation.Neighbors[i]);
                    return;
                }
                i++;
            }
        }
        
        private void OnMove(object sender, PlayerMoveEventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }
}
