using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using DashBoard.Models.Forecast;
using DashBoard.Models.Interface;

namespace DashBoard.Controllers
{
    public class ForecastController : Controller
    {
        private IForecast _forecast;

        public ForecastController(IForecast forecast)
        {
            _forecast = forecast;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtainListResult()
        {
            var model=new ForecastModel();
            BindModel(model);
            var result = new { data = model};
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        private void BindModel(ForecastModel model)
        {
            var get = _forecast.Get();
            model.TotalForecast = Convert.ToDecimal("8805773");
            model.Forecast = get.Total;
            model.TotalClient = Convert.ToDecimal("34");
            model.Client = get.CountTotal;
        }
    }
}
