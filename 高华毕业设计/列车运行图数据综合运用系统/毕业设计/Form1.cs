using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 毕业设计
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                control.Font = new Font("微软雅黑", 12);
            }
            pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_Click);
            this.panelofPic.MouseWheel += new MouseEventHandler(this.panelofPic_MouseWheel);
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //this.panelofPic.Width = this.Width;
            //this.panelofPic.Height = this.Height;
        }

        private int _flag;//当前确定的分钟格数显示值，2，10
        private TrainBasicPicture trainBasicPicture2;
        public Bitmap trainsDiagram;//底图

        private void 生成底图结构ToolStripMenuItem_Click_1(object sender, EventArgs e)//10分格的底图结构生成
        {
            //生成10分格底图结构
            //this.panelofPic.SetAutoScrollMargin(400, 100);//使用scrollbar来控制显示图像的范围
            TrainBasicPicture trainBasicPicture10 = new TrainBasicPicture
            {
                Width = this.pictureBox1.Width - 100,
                Height = this.pictureBox1.Height - 100,
                TrainBasicPicturePos =
                    new PointF(this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y + 10)
            }; //声明10分格底图结构实例
            //底图结构的宽度
            //底图结构的高度
            pictureBox1.Image = trainBasicPicture10.DrawTrainBasicPicture(TrainBasicPicture.Scale.TenMinutes);//将返回的bitmap设置为picbox的背景图片
            _flag = 10;//当前的flag为10分格数
        }

        private void panelofPic_Paint(object sender, PaintEventArgs e)
        {
        }

        private void 生成2分格底图结构ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //生成2分格的底图结构
            TrainBasicPicture TrainBasicPicture2 = new TrainBasicPicture
            {
                Width = this.pictureBox1.Width - 30,
                Height = this.pictureBox1.Height - 30,
                TrainBasicPicturePos =
                    new PointF(this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y + 10)
            }; //声明5分格底图结构实例
            trainsDiagram = TrainBasicPicture2.DrawTrainBasicPicture(TrainBasicPicture.Scale.TwoMinutes);
            pictureBox1.Image = trainsDiagram; //将返回的bitmap设置为picbox的背景图片
            _flag = 2;//当前的flag为10分格数
        }

        public List<Trains> trains;

        /// <summary>
        /// 绘制沪宁线的G字头列车运行线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void 沪宁线高铁车次绘制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            markedTrains.Clear();//刷新操作之后，被选中的列车不再算数

            //设置滚动条的位置，防止刷新时左边的车站不对
            this.panelofPic.HorizontalScroll.Value = 0;
            this.pictureBox_stations.Image = null;//点击刷新的时候进行左侧的车站情况置空
            //默认是生成2分格的底图结构
            pictureBox1.Height = this.panelofPic.Height - 30;//注意这里参数控制的是下面的白带宽度（picturebox能否使得pannel出现滚动条）

            pictureBox1.Width = this.panelofPic.Width * 3;
            trainBasicPicture2 = new TrainBasicPicture
            {
                Width = this.pictureBox1.Width - 40,//控制的是图和picturebox之间的关系
                Height = this.pictureBox1.Height - 80,//控制的是图和picturebox之间的关系
                TrainBasicPicturePos =
                    new PointF(this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y + 30)
            }; //声明5分格底图结构实例
            trainsDiagram = trainBasicPicture2.DrawTrainBasicPicture(TrainBasicPicture.Scale.TenMinutes);

            List<string> trainIdList = GetTrainId();
            //List<string> trainIdList = new List<string> { "G7001" };
            if (trainIdList != null)
            {
                trains = new List<Trains>();//车的集合
                for (int i = 0; i < trainIdList.Count; i++)
                {
                    if (i == 0)
                    {
                        Train train = new Train
                        {
                            TrainId = trainIdList[i], //车次
                            BasicBitmap = trainsDiagram, //存储图
                            trainBasicPicture = trainBasicPicture2, //底图对象
                            isFirstTrain = true
                        };
                        trainsDiagram = train.DrawTrainLine(out List<TrainLine> trainLineList);
                        //注意这里需要区分列车是上行还是下行，它们的起始点相反

                        trains.Add(new Trains(trainLineList, train.TrainId, trainLineList[0].StartPo,
                            trainLineList[trainLineList.Count - 1].EndPo));
                    }
                    else
                    {
                        Train train = new Train
                        {
                            TrainId = trainIdList[i], //车次
                            BasicBitmap = trainsDiagram, //存储图
                            trainBasicPicture = trainBasicPicture2, //底图对象
                            isFirstTrain = false
                        };
                        trainsDiagram = train.DrawTrainLine(out List<TrainLine> trainLineList);

                        if (int.Parse(train.TrainId.Replace("G", "")) % 2 == 0)
                        {
                            trains.Add(new Trains(trainLineList, train.TrainId, trainLineList[0].StartPo,
                                trainLineList[trainLineList.Count - 1].EndPo));
                        }
                        else
                        {
                            trains.Add(new Trains(trainLineList, train.TrainId,
                                trainLineList[trainLineList.Count - 1].EndPo, trainLineList[0].StartPo));
                        }
                    }

                    pictureBox1.Image = trainsDiagram;
                }
            }
            else
            {
                MessageBox.Show("车次数量为0");
            }
        }

        private List<string> GetTrainId()
        {
            DataSet dataSet = new DataSet();
            List<string> trainIdList = new List<string>();
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-49O35N0;Initial Catalog=GraduateProject;Integrated Security=True");
                connection.Open();
                string sqlStr = $"SELECT DISTINCT 车次   FROM dbo.OD为上海站和南京站的所有列车时刻表信息";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, connection);
                adapter.Fill(dataSet, "TrainIdTable");
                Console.WriteLine("数据库连接成功");

                //将datatable存入list
                for (int i = 0; i < dataSet.Tables["TrainIdTable"].Rows.Count; i++)
                {
                    trainIdList.Add(dataSet.Tables["TrainIdTable"].Rows[i]["车次"].ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("数据库连接有误");
                throw;
            }

            return trainIdList;
        }

        //点击一条线使它变色
        private bool ifclickonce = false;

        private List<string> markedTrains = new List<string>();//记录被选中的车

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            if (markedTrains == null || markedTrains.Count < 2)//如果被选中的车数量小于2的话，允许继续选
            {
                //选列车的核心代码
                try
                {
                    Graphics g = Graphics.FromImage(trainsDiagram);
                    //g.FillRectangle(Brushes.White, 0, 0, trainsDiagram.Width, trainsDiagram.Height);
                    if (e.Button == MouseButtons.Right)//鼠标左键点下
                    {
                        bool hasLineBeSelected = false;
                        Pen pen = new Pen(Color.Red, 3f);

                        ///为了避免出现点击选中时，从索引最小的开始选，这里将列车的顺序进行随机排序
                        Random random = new Random();
                        List<Trains> newtrains = new List<Trains>();
                        foreach (var train in trains)
                        {
                            newtrains.Insert(random.Next(newtrains.Count), train);
                        }

                        foreach (var train in newtrains)
                        {
                            foreach (var trainline in train.sections) //判断是否选中
                            {
                                float k = (trainline.EndPo.Y - trainline.StartPo.Y) /
                                          (trainline.EndPo.X - trainline.StartPo.X);
                                float deltX = e.X - trainline.StartPo.X;
                                if (Math.Abs(trainline.StartPo.Y + k * deltX - e.Y) < 1) //控制精度
                                {
                                    hasLineBeSelected = true;
                                    train.beSelected = true;
                                }
                            }

                            if (train.beSelected)//选中的话，进行重绘
                            {
                                markedTrains.Add(train.trainId);
                                foreach (var line in train.sections)
                                {
                                    g.DrawLine(pen, line.StartPo, line.EndPo);
                                }

                                //更换picturebox的图片
                                if (MessageBox.Show("您选中的车次是" + train.trainId, "确定选中车次", MessageBoxButtons.OKCancel) == DialogResult.OK)//确认是否为选中的车次
                                {
                                    pictureBox1.Image = trainsDiagram;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            if (hasLineBeSelected)//如果已经有线被选中，不再循环列车
                            {
                                //train.beSelected = false;
                                markedTrains.Add(train.trainId);
                                markedTrains = markedTrains.Distinct().ToList();//去重
                                newtrains.Remove(train);
                                return;
                            }

                            markedTrains = markedTrains.Distinct().ToList();//去重
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
            else
            {
                MessageBox.Show($"您已经选了{markedTrains.Count}列车:{markedTrains[0]}和{markedTrains[1]}");
                foreach (var item in markedTrains)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private void 导出为excel文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlConnection connection =
                    new SqlConnection(
                        "Data Source=DESKTOP-49O35N0;Initial Catalog=GraduateProject;Integrated Security=True");
                connection.Open();
                string sqlStr = $"SELECT DISTINCT * FROM  dbo.OD为上海站和南京站的所有列车时刻表信息";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, connection);
                adapter.Fill(dataSet, "OD为上海站和南京站的所有列车时刻表信息");
                Console.WriteLine("数据库连接成功");
                GetSciEi.Excel.TableToExcel(dataSet.Tables["OD为上海站和南京站的所有列车时刻表信息"], @".\python\车底勾画\data\OD为上海站和南京站的所有列车时刻表信息.xlsx");
                MessageBox.Show("数据导出成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接有误");
                throw;
            }
        }

        //拿滚动条的位置
        [DllImport("user32.dll", EntryPoint = "GetScrollPos")]
        public static extern int GetScrollPos(IntPtr hwnd, int nBar);

        //如果滚动条发生滚动，就出现站名
        private void panelofPic_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                //滚动条的位置
                int scroll_pos = GetScrollPos(this.panelofPic.Handle, 0);
                //如果滚动条的位置在最左端，就不可见滚动条
                this.panel_stations.Visible = scroll_pos != 0;
                this.panel_stations.Height = this.Height;
                this.pictureBox_stations.Height = this.pictureBox1.Height;//车站picturebox的高度
                this.pictureBox_stations.Width = 1000;
                RectangleF cloneRect = new RectangleF(0, 0, 100, trainsDiagram.Height);
                System.Drawing.Imaging.PixelFormat format = trainsDiagram.PixelFormat;
                Bitmap station_bitmap = trainsDiagram.Clone(cloneRect, format);
                this.pictureBox_stations.Image = station_bitmap;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        //如果鼠标的滚轮发生滚动
        private void panelofPic_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                //滚动条的位置
                int scroll_pos = GetScrollPos(this.panelofPic.Handle, 0);
                //如果滚动条的位置在最左端，就不可见滚动条
                this.panel_stations.Visible = scroll_pos != 0;

                this.panel_stations.Height = this.Height;
                this.pictureBox_stations.Height = this.pictureBox1.Height;//车站picturebox的高度
                this.pictureBox_stations.Width = 1000;
                RectangleF cloneRect = new RectangleF(0, 0, 100, trainsDiagram.Height);
                System.Drawing.Imaging.PixelFormat format = trainsDiagram.PixelFormat;
                Bitmap station_bitmap = trainsDiagram.Clone(cloneRect, format);
                this.pictureBox_stations.Image = station_bitmap;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        //调用python进行列车交路的勾画
        private async void 自动勾画交路ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //从数据库中导出勾画交路所需要的原始数据
            this.沪宁线高铁车次绘制ToolStripMenuItem_Click(sender, e);
            DataSet dataSet = new DataSet();
            try
            {
                SqlConnection connection =
                    new SqlConnection(
                        "Data Source=DESKTOP-49O35N0;Initial Catalog=GraduateProject;Integrated Security=True");
                connection.Open();
                string sqlStr = $"SELECT DISTINCT * FROM  dbo.OD为上海站和南京站的所有列车时刻表信息";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, connection);
                adapter.Fill(dataSet, "OD为上海站和南京站的所有列车时刻表信息");
                Console.WriteLine("数据库连接成功");
                GetSciEi.Excel.TableToExcel(dataSet.Tables["OD为上海站和南京站的所有列车时刻表信息"], @".\python\车底勾画\data\OD为上海站和南京站的所有列车时刻表信息.xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"数据库连接有误，错误信息{ex.Message}");
                throw;
            }

            await Task.Run(() =>
            {
                Directory.SetCurrentDirectory(@".\Python\车底勾画\");//设置python文件运行的路径
                Process process = new Process { StartInfo = { FileName = @".\车底勾画.exe" } };//启动python
                process.Start();
                process.WaitForExit();
                process.Dispose();
            });

            DirectoryInfo currentDirectoryInfoParent = Directory.GetParent(Directory.GetCurrentDirectory());//重新设置主程序运行的路径
            if (currentDirectoryInfoParent.Parent != null)
                Directory.SetCurrentDirectory(currentDirectoryInfoParent.Parent.FullName);

            JiaoLuForm jiaoluForm = new JiaoLuForm(this)
            {
                trainDiagraph = DeepClone(trainsDiagram),
                allTrains = this.trains,//图里的所有列车集合
                dataFilePath=@".\Python\车底勾画\data\交路勾画方案.xlsx"
            };

            jiaoluForm.Show(this);//窗体之间通信
        }

        //深度复制bitmap
        public Bitmap DeepClone(Bitmap bitmap)
        {
            Bitmap dstBitmap = null;
            using (MemoryStream mStream = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(mStream, bitmap);
                mStream.Seek(0, SeekOrigin.Begin);//指定当前流的位置为流的开头。
                dstBitmap = (Bitmap)bf.Deserialize(mStream);
                mStream.Close();
            }
            return dstBitmap;
        }

        private async void 动车所能力限制交路勾画ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //从数据库中导出勾画交路所需要的原始数据
            this.沪宁线高铁车次绘制ToolStripMenuItem_Click(sender, e);//先画原始的列车运行图
            //算法计算引擎
            await Task.Run(() =>
                {

                    Directory.SetCurrentDirectory(@".\能力限制下的交路自动勾画");//设置当前的运行路径
                    //新开一个线程进行交路的算法引擎的运行
                    System.Diagnostics.Process p = new System.Diagnostics.Process
                    {
                        StartInfo =
                            {
                                FileName = @".\test.exe",
                            }
                    };
                    p.Start();
                    p.WaitForExit();
                    p.Dispose();
                });
            //运行路径恢复
            DirectoryInfo currentDirectoryInfoParent = Directory.GetParent(Directory.GetCurrentDirectory());//重新设置主程序运行的路径
            if (currentDirectoryInfoParent.Parent != null)
                Directory.SetCurrentDirectory(currentDirectoryInfoParent.FullName);

            JiaoLuForm capacity_limited_form = new JiaoLuForm(this)
            {
                allTrains = this.trains,
                dataFilePath = @".\能力限制下的交路自动勾画\hello\交路勾画方案既定.xlsx",
                trainDiagraph = DeepClone(trainsDiagram)
            };
            capacity_limited_form.Show(this);
        }
    }
}