using GetSciEi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("即将将原始数据转换成cplex输入数据格式");
            List<string> trainList = pro_data();//处理原始数据
            Console.WriteLine("原始数据处理完毕");


            ///运行cplex
            System.Diagnostics.Process p = new System.Diagnostics.Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            //是否使用操作系统shell启动
            //接受来自调用程序的输入信息
            //由调用程序获取输出信息
            //重定向标准错误输出

            //不显示程序窗口
            p.Start();//启动程序
            p.StandardInput.AutoFlush = true;
            Console.WriteLine("即将开始启动求解规划的运算引擎");

            p.StandardInput.WriteLine(@"oplrun -p hello" + "&exit");

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
            File.WriteAllText("计算结果.txt", output);
            Console.WriteLine("计算完毕，输出结果为\n————————————————————————————————\n" + output + "\n————————————————————————————————\n");

            output = Regex.Replace(output, @"\s", "");//去除所有的转义字符
            List<string> Objective = GetCenterString(output, "OBJECTIVE", "AAA");//匹配最优解
            foreach (var item in Objective)
            {
                Console.WriteLine($"规划最优解{item}");
            }

            List<string> stocksList = GetCenterString(output, "AAA", "BBB");//车底列表
            List<string> realStocksList = new List<string>();
            foreach (var stock in stocksList)
            {
                realStocksList.Add(stock.Replace("[[", "").Replace("]]", "").Replace("][", "\n"));
            }

            List<DataTable> dts = new List<DataTable>();
            int index = 0;
            foreach (var stock in realStocksList)
            {
                index++;
                DataTable dt = CreateDataTable(stock, trainList);
                dt.TableName = $"车底{index}";
                dts.Add(dt);
            }


            Console.WriteLine("-".PadRight(30, '-'));
            Console.WriteLine("正在将求解结果写入excel文件");
            Console.WriteLine("-".PadRight(30, '-'));
            Excel.TablesToExcel(dts, @"hello\\优化交路方案.xlsx");
            Console.WriteLine("写入完毕");
            Console.WriteLine("-".PadRight(30, '-'));

            Console.WriteLine("将数据转化成可视化数据的格式");

            Directory.SetCurrentDirectory(@".\hello");
            Process process_view_data = new Process { StartInfo = { FileName = @".\优化方案数据处理，方便交路可视化.exe" } };
            process_view_data.Start();
            process_view_data.WaitForExit();
            process_view_data.Dispose();
            //运行路径恢复
            DirectoryInfo currentDirectoryInfoParent = Directory.GetParent(Directory.GetCurrentDirectory());//重新设置主程序运行的路径
            if (currentDirectoryInfoParent.Parent != null)
                Directory.SetCurrentDirectory(currentDirectoryInfoParent.FullName);


            Console.WriteLine("可视化数据格式化完成");
            Console.WriteLine("运行结束，按任意键继续");
            Console.ReadKey();
        }

        /// <summary>
        /// 准备输入模型的数据
        /// </summary>
        /// <returns>输出所有的车次编号</returns>
        public static List<string> pro_data()
        {

            Directory.SetCurrentDirectory(@".\hello");
            Process p = new Process { StartInfo = { FileName = @".\将原始的出发到达信息转换为cplex的调用格式.exe" } };
            p.Start();
            p.WaitForExit();
            p.Dispose();

            //运行路径恢复
            DirectoryInfo currentDirectoryInfoParent = Directory.GetParent(Directory.GetCurrentDirectory());//重新设置主程序运行的路径
            if (currentDirectoryInfoParent.Parent != null)
                Directory.SetCurrentDirectory(currentDirectoryInfoParent.FullName);



            Console.WriteLine("初始数据处理完成，按任意键继续");
            Console.ReadKey();
            DataTable dt = Excel.ExcelToTable(@"hello\\初始数据.xlsx");

            
            //列车运行线的数据
            List<DateTime> strat_times = new List<DateTime>();
            List<DateTime> end_times = new List<DateTime>();
            List<string> trainidList = new List<string>();//记录所有的车次

            ///将时刻数据转换为min单位的整数数据
            foreach (DataRow dr in dt.Rows)
            {
                DateTime satrt_time = DateTime.ParseExact(dr["出发时间(min)"].ToString(), "HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture);//将字符串转换为datetime格式
                strat_times.Add(satrt_time);
                TimeSpan strat_span = satrt_time - strat_times[0];//表示该车次距离第一趟车的时间
                dr["出发时间(min)"] = strat_span.TotalMinutes;
                DateTime end_time = DateTime.ParseExact(dr["终到时间(min)"].ToString(), "HH:mm:ss",
    System.Globalization.CultureInfo.InvariantCulture);
                end_times.Add(end_time);
                TimeSpan end_span = end_time - satrt_time;//表示该车次的运行时间
                dr["终到时间(min)"] = strat_span.TotalMinutes + end_span.TotalMinutes;
            }

            dt.DefaultView.Sort = "编号";//将表格按照车次号排序
            dt = dt.DefaultView.ToTable();

            foreach (DataRow dr in dt.Rows)
            {
                trainidList.Add(dr["编号"].ToString());
            }


            dt.TableName = "trips";

            //车场的数据
            DataTable dt_depots = new DataTable { TableName = "depots" };

            dt_depots.Columns.Add("编号");
            dt_depots.Columns.Add("车底数量");
            dt_depots.Columns.Add("连接车站");
            DataRow dr1 = dt_depots.NewRow();
            dr1["编号"] = 1;
            dr1["车底数量"] = 20;
            dr1["连接车站"] = "上海";
            dt_depots.Rows.Add(dr1);
            DataRow dr2 = dt_depots.NewRow();
            dr2["编号"] = 2;
            dr2["车底数量"] = 10;
            dr2["连接车站"] = "南京";
            dt_depots.Rows.Add(dr2);

            //车底的数据
            DataTable dt_stocks = new DataTable { TableName = "stocks" };
            dt_stocks.Columns.Add("车底编号");
            dt_stocks.Columns.Add("所属车场");

            DataRow dt_stocks_dr1 = dt_stocks.NewRow();
            dt_stocks_dr1["车底编号"] = "1-20";
            dt_stocks_dr1["所属车场"] = "1";
            dt_stocks.Rows.Add(dt_stocks_dr1);

            DataRow dt_stocks_dr2 = dt_stocks.NewRow();
            dt_stocks_dr2["车底编号"] = "21-30";
            dt_stocks_dr2["所属车场"] = "2";
            dt_stocks.Rows.Add(dt_stocks_dr2);

            List<DataTable> dts = new List<DataTable>() { dt, dt_depots, dt_stocks };




            if (File.Exists(@"hello\\Casel_60.xlsx"))//如果原有文件存在的话，删除原有文件
            {
                File.Delete(@"hello\\Casel_60.xlsx");
            }

            Excel.TablesToExcel(dts, @"hello\\Casel_60.xlsx");


            return trainidList;
        }

        /// <summary>
        /// 获取某字符串中间的字符串，非贪婪模式
        /// </summary>
        /// <param name="input">全字符串</param>
        /// <param name="left">左边字符</param>
        /// <param name="right">右边字符</param>
        /// <returns></returns>
        public static List<string> GetCenterString(string input, string left, string right)
        {
            List<string> list = new List<string>();
            Regex reg = new Regex("(?<=" + left + ").*?(?=" + right + ")");
            foreach (Match m in reg.Matches(input))
            {
                list.Add(m.Value);
            }

            return list;
        }

        /// <summary>
        /// 输入一个车底的节点矩阵，输出该矩阵的dt
        /// </summary>
        /// <param name="stock">节点矩阵的字符串</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(string stock, List<string> trainidList)
        {
            DataTable dt = new DataTable();
            int index = 0;//记录节点个数
            foreach (char item in stock)
            {
                string item_temp = item.ToString();
                if (item_temp == "\n")
                {
                    break;
                }
                index++;
            }
            //创建列名
            for (int i = 0; i < index; i++)
            {
                dt.Columns.Add($"节点{i + 1}");
            }

            //添加行，每一次循环是一行
            int flag = 0;
            for (int i = 0; i < index; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)//填充该行的列
                {
                    dr[$"节点{j + 1}"] = stock[flag];
                    if (j == dt.Columns.Count - 1)
                    {
                        flag += 2;
                    }
                    else
                    {
                        flag++;
                    }
                }

                dt.Rows.Add(dr);
            }



            //修改列名
            for (int i = 0; i < index; i++)
            {
                if (i == 0)
                {
                    dt.Columns["节点1"].ColumnName = "上海";
                }
                else if (i == 1)
                {
                    dt.Columns["节点2"].ColumnName = "南京";
                }
                else
                {
                    dt.Columns[$"节点{i + 1}"].ColumnName = (trainidList[i - 2]).ToString();
                }
            }

            return dt;
        }

        /// <summary>
        /// 根据datatable获得列名
        /// </summary>
        /// <param name="dt">表对象</param>
        /// <returns>返回结果的数据列数组</returns>
        public static string[] GetColumnsByDataTable(DataTable dt)
        {
            string[] strColumns = null;


            if (dt.Columns.Count > 0)
            {
                int columnNum = 0;
                columnNum = dt.Columns.Count;
                strColumns = new string[columnNum];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    strColumns[i] = dt.Columns[i].ColumnName;
                }
            }


            return strColumns;
        }
    }
}