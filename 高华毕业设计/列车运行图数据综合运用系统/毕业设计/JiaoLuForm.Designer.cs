namespace 毕业设计
{
    partial class JiaoLuForm
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
            this.dataGridView_jiaoLuData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_jiaoLu_KeShiHua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_jiaoLuData)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_jiaoLuData
            // 
            this.dataGridView_jiaoLuData.AllowUserToAddRows = false;
            this.dataGridView_jiaoLuData.AllowUserToDeleteRows = false;
            this.dataGridView_jiaoLuData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_jiaoLuData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_jiaoLuData.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_jiaoLuData.Name = "dataGridView_jiaoLuData";
            this.dataGridView_jiaoLuData.ReadOnly = true;
            this.dataGridView_jiaoLuData.RowTemplate.Height = 27;
            this.dataGridView_jiaoLuData.Size = new System.Drawing.Size(776, 342);
            this.dataGridView_jiaoLuData.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView_jiaoLuData);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 342);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_jiaoLu_KeShiHua);
            this.panel2.Location = new System.Drawing.Point(12, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 78);
            this.panel2.TabIndex = 2;
            // 
            // button_jiaoLu_KeShiHua
            // 
            this.button_jiaoLu_KeShiHua.Location = new System.Drawing.Point(626, 16);
            this.button_jiaoLu_KeShiHua.Name = "button_jiaoLu_KeShiHua";
            this.button_jiaoLu_KeShiHua.Size = new System.Drawing.Size(125, 50);
            this.button_jiaoLu_KeShiHua.TabIndex = 0;
            this.button_jiaoLu_KeShiHua.Text = "交路可视化";
            this.button_jiaoLu_KeShiHua.UseVisualStyleBackColor = true;
            this.button_jiaoLu_KeShiHua.Click += new System.EventHandler(this.button_jiaoLu_KeShiHua_Click);
            // 
            // JiaoLuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "JiaoLuForm";
            this.Text = "交路计算结果";
            this.Load += new System.EventHandler(this.JiaoLuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_jiaoLuData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_jiaoLuData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_jiaoLu_KeShiHua;
    }
}