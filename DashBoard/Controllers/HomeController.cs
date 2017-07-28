using System.Web.Mvc;
using DashBoard.Models.Login;
using Modelo;

namespace DashBoard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var conexion = new ContextManager();
            conexion.Database.Initialize(true);

            if (Session["user"] != null)
            {
                if (Session["user"].Equals("henry@amsaxum.com") /*&& LoginStatic.Password.Equals("1973")*/)
                {
                    
                return View();
            }
            }
            return RedirectToAction("Index", "Login");
        }
        public ActionResult About()
        {
            return View();
        }
    }
}
