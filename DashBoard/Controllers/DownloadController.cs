using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DashBoard.Models.Interface;

namespace DashBoard.Controllers
{
    public class DownloadController : Controller
    {
        //
        // GET: /Download/

        public IInvoice _Invoice;

        public DownloadController(IInvoice invoice)
        {
            _Invoice = invoice;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult File()
        {
            _Invoice.DownloadExcel(20, 2, 3, 4, "Invoice & NOA Follow up", _Invoice.GetAll());
            return View("Index");
        }

        //
        // GET: /Download/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Download/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Download/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Download/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Download/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Download/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Download/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
