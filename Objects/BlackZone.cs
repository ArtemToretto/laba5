using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace laba5.Objects
{
    class BlackZone : BaseObject
    {
        public BlackZone(float X, float Y, float Angle) : base(X, Y, Angle) { }

        public Action<BaseObject> BlackZoneOverlap;

        public override void Render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), -100, -200, 200, 400);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddRectangle(new Rectangle(-100,-200,200,400));
            return path;
        }

        public override void Overlap(BaseObject obj)
        {
            BlackZoneOverlap(obj);
        }
    }
}
