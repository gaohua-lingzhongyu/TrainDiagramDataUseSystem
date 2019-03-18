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
            this.底图结构ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成底图结构ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成5分格底图结构ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成2分格底图结构ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelofPic = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelofPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.底图结构ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(902, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 底图结构ToolStripMenuItem
            // 
            this.底图结构ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成底图结构ToolStripMenuItem,
            this.生成5分格底图结构ToolStripMenuItem,
            this.生成2分格底图结构ToolStripMenuItem});
            this.底图结构ToolStripMenuItem.Name = "底图结构ToolStripMenuItem";
            this.底图结构ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.底图结构ToolStripMenuItem.Text = "底图结构";
            // 
            // 生成底图结构ToolStripMenuItem
            // 
            this.生成底图结构ToolStripMenuItem.Name = "生成底图结构ToolStripMenuItem";
            this.生成底图结构ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.生成底图结构ToolStripMenuItem.Text = "生成10分格底图结构";
            this.生成底图结构ToolStripMenuItem.Click += new System.EventHandler(this.生成底图结构ToolStripMenuItem_Click_1);
            // 
            // 生成5分格底图结构ToolStripMenuItem
            // 
            this.生成5分格底图结构ToolStripMenuItem.Name = "生成5分格底图结构ToolStripMenuItem";
            this.生成5分格底图结构ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.生成5分格底图结构ToolStripMenuItem.Text = "生成5分格底图结构";
            this.生成5分格底图结构ToolStripMenuItem.Click += new System.EventHandler(this.生成5分格底图结构ToolStripMenuItem_Click);
            // 
            // 生成2分格底图结构ToolStripMenuItem
            // 
            this.生成2分格底图结构ToolStripMenuItem.Name = "生成2分格底图结构ToolStripMenuItem";
            this.生成2分格底图结构ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.生成2分格底图结构ToolStripMenuItem.Text = "生成2分格底图结构";
            this.生成2分格底图结构ToolStripMenuItem.Click += new System.EventHandler(this.生成2分格底图结构ToolStripMenuItem_Click);
            // 
            // panelofPic
            // 
            this.panelofPic.AutoScroll = true;
            this.panelofPic.AutoScrollMargin = new System.Drawing.Size(100, 100);
            this.panelofPic.AutoScrollMinSize = new System.Drawing.Size(100, 100);
            this.panelofPic.Controls.Add(this.pictureBox1);
            this.panelofPic.Controls.Add(this.label1);
            this.panelofPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelofPic.Location = new System.Drawing.Point(0, 28);
            this.panelofPic.Name = "panelofPic";
            this.panelofPic.Size = new System.Drawing.Size(902, 600);
            this.panelofPic.TabIndex = 5;
            this.panelofPic.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelofPic_Scroll);
            this.panelofPic.Paint += new System.Windows.Forms.PaintEventHandler(this.panelofPic_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1019, 700);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(864, 585);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 628);
            this.Controls.Add(this.panelofPic);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelofPic.ResumeLayout(false);
            this.panelofPic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 底图结构ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成底图结构ToolStripMenuItem;
        private System.Windows.Forms.Panel panelofPic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 生成5分格底图结构ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成2分格底图结构ToolStripMenuItem;
    }
}

