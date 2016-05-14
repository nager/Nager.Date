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

        public ActionResult PublicHolidays(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                id = "DE";
            }

            var publicHolidays = DateSystem.GetPublicHoliday(id, DateTime.Now.Year);
            if (publicHolidays?.Count > 0)
            {
                return View(publicHolidays);
            }

            return View("NotFound");
        }
    }
}