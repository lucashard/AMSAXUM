using System.Timers;
using System.Web.Mvc;
using DashBoard.Models.Login;

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

        [HttpPost]
        public ActionResult Index(Login model)
        {
            if (model.UserName.Equals("henry@amsaxum.com") && model.Password.Equals("1973"))
            {
                //LoginStatic.UserName = model.UserName;
                //LoginStatic.Password = model.Password;
                Session["user"] = "henry@amsaxum.com";
                Session.Timeout = 10;
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }

  
        [HttpGet]
        public JsonResult GoExit()
        {
            Timer t =new Timer();
            
            Session["user"] = null;
            return Json(null);
        }
    }
}
