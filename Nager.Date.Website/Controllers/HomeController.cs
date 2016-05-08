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

        public ActionResult PublicHolidays(string countryCode)
        {
            if (String.IsNullOrEmpty(countryCode))
            {
                countryCode = "DE";
            }

            var publicHolidays = DateSystem.GetPublicHoliday(countryCode, DateTime.Now.Year);
            return View(publicHolidays);
        }
    }
}