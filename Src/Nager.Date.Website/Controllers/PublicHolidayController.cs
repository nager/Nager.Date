using Bia.Countries;
using Nager.Date.Website.Model;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Nager.Date.Website.Controllers
{
    public class PublicHolidayController : Controller
    {
        public ActionResult Country(string countrycode, int year = 0)
        {
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }

            CountryCode countryCode;
            if (!Enum.TryParse(countrycode, true, out countryCode))
            {
                return View("NotFound");
            }

            var country = Iso3166Countries.GetCountryByAlpha2(countryCode.ToString());

            ViewBag.Country = country.ActiveDirectoryName;
            ViewBag.CountryCode = countrycode;
            ViewBag.Year = year;
            ViewBag.NextYear = year + 1;

            var publicHolidays = DateSystem.GetPublicHoliday(countryCode, year);
            if (publicHolidays?.Count() > 0)
            {
                return View(publicHolidays);
            }

            return View("NotFound");
        }

        public ActionResult CountryJson(string countrycode, int year)
        {
            CountryCode countryCode;
            if (!Enum.TryParse(countrycode, true, out countryCode))
            {
                return Json("Not found");
            }

            var publicHolidays = DateSystem.GetPublicHoliday(countryCode, year);
            if (publicHolidays?.Count() > 0)
            {
                var items = publicHolidays.Select(o => new PublicHoliday(o));
                return Json(items, JsonRequestBehavior.AllowGet);
            }

            return Json("Not found");
        }
    }
}