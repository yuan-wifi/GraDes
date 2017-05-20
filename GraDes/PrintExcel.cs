using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace test
{
    class PrintExcel
    {
        DataBase db = new DataBase();
        DataTable dt = new DataTable();
        public static bool SaveResultToExcel(int pici, DataTable dt)
        {
            try
            {
                //HSSF可以读取xls格式的Excel文件
                IWorkbook workbook = new HSSFWorkbook();
                //XSSF可以读取xlsx格式的Excel文件
                //IWorkbook workbook = new XSSFWorkbook();
                //创建文件保存路径
                string fileSavePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\投票结果(第" + pici + "轮).xls";
                //Excel文件至少要有一个工作表sheet
                ISheet sheet = workbook.CreateSheet("投票结果");
                //设置表头
                sheet.CreateRow(0);
                sheet.GetRow(0).CreateCell(0).SetCellValue("姓名");
                sheet.GetRow(0).CreateCell(1).SetCellValue("身份证号码");
                sheet.GetRow(0).CreateCell(2).SetCellValue("地市州");
                sheet.GetRow(0).CreateCell(3).SetCellValue("单位名称");
                sheet.GetRow(0).CreateCell(4).SetCellValue("拟评审专业技术职务");
                sheet.GetRow(0).CreateCell(5).SetCellValue("评委会名称");
                sheet.GetRow(0).CreateCell(6).SetCellValue("评委会总人数");
                sheet.GetRow(0).CreateCell(7).SetCellValue("评委会参加投票人数");
                sheet.GetRow(0).CreateCell(8).SetCellValue("评委会同意人数");
                sheet.GetRow(0).CreateCell(9).SetCellValue("评委会不同意人数");
                sheet.GetRow(0).CreateCell(10).SetCellValue("评委会弃权人数");
                sheet.GetRow(0).CreateCell(11).SetCellValue("评委会表决结果");
                //创建行
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    IRow row = sheet.CreateRow(i); //i表示创建行的索引，从0开始
                                                   //创建单元格
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row.CreateCell(j);  //同时这个函数还有第二个重载，可以指定单元格存放数据的类型
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                //表格制作完成后，保存
                //创建一个文件流对象
                using (FileStream fs = File.OpenWrite(fileSavePath))
                {
                    workbook.Write(fs);
                    //关闭对象
                    workbook.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
        public static bool SaveCodeToExcel(DataTable dt)
        {
            try
            {
                //HSSF可以读取xls格式的Excel文件
                IWorkbook workbook = new HSSFWorkbook();
                //XSSF可以读取xlsx格式的Excel文件
                //IWorkbook workbook = new XSSFWorkbook();
                //创建文件保存路径
                string fileSavePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\邀请码.xls";
                //Excel文件至少要有一个工作表sheet
                ISheet sheet = workbook.CreateSheet("邀请码");
                //设置表头
                sheet.CreateRow(0);
                sheet.GetRow(0).CreateCell(0).SetCellValue("邀请码");

                //创建行
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row = sheet.CreateRow(i); //i表示创建行的索引，从0开始
                                                   //创建单元格
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row.CreateCell(j);  //同时这个函数还有第二个重载，可以指定单元格存放数据的类型
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                //表格制作完成后，保存
                //创建一个文件流对象
                using (FileStream fs = File.OpenWrite(fileSavePath))
                {
                    workbook.Write(fs);
                    //关闭对象
                    workbook.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
    }
}
