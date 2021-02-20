using System;
using System.Collections.Generic;
using System.Text;

namespace Practice3
{
    public struct Rectangle
    {
        public int width;
        public int height;

        public Point topLeftPoint;
        //public Point bottomRight;

        public Rectangle(int w, int h)
        {
            this.width = w;
            this.height = h;
            this.topLeftPoint = new Point(0, 0);
        }
        public Rectangle(int w, int h, Point topLeft)
        {
            this.width = w;
            this.height = h;
            this.topLeftPoint = topLeft;
        }

        public int CalculateArea()
        {
            return this.width * this.height;
        }

        public bool IsOverlapping(Rectangle rectangle)
        {
            //if ((rectangle.topLeftPoint.X >= this.topLeftPoint.X && rectangle.topLeftPoint.X <= this.topLeftPoint.X + this.width)
            //    || (rectangle.topLeftPoint.Y >= this.topLeftPoint.Y && rectangle.topLeftPoint.Y <= this.topLeftPoint.Y + this.height))
            //{
            //    return true;
            //}
            //else if((rectangle.topLeftPoint.Y >= this.topLeftPoint.Y && rectangle.topLeftPoint.Y <= this.topLeftPoint.Y + this.height)
            //    && rectangle.height + rectangle.topLeftPoint.Y )
            return false;
        }
    }
}
