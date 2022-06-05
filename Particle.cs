using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CircleFinder
{
    class Particle
    {
        public int id;
        public double x, y;
        public double radius;//含gap的半径
        public List<int> adjs = new List<int>();//邻接链表

        public Particle(int i, double x, double y, double r)
        {
            id = i;
            this.x = x;
            this.y = y;
            this.radius = r;
        }

        public override string ToString()
        {
            return string.Format("{0} - ({1:N2},{2:N2},{3:N2})",id,x,y,radius);
        }
    }
}
