using GetSciEi;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace 毕业设计
{
    public partial class Form_trainTimeTable : Form
    {
        public string TrainId;

        public Form_trainTimeTable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 接收父窗体的参数，并刷新本窗体中的datagridView
        /// </summary>
        public void Refresh_DataGridView()
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-49O35N0;Initial Catalog=GraduateProject;Integrated Security=True");
                connection.Open();
                DataSet dataSet = new DataSet();
                string sqlStr = $"SELECT * FROM TrainTimeTable WHERE 车次 ='{TrainId}' ";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, connection);
                MessageBox.Show("数据库连接成功");
                adapter.Fill(dataSet, "TrainId_TimeTable");
                this.dataGridView_trainTimeData.DataSource = dataSet.Tables["TrainId_TimeTable"];
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "数据库连接有误，请重新连接");
                throw;
            }
        }

        //导出excel
        private void btn_export_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel 工作簿(*.xlsx)|*.xlsx",
                    RestoreDirectory = true,
                    InitialDirectory = Directory.GetCurrentDirectory(),
                    FileName = (DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + TrainId + "车次时刻表.xlsx").Replace(" ", "") //初始文件名
                };
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                DataTable exportDataTable = Form_trainTimeData.GetDgvToTable(this.dataGridView_trainTimeData);
                Excel.TableToExcel(exportDataTable, saveFileDialog.FileName);
                MessageBox.Show($"文件保存成功，路径为{saveFileDialog.FileName}");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "操作有误，请重新筛选数据并导出");
            }
        }

        private void Form_trainTimeTable_Load(object sender, EventArgs e)
        {
        }
    }
}