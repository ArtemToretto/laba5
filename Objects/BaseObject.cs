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

        public Action<BaseObject, BaseObject> OnOverlap;

        public virtual void Render(Graphics g)
        {
        }
        public virtual void BlackRender(Graphics g) { }
        public Matrix GetTransform()
        {
            var matrix = new Matrix();
            matrix.Translate(X, Y);
            matrix.Rotate(Angle);
            return matrix;
        }
        public virtual GraphicsPath GetGraphicsPath()
        {
            return new GraphicsPath();
        }
        public virtual bool Overlaps(BaseObject obj, Graphics g)
        {
            var path1 = this.GetGraphicsPath();
            var path2 = obj.GetGraphicsPath();
            path1.Transform(this.GetTransform());
            path2.Transform(obj.GetTransform());
            var region = new Region(path1);
            region.Intersect(path2);
            return !region.IsEmpty(g);
        }
        public virtual void Overlap(BaseObject obj)
        {
            if (this.OnOverlap!=null)
            {
                this.OnOverlap(this, obj);
            }
        }
    }

}
