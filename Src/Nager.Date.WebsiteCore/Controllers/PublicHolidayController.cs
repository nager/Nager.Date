using Microsoft.AspNetCore.Mvc;
using Nager.Date.WebsiteCore.Models;
using System;
using System.Linq;

namespace Nager.Date.WebsiteCore.Controllers
{
    [Route("[controller]")]
    public class PublicHolidayController : Controller
    {
        [Route("Country/{countrycode}/{year}")]
        [Route("Country/{countrycode}")]
        public IActionResult Country(string countrycode, int year = 0)
        {
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }

            if (!Enum.TryParse(countrycode, true, out CountryCode countryCode))
            {
                return NotFound();
            }

            var isoCountry = Bia.Countries.Iso3166.Countries.GetCountryByAlpha2(countryCode.ToString());

            var item = new PublicHolidayInfo
            {
                Country = isoCountry.ActiveDirectoryName,
                CountryCode = countrycode,
                Year = year,
                PublicHolidays = DateSystem.GetPublicHoliday(countryCode, year).ToList(),
                LongWeekends = DateSystem.GetLongWeekend(countryCode, year).ToList()
            };

            if (item.PublicHolidays.Count > 0)
            {
                return View(item);
            }

            return NotFound();
            //return View("NotFound");
        }
    }
}
