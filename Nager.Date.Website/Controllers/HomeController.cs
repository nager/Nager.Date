using Bia.Countries;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace Nager.Date.Website.Controllers
{
    public class HomeController : Controller
    {
        private string GetName(CountryCode countryCode)
        {
            var country = Iso3166Countries.GetCountryByAlpha2(countryCode.ToString());
            return country.ActiveDirectoryName;
        }

        public ActionResult Index()
        {
            var countries = from CountryCode o in Enum.GetValues(typeof(CountryCode)) select new KeyValuePair<string, string>(o.ToString(), GetName(o));
            ViewBag.Countries = countries;

            return View();
        }

        public ActionResult Countries()
        {
            var countries = from CountryCode o in Enum.GetValues(typeof(CountryCode)) select new KeyValuePair<string, string>(o.ToString(), GetName(o));
            ViewBag.Countries = countries;

            return View();
        }

        public ActionResult Api()
        {
            return View();
        }
    }
}