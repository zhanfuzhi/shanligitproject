/*Code highlighting produced by Actipro CodeHighlighter (freeware)http://www.CodeHighlighter.com/-->/*
 * 作者: 牛腩。
项目地址：http://npoi.codeplex.com/
项目经理的博客：http://tonyqus.blog.51cto.com/
关于NPOI2.0http://tonyqus.blog.51cto.com/2676222/1128075

 * 修改代码：梁晓江 2013-8-22
 * 由于msdn上用的类库版本较低，所以不要拷贝msdn上的代码。
 * 本页代码是从官方下载的NPOI 2.0版本适配的代码。可以适用于excel2003、2007、2010
 * 引用的类库下载地址。
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.POIFS;
using NPOI.Util;
using NPOI.SS.UserModel;
namespace Shanlitech_Location
{
    public class ExcelHelper
    {
        /**
下载excel代码。
DataTable table = new DataTable();
MemoryStream ms = DataTableRenderToExcel.RenderDataTableToExcel(table) as MemoryStream;
Response.AddHeader("Content-Disposition", string.Format("attachment; filename=Download.xls"));
Response.BinaryWrite(ms.ToArray());
ms.Close();
ms.Dispose();
上传excel取数据用代码
if (this.fuUpload.HasFile)
{
    // 讀取 Excel 資料流並轉換成 DataTable。
    DataTable table = DataTableRenderToExcel.RenderDataTableFromExcel(this.fuUpload.FileContent, 1, 0);
    this.gvExcel.DataSource = table;
    this.gvExcel.DataBind();
}
         * **/
        /// <summary>
        /// /
        /// </summary>
        /// <param name="SourceTable"></param>
        /// <returns></returns>
        public static Stream RenderDataTableToExcel(DataTable SourceTable)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);

            // handling header.
            foreach (DataColumn column in SourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in SourceTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in SourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }

                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;

            return ms;
        }

        public static void RenderDataTableToExcel(DataTable SourceTable, string FileName)
        {
            MemoryStream ms = RenderDataTableToExcel(SourceTable) as MemoryStream;
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            byte[] data = ms.ToArray();

            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();

            data = null;
            ms = null;
            fs = null;
        }
        /// <summary>
        /// 根据数据流级sheet名称进行读取
        /// </summary>
        /// <param name="ExcelFileStream">文件流</param>
        /// <param name="SheetIndex">sheet名称</param>
        /// <param name="HeaderRowIndex">header所在行编号，从0开始</param>
        /// <returns></returns>
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex)
        {
            IWorkbook workbook = WorkbookFactory.Create(ExcelFileStream);
            ISheet sheet = workbook.GetSheet(SheetName);

            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                table.Rows.Add(dataRow);
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }
        /// <summary>
        /// 根据数据流级sheet索引和sheet中的表格头进行读取
        /// </summary>
        /// <param name="ExcelFileStream">文件流</param>
        /// <param name="SheetIndex">sheet编号，从0开始</param>
        /// <param name="HeaderRowIndex">header所在行编号，从0开始</param>
        /// <returns></returns>
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex)
        {
            IWorkbook workbook = WorkbookFactory.Create(ExcelFileStream);
            ISheet sheet = workbook.GetSheetAt(SheetIndex);

            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            string strHZ = "一二三四五六七八九十";
            string strSZ = "123456789";

            string strLBMC = "";//类别名称
            string strKMMC = "";//科目名称
            string strXMMC = "";//项目名称
            string strQCMC = "";//器材名称
            string strXMJE = "";//项目金额

            //标题列
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            DataColumn column10 = new DataColumn();
            column10.ColumnName = "10";
            table.Columns.Add(column10);
            DataColumn column11 = new DataColumn();
            column11.ColumnName = "11";
            table.Columns.Add(column11);
            DataColumn column12 = new DataColumn();
            column12.ColumnName = "12";
            table.Columns.Add(column12);

            int rowCount = sheet.LastRowNum;

            //从第一个类别开始循环
            for (int i = (sheet.FirstRowNum + 5); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);

                string strNum1 = row.GetCell(0).ToString().Substring(0, 1);
                string strNum2 = "无";
                if (row.GetCell(0).ToString().Length > 2)
                {
                    strNum2 = row.GetCell(0).ToString().Substring(1, 1);
                }


                //判断是否为类别名称 规则：一、二...
                if (strHZ.IndexOf(strNum1) >= 0)
                {
                    strLBMC = row.GetCell(1).ToString();//类别名称
                    continue;
                }
                //判断是否科目名称  规则：(一)、(二)...
                else if (strNum1.Equals("(") && strHZ.IndexOf(strNum2) >= 0)
                {
                    strKMMC = row.GetCell(1).ToString();//科目名称
                    continue;
                }
                //判断是否为项目名称 规则：(1)、(2)...
                else if (strNum1.Equals("(") && strSZ.IndexOf(strNum2) >= 0)
                {
                    strXMMC = row.GetCell(1).ToString();//项目名称
                    strXMJE = row.GetCell(6).ToString();//金额
                    continue;
                }
                //判断是否为器材名称 规则：1、2...
                else if (strSZ.IndexOf(strNum1) >= 0)
                {
                    //如果不是同一项目的第一个器材名称，则将项目名称清空，前台则不需要向项目预算表插入数据 
                    if (!strNum1.Equals("1"))
                    {
                        strXMMC = "";
                    }
                    DataRow dataRow = table.NewRow();
                    dataRow[0] = strLBMC;//类别名称
                    dataRow[1] = strKMMC;//科目名称
                    dataRow[2] = strXMMC;//项目名称
                    dataRow[3] = strXMJE;//项目金额
                    dataRow[4] = row.GetCell(1).ToString();//器材名称
                    dataRow[5] = row.GetCell(2).ToString();//预算收入
                    dataRow[6] = row.GetCell(3).ToString();//计量单位
                    dataRow[7] = row.GetCell(4).ToString();//单价
                    dataRow[8] = row.GetCell(5).ToString();//数量
                    dataRow[9] = row.GetCell(6).ToString();//金额
                    dataRow[10] = row.GetCell(7).ToString();//供货单位
                    dataRow[11] = row.GetCell(8).ToString();//预算余额
                    dataRow[12] = row.GetCell(9).ToString();//备注
                    table.Rows.Add(dataRow);
                }

            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        /// <summary>读取excel
        /// 默认第一行为标头
        /// </summary>
        /// <param name="path">excel文档路径</param>
        /// <returns></returns>
        public static DataTable RenderDataTableFromExcel(string path)
        {
            DataTable dt = new DataTable();

            IWorkbook workbook = WorkbookFactory.Create(path);

            ISheet sheet = workbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                dt.Rows.Add(dataRow);
            }
            return dt;
        }
    }
}