using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataTable dataTable=   GetTrainTimeTable("G7038");
            //List<DateTime> time = new List<DateTime>();
            //List<TimeSpan> timeSpans = new List<TimeSpan>();

            //List<float> stayTimes=new List<float>();
            //for (int i = 0; i < dataTable.Rows.Count; i++)
            //{
            //    Console.WriteLine(dataTable.Rows[i]["停留时间"]);
            //    if (dataTable.Rows[i]["停留时间"].ToString()=="----")
            //    {
            //        stayTimes.Add(0);
            //    }
            //    else
            //    {
            //        stayTimes.Add(float.Parse(dataTable.Rows[i]["停留时间"].ToString().Replace("分钟","")));
            //    }

            //       //time.Add(DateTime.Parse(dataTable.Rows[i]["出发时间"].ToString()));
            //   }

            //if (int.Parse("G3077".Replace("G",""))%2==0)
            //{
            //    Console.WriteLine("s是");
            //}
            //else
            //{
            //    Console.WriteLine("不是");
            //}

            //for (int i = 0; i < dataTable.Rows.Count; i++)
            //{

            //    if (i==time.Count-1)
            //    {
            //        break;
            //    }
            //    timeSpans.Add(time[i+1]-time[i]);
            //    Console.WriteLine(timeSpans[i]);
            //}

            //Console.WriteLine(time[timeSpans.Count-1]-time[0]);


            //List<float>diff=new List<float>();
            //for (int i = 0; i < timeSpans.Count; i++)
            //{
            //    diff.Add((float)(timeSpans[i].TotalSeconds/(time[time.Count-1]-time[0]).TotalSeconds));
            //    Console.WriteLine(diff[i]);
            //    //Console.WriteLine(diff.Sum());
            //}

            DataSet dataSet = new DataSet();
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


            List<float>timePercentList=new List<float>();
            for (int i = 1; i < stationDistance.Count-1; i++)
            {
                timePercentList.Add(stationDistance[i]/stationDistance[stationDistance.Count-1]);
            }
            Console.ReadKey();
        }




       public static DataTable GetTrainTimeTable(string trainId)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-49O35N0;Initial Catalog=GraduateProject;Integrated Security=True");
                connection.Open();
                string sqlStr = $"SELECT DISTINCT * FROM TrainTimeTable WHERE 车次 ='{trainId}'";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, connection);
                adapter.Fill(dataSet, "TimeTable");
               Console.WriteLine("数据库连接成功");
            }
            catch (Exception exception)
            {
                throw;
            }
            return dataSet.Tables["TimeTable"];
        }
    }
}
