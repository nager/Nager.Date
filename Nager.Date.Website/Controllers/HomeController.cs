using System;
using System.Web.Mvc;

namespace Nager.Date.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Api()
        {
            return View();
        }
    }
}