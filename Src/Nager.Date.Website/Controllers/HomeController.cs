using Microsoft.AspNetCore.Mvc;
using Nager.Country;
using Nager.Date.Website.Helper;
using Nager.Date.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.Website.Controllers
{
    /// <summary>
    /// Home
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private readonly CountryProvider _countryProvider;

        public HomeController()
        {
            this._countryProvider = new CountryProvider();
        }

        private string GetName(CountryCode countryCode)
        {
            var country = this._countryProvider.GetCountry(countryCode.ToString());
            return country?.CommonName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Countries()
        {
            var countryCodes = (CountryCode[])Enum.GetValues(typeof(CountryCode));

            var availableCountryCodes = from CountryCode countryCode in countryCodes
                                        where DateSystem.GetPublicHolidays(DateTime.Today.Year, countryCode).Any()
                                        select countryCode;

            var countries = availableCountryCodes.Select(countryCode => new KeyValuePair<string, string>(countryCode.ToString(), this.GetName(countryCode)));

            ViewBag.Count = countries.Count();
            ViewBag.Countries = countries;

            return View();
        }

        public ActionResult<IEnumerable<RegionStatisticDto>> RegionStatistic()
        {
            var countryCodes = (CountryCode[])Enum.GetValues(typeof(CountryCode));

            var availableCountryCodes = from CountryCode countryCode in countryCodes
                                        where DateSystem.GetPublicHolidays(DateTime.Today.Year, countryCode).Any()
                                        select countryCode;

            var missingCountryCodes = countryCodes.Except(availableCountryCodes);

            var availableCountries = availableCountryCodes.Select(o => this._countryProvider.GetCountry(o.ToString()));
            var missingCountries = missingCountryCodes.Select(o => this._countryProvider.GetCountry(o.ToString()));

            var regions = (Region[])Enum.GetValues(typeof(Region));

            var regionStatistic = from Region region in regions
                                  where region != Region.None
                                  select new RegionStatisticDto
                                  {
                                      RegionName = region.ToString(),
                                      AvailableCountries = availableCountries.Where(o => o.Region == region)
                                                            .Select(o => CountryHelper.Convert(o))
                                                            .OrderBy(o => o.CommonName)
                                                            .ToArray(),
                                      MissingCountries = missingCountries.Where(o => o.Region == region)
                                                            .Select(o => CountryHelper.Convert(o))
                                                            .OrderBy(o => o.CommonName)
                                                            .ToArray(),
                                  };

            return View(regionStatistic);
        }

        public IActionResult Api()
        {
            return RedirectPermanent("/Api");
        }
    }
}
