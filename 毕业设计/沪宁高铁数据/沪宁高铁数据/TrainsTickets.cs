using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;


namespace 沪宁高铁数据
{
    class TrainsTickets
    {
        public DateTime SelectDateTime { get; set; } = DateTime.Now;//查询时间,如果没有赋值的话，为此刻
        public string FromStation { get; set; }//出发的上海站点
        public string ToStation { get; set; }//到达的南京站点
        public string TrainsTicketsExcelPath { get; set; }

        /// <summary>
        /// get获取url的json的数组数据
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static JArray GetUrlJson(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;
            //request.Referer = "https://kyfw.12306.cn/otn/leftTicket/init?linktypeid=dc&fs=%E4%B8%8A%E6%B5%B7,SHH&ts=%E5%8C%97%E4%BA%AC,BJP&date=2019-03-10&flag=N,N,Y";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36";
            request.IfModifiedSince = DateTime.Now;
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
            request.Headers.Add("Cache-Control", "no-cache");
            //request.Headers.Add("Cookie", "JSESSIONID=B3E21D8294C2857736E095CEF113768E; RAIL_EXPIRATION=1552454853784; RAIL_DEVICEID=GgvErOZ2x9C_UW86grSWfz56ZIs2Z7tcU9WMgHJNjckrQXWBjJe_vgSo7_P5mQUvQF65tCAKajeWvDDLGyJb_bPWKRV33ZN5MW2F903JtxaWZ4cWK4tnUxeTzqhJWEK40UqVS5ijbPbgAT4Z-2GzjyP4AuWDHGGz; _jc_save_fromStation=%u4E0A%u6D77%2CSHH; _jc_save_wfdc_flag=dc; BIGipServerpool_passport=300745226.50215.0000; route=9036359bb8a8a461c164a04f8f50b252; BIGipServerotn=569377290.64545.0000; _jc_save_toDate=2019-03-10; _jc_save_toStation=%u5317%u4EAC%2CBJP; _jc_save_fromDate=2019-03-10");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }
            JObject jObject = (JObject)JsonConvert.DeserializeObject(retString);//解析json
            JArray jArray;

            if (Url.Contains("train_no="))
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
        /// <returns></returns>
        public  string GetTrainInfo()
        {
            string date_time = SelectDateTime.ToString("yyyy-MM-dd");
            string url = string.Format("https://kyfw.12306.cn/otn/leftTicket/queryX?leftTicketDTO.train_date={0}&leftTicketDTO.from_station={1}&leftTicketDTO.to_station={2}&purpose_codes=ADULT", date_time, this.FromStation, this.ToStation);
            JArray jArray = GetUrlJson(url);//发送请求返回json的jarray数据
            DataTable TrainsTable = Json2TrainInfoDatable(jArray);
            var file = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + string.Format("\\train_{0}_{1}_{2}.xlsx", DateTime.Now.ToString("yyyyMMddhhmmss"), this.FromStation, this.ToStation);//桌面上生成数据文件
            if (this.TrainsTicketsExcelPath == null)
            {
                this.TrainsTicketsExcelPath = file;//存储输出的excel路径
            }
            Excel.TableToExcel(TrainsTable, file);

            Console.WriteLine(string.Format("列车车票信息存储完毕，Excel地址为:\n{0}\n", TrainsTicketsExcelPath));
            return file;
        }
        /// <summary>
        /// 输入一条json的data记录输出解析后的一趟车的具体信息列表
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> ProcessStr(string str)
        {
            List<string> train = new List<string>();
            train.Add(str.ToString().Split('|')[2]);
            train.Add(str.ToString().Split('|')[1]);
            train.Add(str.ToString().Split('|')[3]);
            train.Add(str.ToString().Split('|')[4]);
            train.Add(str.ToString().Split('|')[5]);
            train.Add(str.ToString().Split('|')[6]);
            train.Add(str.ToString().Split('|')[7]);
            train.Add(str.ToString().Split('|')[8]);
            train.Add(str.ToString().Split('|')[9]);
            train.Add(str.ToString().Split('|')[10]);
            train.Add(DateTime.Now.ToString());
            train.Add(str.ToString().Split('|')[22]);
            train.Add(str.ToString().Split('|')[23]);
            train.Add(str.ToString().Split('|')[25]);
            train.Add(str.ToString().Split('|')[26]);
            train.Add(str.ToString().Split('|')[27]);
            train.Add(str.ToString().Split('|')[28]);
            train.Add(str.ToString().Split('|')[29]);
            train.Add(str.ToString().Split('|')[30]);
            train.Add(str.ToString().Split('|')[31]);
            train.Add(str.ToString().Split('|')[32]);
            train.Add(str.ToString().Split('|')[21]);
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
        /// <param name="trainInfoExcelPath"></param>
        /// <returns></returns>
        public  List<string> ReadExcelTrainNo(string trainInfoExcelPath, out List<string> trainStartStationLists, out List<string> trainEndStationLists)
        {

            trainStartStationLists = new List<string>();//需要重新分配空间
            trainEndStationLists = new List<string>();//需要重新分配空间
            var dataTable = Excel.ExcelToTable(trainInfoExcelPath);
            List<string> TrainNoLists = new List<string>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                TrainNoLists.Add(dataRow["TrainNo"].ToString());
                trainStartStationLists.Add(dataRow["途经上海站"].ToString());
                trainEndStationLists.Add(dataRow["途经南京站"].ToString());

            }
            return TrainNoLists;
        }

    }
}
