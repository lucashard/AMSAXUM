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
            return View(new Login());
        }

        [HttpPost]
        public ActionResult Index(Login model)
        {
            if (model.UserName.Equals("henry@northbridgeconsultants.com") && model.Password.Equals("1973"))
            {
                LoginStatic.UserName = model.UserName;
                LoginStatic.Password = model.Password;
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }

        [HttpGet]
        public JsonResult GoExit()
        {
            LoginStatic.UserName = null;
            return Json(null);
        }
    }
}
