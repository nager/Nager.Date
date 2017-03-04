using Nager.Date.Website.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Nager.Date.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var countries = from CountryCode o in Enum.GetValues(typeof(CountryCode)) select new KeyValuePair<string, string>(o.ToString(), EnumExtension.GetEnumDescription(o));
            ViewBag.Countries = countries;

            return View();
        }

        public ActionResult Countries()
        {
            var countries = from CountryCode o in Enum.GetValues(typeof(CountryCode)) select new KeyValuePair<string, string>(o.ToString(), EnumExtension.GetEnumDescription(o));
            ViewBag.Countries = countries;

            return View();
        }

        public ActionResult Api()
        {
            return View();
        }
    }
}