namespace 毕业设计
{
    partial class NewProject
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
            this.NameOfProjectLabel = new System.Windows.Forms.Label();
            this.LocationOfProjectLabel = new System.Windows.Forms.Label();
            this.ProjectNametextBox = new System.Windows.Forms.TextBox();
            this.LocationOfProjectTextBox = new System.Windows.Forms.TextBox();
            this.BrowserButton = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameOfProjectLabel
            // 
            this.NameOfProjectLabel.AutoSize = true;
            this.NameOfProjectLabel.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NameOfProjectLabel.Location = new System.Drawing.Point(31, 60);
            this.NameOfProjectLabel.Name = "NameOfProjectLabel";
            this.NameOfProjectLabel.Size = new System.Drawing.Size(110, 31);
            this.NameOfProjectLabel.TabIndex = 0;
            this.NameOfProjectLabel.Text = "项目名称";
            // 
            // LocationOfProjectLabel
            // 
            this.LocationOfProjectLabel.AutoSize = true;
            this.LocationOfProjectLabel.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LocationOfProjectLabel.Location = new System.Drawing.Point(31, 112);
            this.LocationOfProjectLabel.Name = "LocationOfProjectLabel";
            this.LocationOfProjectLabel.Size = new System.Drawing.Size(110, 31);
            this.LocationOfProjectLabel.TabIndex = 1;
            this.LocationOfProjectLabel.Text = "项目位置";
            // 
            // ProjectNametextBox
            // 
            this.ProjectNametextBox.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProjectNametextBox.Location = new System.Drawing.Point(163, 57);
            this.ProjectNametextBox.Name = "ProjectNametextBox";
            this.ProjectNametextBox.Size = new System.Drawing.Size(315, 38);
            this.ProjectNametextBox.TabIndex = 2;
            // 
            // LocationOfProjectTextBox
            // 
            this.LocationOfProjectTextBox.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LocationOfProjectTextBox.Location = new System.Drawing.Point(163, 112);
            this.LocationOfProjectTextBox.Name = "LocationOfProjectTextBox";
            this.LocationOfProjectTextBox.Size = new System.Drawing.Size(450, 38);
            this.LocationOfProjectTextBox.TabIndex = 3;
            // 
            // BrowserButton
            // 
            this.BrowserButton.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BrowserButton.Location = new System.Drawing.Point(641, 104);
            this.BrowserButton.Name = "BrowserButton";
            this.BrowserButton.Size = new System.Drawing.Size(112, 52);
            this.BrowserButton.TabIndex = 4;
            this.BrowserButton.Text = "浏览";
            this.BrowserButton.UseVisualStyleBackColor = true;
            this.BrowserButton.Click += new System.EventHandler(this.BrowserButton_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OKBtn.Location = new System.Drawing.Point(501, 196);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(112, 52);
            this.OKBtn.TabIndex = 5;
            this.OKBtn.Text = "确定";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CancelBtn.Location = new System.Drawing.Point(641, 196);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(112, 52);
            this.CancelBtn.TabIndex = 6;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // NewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 280);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.BrowserButton);
            this.Controls.Add(this.LocationOfProjectTextBox);
            this.Controls.Add(this.ProjectNametextBox);
            this.Controls.Add(this.LocationOfProjectLabel);
            this.Controls.Add(this.NameOfProjectLabel);
            this.Name = "NewProject";
            this.Text = "新建项目";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameOfProjectLabel;
        private System.Windows.Forms.Label LocationOfProjectLabel;
        private System.Windows.Forms.TextBox ProjectNametextBox;
        private System.Windows.Forms.TextBox LocationOfProjectTextBox;
        private System.Windows.Forms.Button BrowserButton;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}