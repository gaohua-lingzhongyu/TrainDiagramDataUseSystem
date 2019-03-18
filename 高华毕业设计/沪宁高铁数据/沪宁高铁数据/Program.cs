using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace 沪宁高铁数据
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainsTickets trainsTickets = new TrainsTickets();
            trainsTickets.SelectDateTime = DateTime.Now.AddDays(3);//车票信息的查询时间
            trainsTickets.FromStation = "SHH";//车票信息的起点站
            trainsTickets.ToStation = "NJH";//车票信息的终点站
            trainsTickets.GetTrainInfo();
            List<string> trainNoLists= trainsTickets.ReadExcelTrainNo(trainsTickets.TrainsTicketsExcelPath,out List<string>trainStartStationLists, out  List<string> trainEndStationLists);//输出车票信息的列车编号列表，起点站列表，终点站列表
            Console.WriteLine("车票信息存储完毕\n-----------------------------------------------------------------------------------------------------");


            TrainTimeTable trainTimeTable = new TrainTimeTable(trainNoLists[0], trainStartStationLists[0], trainEndStationLists[0], trainsTickets.SelectDateTime);//拿到第一列车的时刻表信息
            trainTimeTable.CreateTrainTimeDataTable();
            Console.WriteLine(string.Format("车次{0}时刻表信息存储完毕\n-------------------------------------------------------------------------------------------------------",trainTimeTable.trainNo));
            Console.ReadKey();
        }
    }

}
