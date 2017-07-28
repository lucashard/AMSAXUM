using System;
using System.Timers;
using System.Web.Mvc;
using DashBoard.Models.Login;
using Google.GData.Spreadsheets;

namespace DashBoard.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["user"]==null)
            {
                
                return View(new Login());
            }
            return View("Index");
        }

        public bool Estado { get; set; }


        public  void DisplayTimeEvent(object source, ElapsedEventArgs e)
        {
            if (!Estado)
            {
                RedirectToAction("Index", "Login");
            }
            else
            {
                
            }
            Estado = true;
        }

        [HttpPost]
        public ActionResult Index(Login model)
        {
            if (model.UserName.Equals("henry@amsaxum.com") && model.Password.Equals("1973"))
            {
                //LoginStatic.UserName = model.UserName;
                //LoginStatic.Password = model.Password;
                Session["user"] = "henry@amsaxum.com";
                
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }

  
        [HttpGet]
        public JsonResult Conexion()
        {
            Estado = false;
            
            Session["user"] = null;
            return Json("",JsonRequestBehavior.AllowGet);
        }
    }
}
