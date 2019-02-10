using Microsoft.AspNetCore.Mvc;
using Nager.Date.WebsiteCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Nager.Date.WebsiteCore.Controllers
{
    /// <summary>
    /// Home
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private string GetName(CountryCode countryCode)
        {
            var country = new Country.CountryProvider().GetCountry(countryCode.ToString());
            return country.CommonName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Countries()
        {
            var countries = from CountryCode o in Enum.GetValues(typeof(CountryCode))
                            where DateSystem.GetPublicHoliday(DateTime.Today.Year, o).Any()
                            select new KeyValuePair<string, string>(o.ToString(), GetName(o));

            ViewBag.Countries = countries;

            return View();
        }

        public IActionResult Api()
        {
            return RedirectPermanent("/Api");
        }
    }
}
