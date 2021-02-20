using System;
using System.Collections.Generic;
using System.Text;

namespace Practice3
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Point point = (Point)obj;
            return this.X == point.X && this.Y == point.Y;
        }
        public bool IsEqual(Point obj)
        {
            return false;
        }
    }
}