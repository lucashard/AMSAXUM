using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using DashBoard.Models.Interface;
using DashBoard.ViewModel;
using Modelo.Entity;

namespace DashBoard.Controllers
{
    public class ContractRenewalsController : Controller
    {
        private IContractRenew _contractRenew;

        public ContractRenewalsController(IContractRenew iContractRenew)
        {
            _contractRenew = iContractRenew;

        }

        public ActionResult ViewGrid()
        {
            return View("Grid");
        }

        public ActionResult ViewGridData(DataContractRenewalsViewModel vm)
        {
            var contraclist=_contractRenew.GetAllList().Where(x => (vm.Business  == null || x.Business.ToLower().Contains(vm.Business.ToLower()))).ToList(); 
            DataContractRenewalsVm result=new DataContractRenewalsVm();
            result.List = contraclist;
            return View("ViewGrid",result);
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grid()
        {
            return PartialView("Grid");
        }

        public ActionResult GridPending()
        {
            return PartialView("_GridPending");
        }

        [HttpPost]
        public string Create([Bind(Exclude = "Id")] ContractRenewals objTodo)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    _contractRenew.AddContracto(objTodo);
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        [HttpPost]
        public string CreatePending([Bind(Exclude = "Id")] Pending objTodo)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    _contractRenew.AddPending(objTodo);
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        public string Edit(ContractRenewals objTodo)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    _contractRenew.Edit(objTodo);
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        public string EditPending(Pending objTodo)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    _contractRenew.EditPending(objTodo);
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        public string Delete(int Id)
        {
            _contractRenew.Delete(Id);
            return "Deleted successfully";
        }

        public string DeletePending(int Id)
        {
            _contractRenew.DeletePending(Id);
            return "Deleted successfully";
        }

        public JsonResult Load(string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var lista = _contractRenew.GetAll();
            int totalRecords = lista.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                lista = lista.OrderByDescending(s => s.Business);
                lista = lista.Skip(pageIndex * pageSize).Take(pageSize) ;
            }
            else
            {
                lista =lista.OrderBy(s => s.Business);
                lista = lista.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = lista
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadPending(string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var lista = _contractRenew.GetAllPending();
            int totalRecords = lista.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                lista = lista.OrderByDescending(s => s.Business);
                lista = lista.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                lista = lista.OrderBy(s => s.Business);
                lista = lista.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = lista
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtainListResultGoogle()
        {
            var lista = Lista();

            var pending = _contractRenew.GetPending();
            var lista2 = new List<int>();
            lista2.Add(pending.Column1.Value);
            lista2.Add(pending.Column2.Value);
            lista2.Add(pending.Column3.Value);
            lista2.Add(pending.Column4.Value);
            lista2.Add(pending.Column5.Value);
            lista2.Add(pending.Column6.Value);
            lista2.Add(pending.Column7.Value);
            lista2.Add(pending.Column8.Value);
            lista2.Add(pending.Column9.Value);
            lista2.Add(pending.Column10.Value);
            lista2.Add(pending.Column11.Value);
            lista2.Add(pending.Column12.Value);

            var result = new { data = lista,pending=lista2 };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private List<int> Lista()
        {
            var lista = new List<int>();
            var contract = _contractRenew.Get();
            lista.Add(contract.Column1.Value);
            lista.Add(contract.Column2.Value);
            lista.Add(contract.Column3.Value);
            lista.Add(contract.Column4.Value);
            lista.Add(contract.Column5.Value);
            lista.Add(contract.Column6.Value);
            lista.Add(contract.Column7.Value);
            lista.Add(contract.Column8.Value);
            lista.Add(contract.Column9.Value);
            lista.Add(contract.Column10.Value);
            lista.Add(contract.Column11.Value);
            lista.Add(contract.Column12.Value);
            return lista;
        }
    }
}
