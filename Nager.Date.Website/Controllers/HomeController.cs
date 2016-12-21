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
            CountryCode countryCode;
            if (!Enum.TryParse(id, true, out countryCode))
            {
                return View("NotFound");
            }

            var publicHolidays = DateSystem.GetPublicHoliday(countryCode, DateTime.Now.Year);
            if (publicHolidays?.Count > 0)
            {
                return View(publicHolidays);
            }

            return View("NotFound");
        }
    }
}