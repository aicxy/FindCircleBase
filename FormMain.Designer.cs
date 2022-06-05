namespace CircleFinder
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveCircleBase = new System.Windows.Forms.Button();
            this.btnFindCircleBase = new System.Windows.Forms.Button();
            this.btnLoadAdjacency = new System.Windows.Forms.Button();
            this.btnLoadParticle = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCircleBaseCount = new System.Windows.Forms.Label();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.cbShowID = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.cbShowID);
            this.groupBox1.Controls.Add(this.tbTime);
            this.groupBox1.Controls.Add(this.tbCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelCircleBaseCount);
            this.groupBox1.Controls.Add(this.labelCount);
            this.groupBox1.Controls.Add(this.btnSaveCircleBase);
            this.groupBox1.Controls.Add(this.btnFindCircleBase);
            this.groupBox1.Controls.Add(this.btnLoadAdjacency);
            this.groupBox1.Controls.Add(this.btnLoadParticle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 770);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制面板(Control Panel)";
            // 
            // btnSaveCircleBase
            // 
            this.btnSaveCircleBase.Location = new System.Drawing.Point(12, 214);
            this.btnSaveCircleBase.Name = "btnSaveCircleBase";
            this.btnSaveCircleBase.Size = new System.Drawing.Size(175, 38);
            this.btnSaveCircleBase.TabIndex = 3;
            this.btnSaveCircleBase.Text = "Save CircleBases";
            this.btnSaveCircleBase.UseVisualStyleBackColor = true;
            this.btnSaveCircleBase.Click += new System.EventHandler(this.btnSaveCircleBase_Click);
            // 
            // btnFindCircleBase
            // 
            this.btnFindCircleBase.Location = new System.Drawing.Point(13, 170);
            this.btnFindCircleBase.Name = "btnFindCircleBase";
            this.btnFindCircleBase.Size = new System.Drawing.Size(175, 38);
            this.btnFindCircleBase.TabIndex = 2;
            this.btnFindCircleBase.Text = "Find CircleBases";
            this.btnFindCircleBase.UseVisualStyleBackColor = true;
            this.btnFindCircleBase.Click += new System.EventHandler(this.btnFindCircleBase_Click);
            // 
            // btnLoadAdjacency
            // 
            this.btnLoadAdjacency.Location = new System.Drawing.Point(12, 126);
            this.btnLoadAdjacency.Name = "btnLoadAdjacency";
            this.btnLoadAdjacency.Size = new System.Drawing.Size(175, 38);
            this.btnLoadAdjacency.TabIndex = 1;
            this.btnLoadAdjacency.Text = "Load Adjacency ";
            this.btnLoadAdjacency.UseVisualStyleBackColor = true;
            this.btnLoadAdjacency.Click += new System.EventHandler(this.btnLoadAdjacency_Click);
            // 
            // btnLoadParticle
            // 
            this.btnLoadParticle.Location = new System.Drawing.Point(13, 81);
            this.btnLoadParticle.Name = "btnLoadParticle";
            this.btnLoadParticle.Size = new System.Drawing.Size(175, 38);
            this.btnLoadParticle.TabIndex = 0;
            this.btnLoadParticle.Text = "Load Paticles";
            this.btnLoadParticle.UseVisualStyleBackColor = true;
            this.btnLoadParticle.Click += new System.EventHandler(this.btnLoadParticle_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(14, 272);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(42, 16);
            this.labelCount.TabIndex = 4;
            this.labelCount.Text = "Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Time(ms)";
            // 
            // labelCircleBaseCount
            // 
            this.labelCircleBaseCount.AutoSize = true;
            this.labelCircleBaseCount.Location = new System.Drawing.Point(12, 257);
            this.labelCircleBaseCount.Name = "labelCircleBaseCount";
            this.labelCircleBaseCount.Size = new System.Drawing.Size(0, 16);
            this.labelCircleBaseCount.TabIndex = 4;
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(16, 292);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(100, 22);
            this.tbCount.TabIndex = 5;
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(17, 350);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(100, 22);
            this.tbTime.TabIndex = 5;
            // 
            // cbShowID
            // 
            this.cbShowID.AutoSize = true;
            this.cbShowID.Location = new System.Drawing.Point(17, 40);
            this.cbShowID.Name = "cbShowID";
            this.cbShowID.Size = new System.Drawing.Size(119, 20);
            this.cbShowID.TabIndex = 6;
            this.cbShowID.Text = "show particle id";
            this.cbShowID.UseVisualStyleBackColor = true;
            this.cbShowID.CheckedChanged += new System.EventHandler(this.cbShowID_CheckedChanged);
            // 
            // FormMain
            // 
            this.AcceptButton = this.btnLoadParticle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(917, 770);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CircleBase Finder by GZU";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFindCircleBase;
        private System.Windows.Forms.Button btnLoadParticle;
        private System.Windows.Forms.Button btnSaveCircleBase;
        private System.Windows.Forms.Button btnLoadAdjacency;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCircleBaseCount;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.CheckBox cbShowID;
    }
}

