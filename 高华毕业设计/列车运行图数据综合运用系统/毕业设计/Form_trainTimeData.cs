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
        private string _selectedTrainId;

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
                _dataTable = _dataSet.Tables["TrainId"];
                foreach (DataRow dr in _dataTable.Rows)
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
                datagridview_trainId.DataSource = _dataTable;
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
                DataTable exportDataTable = GetDgvToTable(this.datagridview_trainId);
                Excel.TableToExcel(exportDataTable, saveFileDialog.FileName);
                MessageBox.Show($"文件保存成功，路径为{saveFileDialog.FileName}");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "操作有误，请重新筛选数据并导出");
            }
        }

        private void datagridview_trainId_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dr in datagridview_trainId.Rows)
            {
                if (dr.Selected != true) continue;
                _selectedTrainId = dr.Cells[2].Value.ToString();//被选中的车次
                MessageBox.Show($"您被选中的车次是{_selectedTrainId}");
            }

            //判断是否已经打开了列车时刻表的form
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name != "Form_trainTimeTable") continue;
                frm.Text = $"{_selectedTrainId}车次的列车时刻表";
                var formTrainTimeTable = (Form_trainTimeTable)frm;
                formTrainTimeTable.TrainId = _selectedTrainId;
                formTrainTimeTable.Refresh_DataGridView();
            }
        }

        /// <summary>
        /// 读取datagridview数据到datatable
        /// </summary>
        /// <param name="dgv">datagridview</param>
        /// <returns>datatable</returns>
        public static DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void datagridview_trainId_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}