using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace laba5.Objects
{
    class Marker : BaseObject
    {
        public Marker(float X, float Y, float Angle) : base(X,Y,Angle){ }

        public override void Render(Graphics g)
        {
            if (color)
            {
                g.FillEllipse(new SolidBrush(Color.Red), -3, -3, 6, 6);
                g.DrawEllipse(new Pen(Color.Red, 2), -6, -6, 12, 12);
                g.DrawEllipse(new Pen(Color.Red, 2), -10, -10, 20, 20);
            }
            else
            {
                g.FillEllipse(new SolidBrush(Color.White), -3, -3, 6, 6);
                g.DrawEllipse(new Pen(Color.White, 2), -6, -6, 12, 12);
                g.DrawEllipse(new Pen(Color.White, 2), -10, -10, 20, 20);
            }
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-3,-3,6,6);
            return path;
        }
    }
}
