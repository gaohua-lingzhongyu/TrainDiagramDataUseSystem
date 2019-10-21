namespace 毕业设计
{
    partial class Form_trainTimeData
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.datagridview_trainId = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_view_all = new System.Windows.Forms.Button();
            this.btn_select_item = new System.Windows.Forms.Button();
            this.btn_OD = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_trainId)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 732F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.datagridview_trainId, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(165, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(706, 471);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // datagridview_trainId
            // 
            this.datagridview_trainId.AllowUserToAddRows = false;
            this.datagridview_trainId.AllowUserToDeleteRows = false;
            this.datagridview_trainId.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_trainId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridview_trainId.Location = new System.Drawing.Point(3, 3);
            this.datagridview_trainId.Name = "datagridview_trainId";
            this.datagridview_trainId.ReadOnly = true;
            this.datagridview_trainId.RowTemplate.Height = 27;
            this.datagridview_trainId.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridview_trainId.Size = new System.Drawing.Size(726, 445);
            this.datagridview_trainId.TabIndex = 0;
            this.datagridview_trainId.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_trainId_CellClick);
            this.datagridview_trainId.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_trainId_CellContentClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btn_view_all, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_select_item, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_OD, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.44231F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.78846F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(156, 280);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btn_view_all
            // 
            this.btn_view_all.Location = new System.Drawing.Point(3, 3);
            this.btn_view_all.Name = "btn_view_all";
            this.btn_view_all.Size = new System.Drawing.Size(144, 45);
            this.btn_view_all.TabIndex = 1;
            this.btn_view_all.Text = "查看所有车次信息";
            this.btn_view_all.UseVisualStyleBackColor = true;
            this.btn_view_all.Click += new System.EventHandler(this.btn_view_all_Click);
            // 
            // btn_select_item
            // 
            this.btn_select_item.Location = new System.Drawing.Point(3, 54);
            this.btn_select_item.Name = "btn_select_item";
            this.btn_select_item.Size = new System.Drawing.Size(144, 47);
            this.btn_select_item.TabIndex = 2;
            this.btn_select_item.Text = "只看G和D";
            this.btn_select_item.UseVisualStyleBackColor = true;
            this.btn_select_item.Click += new System.EventHandler(this.btn_select_item_Click);
            // 
            // btn_OD
            // 
            this.btn_OD.Location = new System.Drawing.Point(3, 111);
            this.btn_OD.Name = "btn_OD";
            this.btn_OD.Size = new System.Drawing.Size(144, 56);
            this.btn_OD.TabIndex = 3;
            this.btn_OD.Text = "筛选条件";
            this.btn_OD.UseVisualStyleBackColor = true;
            this.btn_OD.Click += new System.EventHandler(this.btn_OD_Click);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(6, 407);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(144, 53);
            this.btn_export.TabIndex = 4;
            this.btn_export.Text = "右表数据导出";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // Form_trainTimeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 485);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form_trainTimeData";
            this.Text = "列车车次查看";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_trainTimeData_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_trainId)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView datagridview_trainId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_select_item;
        private System.Windows.Forms.Button btn_OD;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_view_all;
    }
}