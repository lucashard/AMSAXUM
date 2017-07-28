using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using DashBoard.Models.Forecast;
using DashBoard.Models.Interface;
using DashBoard.ViewModel;

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

        public ActionResult ViewGrid(ForecastViewModel vm)
        {
            var get = _forecast.GetAll().Where(x => (vm.ClientName == null || x.ClientName.ToLower().Contains(vm.ClientName.ToLower()))).ToList();
            var model=new Forecastvm();
            model.ForecastView = get;
            
            return View("_Grid",model);
        }
     
        public ActionResult Create()
        {
            var vm=new ViewModel.ForecastViewModel();
            return View("Create",vm);
        }

        [HttpPost]
        public ActionResult Create(ViewModel.ForecastViewModel vm)
        {
            _forecast.AddInvoiced(vm);
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var result = _forecast.GetAll().Single(x => x.id == id);
            return View(result);
        }
        
        [HttpPost]
        public ActionResult Edit(ViewModel.ForecastViewModel fcForecastViewModel)
        {
            _forecast.Update(fcForecastViewModel);
            return RedirectToAction("ViewGrid");
        }

        public ActionResult Delete(int id)
        {
            _forecast.Delete(id);
            return RedirectToAction("ViewGrid");
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
