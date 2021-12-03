using laba5.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba5
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new List<BaseObject>();
        Player player;
        Marker marker;
        public Form1()
        {
            InitializeComponent();
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);
            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            objects.Add(player);
            objects.Add(marker);
            objects.Add(new MyRectangle(100, 100, 45));
            objects.Add(new MyRectangle(50, 50, 0));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);
            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float dx = marker.X - player.X;
            float dy = marker.Y - player.Y;

            float length = MathF.Sqrt(dx * dx + dy * dy);
            dx = dx / length;
            dy = dy / length;
            player.X += dx * 2;
            player.Y += dy * 2;
            pbMain.Invalidate();
        }
    }
}
