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

            var isoCountry = Iso3166Countries.GetCountryByAlpha2(countryCode.ToString());

            var item = new PublicHolidayInfo();
            item.Country = isoCountry.ActiveDirectoryName;
            item.CountryCode = countrycode;
            item.Year = year;
            item.PublicHolidays = DateSystem.GetPublicHoliday(countryCode, year).ToList();
            item.LongWeekends = DateSystem.GetLongWeekend(countryCode, year).ToList();

            if (item.PublicHolidays.Count > 0)
            {
                return View(item);
            }

            return View("NotFound");
        }
    }
}
