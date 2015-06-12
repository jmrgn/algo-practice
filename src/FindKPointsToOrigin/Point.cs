using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindKPointsToOrigin
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Distance { get; private set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            Distance = 0.0;
        }

        public void SetDistanceFromOrigin(Point origin)
        {
            var distance = Math.Sqrt(Math.Pow(origin.X - X, 2) + Math.Pow(origin.Y - Y, 2));
            Distance = distance;
        }
    }
}
