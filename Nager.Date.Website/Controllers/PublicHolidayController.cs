using System;
using System.Web.Mvc;

namespace Nager.Date.Website.Controllers
{
    public class PublicHolidayController : Controller
    {
        public ActionResult Country(string id)
        {
            CountryCode countryCode;
            if (!Enum.TryParse(id, true, out countryCode))
            {
                return View("NotFound");
            }

            ViewBag.Country = id;

            var publicHolidays = DateSystem.GetPublicHoliday(countryCode, DateTime.Now.Year);
            if (publicHolidays?.Count > 0)
            {
                return View(publicHolidays);
            }

            return View("NotFound");
        }
    }
}