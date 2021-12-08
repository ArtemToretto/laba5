using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace laba5.Objects
{
    class GreenRing : BaseObject
    {
        public GreenRing(float X, float Y, float Angle) : base(X, Y, Angle) { }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.LawnGreen), -15, -15, 30, 30);
        }

        public override void BlackRender(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.White), -15, -15, 30, 30);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }
    }
}
