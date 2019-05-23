using System;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace GetSciEi
{
    internal class Excel
    {
        /// <summary>
        /// Excel导入成Datable
        /// </summary>
        /// <param name="file">导入路径(包含文件名与扩展名)</param>
        /// <returns></returns>
        public static DataTable ExcelToTable(string file)
        {
            DataTable dt = new DataTable();
            string fileExt = Path.GetExtension(file)?.ToLower();
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式
                IWorkbook workbook;
                if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(fs); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(fs); } else { workbook = null; }
                if (workbook == null) { return null; }
                ISheet sheet = workbook.GetSheetAt(0);

                //表头
                IRow header = sheet.GetRow(sheet.FirstRowNum);
                List<int> columns = new List<int>();
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = GetValueType(header.GetCell(i));
                    if (obj == null || obj.ToString() == string.Empty)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                    }
                    else
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    columns.Add(i);
                }
                //数据
                for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    DataRow dr = dt.NewRow();
                    var hasValue = false;
                    foreach (int j in columns)
                    {
                        dr[j] = GetValueType(sheet.GetRow(i).GetCell(j));
                        if (dr[j] != null && dr[j].ToString() != string.Empty)
                        {
                            hasValue = true;
                        }
                    }
                    if (hasValue)
                    {
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Datable导出成Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file">导出路径(包括文件名与扩展名)</param>
        public static void TablesToExcel(List<DataTable> dts, string file)
        {
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file)?.ToLower();
            if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(); } else { workbook = null; }
            if (workbook == null) { return; }

            int index = 0;
            foreach (DataTable dt in dts)
            {
                index++;
                ISheet sheet = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet($"Sheet{index}") : workbook.CreateSheet(dt.TableName);
                //表头
                IRow row = sheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = row.CreateCell(i);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                }

                ICellStyle style = workbook.CreateCellStyle();
                style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");//设置单元格数字格式

                //数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row1 = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        var temp = dt.Rows[i][j].ToString();
                        if (double.TryParse(temp, out double convertResult))
                        {
                            cell.SetCellValue(Convert.ToInt32(convertResult));
                            cell.CellStyle = style;
                        }
                        else
                        {
                            cell.SetCellValue(temp);
                        }
                    }
                }

                //转为字节数组
                MemoryStream stream = new MemoryStream();
                workbook.Write(stream);
                byte[] buf = stream.ToArray();

                //保存为Excel文件
                using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Write(buf, 0, buf.Length);
                    fs.Flush();
                }
            }
        }

        /// <summary>
        /// 获取单元格类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            if (cell.CellType == CellType.Blank)
                return null;
            else if (cell.CellType == CellType.Boolean)
                return cell.BooleanCellValue;
            else if (cell.CellType == CellType.Numeric)
                return cell.NumericCellValue;
            else if (cell.CellType == CellType.String)
                return cell.StringCellValue;
            else if (cell.CellType == CellType.Error)
                return cell.ErrorCellValue;
            else
                return "=" + cell.CellFormula;
        }
    }
}