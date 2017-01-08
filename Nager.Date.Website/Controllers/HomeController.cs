using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace Nager.Date.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var countries = from CountryCode o in Enum.GetValues(typeof(CountryCode)) select new KeyValuePair<string, string>(o.ToString(), GetEnumDescription(o));
            ViewBag.Countries = countries;

            return View();
        }

        public static string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public ActionResult Api()
        {
            return View();
        }
    }
}