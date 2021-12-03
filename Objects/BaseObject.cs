using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace laba5.Objects
{
    class BaseObject
    {
        public float X;
        public float Y;
        public float Angle;
        public BaseObject(float X, float Y, float Angle)
        {
            this.X = X;
            this.Y = Y;
            this.Angle = Angle;
        }

        public virtual void Render(Graphics g)
        {
        }
        public Matrix GetTransform()
        {
            var matrix = new Matrix();
            matrix.Translate(X, Y);
            matrix.Rotate(Angle);
            return matrix;
        }
    }

}
