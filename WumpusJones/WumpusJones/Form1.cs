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
        private bool shooting;
        private bool triviaActive;
        private bool gameEnded;
        private const int hexSize = 100;

        private Point? mouseLocation = null;

        private readonly IReadOnlyList<Point[]> hexagons;

        private readonly Trivia _trivaSource;
        private readonly GameController _gameController;
        private readonly Random rnd = new();

        public Form1(string playerName, int cave)
        {
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

            // Game Init
            _trivaSource = new();
            _gameController = new(playerName, cave, Trivia, _trivaSource);
            triviaControl1.Trivia = _trivaSource;
            mapControl1.Cave = _gameController.Cave;
            mapControl1.GameLocations = _gameController.GameLocation;
            labelArrows.Text = $"Arrows: {_gameController.Player.Arrows}";
            labelCoins.Text = $"Coins: {_gameController.Player.Coins}";

            _gameController.OnMove += OnMove;
            _gameController.OnTextChanged += OnTextChanged;
            _gameController.OnGameEnd += OnGameEnd;
            OnTextChanged(this, new TextChangeEventArgs { Text = _gameController.GameLocation.MovePlayer(_gameController.GameLocation.PlayerRoom) });
        }

        private void OnGameEnd(object sender, GameEndEventArgs e)
        {
            gameEnded = true;
            gameEndControl1.Title = e.Won ? "You Won" : "You Lost";
            gameEndControl1.Message = e.Message;
            gameEndControl1.Show();
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

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        #endregion Borderless dragging

        private void Trivia(string title, TriviaType type, Action<bool> callback)
        {
            triviaActive = true;
            if (type is not TriviaType.Arrows and not TriviaType.Secret)
            {
                pictureBoxImage.Image = type switch
                {
                    TriviaType.Boulder => Properties.Resources.boulder,
                    TriviaType.Snakes => Properties.Resources.indiana_jones_snakes,
                    _ => Properties.Resources.bottomlesspit
                };
                pictureBoxImage.Show();
            }
            triviaControl1.Init(title, 3);
            void handler(object _, TriviaFinishedEventArgs args)
            {
                triviaActive = false;
                pictureBoxImage.Hide();
                triviaControl1.TriviaFinished -= handler;
                callback(args.Correct >= 2);
            }
            triviaControl1.TriviaFinished += handler;
            triviaControl1.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e) =>
            Application.Exit();

        internal static Point[] RegularHexagonCoordinates(int length, Point center)
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
                var room = Math.Abs(neighbors[i]);
                var brush = neighbors.Any(x => Math.Abs(x) == room) && neighbors.First(x => Math.Abs(x) == room) > 0
                        ? (_gameController.Cave.Explored.Contains(room)
                           ? Brushes.CadetBlue
                           : Brushes.CornflowerBlue)
                        : (_gameController.Cave.Explored.Contains(room)
                           ? Brushes.PowderBlue
                           : Brushes.DarkGray);
                if (neighbors[i] > 0 && mouseLocation.HasValue && IsPointInPolygon(hex, mouseLocation.Value))
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
            if (triviaActive || gameEnded) return;
            // Figure out click location
            var i = 0;
            foreach (var hex in hexagons.Skip(1))
            {
                var target = _gameController.PlayerLocation.Neighbors[i];
                if (target > 0 && mouseLocation.HasValue && IsPointInPolygon(hex, mouseLocation.Value))
                {
                    if (shooting)
                    {
                        _gameController.Shoot(_gameController.PlayerLocation.Neighbors[i]);
                        labelArrows.Text = $"Arrows: {_gameController.Player.Arrows}";
                        buttonArrow_Click(null, null);
                    }
                    else
                        _gameController.Move(_gameController.PlayerLocation.Neighbors[i]);
                    return;
                }
                i++;
            }
        }

        private void buttonMap_Click(object sender, EventArgs e)
        {
            mapControl1.Visible = !mapControl1.Visible;
            if (mapControl1.Visible)
                mapControl1.Invalidate();
        }

        private void OnMove(object sender, PlayerMoveEventArgs e)
        {
            labelCoins.Text = $"Coins: {_gameController.Player.Coins}";
            pictureBox1.Invalidate();
        }

        private void OnTextChanged(object sender, TextChangeEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Text)) return;
            var lines = e.Text.Split('\n').Where(x => !string.IsNullOrWhiteSpace(x));
            var num = _gameController.GameLocation.PlayerRoom;
            foreach (var line in lines)
                richTextBox1.AppendText(e.IncludeRoom ? $"{num}: {line}\n" : $"{line}\n");
            richTextBox1.ScrollToCaret();
        }

        private string GetSecret() => rnd.Next(6) switch
        {
            0 => $"Snakes at {(rnd.Next(2) == 0 ? _gameController.GameLocation.BatRoom1 : _gameController.GameLocation.BatRoom2)}",
            1 => $"Pit at {_gameController.GameLocation.HoleRoom}",
            2 => $"Boulder at {_gameController.GameLocation.WumpusRoom}",
            3 => $"Wumpus is {(_gameController.GameLocation.IsWumpusNearby ? string.Empty : "not")} nearby",
            4 => $"You're at {_gameController.GameLocation.PlayerRoom}",
            _ => $"{_trivaSource.GetAlreadyAskedQuestion()}"
        };

        private void buttonBuySecret_Click(object sender, EventArgs e)
        {
            if (triviaActive || gameEnded || _gameController.Player.Coins < 1) return;
            _gameController.Player.Coins--;
            Trivia("Buying a secret", TriviaType.Secret, success =>
            {
                OnTextChanged(this, new TextChangeEventArgs { IncludeRoom = false, Text = success ? $"SECRET: {GetSecret()}" : "No secret" });
                _gameController.Player.SecretPurchase();
                labelCoins.Text = $"Coins: {_gameController.Player.Coins}";
            });
        }

        private void buttonBuyArrows_Click(object sender, EventArgs e)
        {
            if (triviaActive || gameEnded || _gameController.Player.Coins < 1) return;
            _gameController.Player.Coins--;
            Trivia("Buying arrows", TriviaType.Arrows, success =>
            {
                if (success) _gameController.Player.ArrowPurchase();
                labelArrows.Text = $"Arrows: {_gameController.Player.Arrows}";
                labelCoins.Text = $"Coins: {_gameController.Player.Coins}";
            });
        }

        private void buttonHighScores_Click(object sender, EventArgs e)
        {
        }
    }
}