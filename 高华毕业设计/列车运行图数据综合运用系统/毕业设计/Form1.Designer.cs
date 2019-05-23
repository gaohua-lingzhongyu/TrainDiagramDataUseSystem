namespace 毕业设计
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.绘制列车运行线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.沪宁线高铁车次绘制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.所有列车时刻信息导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出为excel文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.交路勾画ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动勾画交路ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelofPic = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_stations = new System.Windows.Forms.Panel();
            this.pictureBox_stations = new System.Windows.Forms.PictureBox();
            this.动车所能力限制交路勾画ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成底图结构ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成2分格底图结构ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.底图结构ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panelofPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_stations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_stations)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.底图结构ToolStripMenuItem,
            this.绘制列车运行线ToolStripMenuItem,
            this.所有列车时刻信息导出ToolStripMenuItem,
            this.交路勾画ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(985, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 绘制列车运行线ToolStripMenuItem
            // 
            this.绘制列车运行线ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.沪宁线高铁车次绘制ToolStripMenuItem});
            this.绘制列车运行线ToolStripMenuItem.Name = "绘制列车运行线ToolStripMenuItem";
            this.绘制列车运行线ToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.绘制列车运行线ToolStripMenuItem.Text = "绘制列车运行线";
            // 
            // 沪宁线高铁车次绘制ToolStripMenuItem
            // 
            this.沪宁线高铁车次绘制ToolStripMenuItem.Name = "沪宁线高铁车次绘制ToolStripMenuItem";
            this.沪宁线高铁车次绘制ToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.沪宁线高铁车次绘制ToolStripMenuItem.Text = "沪宁线高铁车次绘制";
            this.沪宁线高铁车次绘制ToolStripMenuItem.Click += new System.EventHandler(this.沪宁线高铁车次绘制ToolStripMenuItem_Click);
            // 
            // 所有列车时刻信息导出ToolStripMenuItem
            // 
            this.所有列车时刻信息导出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出为excel文件ToolStripMenuItem});
            this.所有列车时刻信息导出ToolStripMenuItem.Name = "所有列车时刻信息导出ToolStripMenuItem";
            this.所有列车时刻信息导出ToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.所有列车时刻信息导出ToolStripMenuItem.Text = "所有列车时刻信息导出";
            // 
            // 导出为excel文件ToolStripMenuItem
            // 
            this.导出为excel文件ToolStripMenuItem.Name = "导出为excel文件ToolStripMenuItem";
            this.导出为excel文件ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.导出为excel文件ToolStripMenuItem.Text = "导出为excel文件";
            this.导出为excel文件ToolStripMenuItem.Click += new System.EventHandler(this.导出为excel文件ToolStripMenuItem_Click);
            // 
            // 交路勾画ToolStripMenuItem
            // 
            this.交路勾画ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自动勾画交路ToolStripMenuItem,
            this.动车所能力限制交路勾画ToolStripMenuItem});
            this.交路勾画ToolStripMenuItem.Name = "交路勾画ToolStripMenuItem";
            this.交路勾画ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.交路勾画ToolStripMenuItem.Text = "交路勾画";
            // 
            // 自动勾画交路ToolStripMenuItem
            // 
            this.自动勾画交路ToolStripMenuItem.Name = "自动勾画交路ToolStripMenuItem";
            this.自动勾画交路ToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.自动勾画交路ToolStripMenuItem.Text = "接续最紧凑自动勾画交路";
            this.自动勾画交路ToolStripMenuItem.Click += new System.EventHandler(this.自动勾画交路ToolStripMenuItem_Click);
            // 
            // panelofPic
            // 
            this.panelofPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelofPic.AutoScroll = true;
            this.panelofPic.Controls.Add(this.pictureBox1);
            this.panelofPic.Location = new System.Drawing.Point(127, 36);
            this.panelofPic.Name = "panelofPic";
            this.panelofPic.Size = new System.Drawing.Size(858, 634);
            this.panelofPic.TabIndex = 0;
            this.panelofPic.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelofPic_Scroll);
            this.panelofPic.Paint += new System.Windows.Forms.PaintEventHandler(this.panelofPic_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(902, 600);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // panel_stations
            // 
            this.panel_stations.Controls.Add(this.pictureBox_stations);
            this.panel_stations.Location = new System.Drawing.Point(0, 36);
            this.panel_stations.Name = "panel_stations";
            this.panel_stations.Size = new System.Drawing.Size(121, 634);
            this.panel_stations.TabIndex = 5;
            // 
            // pictureBox_stations
            // 
            this.pictureBox_stations.BackColor = System.Drawing.Color.White;
            this.pictureBox_stations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_stations.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_stations.Name = "pictureBox_stations";
            this.pictureBox_stations.Size = new System.Drawing.Size(121, 634);
            this.pictureBox_stations.TabIndex = 0;
            this.pictureBox_stations.TabStop = false;
            // 
            // 动车所能力限制交路勾画ToolStripMenuItem
            // 
            this.动车所能力限制交路勾画ToolStripMenuItem.Name = "动车所能力限制交路勾画ToolStripMenuItem";
            this.动车所能力限制交路勾画ToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.动车所能力限制交路勾画ToolStripMenuItem.Text = "能力限制下的交路自动勾画";
            this.动车所能力限制交路勾画ToolStripMenuItem.Click += new System.EventHandler(this.动车所能力限制交路勾画ToolStripMenuItem_Click);
            // 
            // 生成底图结构ToolStripMenuItem
            // 
            this.生成底图结构ToolStripMenuItem.Name = "生成底图结构ToolStripMenuItem";
            this.生成底图结构ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.生成底图结构ToolStripMenuItem.Text = "生成10分格底图结构";
            this.生成底图结构ToolStripMenuItem.Click += new System.EventHandler(this.生成底图结构ToolStripMenuItem_Click_1);
            // 
            // 生成2分格底图结构ToolStripMenuItem
            // 
            this.生成2分格底图结构ToolStripMenuItem.Name = "生成2分格底图结构ToolStripMenuItem";
            this.生成2分格底图结构ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.生成2分格底图结构ToolStripMenuItem.Text = "生成2分格底图结构";
            this.生成2分格底图结构ToolStripMenuItem.Click += new System.EventHandler(this.生成2分格底图结构ToolStripMenuItem_Click);
            // 
            // 底图结构ToolStripMenuItem
            // 
            this.底图结构ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成底图结构ToolStripMenuItem,
            this.生成2分格底图结构ToolStripMenuItem});
            this.底图结构ToolStripMenuItem.Name = "底图结构ToolStripMenuItem";
            this.底图结构ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.底图结构ToolStripMenuItem.Text = "底图结构";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 682);
            this.Controls.Add(this.panel_stations);
            this.Controls.Add(this.panelofPic);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "列车交路勾画";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelofPic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_stations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_stations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panelofPic;
        private System.Windows.Forms.ToolStripMenuItem 绘制列车运行线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 沪宁线高铁车次绘制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 所有列车时刻信息导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出为excel文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 交路勾画ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动勾画交路ToolStripMenuItem;
        private System.Windows.Forms.Panel panel_stations;
        private System.Windows.Forms.PictureBox pictureBox_stations;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 动车所能力限制交路勾画ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 底图结构ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成底图结构ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成2分格底图结构ToolStripMenuItem;
    }
}

