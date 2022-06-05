using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CircleFinder
{
    public partial class FormMain : Form
    {
        Finder finder = new Finder();
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadFile("default.csv");
        }

        private void btnLoadParticle_Click(object sender, EventArgs e)
        {
            finder.LoadParticle("每个颗粒的坐标和半径.csv");
        }

        private void btnLoadAdjacency_Click(object sender, EventArgs e)
        {
            if (finder.Particles == null)
                btnLoadParticle_Click(sender, e);
            finder.LoadAdjacency("邻接矩阵.csv");
        }

        private void btnFindCircleBase_Click(object sender, EventArgs e)
        {
            if (finder.adjLoaded == false)
                btnLoadAdjacency_Click(sender, e);
            

            finder.FindBaseCircle();
        }
        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            if (finder == null || finder.Particles== null) return;
            finder.Draw(e.Graphics, groupBox1.Width, 0, ClientSize.Width - groupBox1.Width, ClientSize.Height, Font);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
            tbTime.Text = finder.timecost.TotalMilliseconds.ToString();
            tbCount.Text = finder.Circles.Count.ToString();
        }

        private void btnSaveCircleBase_Click(object sender, EventArgs e)
        {
            string filename = "circles.csv";
            finder.SaveCircles(filename);
            Process process = new Process();

            process.StartInfo.FileName = filename;
            process.Start();
        }

        private void cbShowID_CheckedChanged(object sender, EventArgs e)
        {
            finder.showID = cbShowID.Checked;
        }
    }
}
