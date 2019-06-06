using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace 毕业设计
{
    public partial class JiaoLuForm : Form
    {
        private static Form1 paintForm1;
        public Bitmap trainDiagraph { set; get; }
        public List<Trains> allTrains { set; get; }
        public string dataFilePath { set; get; }

        public JiaoLuForm(Form1 form1)
        {
            InitializeComponent();
            paintForm1 = form1;
        }

        public DataTable datagridviewSourceTable;

        private void JiaoLuForm_Load(object sender, EventArgs e)
        {
            this.dataGridView_jiaoLuData.DataSource =
                GetSciEi.Excel.ExcelToTable(dataFilePath); //将交路勾画的方案进行可视化
        }

        private int train_nums;//记录的是车底数量

        private void button_jiaoLu_KeShiHua_Click(object sender, EventArgs e)
        {
            //trainDiagraph = paintForm1.trainsDiagram;
            paintForm1.沪宁线高铁车次绘制ToolStripMenuItem_Click(sender, e);
            DataTable dt = Form_trainTimeData.GetDgvToTable(this.dataGridView_jiaoLuData);
            train_nums = dt.Columns.Count;
            Graphics g = Graphics.FromImage(trainDiagraph);//在原图上操作
            Pen pen = new Pen(Color.Purple, 1f);
            //train_nums = 10;//画几个车底
            List<bool> is_first_train_up = null;//记录第一趟车是上还是下的数组
            //画全部车底
            for (int i = 1; i <= train_nums; i++)
            {
                List<PointF> jiaoLu_Pos = new List<PointF>();//交路的点列表
                foreach (DataRow dr in dt.Rows)//这个循环里面是同一个车底
                {
                    int index = 0;//记录是第几个找到的车号
                    //找到一个车底的所有交路坐标
                    foreach (Trains train in allTrains)
                    {
                        //找到所有的交路的坐标
                        if (train.trainId == dr[$"车底{i}"].ToString())
                        {
                            if ((int.Parse(train.trainId.Replace("G", "")) % 2 == 0)||(int.Parse(train.trainId.Replace("G", ""))==7001))
                            {
                                jiaoLu_Pos.Add(train.startPo);//添加起点坐标
                                jiaoLu_Pos.Add(train.endPo);//添加终点坐标
                            }
                            else
                            {
                                jiaoLu_Pos.Add(train.endPo);//添加终点坐标
                                jiaoLu_Pos.Add(train.startPo);//添加起点坐标
                            }
                        }
                    }
                }
                List<int> heights = new List<int>();
                for (int j = 1; j <= train_nums; j++)
                {
                    heights.Add(8);
                    heights.Add(10);
                    heights.Add(12);
                }
                int height = heights[i];
                jiaoLu_Pos.RemoveAt(0);//删除第一个坐标（起点坐标）
                int mark = 1;//记录第几个点
                for (int j = 1; j < jiaoLu_Pos.Count; j+=2)
                {
                    //需要判断第一个车号是上还是下的情况
                    if (int.Parse(dt.Rows[0][$"车底{i}"].ToString().Replace("G", "")) % 2 == 0)
                    {
                        if (mark % 2 != 0)
                        {
                            g.DrawLine(pen, jiaoLu_Pos[j - 1].X, jiaoLu_Pos[j - 1].Y, jiaoLu_Pos[j - 1].X, jiaoLu_Pos[j - 1].Y - height);
                            g.DrawLine(pen, jiaoLu_Pos[j - 1].X, jiaoLu_Pos[j - 1].Y - height, jiaoLu_Pos[j].X, jiaoLu_Pos[j].Y - height);
                            g.DrawLine(pen, jiaoLu_Pos[j].X, jiaoLu_Pos[j].Y - height, jiaoLu_Pos[j].X, jiaoLu_Pos[j].Y);
                        }
                        else
                        {
                            g.DrawLine(pen, jiaoLu_Pos[j - 1].X, jiaoLu_Pos[j - 1].Y, jiaoLu_Pos[j - 1].X, jiaoLu_Pos[j - 1].Y + height);
                            g.DrawLine(pen, jiaoLu_Pos[j].X, jiaoLu_Pos[j].Y + height, jiaoLu_Pos[j].X, jiaoLu_Pos[j].Y);
                            g.DrawLine(pen, jiaoLu_Pos[j - 1].X, jiaoLu_Pos[j - 1].Y + height, jiaoLu_Pos[j].X, jiaoLu_Pos[j].Y + height);
                        }
                    }
                    else
                    {
                        if (mark % 2 != 0)
                        {
                            g.DrawLine(pen, jiaoLu_Pos[j - 1].X, jiaoLu_Pos[j - 1].Y, jiaoLu_Pos[j - 1].X, jiaoLu_Pos[j - 1].Y + height);
                            g.DrawLine(pen, jiaoLu_Pos[j].X, jiaoLu_Pos[j].Y + height, jiaoLu_Pos[j].X, jiaoLu_Pos[j].Y);
                            g.DrawLine(pen, jiaoLu_Pos[j - 1].X, jiaoLu_Pos[j - 1].Y + height, jiaoLu_Pos[j].X, jiaoLu_Pos[j].Y + height);
                        }
                        else
                        {
                            g.DrawLine(pen, jiaoLu_Pos[j - 1].X, jiaoLu_Pos[j - 1].Y, jiaoLu_Pos[j - 1].X, jiaoLu_Pos[j - 1].Y - height);
                            g.DrawLine(pen, jiaoLu_Pos[j - 1].X, jiaoLu_Pos[j - 1].Y - height, jiaoLu_Pos[j].X, jiaoLu_Pos[j].Y - height);
                            g.DrawLine(pen, jiaoLu_Pos[j].X, jiaoLu_Pos[j].Y - height, jiaoLu_Pos[j].X, jiaoLu_Pos[j].Y);
                        }
                    }
                    mark++;
                }
            }
            paintForm1.pictureBox1.Image = trainDiagraph;
        }
    }
}