using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleFinder
{
    class Line
    {
        public Point2d p1, p2;
        public int aid1,aid2;
        public Line(double x1,double y1,double x2,double y2)
        {
            p1 = new Point2d(x1, y1);
            p2 = new Point2d(x2, y2);
        }

        public Line(Point2d p1, Point2d p2,int id1,int id2)
        {
            this.p1 = p1;
            this.p2 = p2;
            aid1 = id1;
            aid2 = id2;
        }

        /// <summary>
        /// 求两条射线的交点
        /// </summary>
        public Point2d Cross(Line other)
        {
            double x1=p1.x, x2=p2.x,x3=other.p1.x,x4=other.p2.x;
            double y1=p1.y, y2=p2.y,y3=other.p1.y,y4=other.p2.y;
            double d = (x1 * y3 - x3 * y1 - x1 * y4 - x2 * y3 + x3 * y2 + x4 * y1 + x2 * y4 - x4 * y2);
            double x = (x1 * x3 * y2 - x2 * x3 * y1 - x1 * x4 * y2 + x2 * x4 * y1 - x1 * x3 * y4 + x1 * x4 * y3 + x2 * x3 * y4 - x2 * x4 * y3) / d;
            double y = (x1 * y2 * y3 - x2 * y1 * y3 - x1 * y2 * y4 + x2 * y1 * y4 - x3 * y1 * y4 + x4 * y1 * y3 + x3 * y2 * y4 - x4 * y2 * y3) / d;
            return new Point2d(x, y);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} {2}x{3}",p1,p2,aid1,aid2); 
        }

        /// <summary>
        /// 点到直线距离
        /// </summary>
        public double Distance(Point2d pt)
        {
            double len = p1.Distance(p2);
            return Math.Abs((p2.x - p1.x) * (pt.y - p1.y) - (pt.x - p1.x) * (p2.y - p1.y)) / len;
        }

    }
}
