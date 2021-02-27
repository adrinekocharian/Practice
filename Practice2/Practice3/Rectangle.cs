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
        public Point bottomRight;

        public Rectangle(int w, int h)
        {
            this.width = w;
            this.height = h;
            this.topLeftPoint = new Point(0, 0);
            this.bottomRight = new Point(width, height);
        }
        public Rectangle(int w, int h, Point topLeft)
        {
            this.width = w;
            this.height = h;
            this.topLeftPoint = topLeft;
            this.bottomRight = new Point(topLeft.X + w, topLeft.Y + h);
        }

        public int CalculateArea()
        {
            return this.width * this.height;
        }

        public bool IsOverlapping(Rectangle rect)
        {
            if (rect.topLeftPoint.X > this.bottomRight.X || this.topLeftPoint.X > rect.bottomRight.X)
                return false;

            if (rect.topLeftPoint.Y > this.bottomRight.Y || this.topLeftPoint.Y > rect.bottomRight.Y)
                return false;

            return true;
        }
    }
}
