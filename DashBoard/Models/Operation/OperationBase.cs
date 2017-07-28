using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DashBoard.ViewModel;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace DashBoard.Models.Operation
{
    public class OperationBase
    {
        protected DataTable ReadExcel(int startcolumn, int endcolumn, int startrow, int endrow, int sheet)
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

        private DataTable DataTable(int startcolumn, int endcolumn, int startrow, int endrow, IList<IList<object>> lista)
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

        public void DownloadExcel<T>(int startcolumn, int endcolumn, int startrow, int endrow, string sheet, List<T> lista)
        {
            try
            {
            Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlApp.Workbooks.Open(System.Web.HttpContext.Current.Server.MapPath(@"/ExcelFolder/Report.xlsx"), Type.Missing, Type.Missing,
                                                   Type.Missing, Type.Missing,
                                                   Type.Missing, Type.Missing,
                                                   Type.Missing, Type.Missing,
                                                   Type.Missing, Type.Missing,
                                                   Type.Missing, Type.Missing,
                                                   Type.Missing, Type.Missing);
                var co = xlWorkBook.Worksheets.Count;
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            List<InvoiceViewModel> copyList = null;
            if (lista.GetType() == typeof(List<InvoiceViewModel>))
            {
                copyList = lista as List<InvoiceViewModel>;
            }

            if (copyList != null)
                foreach (InvoiceViewModel elem in copyList)
                {

                    xlWorkSheet.Cells[startcolumn, 2] = elem.SentToAccount;
                    xlWorkSheet.Cells[startcolumn, 3] = elem.Company;
                    //xlWorkSheet.Cells[2, 1] = "1";
                    //xlWorkSheet.Cells[2, 2] = "One";
                    //xlWorkSheet.Cells[3, 1] = "2";
                    //xlWorkSheet.Cells[3, 2] = "Two";

                    startcolumn ++;


                }
          //  xlWorkBook.SaveAs(System.Web.HttpContext.Current.Server.MapPath(@"/ExcelFolder/Report.xlsx"), XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlApp.Save(System.Web.HttpContext.Current.Server.MapPath(@"/ExcelFolder/Report1.xlsx"));
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        
    }
}