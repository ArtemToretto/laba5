using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace laba5.Objects
{
    class MyRectangle : BaseObject
    {
        public MyRectangle(float X,float Y, float Angle) : base(X, Y, Angle) { }
        public override void Render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.YellowGreen), -25, -15, 50, 30);
            g.DrawRectangle(new Pen(Color.Red), -25, -15, 50, 30);
        }
    }
}
