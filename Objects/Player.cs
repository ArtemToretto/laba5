﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace laba5.Objects
{
    class Player : BaseObject
    {
        public Player(float x, float y, float angle) : base(x, y, angle){ }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Aquamarine),-15,-15,30,30);
            g.DrawEllipse(new Pen(Color.Black, 2), -15, -15, 30, 30);
        }

    }
}