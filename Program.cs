using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CircleFinder
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Particle a = new Particle(0, 0, 0, 0);
            Particle b = new Particle(0, 1, 1, 0);
            Particle c = new Particle(0, 2,2.11 , 0);
            double lenAB = Geometry.Distance(a, b);
            double lenBC = Geometry.Distance(b, c);
            double sin = Geometry.cross(a, b, c) / (lenAB * lenBC);
            double cos = Geometry.dot(a, b, c) / (lenAB * lenBC);
            double angle = Math.Atan2(sin, -cos) * 180 / Math.PI;
            if (angle < 0) angle += 360;

            if (args.Length>0)
            {
                Finder finder = new Finder();
                finder.LoadParticle(args[0]);
                finder.LoadAdjacency(args[1]);
                finder.FindBaseCircle();
                finder.SaveCircles("circles.csv");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
