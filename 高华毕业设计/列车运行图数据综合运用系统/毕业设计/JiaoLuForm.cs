using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace 毕业设计
{
    public partial class JiaoLuForm : Form
    {

        private static Form1 paintForm1 = null;
        public Bitmap trainDiagraph { set; get; }
        public List<Trains> allTrains { set; get; }


        public JiaoLuForm(Form1 form1)
        {
            InitializeComponent();
            paintForm1 = form1;

        }

        public DataTable datagridviewSourceTable;

        private void JiaoLuForm_Load(object sender, EventArgs e)
        {
            this.dataGridView_jiaoLuData.DataSource =
                GetSciEi.Excel.ExcelToTable(@".\Python\车底勾画\data\交路勾画方案.xlsx"); //将交路勾画的方案进行可视化
        }


        int train_nums;
        private void button_jiaoLu_KeShiHua_Click(object sender, EventArgs e)
        {
            //trainDiagraph = paintForm1.trainsDiagram;
            paintForm1.沪宁线高铁车次绘制ToolStripMenuItem_Click(sender, e);
            DataTable dt = Form_trainTimeData.GetDgvToTable(this.dataGridView_jiaoLuData);
            train_nums = dt.Columns.Count;
            Graphics g=Graphics.FromImage(trainDiagraph);//在原图上操作
            Pen pen=new Pen(Color.Purple,0.5f);


            


            for (int i = 1; i <= train_nums; i++)
            {
                List<PointF>jiaoLu_Pos=new List<PointF>();//交路的点列表
                foreach (DataRow dr in dt.Rows)//这个循环里面是同一个车底
                {

                    int index = 0;//记录是第几个找到的车号

                    //找到一个车底的所有交路坐标
                    foreach (Trains train in allTrains)
                    {

                        //找到所有的交路的坐标
                        if (train.trainId==dr[$"车底{i}"].ToString())
                        {
                            index++;
                            if (index==1)//如果是第一个的话，就是终点
                            {
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
                List<int>heights=new List<int>(); 
                for (int j = 1; j < jiaoLu_Pos.Count; j = j + 2)
                {
                    heights.Add(10);
                    heights.Add(20);
                    heights.Add(30);
                }

                for (int j = 1; j < jiaoLu_Pos.Count; j=j+2)
                {
                    float width = jiaoLu_Pos[j].X - jiaoLu_Pos[j - 1].X;//记录矩形的宽度

                    float height = heights[j];
                    g.DrawLine(pen,jiaoLu_Pos[j-1].X,jiaoLu_Pos[j-1].Y,jiaoLu_Pos[j-1].X,jiaoLu_Pos[j-1].Y-height);
                    g.DrawLine(pen,jiaoLu_Pos[j-1].X,jiaoLu_Pos[j-1].Y-height,jiaoLu_Pos[j].X,jiaoLu_Pos[j].Y-height);
                    g.DrawLine(pen,jiaoLu_Pos[j].X,jiaoLu_Pos[j].Y-height,jiaoLu_Pos[j].X,jiaoLu_Pos[j].Y);
                    paintForm1.pictureBox1.Image = trainDiagraph;
                }

                
            }

        }
    }
}