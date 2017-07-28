﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DashBoard.Controllers
{
    public class PendingRenewalsController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtainListResult()
        {
            var table = ReadExcel(7, 7, 3, 14, 5);
            var total = (from co in table.AsEnumerable()
                         where !co.Field<string>("colunmn1").Equals(string.Empty)
                            select co.Field<string>("colunmn1")).ToList();

            var result = new { data = total.Select(int.Parse).ToArray() };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
