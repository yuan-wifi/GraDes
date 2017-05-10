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
        public static bool SaveResultToExcel()
        {
            try
            { //HSSF可以读取xls格式的Excel文件
                IWorkbook workbook = new HSSFWorkbook();
                //XSSF可以读取xlsx格式的Excel文件
                //IWorkbook workbook = new XSSFWorkbook();

                //Excel文件至少要有一个工作表sheet
                ISheet sheet = workbook.CreateSheet("工作表");
                //创建行
                for (int i = 0; i < 10; i++)
                {
                    IRow row = sheet.CreateRow(i); //i表示了创建行的索引，从0开始
                                                   //创建单元格
                    for (int j = 0; j < 5; j++)
                    {
                        ICell cell = row.CreateCell(j);  //同时这个函数还有第二个重载，可以指定单元格存放数据的类型
                        cell.SetCellValue(i.ToString() + j.ToString());
                    }
                }
                //表格制作完成后，保存
                //创建一个文件流对象
                using (FileStream fs = File.Open((Environment.SpecialFolder.DesktopDirectory) + "test.xls", FileMode.OpenOrCreate))
                {
                    workbook.Write(fs);
                    //最后记得关闭对象
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
