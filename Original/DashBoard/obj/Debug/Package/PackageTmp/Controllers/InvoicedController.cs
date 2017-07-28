using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DashBoard.Controllers
{
    public class InvoicedController : BaseController
    {
        //
        // GET: /Invoiced/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtainListResult()
        {
            var table = ReadExcel(33, 33, 4, 15, 4);
            var lista = new List<decimal>();
            foreach (DataRow row in table.Rows)
            {
                foreach (string item in row.ItemArray)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        lista.Add(Convert.ToDecimal(item.Substring(1).Replace(".",",")));
                    }
                }
            }
            
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}