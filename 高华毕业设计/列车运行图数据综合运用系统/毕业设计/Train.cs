using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace 毕业设计
{
    internal class Train
    {
        private static string _trainId;//列车车次
        private static Bitmap _basicBitmap;//存储图
        private static TrainBasicPicture trainBasicPicture2;//底图
        private static bool isDownDirection;//上海到南京方向为True
        private static bool _isFirstTrain;

        public string TrainId
        {
            get => _trainId;
            set
            {
                _trainId = value;
                _trainId = TrainId;
            }
        }

        public Bitmap BasicBitmap
        {
            get => _basicBitmap;
            set
            {
                _basicBitmap = value;
                _basicBitmap = BasicBitmap;
            }
        }

        public TrainBasicPicture trainBasicPicture
        {
            get => trainBasicPicture2;

            set
            {
                trainBasicPicture2 = value;
                trainBasicPicture2 = trainBasicPicture;
            }
        }

        public bool isFirstTrain
        {
            get => _isFirstTrain;
            set
            {
                _isFirstTrain = value;
                _isFirstTrain = isFirstTrain;
            }
        }

        private static readonly List<string> StationIndex = new List<string>();//站序集合
        private static readonly List<string> StationNames = new List<string>();//站名集合
        private static readonly List<string> ArriveStationTimes = new List<string>();//到站时间集合
        private static readonly List<DateTime> StartStationTimes = new List<DateTime>();//出发时间集合
        private static readonly List<float> StayTimes = new List<float>();//到站时间集合
        private static List<float> trainTimePercent = new List<float>();

        public Bitmap DrawTrainLine(out List<TrainLine> TrainLineList)
        {
            ///画列车运行线
            TrainLineList = new List<TrainLine>();
            // ReSharper disable once CollectionNeverQueried.Local
            //是第一趟车的话要话车站的中心线

            if (_isFirstTrain)
            {
                DataTable trainTimeTable = GetTrainTimeTable(); //得到列车时刻表
                Graphics g = Graphics.FromImage(_basicBitmap); //在底图上重新画
                trainTimePercent = getTrainTimePercentList();
                //画车站的中心线
                Pen pen = new Pen(Color.Blue, 1.5f)
                { DashStyle = DashStyle.Custom, DashPattern = new float[] { 3, 3 } }; //定义笔颜色，线型和宽度

                //判断列车的方向
                float sumY = int.Parse(TrainId.Replace("G", "")) % 2 != 0
                    ? trainBasicPicture2.TrainBasicPicturePos.Y
                    : (float)(trainBasicPicture2.TrainBasicPicturePos.Y + trainBasicPicture2.Height);

                List<float> sumYList = new List<float> { sumY }; //存储中心线坐标

                ///画站名和站中心线
                for (int i = 0; i < StayTimes.Count - 1; i++)
                {
                    //判断列车的方向
                    sumY = int.Parse(TrainId.Replace("G", "")) % 2 != 0
                        ? sumY + (float)(trainBasicPicture2.Height * trainTimePercent[i])
                        : sumY - (float)(trainBasicPicture2.Height * trainTimePercent[trainTimePercent.Count - 1 - i]);

                    sumYList.Add(sumY);
                    PointF startPo = new PointF((float)(trainBasicPicture2.TrainBasicPicturePos.X), sumY);
                    PointF endPo =
                        new PointF((float)(trainBasicPicture2.TrainBasicPicturePos.X + trainBasicPicture2.Width),
                            sumY);
                    g.DrawLine(pen, startPo, endPo); //站的中心线
                                                     //添加站名
                    if (i == 0)
                    {
                        if (int.Parse(TrainId.Replace("G", "")) % 2 != 0)
                        {
                            g.DrawString(StationNames[i].ToString(), new Font("华文仿宋", 10, FontStyle.Regular),
                                new SolidBrush(Color.Black), new PointF(trainBasicPicture2.TrainBasicPicturePos.X, trainBasicPicture2.TrainBasicPicturePos.Y - 5)); //站名
                        }
                        else
                        {
                            g.DrawString(StationNames[i].ToString(), new Font("华文仿宋", 10, FontStyle.Regular),
                                new SolidBrush(Color.Black), trainBasicPicture2.TrainBasicPicturePos.X,
                                (float)(trainBasicPicture2.TrainBasicPicturePos.Y + trainBasicPicture2.Height - 5)); //站名
                        }

                        g.DrawString(StationNames[i + 1].ToString(), new Font("华文仿宋", 10, FontStyle.Regular),
                            new SolidBrush(Color.Black), startPo); //站名
                    }
                    else
                    {
                        g.DrawString(StationNames[i + 1].ToString(), new Font("华文仿宋", 10, FontStyle.Regular),
                            new SolidBrush(Color.Black), startPo.X, startPo.Y - 5); //站名
                    }
                }

                for (int index = 0; index < StartStationTimes.Count; index++)
                {
                    var hour = StartStationTimes[index].Hour; //出发时间的小时数
                    var min = StartStationTimes[index].Minute + StartStationTimes[index].Second / 60; //出发时间的分钟数
                    var hourWidth = trainBasicPicture2.Width / 24; //小时的宽度
                    var minWidth = hourWidth / 60; //1min所对应的宽度
                    PointF stayTrainLineStartPointF =
                        new PointF(
                            (float)(trainBasicPicture2.TrainBasicPicturePos.X + hour * hourWidth + minWidth * min),
                            sumYList[index]); //停站运行线的起点坐标
                    PointF stayTrainLineEndPointF =
                        new PointF((float)(stayTrainLineStartPointF.X + minWidth * StayTimes[index]),
                            stayTrainLineStartPointF.Y); //停站运行线的终点坐标

                    //停站时间
                    //g.DrawString(StayTimes[index].ToString(CultureInfo.InvariantCulture),
                    //    new Font("华文仿宋", 8, FontStyle.Regular), new SolidBrush(Color.Black),
                    //    stayTrainLineStartPointF);

                    //停站运行线
                    TrainLine stayTrainLine = new TrainLine(stayTrainLineStartPointF, stayTrainLineEndPointF);
                    g.DrawLine(new Pen(Color.Red, 1f), stayTrainLine.StartPo, stayTrainLine.EndPo);
                    TrainLineList.Add(stayTrainLine);

                    if (index >= StartStationTimes.Count - 1) continue;

                    TrainLine runTrainLine = new TrainLine(PointF.Empty, PointF.Empty);//声明列车运行线
                    PointF nextPointF =
                     new PointF(
                         (float)(trainBasicPicture2.TrainBasicPicturePos.X +
                                  StartStationTimes[index + 1].Hour * hourWidth +
                                  minWidth * (StartStationTimes[index + 1].Minute + StartStationTimes[index + 1].Second / 60)),
                         sumYList[index + 1]); //下一个停站线的起点
                    runTrainLine.StartPo = stayTrainLineEndPointF;
                    runTrainLine.EndPo = nextPointF;
                    TrainLineList.Add(runTrainLine);

                    //列车车次
                    if (index == 0)
                    {
                        g.DrawString(_trainId, new Font("华文仿宋", 8, FontStyle.Regular), new SolidBrush(Color.Black), runTrainLine.StartPo);
                    }
                    g.DrawLine(new Pen(Color.Red, 1f), runTrainLine.StartPo, runTrainLine.EndPo);
                }
                g.Dispose();
            }
            else
            {
                DataTable trainTimeTable = GetTrainTimeTable(); //得到列车时刻表
                Graphics g = Graphics.FromImage(_basicBitmap); //在底图上重新画
                                                               //List<float>trainTimePercent = getTrainTimePercentLIst();
                                                               //判断列车的方向
                float sumY = int.Parse(TrainId.Replace("G", "")) % 2 != 0
                    ? trainBasicPicture2.TrainBasicPicturePos.Y
                    : (float)(trainBasicPicture2.TrainBasicPicturePos.Y + trainBasicPicture2.Height);

                List<float> sumYList = new List<float> { sumY }; //存储中心线坐标
                for (int i = 0; i < StayTimes.Count - 1; i++)
                {
                    //判断列车的方向
                    sumY = int.Parse(TrainId.Replace("G", "")) % 2 != 0
                        ? sumY + (float)(trainBasicPicture2.Height * trainTimePercent[i])
                        : sumY - (float)(trainBasicPicture2.Height * trainTimePercent[trainTimePercent.Count - 1 - i]);

                    sumYList.Add(sumY);
                }

                for (int index = 0; index < StartStationTimes.Count; index++)
                {
                    var hour = StartStationTimes[index].Hour; //出发时间的小时数
                    var min = StartStationTimes[index].Minute; //出发时间的分钟数
                    var hourWidth = trainBasicPicture2.Width / 24; //小时的宽度
                    var minWidth = hourWidth / 60; //1min所对应的宽度
                    PointF stayTrainLineStartPointF =
                        new PointF(
                            (float)(trainBasicPicture2.TrainBasicPicturePos.X + hour * hourWidth + minWidth * min),
                            sumYList[index]); //停站运行线的起点坐标
                    PointF stayTrainLineEndPointF =
                        new PointF((float)(stayTrainLineStartPointF.X + minWidth * StayTimes[index]),
                            stayTrainLineStartPointF.Y); //停站运行线的终点坐标

                    //标注停站线左端点的数字
                    if (StartStationTimes[index].Minute % 10 != 0)//10的倍数的不画
                    {
                        if (int.Parse(TrainId.Replace("G", "")) % 2 == 0)//如果是下行的车的话，出发时间在停站线的偏右偏下
                        {
                            g.DrawString((StartStationTimes[index].Minute % 10).ToString(CultureInfo.InvariantCulture),
                                new Font("华文仿宋", 8, FontStyle.Regular), new SolidBrush(Color.Black),
                                stayTrainLineStartPointF.X + 1.5f, stayTrainLineStartPointF.Y + 3);
                        }
                        else//如果是上行的车的话，出发时间在停站线的偏左偏上
                        {
                            g.DrawString((StartStationTimes[index].Minute % 10).ToString(CultureInfo.InvariantCulture),
                                new Font("华文仿宋", 8, FontStyle.Regular), new SolidBrush(Color.Black),
                                stayTrainLineStartPointF.X - 1.5f, stayTrainLineStartPointF.Y - 10);
                        }
                    }

                    //标注停站线右端点的数字
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (((StartStationTimes[index].Minute + StayTimes[index]) % 10 != 0) && (StayTimes[index] != 0))
                    {
                        if (int.Parse(TrainId.Replace("G", "")) % 2 == 0)//如果是下行的车的话，出发时间在停站线的偏左偏上
                        {
                            g.DrawString(((StartStationTimes[index].Minute + StayTimes[index]) % 10).ToString(CultureInfo.InvariantCulture),
                                new Font("华文仿宋", 8, FontStyle.Regular), new SolidBrush(Color.Black),
                                stayTrainLineEndPointF.X - 3f, stayTrainLineEndPointF.Y - 10);
                        }
                        else
                        {
                            g.DrawString(((StartStationTimes[index].Minute + StayTimes[index]) % 10).ToString(CultureInfo.InvariantCulture),
                                  new Font("华文仿宋", 8, FontStyle.Regular), new SolidBrush(Color.Black),
                                  stayTrainLineStartPointF.X + 1.5f, stayTrainLineStartPointF.Y + 3);
                        }
                    }

                    //停站运行线
                    TrainLine stayTrainLine = new TrainLine(stayTrainLineStartPointF, stayTrainLineEndPointF);
                    g.DrawLine(new Pen(Color.Red, 1f), stayTrainLine.StartPo, stayTrainLine.EndPo);
                    TrainLineList.Add(stayTrainLine);

                    if (index >= StartStationTimes.Count - 1) continue;
                    TrainLine runTrainLine = new TrainLine(PointF.Empty, PointF.Empty);//声明列车运行线
                    PointF nextPointF =
                     new PointF(
                         (float)(trainBasicPicture2.TrainBasicPicturePos.X +
                                  StartStationTimes[index + 1].Hour * hourWidth +
                                  minWidth * (StartStationTimes[index + 1].Minute + StartStationTimes[index + 1].Second / 60)),
                         sumYList[index + 1]); //下一个停站线的起点
                    runTrainLine.StartPo = stayTrainLineEndPointF;
                    runTrainLine.EndPo = nextPointF;
                    TrainLineList.Add(runTrainLine);

                    //列车车次
                    if (index == 0)
                    {
                        g.DrawString(_trainId, new Font("华文仿宋", 11, FontStyle.Regular), new SolidBrush(Color.Black), runTrainLine.StartPo.X, runTrainLine.StartPo.Y);
                    }
                    g.DrawLine(new Pen(Color.Red, 1f), runTrainLine.StartPo, runTrainLine.EndPo);
                }
                g.Dispose();
            }
            return _basicBitmap;
        }

        /// <summary>
        /// 得到列车在每一个区间运行的时间间隔比例（根据站间距计算的比例）
        /// </summary>
        /// <returns></returns>
        private static List<float> getTrainTimePercentList()
        {
            DataSet dataSet = new DataSet();
            List<float> timePercentList = new List<float>();//存储站间时间比例
            try
            {
                SqlConnection connection =
          new SqlConnection(
              "Data Source=DESKTOP-49O35N0;Initial Catalog=GraduateProject;Integrated Security=True");
                connection.Open();
                string sqlStr = $"SELECT DISTINCT  * FROM [GraduateProject].[dbo].[StstionsInfo]";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, connection);
                adapter.Fill(dataSet, "StationInfoTable");
                Console.WriteLine("数据库连接成功");
                List<float> stationDistance = new List<float>();//存储站间距离
                for (int i = 0; i < dataSet.Tables["StationInfoTable"].Rows.Count; i++)
                {
                    stationDistance.Add(float.Parse(dataSet.Tables["StationInfoTable"].Rows[i]["里程（千米）"].ToString()));
                }

                for (int i = 0; i <= stationDistance.Count - 2; i++)
                {
                    timePercentList.Add((stationDistance[i + 1] - stationDistance[i]) / stationDistance[stationDistance.Count - 1]);
                }
                //timePercentList.Add(timePercentList[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接有误");
                throw;
            }

            timePercentList.Reverse();//将元素列表逆序
            return timePercentList;
        }

        /// <summary>
        /// 得到具体车次的时刻表
        /// </summary>
        /// <param name="trainId">输入车次</param>
        /// <returns>输出时刻表的timeTable</returns>

        public static DataTable GetTrainTimeTable()
        {
            StartStationTimes.Clear();
            ArriveStationTimes.Clear();
            StationNames.Clear();
            StayTimes.Clear();
            StationIndex.Clear();
            DataSet dataSet = new DataSet();
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-49O35N0;Initial Catalog=GraduateProject;Integrated Security=True");
                connection.Open();
                string sqlStr = $"SELECT DISTINCT  * FROM  OD为上海站和南京站的所有列车时刻表信息  WHERE 车次 ='{_trainId}'";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, connection);
                adapter.Fill(dataSet, "TimeTable");
                Console.WriteLine("数据库连接成功");

                //将datatable存入list
                for (int i = 0; i < dataSet.Tables["TimeTable"].Rows.Count; i++)
                {
                    StationIndex.Add(dataSet.Tables["TimeTable"].Rows[i]["站序"].ToString());
                    StationNames.Add(dataSet.Tables["TimeTable"].Rows[i]["站名"].ToString());
                    ArriveStationTimes.Add(dataSet.Tables["TimeTable"].Rows[i]["到站时间"].ToString());
                    StartStationTimes.Add(DateTime.Parse(dataSet.Tables["TimeTable"].Rows[i]["出发时间"].ToString()));
                    if (dataSet.Tables["TimeTable"].Rows[i]["停留时间"].ToString() == "----")
                    {
                        StayTimes.Add(0);
                    }
                    else
                    {
                        StayTimes.Add(float.Parse(dataSet.Tables["TimeTable"].Rows[i]["停留时间"].ToString().Replace("分钟", "")));
                    }
                }
                //如果是前两行数据重复的话
                if (StationIndex[0] == StationIndex[1])
                {
                    StationIndex.RemoveAt(0);
                    StartStationTimes.RemoveAt(0);
                    StayTimes.RemoveAt(0);
                    StationNames.RemoveAt(0);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("数据库连接有误");
                throw;
            }
            return dataSet.Tables["TimeTable"];
        }
    }

    public class TrainLine
    {
        public PointF StartPo;
        public PointF EndPo;
        public bool BeSelected;

        public TrainLine(PointF startPo, PointF endPo)
        {
            this.StartPo = startPo;
            this.EndPo = endPo;
            this.BeSelected = false;
        }
    }
}