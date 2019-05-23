using System;
using System.Collections.Generic;
using System.Data;

namespace 沪宁高铁数据
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            Console.WriteLine("请输入FromStation（SHH || NJH）：");
            string  from_station=Console.ReadLine();
            Console.WriteLine("请输入EndStation（SHH || NJH）：");
            string end_station = Console.ReadLine();
            Console.WriteLine("请输入爬取数据的日期距离今天的天数（0~30）：");
            int delta_day =int.Parse( Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine($"12306爬虫参数为：from_station={from_station}");
            Console.WriteLine($"12306爬虫参数为：end_station={end_station}");
            Console.WriteLine($"12306爬虫参数为：delta_day={delta_day}");

            ///车次及车票数据爬取部分
            TrainsTickets trainsTickets = new TrainsTickets
            {
                SelectDateTime = DateTime.Now.AddDays(delta_day),//车票信息的查询时间
                FromStation =from_station,//车票信息的起点站
                ToStation = end_station //车票信息的终点站
            };
            ///爬取信息并存储excel
            trainsTickets.GetTrainInfo(out var trainsTable);
            List<string> trainNoLists = trainsTickets.ReadExcelTrainNo(trainsTickets.TrainsTicketsExcelPath, out List<string> trainStartStationLists, out List<string> trainEndStationLists);
            //输出车票信息的列车编号列表，起点站列表，终点站列表
            ///将数据存储进sql_sever
            trainsTickets.DataTable2SqlServer(trainsTable);//将dataTable存进sqlServer
            Console.WriteLine("车票信息存储完毕\n-----------------------------------------------------------------------------------------------------");


            Console.WriteLine("按下回车键进行爬取每一个车次的时刻表信息(*^_^*)");
            Console.ReadKey();

            ///时刻表爬取部分
            List<string> bugTrain = new List<string>();
            for (int i = 0; i < trainNoLists.Count; i++)
            {


                //拿到第一列车的时刻表信息
                TrainTimeTable trainTimeTable = new TrainTimeTable(trainNoLists[i], trainStartStationLists[i], trainEndStationLists[i], trainsTickets.SelectDateTime);
                try
                {
                    DataTable dataTable = trainTimeTable.CreateTrainTimeDataTable();
                    trainTimeTable.DataTable2SqlServer(dataTable);
                    Console.WriteLine(
        $"车次{trainTimeTable.TrainNo}时刻表信息存储完毕\n-------------------------------------------------------------------------------------------------------");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    bugTrain.Add(trainNoLists[i]);
                }

            }




            Console.ReadKey();
        }
    }
}