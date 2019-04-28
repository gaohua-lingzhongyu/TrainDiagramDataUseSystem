namespace 毕业设计
{
    partial class Form_trainTimeTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_trainTimeData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_paint = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_trainTimeData)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_trainTimeData
            // 
            this.dataGridView_trainTimeData.AllowUserToAddRows = false;
            this.dataGridView_trainTimeData.AllowUserToDeleteRows = false;
            this.dataGridView_trainTimeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_trainTimeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_trainTimeData.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_trainTimeData.Name = "dataGridView_trainTimeData";
            this.dataGridView_trainTimeData.ReadOnly = true;
            this.dataGridView_trainTimeData.RowTemplate.Height = 27;
            this.dataGridView_trainTimeData.Size = new System.Drawing.Size(776, 367);
            this.dataGridView_trainTimeData.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView_trainTimeData);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 367);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_paint);
            this.panel2.Controls.Add(this.btn_export);
            this.panel2.Location = new System.Drawing.Point(12, 385);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 53);
            this.panel2.TabIndex = 2;
            // 
            // btn_paint
            // 
            this.btn_paint.Location = new System.Drawing.Point(624, 3);
            this.btn_paint.Name = "btn_paint";
            this.btn_paint.Size = new System.Drawing.Size(149, 47);
            this.btn_paint.TabIndex = 1;
            this.btn_paint.Text = "添加列车运行线";
            this.btn_paint.UseVisualStyleBackColor = true;
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(486, 3);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(122, 47);
            this.btn_export.TabIndex = 0;
            this.btn_export.Text = "导出时刻表";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // Form_trainTimeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_trainTimeTable";
            this.Text = "列车时刻表数据查看";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_trainTimeTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_trainTimeData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_trainTimeData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_paint;
        private System.Windows.Forms.Button btn_export;
    }
}