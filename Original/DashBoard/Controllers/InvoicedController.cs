using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Web.Mvc;

namespace DashBoard.Controllers
{
    public class InvoicedController : BaseController
    {
        //
        // GET: /Invoiced/

        public ActionResult Index()
        {
            this.ReadExcelGoogle();
            return View();
        }

        [HttpGet]
        public ActionResult ObtainListResult()
        {
            var lista = new List<decimal>();
            
            try
            {
                
                var table = ReadExcel(33, 33, 4, 15, 4);

                foreach (DataRow row in table.Rows)
                {
                    foreach (string item in row.ItemArray)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            lista.Add(Convert.ToDecimal(item.Substring(1).Replace(".", ",")));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               // string dir = Environment.CurrentDirectory+@"\Error.txt";// @"C:\inetpub\wwwroot\DataBoard\Error.txt";  // folder location
               // //if (!Directory.Exists(dir))
               // //{
               //     CreateError(dir, ex);
               //// }
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        private void CreateError(string dir, Exception ex)
        {
            //Directory.CreateDirectory(dir);

            string ruta = AppDomain.CurrentDomain.BaseDirectory + @"Error.txt";
            //var ruta = System.IO.Path.GetDirectoryName(
            //    System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            //var r=ruta.ToString()+ @"\Error.txt";     
            System.IO.File.WriteAllText(ruta,
                "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
            string New = Environment.NewLine + "-----------------------------------------------------------------------------" +
                         Environment.NewLine;
            System.IO.File.AppendAllText(ruta, New);
        }
    }
}