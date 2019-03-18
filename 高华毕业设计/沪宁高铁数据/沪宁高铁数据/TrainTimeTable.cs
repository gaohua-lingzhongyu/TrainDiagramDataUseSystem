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
    class TrainTimeTable
    {
        public  string trainTimeTableUrl;//当前列车车次的服务器地址
        public string trainNo;//车次号
        public string fromStation;//起点站
        public string endStation;//终点站
        public string trainTimeTableExcelPath { set; get; }

        public TrainTimeTable(string _trainNo,string _fromStation,string _endStation,DateTime _selectDateTime)//构造当前列车车次的服务器地址
        {
          trainTimeTableUrl = string.Format("https://kyfw.12306.cn/otn/czxx/queryByTrainNo?train_no=" +
                     "{0}&from_station_telecode={1}&to_station_telecode={2}&depart_date={3}",
                     _trainNo, _fromStation,_endStation, _selectDateTime.ToString("yyyy-MM-dd"));//此处的到站只有NJH和NKH
            trainNo = _trainNo;
            fromStation = _fromStation;
            endStation = _endStation;
        }

/// <summary>
/// 输出具体车次时刻表的datatable。输出其excel，默认地址为桌面
/// </summary>
/// <returns></returns>
        public  DataTable CreateTrainTimeDataTable()
        {
            JArray jArray=TrainsTickets.GetUrlJson(trainTimeTableUrl);
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
            var trainTimeTableExcel = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + string.Format("\\trainTime_{0}.xlsx", DateTime.Now.ToString("yyyyMMddhhmmss"));//桌面上生成数据文件
            if (this.trainTimeTableExcelPath == null)
            {
                this.trainTimeTableExcelPath = trainTimeTableExcel;
            }
            Excel.TableToExcel(dataTable,this.trainTimeTableExcelPath);
            Console.WriteLine(string.Format("车次信息存储完毕，Excel地址为:\n{0}\n", this.trainTimeTableExcelPath));
            return dataTable;
        }



    }
}
