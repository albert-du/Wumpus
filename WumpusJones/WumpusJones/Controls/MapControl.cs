using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WumpusJones
{
    public partial class MapControl : UserControl
    {
        const int hexSize = 50;
        readonly int dx = (int)(hexSize * 1.5);
        readonly int dy = (int)(Math.Sqrt(3) * hexSize / 2);
        public Cave Cave { get; set; }
        public GameLocation GameLocations { get; set; }
        public MapControl()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e) =>
            Hide();

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!Visible || Cave is null || GameLocations is null) return;
            var g = e.Graphics;
            var center = new Size(120, 125);
            using Pen border = new(Brushes.Black, 2);
            using Font font = new("Times New Roman", 20, FontStyle.Bold);

            var room = GameLocations.PlayerRoom;
            var loc = (Point)center;
            var brush = Brushes.SkyBlue;
            var neighbors = Cave.RoomAt(GameLocations.PlayerRoom).Neighbors;
            var first = true;
            DrawHex(0, 0);

            for (var layer = 1; layer <= 4; layer++)
            {
                // Move north and draw
                room = Math.Abs(Cave.RoomAt(room).North);
                loc += new Size(0, -2 * dy);

                // south east
                for (var i = 0; i < layer; i++)
                {
                    room = Math.Abs(Cave.RoomAt(room).SouthEast);
                    UpdateBrush();
                    DrawHex(dx, dy);
                }

                for (var i = 0; i < layer; i++)
                {
                // south
                    room = Math.Abs(Cave.RoomAt(room).South);
                    UpdateBrush();
                    DrawHex(0, 2 * dy);
                }

                // south west
                for (var i = 0; i < layer; i++)
                {
                    room = Math.Abs(Cave.RoomAt(room).SouthWest);
                    UpdateBrush();
                    DrawHex(-dx, dy);
                }

                // north west
                for (var i = 0; i < layer; i++)
                {
                    room = Math.Abs(Cave.RoomAt(room).NorthWest);
                    UpdateBrush();
                    DrawHex(-dx, -dy);
                }

                // north
                for (var i = 0; i < layer; i++)
                {
                    room = Math.Abs(Cave.RoomAt(room).North);
                    UpdateBrush();
                    DrawHex(0, -2 * dy);
                }

                // north east
                for (var i = 0; i < layer; i++)
                {
                    room = Math.Abs(Cave.RoomAt(room).NorthEast);
                    UpdateBrush();
                    DrawHex(dx, -dy);
                }
                first = false;
            }
            ControlPaint.DrawBorder(e.Graphics, pictureBox1.ClientRectangle, Color.Goldenrod, ButtonBorderStyle.Solid);

            void UpdateBrush()
            {
                if (room == GameLocations.StartingRoom)
                {
                    brush = Brushes.Goldenrod;
                    return;
                }
                brush = first && neighbors.Any(x => Math.Abs(x) == room) && neighbors.First(x => Math.Abs(x) == room) > 0
                        ? (Cave.Explored.Contains(room)
                           ? Brushes.CadetBlue
                           : Brushes.CornflowerBlue)
                        : (Cave.Explored.Contains(room)
                           ? Brushes.PowderBlue
                           : (first ? Brushes.DarkGray : Brushes.Gray));
            }
            void DrawHex(int x, int y)
            {
                loc += new Size(x, y);
                var hex = Form1.RegularHexagonCoordinates(hexSize, loc + center);
                g.FillPolygon(brush, hex);
                g.DrawPolygon(border, hex);
                g.DrawString(room.ToString(), font, Brushes.Black, hex[0] + new Size(hexSize / 2 + 5, -5));
            }
        }
    }
}
