using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DashBoard.Models.Interface;

namespace DashBoard.Controllers
{
    public class UploadController : BaseController
    {
        //
        // GET: /Upload/
        private IContractRenew _contractRenew;
        private IInvoice _invoice;
        private IForecast _forecast;

        public UploadController(IContractRenew contractRenew,IInvoice invoice,IForecast forecast)
        {
            _contractRenew = contractRenew;
            _invoice = invoice;
            _forecast = forecast;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                if (System.IO.File.Exists(Path.Combine(Server.MapPath("/ExcelFolder/"), fileName)))
                {
                     System.IO.File.Delete(Path.Combine(Server.MapPath("/ExcelFolder/"), fileName));
                }
                var path = Path.Combine(Server.MapPath("/ExcelFolder/"), fileName);
                file.SaveAs(path);
            }
            _forecast.Import();
            _invoice.Import();
            _contractRenew.Import();
           

            return RedirectToAction("Index","Home");
        }

    }
}
