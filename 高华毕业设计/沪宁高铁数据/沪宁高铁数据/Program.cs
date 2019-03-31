using System;
using System.Collections.Generic;
using System.Data;

namespace 沪宁高铁数据
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TrainsTickets trainsTickets = new TrainsTickets
            {
                //上海到南京
                //SelectDateTime = DateTime.Now.AddDays(3), FromStation = "SHH", ToStation = "NJH"

                //南京到上海
                 SelectDateTime = DateTime.Now.AddDays(3), FromStation = "NJH", ToStation = "SHH"
            };
            //车票信息的查询时间
            //车票信息的起点站
            //车票信息的终点站
            trainsTickets.GetTrainInfo(out var trainsTable);
            List<string> trainNoLists = trainsTickets.ReadExcelTrainNo(trainsTickets.TrainsTicketsExcelPath, out List<string> trainStartStationLists, out List<string> trainEndStationLists);//输出车票信息的列车编号列表，起点站列表，终点站列表

            trainsTickets.DataTable2SqlServer(trainsTable);//将dataTable存进sqlServer

            Console.WriteLine("车票信息存储完毕\n-----------------------------------------------------------------------------------------------------");



            // ReSharper disable once CollectionNeverQueried.Local
            List<string>bugTrain=new List<string>();
            for (int i = 0; i < trainNoLists.Count; i++)
            {
                TrainTimeTable trainTimeTable = new TrainTimeTable(trainNoLists[i], trainStartStationLists[i], trainEndStationLists[i], trainsTickets.SelectDateTime);//拿到第一列车的时刻表信息
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