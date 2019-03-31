using GetSciEi;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace 毕业设计
{
    public partial class Form_trainTimeData : Form
    {
        private DataSet _dataSet;
        private DataTable _dataTable;
        string selectedTrainId;
        public Form_trainTimeData()
        {
            InitializeComponent();
            this.btn_export.Enabled = false;
        }

        private void Form_trainTimeData_Load(object sender, EventArgs e)
        {
        }

        private void btn_view_all_Click(object sender, EventArgs e)//查看所有数据按钮
        {
            //连接数据库
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-49O35N0;Initial Catalog=GraduateProject;Integrated Security=True");
                connection.Open();
                const string sqlStr = "SELECT DISTINCT TrainNo,运营状态,车次,出发站,终点站,途经沪宁O站,途经沪宁D站,出发时间,到达时间,历时 FROM dbo.TrainTicket ORDER BY 车次";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, connection);
                MessageBox.Show("数据库连接成功");
                _dataSet = new DataSet();
                adapter.Fill(_dataSet, "TrainId");
                datagridview_trainId.DataSource = _dataSet.Tables["TrainId"];
                _dataTable = _dataSet.Tables["TrainId"];
                this.btn_export.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "数据库连接有误，请重新连接");
                throw;
            }
        }

        private void btn_select_item_Click(object sender, EventArgs e)//查看所有的高铁动车
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-49O35N0;Initial Catalog=GraduateProject;Integrated Security=True");
                connection.Open();
                _dataSet = new DataSet();
                const string sqlStr = "SELECT DISTINCT TrainNo,运营状态,车次,出发站,终点站,途经沪宁O站,途经沪宁D站,出发时间,到达时间,历时 FROM dbo.TrainTicket WHERE SUBSTRING(车次, 1, 1) = 'G'OR SUBSTRING(车次,1,1) = 'D'";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, connection);
                MessageBox.Show("数据库连接成功");
                adapter.Fill(_dataSet, "TrainId");
                datagridview_trainId.DataSource = _dataSet.Tables["TrainId"];
                _dataTable = _dataSet.Tables["TrainId"];
                this.btn_export.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "数据库连接有误，请重新连接");
                throw;
            }
        }

        private void btn_OD_Click(object sender, EventArgs e)//OD站点选择
        {
            form_Select_OD frmSelectOd = new form_Select_OD { StartPosition = FormStartPosition.CenterScreen };
            frmSelectOd.ShowDialog();//筛选条件窗口
            string shangHaiStations = frmSelectOd.ShangHaiStations;
            string nanJingStations = frmSelectOd.NanJingStations;
            string trainKind = frmSelectOd.TrainKind;
            try
            {
                DataTable dt = _dataSet.Tables["TrainId"];
                foreach (DataRow dr in dt.Rows)
                {
                    if (!dr["车次"].ToString().Contains(trainKind))
                    {
                        dr.Delete();
                    }
                    else
                    {
                        if ((dr["出发站"].ToString() != shangHaiStations) && (dr["出发站"].ToString() != nanJingStations))
                        {
                            dr.Delete();
                        }
                        else if ((dr["终点站"].ToString() != shangHaiStations) && (dr["终点站"].ToString() != nanJingStations))
                        {
                            dr.Delete();
                        }
                    }
                }
                datagridview_trainId.DataSource = dt;
                this.btn_export.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "数据库连接有误，请重新连接");
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel 工作簿(*.xlsx)|*.xlsx",
                    RestoreDirectory = true,
                    InitialDirectory = Directory.GetCurrentDirectory(),
                    FileName = (DateTime.Now.ToString("yyyyMMddhhmmss") + "车次表.xlsx").Replace(" ", "") //初始文件名
                };
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                Excel.TableToExcel(_dataTable, saveFileDialog.FileName);
                MessageBox.Show($"文件保存成功，路径为{saveFileDialog.FileName}");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message+"操作有误，请重新筛选数据并导出");

            }
        }

        private void datagridview_trainId_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dr  in datagridview_trainId.Rows)
            {
                if (dr.Selected != true) continue;
                selectedTrainId = dr.Cells[2].Value.ToString();//被选中的车次
                MessageBox.Show($"您被选中的车次是{selectedTrainId}");
            }


            //将被选中车次的时刻表进行查询



        }
    }
}