using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace DashBoard.Models.Operation
{
    public class OperationBase
    {
        public DataTable ReadExcel(int startcolumn, int endcolumn, int startrow, int endrow, int sheet)
        {
            // xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Range range;

            var table = new DataTable();
            int column = 0, pivote = startcolumn;
            while (pivote <= endcolumn)
            {
                column = column + 1;
                table.Columns.Add("colunmn" + column, typeof(string));
                pivote = pivote + 1;
            }

            var rCnt = 0;
            var cCnt = 0;

            Application xlApp = new Application();
            xlWorkBook = xlApp.Workbooks.Open(System.Web.HttpContext.Current.Server.MapPath(@"/ExcelFolder/PERFORMANCE DASHBOARD Rev6.xlsx"));
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(sheet);

            range = xlWorkSheet.UsedRange;

            for (rCnt = startrow; rCnt <= endrow; rCnt++)
            {
                column = -1;
                var _ravi = table.NewRow();
                for (cCnt = startcolumn; cCnt <= endcolumn; cCnt++)
                {
                    column = column + 1;
                    var str = (range.Cells[rCnt, cCnt] as Range).Text;
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
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        
        public DataTable DataTable(int startcolumn, int endcolumn, int startrow, int endrow, IList<IList<object>> lista)
        {
            var table = new DataTable();
            int column = 0, pivote = startcolumn;
            while (pivote <= endcolumn)
            {
                column = column + 1;
                table.Columns.Add("colunmn" + column, typeof(string));
                pivote = pivote + 1;
                column = column + 1;
            }

            var rCnt = 0; var cCnt = 0;
            int indice = 0;
            for (rCnt = startrow; rCnt < endrow; rCnt++)
            {
                column = -1;
                var _ravi = table.NewRow();

                int key = 0;
                for (cCnt = startcolumn; cCnt <= endcolumn; cCnt++)
                {
                    column = column + 1;
                    var str = lista[indice][key];
                    _ravi[column] = str;
                    key += 1;
                }
                table.Rows.Add(_ravi);
                indice += 1;
            }

            return table;
        }
    }
}