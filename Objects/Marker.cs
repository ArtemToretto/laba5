using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace laba5.Objects
{
    class Marker : BaseObject
    {
        public Marker(float X, float Y, float Angle) : base(X,Y,Angle){ }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red), -3, -3, 6, 6);
            g.DrawEllipse(new Pen(Color.Red, 2), -6, -6, 12, 12);
            g.DrawEllipse(new Pen(Color.Red, 2), -10, -10, 20, 20);
        }
    }
}
