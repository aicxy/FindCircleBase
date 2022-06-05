using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CircleFinder
{
    class Finder
    {
        public Particle[] Particles;
        public List<Circle> Circles = new List<Circle>();
        int n = 0;//Particles的数量
        Pen penShell = new Pen(Color.DarkRed, 2);
        Pen penEdge = new Pen(Color.Green, 3);
        public bool adjLoaded = false;
        public TimeSpan timecost;
        public DateTime dtStart;
        public DateTime dtEnd;
        public bool showID;
        public void Initialize()
        {

        }
        public void LoadParticle(string filename)
        {
            using (TextReader tr = File.OpenText(filename))
                try
                {
                    string line;
                    List<Particle> ps = new List<Particle>();
                    n = 0;
                    while ((line = tr.ReadLine()) != null)
                    {
                        string[] strings = line.Split(',');
                        //读取x,y,r
                        double x = double.Parse(strings[0]);
                        double y = double.Parse(strings[1]);
                        double r = double.Parse(strings[2]);
                        Particle p = new Particle(n++, x, y, r);
                        ps.Add(p);
                    }
                    Particles = ps.ToArray();
                    Circles.Clear();
                    adjLoaded = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件读取异常:" + ex.Message);
                }
        }

        HashSet<int> singles = new HashSet<int>();

        public void LoadAdjacency(string filename)
        {

            using (TextReader tr = File.OpenText(filename))
                try
                {
                    string line;
                    for (int i = 0; i < n; i++)
                    {
                        line = tr.ReadLine();
                        string[] strings = line.Split(',');
                        Particle p = Particles[i];
                        for (int j = 0; j < n; j++)
                        {
                            double v = double.Parse(strings[j]);
                            if (v != 0)
                                p.adjs.Add(j);
                        }
                    }
                    singles.Clear();
                    foreach (Particle p in Particles)
                    {
                        if (p.adjs.Count == 1)
                        {
                            //标记为孤立点
                            singles.Add(p.id);
                            Particle next = Particles[p.adjs[0]];
                            int from = p.id;
                            while (next.adjs.Count == 2)
                            {
                                singles.Add(next.id);//移除悬臂
                                if (next.adjs[0] == from)
                                {
                                    from = next.id;
                                    next = Particles[next.adjs[1]];
                                }
                                else
                                {
                                    from = next.id;
                                    next = Particles[next.adjs[0]];
                                }
                            }
                        }
                    }
                    adjLoaded = true;
                    Circles.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件读取异常:" + ex.Message);
                }
        }

        float lastZoomRatio, lastXOffset, lastYOffset;//上一次的缩放和偏移量
        bool lastReady = false;
        double L = double.MaxValue, T, R, B = double.MinValue;

        // 统计边界位置
        public void GetBounds()
        {
            double L = double.MaxValue;
            double T = double.MaxValue;
            double R = double.MinValue;
            double B = double.MinValue;
            // Parallel.ForEach<Axon>(Axons,(axon)=>

            foreach (Particle p in Particles)
            {
                //Axon axon = Axons[i];
                if (p.y < T) T = Math.Min(p.y, T);
                if (p.y > B) B = Math.Max(p.y, B);
                if (p.x < L) L = Math.Min(p.x, L);
                if (p.x > R) R = Math.Max(p.x, R);
            }
            // );

            if (L == R) { L -= 1; R += 1; }
            if (T == B) { T -= 1; B += 1; }
            this.L = L; this.T = T; this.B = B; this.R = R;
        }
        public void TranslatePoint(int x, int y, out double X, out double Y)
        {//将窗口的坐标（像素单位）转换为axon的放置坐标
            X = (x - offsetX) / zoomRatio;
            Y = (y - offsetY) / zoomRatio;
        }
        float offsetX, offsetY, zoomRatio;
        public void Draw(Graphics g, int Left, int Top, int Width, int Height, Font font)
        {
            //画当前Packer中所有的Axon
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //确定从µm到pixel的缩大因子
            if (L == double.MaxValue)
                GetBounds();
            float margin = 10;
            float rangeH = (float)(B - T+0.05 ), rangeW = (float)(R - L +0.05);
            float centerX = (float)(R + L) / 2;
            float centerY = (float)(B + T) / 2;
            zoomRatio = (float)Math.Min((Height - margin) / rangeH, (Width - margin) / rangeW);
            offsetX = Left + Width / 2 - centerX * zoomRatio;
            offsetY = Top + Height / 2 - centerY * zoomRatio;
            if (lastReady)
            {
                zoomRatio = zoomRatio * 0.5f + lastZoomRatio * 0.5f;
                offsetX = offsetX * 0.5f + lastXOffset * 0.5f;
                offsetY = offsetY * 0.5f + lastYOffset * 0.5f;
            }

            lastReady = true;
            lastZoomRatio = zoomRatio;
            lastXOffset = offsetX;
            lastYOffset = offsetY;
            foreach (Particle p in Particles)
            {
                float radius = (float)(p.radius) * zoomRatio;
                float diameter = radius *2;
                float x = offsetX + (float)p.x * zoomRatio - radius;
                float y = offsetY + centerY - (float)p.y * zoomRatio - radius;

                if (singles.Contains(p.id))
                    g.FillEllipse(Brushes.DarkGray, x, y, diameter, diameter);
                else
                    g.FillEllipse(Brushes.DarkBlue, x, y, diameter, diameter);
                //g.DrawEllipse(penShell, x, y, diameter, diameter);
            }
            foreach (Particle p in Particles)
                foreach (int j in p.adjs)
                {
                    if (j < p.id) continue; //利用对称性跳过一半
                    Particle q = Particles[j];
                    g.DrawLine(penEdge, offsetX + (float)p.x * zoomRatio, offsetY + centerY - (float)p.y * zoomRatio, offsetX + (float)q.x * zoomRatio, offsetY + centerY - (float)q.y * zoomRatio);
                }
            foreach (Particle p in Particles)
            {
                float radius = (float)(p.radius) * zoomRatio;
                float diameter = radius * 2;
                float x = offsetX + (float)p.x * zoomRatio - radius;
                float y = offsetY + centerY - (float)p.y * zoomRatio - radius;
                if (showID)
                    g.DrawString( (p.id).ToString(), font, Brushes.Yellow, x+radius/2, y+ radius / 2);
            }
            int colorid = 0;
            foreach (Circle c in Circles)
            {
                //求重心
                double sumx = 0, sumy = 0;
                foreach (int v in c.a)
                {
                    sumx += Particles[v].x;
                    sumy += Particles[v].y;
                }
                sumx = sumx/c.a.Length*0.2;
                sumy = sumy /c.a.Length * 0.2;
                //随机颜色

                Random random = new Random(colorid++);
                Color color = Color.FromArgb(random.Next(192) + 63, random.Next(192) + 63, random.Next(192) + 63);
                //产生点
                using (Pen pen = new Pen(color, 2))
                {
                    List<PointF> pointFs = new List<PointF>();
                    foreach (int v in c.a)
                    {
                        Particle p = Particles[v];
                        pointFs.Add(new PointF(offsetX + (float)(p.x*0.8+sumx)* zoomRatio, offsetY + centerY - (float)(p.y*0.8+sumy)* zoomRatio));
                    }
                    g.DrawLines(pen, pointFs.ToArray());
                }
            }
        }

        public void FindBaseCircle()
        {
            dtStart = DateTime.Now;
            Circles.Clear();
            //循环每个顶点，找到从他出发，顺时针角度最大的顶点，存入邻接矩阵
            int[,] T = new int[n, n];//二阶矩阵
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    T[i, j] = -1;
                }
            foreach (Particle a in Particles)
            {
                int i = a.id;
                foreach (int j in a.adjs)
                {
                    //找所有的k，使得[i,j,k]左转角度最大
                    int minK = -1;
                    double minAngle = 360;
                    Particle b = Particles[j];
                    double lenAB = Geometry.Distance(a, b);
                    
                    foreach (int k in b.adjs)
                    {
                        if (i == k) continue;
                        if (singles.Contains(k))//孤立点跳过
                            continue;
                        Particle c = Particles[k];
                        double lenBC = Geometry.Distance(b, c);
                        double sin = Geometry.cross(a, b, c) / (lenAB * lenBC);
                        double cos = Geometry.dot(a, b, c) / (lenAB * lenBC);
                        double angle = Math.Atan2(sin,-cos) * 180 / Math.PI;
                        if (angle < 0) angle += 360;
 

                        if (angle < minAngle)
                        {
                            minAngle = angle;
                            minK = k;
                        }
                    }
                    if (minK >= 0)
                        T[i, j] = minK;
                }
            }
            Circles.Clear();
            foreach (Particle a in Particles)
            {
                int ii = a.id;

                if (singles.Contains(ii) )//孤立点掉过
                    continue;
                foreach (int jj in a.adjs)
                {
                    if (singles.Contains(jj) )//孤立点掉过
                        continue;
                    int j = jj;
                    int i = ii;
                    int k = T[i, j];
                    List<int> vertexes = new List<int>();
                    vertexes.Add(i);
                    vertexes.Add(j);
                    while (k != ii && k > -1)
                    {
                        if (singles.Contains(k)==false)//孤立点掉过
                            vertexes.Add(k);
                        i = j;
                        j = k;
                        k = T[i, j];
                    }
                    if (k == ii && vertexes.Count>2)//找到出发点，得到一个圈基
                    {
                        vertexes.Add(k);
                        Circle c = new Circle();
                        c.a=vertexes.ToArray();
                        Circles.Add(c);
                        for(int v=0;v<c.a.Length-1;v++)
                        {
                            T[c.a[v], c.a[v + 1]] = -1;//移除已经有的圈环
                        }
                    }
                }
            }
            dtEnd= DateTime.Now;
            timecost = dtEnd - dtStart;
        }

        public void SaveCircles(string filename)
        {
            using (StreamWriter tw = new StreamWriter(filename))
            {
                foreach (Circle c in Circles)
                {
                    StringBuilder line = new StringBuilder();
                    foreach(int v in c.a)
                    {
                        line.Append(v+1);
                        line.Append(',');
                    }
                    line.Remove(line.Length - 1, 1);//移除最后一个
                   tw.WriteLine(line);
                }
            }
        }
    }
}

