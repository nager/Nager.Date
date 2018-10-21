using Microsoft.AspNetCore.Mvc;
using Nager.Date.WebsiteCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Nager.Date.WebsiteCore.Controllers
{
    public class HomeController : Controller
    {
        private string GetName(CountryCode countryCode)
        {
            var country = Bia.Countries.Iso3166.Countries.GetCountryByAlpha2(countryCode.ToString());
            return country.ActiveDirectoryName;
        }

        public IActionResult Index()
        {
            var items = new List<CountryInfo>();
            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var item = new CountryInfo();
                item.Name = this.GetName(countryCode);
                item.CountryCode = countryCode.ToString();
                item.PublicHolidayCount = DateSystem.GetPublicHoliday(countryCode, DateTime.Now.Year).GroupBy(o => o.Date).Count();

                if (item.PublicHolidayCount > 0)
                {
                    items.Add(item);
                }
            }

            return View(items);
        }

        public IActionResult Countries()
        {
            var countries = from CountryCode o in Enum.GetValues(typeof(CountryCode))
                            where DateSystem.GetPublicHoliday(o, DateTime.Today.Year).Any()
                            select new KeyValuePair<string, string>(o.ToString(), GetName(o));

            ViewBag.Countries = countries;

            return View();
        }

        public IActionResult Api()
        {
            return RedirectPermanent("/Api");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
