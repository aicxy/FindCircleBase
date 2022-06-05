using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleFinder
{
    class Point2d
    {
        public double x, y;
        public Point2d(double _x, double _y)
        {
            x = _x; y = _y;
        }

        public override string ToString()
        {
            return string.Format("{0:N1},{1:N1}", x, y);
        }

        public double Distance(Point2d pt)
        {
            double dx = pt.x - x;
            double dy = pt.y - y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
