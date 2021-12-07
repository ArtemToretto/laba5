using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace laba5.Objects
{
    class Player : BaseObject
    {
        public float vX,vY;
        public Player(float x, float y, float angle) : base(x, y, angle){ }

        public Action<Marker> OnMarkerOverlap;

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Aquamarine),-15,-15,30,30);
            g.DrawEllipse(new Pen(Color.Black, 2), -15, -15, 30, 30);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0);
        }

        public override void BlackRender(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.White), -15, -15, 30, 30);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0);
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }
        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);
            if (obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }
        }
    }
}
