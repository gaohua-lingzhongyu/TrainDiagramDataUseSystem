namespace 毕业设计
{
    partial class form_Select_OD
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
            this.groupBox_ShangHai = new System.Windows.Forms.GroupBox();
            this.radioButton_SNH = new System.Windows.Forms.RadioButton();
            this.radioButton_AOH = new System.Windows.Forms.RadioButton();
            this.radioButton_SHH = new System.Windows.Forms.RadioButton();
            this.groupBoxNanJing = new System.Windows.Forms.GroupBox();
            this.radioButton_NKH = new System.Windows.Forms.RadioButton();
            this.radioButton_NJH = new System.Windows.Forms.RadioButton();
            this.btn_OK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox_TrainKinds = new System.Windows.Forms.GroupBox();
            this.radioButton_All = new System.Windows.Forms.RadioButton();
            this.radioButton_trainD = new System.Windows.Forms.RadioButton();
            this.radioButton_trainG = new System.Windows.Forms.RadioButton();
            this.groupBox_ShangHai.SuspendLayout();
            this.groupBoxNanJing.SuspendLayout();
            this.groupBox_TrainKinds.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_ShangHai
            // 
            this.groupBox_ShangHai.Controls.Add(this.radioButton_SNH);
            this.groupBox_ShangHai.Controls.Add(this.radioButton_AOH);
            this.groupBox_ShangHai.Controls.Add(this.radioButton_SHH);
            this.groupBox_ShangHai.Location = new System.Drawing.Point(235, 54);
            this.groupBox_ShangHai.Name = "groupBox_ShangHai";
            this.groupBox_ShangHai.Size = new System.Drawing.Size(155, 127);
            this.groupBox_ShangHai.TabIndex = 0;
            this.groupBox_ShangHai.TabStop = false;
            this.groupBox_ShangHai.Text = "上海车站";
            // 
            // radioButton_SNH
            // 
            this.radioButton_SNH.AutoSize = true;
            this.radioButton_SNH.Location = new System.Drawing.Point(6, 74);
            this.radioButton_SNH.Name = "radioButton_SNH";
            this.radioButton_SNH.Size = new System.Drawing.Size(52, 19);
            this.radioButton_SNH.TabIndex = 2;
            this.radioButton_SNH.TabStop = true;
            this.radioButton_SNH.Text = "SNH";
            this.radioButton_SNH.UseVisualStyleBackColor = true;
            // 
            // radioButton_AOH
            // 
            this.radioButton_AOH.AutoSize = true;
            this.radioButton_AOH.Location = new System.Drawing.Point(6, 49);
            this.radioButton_AOH.Name = "radioButton_AOH";
            this.radioButton_AOH.Size = new System.Drawing.Size(52, 19);
            this.radioButton_AOH.TabIndex = 1;
            this.radioButton_AOH.TabStop = true;
            this.radioButton_AOH.Text = "AOH";
            this.radioButton_AOH.UseVisualStyleBackColor = true;
            // 
            // radioButton_SHH
            // 
            this.radioButton_SHH.AutoSize = true;
            this.radioButton_SHH.Location = new System.Drawing.Point(6, 24);
            this.radioButton_SHH.Name = "radioButton_SHH";
            this.radioButton_SHH.Size = new System.Drawing.Size(52, 19);
            this.radioButton_SHH.TabIndex = 0;
            this.radioButton_SHH.TabStop = true;
            this.radioButton_SHH.Text = "SHH";
            this.radioButton_SHH.UseVisualStyleBackColor = true;
            // 
            // groupBoxNanJing
            // 
            this.groupBoxNanJing.Controls.Add(this.radioButton_NKH);
            this.groupBoxNanJing.Controls.Add(this.radioButton_NJH);
            this.groupBoxNanJing.Location = new System.Drawing.Point(396, 54);
            this.groupBoxNanJing.Name = "groupBoxNanJing";
            this.groupBoxNanJing.Size = new System.Drawing.Size(162, 127);
            this.groupBoxNanJing.TabIndex = 1;
            this.groupBoxNanJing.TabStop = false;
            this.groupBoxNanJing.Text = "南京车站";
            // 
            // radioButton_NKH
            // 
            this.radioButton_NKH.AutoSize = true;
            this.radioButton_NKH.Location = new System.Drawing.Point(0, 74);
            this.radioButton_NKH.Name = "radioButton_NKH";
            this.radioButton_NKH.Size = new System.Drawing.Size(52, 19);
            this.radioButton_NKH.TabIndex = 2;
            this.radioButton_NKH.TabStop = true;
            this.radioButton_NKH.Text = "NKH";
            this.radioButton_NKH.UseVisualStyleBackColor = true;
            // 
            // radioButton_NJH
            // 
            this.radioButton_NJH.AutoSize = true;
            this.radioButton_NJH.Location = new System.Drawing.Point(0, 24);
            this.radioButton_NJH.Name = "radioButton_NJH";
            this.radioButton_NJH.Size = new System.Drawing.Size(52, 19);
            this.radioButton_NJH.TabIndex = 1;
            this.radioButton_NJH.TabStop = true;
            this.radioButton_NJH.Text = "NJH";
            this.radioButton_NJH.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(207, 212);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(106, 43);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "确认";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(331, 212);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 43);
            this.button2.TabIndex = 3;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox_TrainKinds
            // 
            this.groupBox_TrainKinds.Controls.Add(this.radioButton_All);
            this.groupBox_TrainKinds.Controls.Add(this.radioButton_trainD);
            this.groupBox_TrainKinds.Controls.Add(this.radioButton_trainG);
            this.groupBox_TrainKinds.Location = new System.Drawing.Point(74, 54);
            this.groupBox_TrainKinds.Name = "groupBox_TrainKinds";
            this.groupBox_TrainKinds.Size = new System.Drawing.Size(155, 127);
            this.groupBox_TrainKinds.TabIndex = 4;
            this.groupBox_TrainKinds.TabStop = false;
            this.groupBox_TrainKinds.Text = "列车类型";
            // 
            // radioButton_All
            // 
            this.radioButton_All.AutoSize = true;
            this.radioButton_All.Location = new System.Drawing.Point(6, 74);
            this.radioButton_All.Name = "radioButton_All";
            this.radioButton_All.Size = new System.Drawing.Size(58, 19);
            this.radioButton_All.TabIndex = 2;
            this.radioButton_All.TabStop = true;
            this.radioButton_All.Text = "默认";
            this.radioButton_All.UseVisualStyleBackColor = true;
            // 
            // radioButton_trainD
            // 
            this.radioButton_trainD.AutoSize = true;
            this.radioButton_trainD.Location = new System.Drawing.Point(6, 49);
            this.radioButton_trainD.Name = "radioButton_trainD";
            this.radioButton_trainD.Size = new System.Drawing.Size(36, 19);
            this.radioButton_trainD.TabIndex = 1;
            this.radioButton_trainD.TabStop = true;
            this.radioButton_trainD.Text = "D";
            this.radioButton_trainD.UseVisualStyleBackColor = true;
            // 
            // radioButton_trainG
            // 
            this.radioButton_trainG.AutoSize = true;
            this.radioButton_trainG.Location = new System.Drawing.Point(6, 24);
            this.radioButton_trainG.Name = "radioButton_trainG";
            this.radioButton_trainG.Size = new System.Drawing.Size(36, 19);
            this.radioButton_trainG.TabIndex = 0;
            this.radioButton_trainG.TabStop = true;
            this.radioButton_trainG.Text = "G";
            this.radioButton_trainG.UseVisualStyleBackColor = true;
            // 
            // form_Select_OD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 289);
            this.Controls.Add(this.groupBox_TrainKinds);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.groupBoxNanJing);
            this.Controls.Add(this.groupBox_ShangHai);
            this.Name = "form_Select_OD";
            this.Text = "筛选条件";
            this.Load += new System.EventHandler(this.frm_Select_OD_Load);
            this.groupBox_ShangHai.ResumeLayout(false);
            this.groupBox_ShangHai.PerformLayout();
            this.groupBoxNanJing.ResumeLayout(false);
            this.groupBoxNanJing.PerformLayout();
            this.groupBox_TrainKinds.ResumeLayout(false);
            this.groupBox_TrainKinds.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_ShangHai;
        private System.Windows.Forms.RadioButton radioButton_SNH;
        private System.Windows.Forms.RadioButton radioButton_AOH;
        private System.Windows.Forms.RadioButton radioButton_SHH;
        private System.Windows.Forms.GroupBox groupBoxNanJing;
        private System.Windows.Forms.RadioButton radioButton_NKH;
        private System.Windows.Forms.RadioButton radioButton_NJH;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox_TrainKinds;
        private System.Windows.Forms.RadioButton radioButton_All;
        private System.Windows.Forms.RadioButton radioButton_trainD;
        private System.Windows.Forms.RadioButton radioButton_trainG;
    }
}