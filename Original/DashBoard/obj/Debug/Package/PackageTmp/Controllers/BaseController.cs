using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel; 

namespace DashBoard.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        public DataTable ReadExcel(int startcolumn, int endcolumn, int startrow, int endrow,int sheet)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            
            DataTable table = new DataTable();
            int column = 0, pivote=startcolumn;
            while (pivote<=endcolumn)
            {
                column = column + 1;
                table.Columns.Add("colunmn" + column,typeof(string));
                pivote = pivote + 1;
                column = column + 1;
            }
           
            int rCnt = 0;
            int cCnt = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(Server.MapPath(@"~/ExcelFolder/PERFORMANCE DASHBOARD Rev3.xlsx"), 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(sheet);

            range = xlWorkSheet.UsedRange;
           
            for (rCnt = startrow; rCnt <= endrow; rCnt++)
            {
                column = -1;
                DataRow _ravi = table.NewRow();
                for (cCnt = startcolumn; cCnt <= endcolumn; cCnt++)
                {
                    column=column + 1;
                    var str = (range.Cells[rCnt, cCnt] as Excel.Range).Text;
                    _ravi[column] = str;
                }
                table.Rows.Add(_ravi);
            }
            
            xlWorkBook.Close(0);
            xlApp.Quit();
          
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            return table;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception )
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        } 
    }
}
