
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleFinder
{
    class Geometry
    {
        /// <summary>
        /// 求向量p1-p0和向量p2-p1的点乘
        /// </summary>
        public static double dot(Particle p0, Particle p1, Particle p2)
        {
            return (p1.x - p0.x) * (p2.x - p1.x) + (p1.y - p0.y) * (p2.y - p1.y);
        }

        /// <summary>
        /// 求向量p1-p0和向量p2-p1的叉乘
        /// </summary>
        public static double cross(Particle p0, Particle p1, Particle p2)
        {
            return (p1.x - p0.x) * (p2.y - p1.y) - (p2.x - p1.x) * (p1.y - p0.y);
        }

        /// <summary>
        /// 求向量X2-X投影在向量X1-X上的位置
        /// </summary>
        public static Point2d project(Particle p0, Particle p1, Particle p2)
        {
            double dx1 = p1.x - p0.x, dy1 = p1.y - p0.y;
            double d = dx1 * (p2.x - p0.x) + dy1 * (p2.y - p0.y);
            double x = p0.x + dx1 * d / (dx1 * dx1 + dy1 * dy1);
            double y = p0.y + dy1 * d / (dx1 * dx1 + dy1 * dy1);
            return new Point2d(x, y);
        }

        public static double Distance(Particle a, Particle b)
        {
            double dx = a.x - b.x;
            double dy = a.y - b.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
