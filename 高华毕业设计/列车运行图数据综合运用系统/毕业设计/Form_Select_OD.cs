using System;
using System.Windows.Forms;

namespace 毕业设计
{
    public partial class form_Select_OD : Form
    {
        public string ShangHaiStations;
        public string NanJingStations;
        public string TrainKind;

        public form_Select_OD()
        {
            InitializeComponent();
        }

        private void frm_Select_OD_Load(object sender, EventArgs e)
        {
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            foreach (RadioButton radioButton in groupBox_ShangHai.Controls)
            {
                if (radioButton.Checked == true)
                {
                    ShangHaiStations = radioButton.Text;
                }
            }

            foreach (RadioButton radioButton in groupBoxNanJing.Controls)
            {
                if (radioButton.Checked == true)
                {
                    NanJingStations = radioButton.Text;
                }
            }

            foreach (RadioButton radioButton in groupBox_TrainKinds.Controls)
            {
                if (radioButton.Checked == true)
                {
                    TrainKind = radioButton.Text;
                }
            }

            if ((TrainKind == null) || (ShangHaiStations == null) || (NanJingStations == null))
            {
                MessageBox.Show("筛选条件选择不全");
            }
            else
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}