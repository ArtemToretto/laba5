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
        GreenRing firstRing;
        GreenRing secondRing;
        BlackZone zone=new BlackZone(-100,0,0);
        int score = 0;
        public Form1()
        {
            InitializeComponent();
            Score.Text = "Счет: 0";
            marker = new Marker(pbMain.Width / 2+5, pbMain.Height / 2+5, 0);
            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            objects.Add(zone);
            objects.Add(player);
            player.OnRingOverlap += (obj) =>
              {
                  score++;
                  RandomGreenRing(obj as GreenRing);
                  Score.Text = $"Счет: {score}";
                  txtLog.Text = $"[{DateTime.Now:G}] Игрок пересекся с {obj}\n";
              };
            player.OnMarkerOverlap += (m) =>
              {
                  txtLog.Text = $"[{DateTime.Now:G}] Игрок достиг {m}\n";
                  objects.Remove(m);
                  marker = null;   
              };
            zone.BlackZoneOverlap += (o) =>
              {
                  txtLog.Text = $"[{DateTime.Now:G}] {o} находится в ЧЕРНОЙ ЗОНЕ!\n";
              };
            objects.Add(marker);
            firstRing=new GreenRing(100, 100, 0);
            secondRing=new GreenRing(300, 170, 0);
            objects.Add(firstRing);
            objects.Add(secondRing);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            UpdatePlayer();

            foreach (var obj1 in objects.ToList())
            {
                foreach (var obj2 in objects.ToList())
                {
                    if (obj1 != obj2 && obj1.Overlaps(obj2, g))
                    {
                        obj1.Overlap(obj2);
                    }
                }
            }

            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ZoneGo();
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
           if (marker==null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }
            
            marker.X = e.X;
            marker.Y = e.Y;
        }

        private void UpdatePlayer()
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;
                float length = MathF.Sqrt(dx * dx + dy * dy);
                dx = dx / length;
                dy = dy / length;
                player.vX += dx * 0.5f;
                player.vY += dy * 0.5f;
                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;
            player.X += player.vX;
            player.Y += player.vY;
        }

        private void RandomGreenRing(GreenRing obj)
        {
            Random randomX = new Random();
            obj.X = randomX.Next(15, pbMain.Width-15);
            Random randomY = new Random();
            obj.Y = randomY.Next(15, pbMain.Height - 15);
        }

        private void ZoneGo()
        {
            if (zone.X<750)
            {
                zone.X += 4;
            }
            else 
            {
                zone.X = -100;
            }
        }
        private void Score_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
         
        }
    }
}
