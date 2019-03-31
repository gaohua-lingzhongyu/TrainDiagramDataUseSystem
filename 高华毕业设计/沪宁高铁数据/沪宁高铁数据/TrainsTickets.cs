using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace 沪宁高铁数据
{
    interface IDataTable2SqlServerAble
    {
         void DataTable2SqlServer(DataTable dt);
    }
    internal class TrainsTickets:IDataTable2SqlServerAble
    {
        public DateTime SelectDateTime { get; set; } = DateTime.Now;//查询时间,如果没有赋值的话，为此刻
        public string FromStation { get; set; }//出发的上海站点
        public string ToStation { get; set; }//到达的南京站点
        public string TrainsTicketsExcelPath { get; set; }

        /// <summary>
        /// get获取url的json的数组数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static JArray GetUrlJson(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            // ReSharper disable once AssignNullToNotNullAttribute
            request.Proxy = null;
            request.KeepAlive = true;
            request.Method = "GET";
            request.Referer = "https://kyfw.12306.cn/otn/leftTicket/init?linktypeid=dc&fs=%E4%B8%8A%E6%B5%B7,SHH&ts=%E5%8D%97%E4%BA%AC,NJH&date=2019-03-28&flag=N,N,Y";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36";
            //request.IfModifiedSince = DateTime.Now;
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
            request.Headers.Add("Cache-Control", "no-cache");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream ?? throw new InvalidOperationException(), Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            response.Close();
            request.Abort();
            JObject jObject = (JObject)JsonConvert.DeserializeObject(retString);//解析json
            JArray jArray;

            if (url.Contains("train_no="))
            {
                jArray = (JArray)jObject["data"]["data"];//检索的是时间信息
            }
            else
            {
                jArray = (JArray)jObject["data"]["result"];//检索的是车次信息
            }
            return jArray;
        }

        /// <summary>
        /// 入口函数，输出保存的excel地址
        /// </summary>
        /// <returns>返回excel的路径，返回TrainTickets的datable</returns>
        public string GetTrainInfo(out DataTable trainsTable)
        {
            string dateTime = SelectDateTime.ToString("yyyy-MM-dd");
            string url =
                $"https://kyfw.12306.cn/otn/leftTicket/query?leftTicketDTO.train_date={dateTime}&leftTicketDTO.from_station={this.FromStation}&leftTicketDTO.to_station={this.ToStation}&purpose_codes=ADULT";


            JArray jArray = GetUrlJson(url);//发送请求返回json的jarray数据
           trainsTable = Json2TrainInfoDatable(jArray);
            var file = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) +
                       $"\\train_{DateTime.Now:yyyyMMddhhmmss}_{this.FromStation}_{this.ToStation}.xlsx";//桌面上生成数据文件
            if (this.TrainsTicketsExcelPath == null)
            {
                this.TrainsTicketsExcelPath = file;//存储输出的excel路径
            }
            Excel.TableToExcel(trainsTable, file);

            Console.WriteLine($"列车车票信息存储完毕，Excel地址为:\n{TrainsTicketsExcelPath}\n");
            return file;
        }

        /// <summary>
        /// 输入一条json的data记录输出解析后的一趟车的具体信息列表
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> ProcessStr(string str)
        {
            List<string> train = new List<string>
            {
                str.ToString().Split('|')[2],
                str.ToString().Split('|')[1],
                str.ToString().Split('|')[3],
                str.ToString().Split('|')[4],
                str.ToString().Split('|')[5],
                str.ToString().Split('|')[6],
                str.ToString().Split('|')[7],
                str.ToString().Split('|')[8],
                str.ToString().Split('|')[9],
                str.ToString().Split('|')[10],
                DateTime.Now.ToString(CultureInfo.InvariantCulture),
                str.ToString().Split('|')[22],
                str.ToString().Split('|')[23],
                str.ToString().Split('|')[25],
                str.ToString().Split('|')[26],
                str.ToString().Split('|')[27],
                str.ToString().Split('|')[28],
                str.ToString().Split('|')[29],
                str.ToString().Split('|')[30],
                str.ToString().Split('|')[31],
                str.ToString().Split('|')[32],
                str.ToString().Split('|')[21]
            };
            return train;
        }

        /// <summary>
        /// 输入json数组返回datable
        /// </summary>
        /// <param name="jArray"></param>
        /// <returns></returns>
        public static DataTable Json2TrainInfoDatable(JArray jArray)
        {
            DataTable dataTable = CreateTrainInfoDataTable();//创建数据表
            foreach (var item in jArray)
            {
                var train = ProcessStr(item.ToString());
                DataRow dr = dataTable.NewRow();
                int i = 0;
                foreach (var info in train)
                {
                    dr[i] = info;
                    i++;
                }
                dataTable.Rows.Add(dr);
            }
            return dataTable;
        }

        /// <summary>
        /// 创建一个列车的车票信息的表
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTrainInfoDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("TrainNo");
            dataTable.Columns.Add("运营状态");
            dataTable.Columns.Add("车次");
            dataTable.Columns.Add("出发站");
            dataTable.Columns.Add("终点站");
            dataTable.Columns.Add("途经上海站");
            dataTable.Columns.Add("途经南京站");
            dataTable.Columns.Add("出发时间");
            dataTable.Columns.Add("到达时间");
            dataTable.Columns.Add("历时");
            dataTable.Columns.Add("查询时间");//注：此处修改了原json的数据，原json数据为20190103，修改为2019/3/10 16:03:56
            dataTable.Columns.Add("其他");
            dataTable.Columns.Add("软卧一等卧");
            dataTable.Columns.Add("软座");
            dataTable.Columns.Add("无座");
            dataTable.Columns.Add("动卧");
            dataTable.Columns.Add("硬卧二等卧");
            dataTable.Columns.Add("硬座");
            dataTable.Columns.Add("二等座");
            dataTable.Columns.Add("一等座");
            dataTable.Columns.Add("商务座/特等座");
            dataTable.Columns.Add("高级软卧");
            return dataTable;
        }

        /// <summary>
        /// 输入包含TrainNo字段的excel路径，返回TrainNos的列表
        /// 返回上海的火车站代码，南京的火车站代码
        /// </summary>
        /// <param name="trainInfoExcelPath">列车车票信息的excel路径</param>
        /// <returns></returns>
        public List<string> ReadExcelTrainNo(string trainInfoExcelPath, out List<string> trainStartStationLists, out List<string> trainEndStationLists)
        {
            trainStartStationLists = new List<string>();//需要重新分配空间
            trainEndStationLists = new List<string>();//需要重新分配空间
            var dataTable = Excel.ExcelToTable(trainInfoExcelPath);
            List<string> trainNoLists = new List<string>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                trainNoLists.Add(dataRow["TrainNo"].ToString());
                trainStartStationLists.Add(dataRow["途经上海站"].ToString());
                trainEndStationLists.Add(dataRow["途经南京站"].ToString());
            }
            return trainNoLists;
        }


        /// <summary>
        /// 将datatable数据存入sqlserver数据库，输入的是TrainTicke datatable
        /// </summary>
        public  void DataTable2SqlServer(DataTable dt)
        {
            const string con = "Data Source=DESKTOP-49O35N0;Initial Catalog=GraduateProject;Integrated Security=True"; //数据库的 连接字符串
            const string sql = "";//sql字符串执行
            SqlConnection sqlConnection=new SqlConnection(con);
            sqlConnection.Open();
            SqlCommand sqlCommand=new SqlCommand(sql,sqlConnection);//执行sql命令
            SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConnection) {DestinationTableName = "TrainTicket"};
            sqlBulkCopy.WriteToServer(dt);
            sqlBulkCopy.Close();
            Console.WriteLine("数据库更新完毕");
        }
    }


}