using Bia.Countries;
using Nager.Date.Website.Model;
using System;
using System.Collections.Generic;
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

        public ActionResult Countries()
        {
            var countries = from CountryCode o in Enum.GetValues(typeof(CountryCode))
                            where DateSystem.GetPublicHoliday(o, DateTime.Today.Year).Any()
                            select new KeyValuePair<string, string>(o.ToString(), GetName(o));

            ViewBag.Countries = countries;

            return View();
        }

        public ActionResult Api()
        {
            return View();
        }
    }
}
