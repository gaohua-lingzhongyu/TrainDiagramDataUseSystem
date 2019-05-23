using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using  System.Threading;

namespace 沪宁高铁数据
{
    internal class TrainTimeTable:IDataTable2SqlServerAble
    {
        public string TrainTimeTableUrl;//当前列车车次的服务器地址
        public string TrainNo;//车次号
        public string FromStation;//起点站
        public string EndStation;//终点站
        public string TrainTimeTableExcelPath { set; get; }

        public TrainTimeTable(string trainNo, string fromStation, string endStation, DateTime selectDateTime)//构造当前列车车次的服务器地址
        {
            TrainTimeTableUrl = "https://kyfw.12306.cn/otn/czxx/queryByTrainNo?train_no=" +
                                $"{trainNo}&from_station_telecode={fromStation}&to_station_telecode={endStation}&depart_date={selectDateTime.ToString("yyyy-MM-dd")}";//此处的到站只有NJH和NKH
            TrainNo = trainNo;
            FromStation = fromStation;
            EndStation = endStation;
        }


        /// <summary>
        /// 输出具体车次时刻表的datatable。输出其excel，默认地址为桌面
        /// </summary>
        /// <returns></returns>
        public DataTable CreateTrainTimeDataTable()
        {
            //Thread.Sleep(3000);
            JArray jArray = TrainsTickets.GetUrlJson(TrainTimeTableUrl);
            DataTable dataTable = new DataTable(jArray[0]["station_train_code"].ToString());//表名为列车编号，这里需要注意的是json返回的数据结构、
            dataTable.Columns.Add("车次");
            dataTable.Columns.Add("站序");
            dataTable.Columns.Add("站名");
            dataTable.Columns.Add("到站时间");
            dataTable.Columns.Add("出发时间");
            dataTable.Columns.Add("停留时间");
            dataTable.Columns.Add("始发站");
            dataTable.Columns.Add("终点站");
            foreach (var item in jArray)
            {
                DataRow dataRow = dataTable.NewRow();//新创建一行
                dataRow["车次"] = jArray[0]["station_train_code"].ToString();//注意这里的车次号和trainNo是不一样的，trainNo是580000K5260E
                dataRow["站序"] = item["station_no"];
                dataRow["站名"] = item["station_name"];
                dataRow["到站时间"] = item["arrive_time"];
                dataRow["出发时间"] = item["start_time"];
                dataRow["停留时间"] = item["stopover_time"];
                dataRow["始发站"] = jArray[0]["start_station_name"];
                dataRow["终点站"] = jArray[0]["end_station_name"];
                dataTable.Rows.Add(dataRow);
            }



            ///展示部分可以使用
            //将datatable存储为excel
            var trainTimeTableExcel = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) +
                                      $"\\trainTime_{DateTime.Now:yyyyMMddhhmmss}.xlsx";//桌面上生成数据文件
            if (this.TrainTimeTableExcelPath == null)
            {
                this.TrainTimeTableExcelPath = trainTimeTableExcel;
            }
            Excel.TableToExcel(dataTable, this.TrainTimeTableExcelPath);
            Console.WriteLine($"车次信息存储完毕，Excel地址为:\n{this.TrainTimeTableExcelPath}\n");
            return dataTable;
        }

        public void DataTable2SqlServer(DataTable dt)
        {
            const string con = "Data Source=DESKTOP-49O35N0;Initial Catalog=GraduateProject;Integrated Security=True"; //数据库的 连接字符串
            const string sql = "";//sql字符串执行
            SqlConnection sqlConnection = new SqlConnection(con);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);//执行sql命令
            SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConnection) { DestinationTableName = "TrainTimeTable" };
            sqlBulkCopy.WriteToServer(dt);
            sqlBulkCopy.Close();
            Console.WriteLine("数据库更新完毕");
        }
    }
}