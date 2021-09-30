using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nager.Date.Website.Helper;
using Nager.Date.Website.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.Website.Controllers
{
    /// <summary>
    /// Country V2
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "Country V2")]
    [Route("api/v2")]
    public class CountryV2Controller : Controller
    {
        private string AutoDetectCountryCode()
        {
            var acceptLanguages = this.HttpContext?.Request?.GetTypedHeaders()?.AcceptLanguage;
            var firstLanguage = acceptLanguages?.FirstOrDefault()?.ToString();

            if (string.IsNullOrEmpty(firstLanguage))
            {
                return "US";
            }

            var cultureInfo = CultureInfo.GetCultureInfo(firstLanguage);
            if (cultureInfo.IsNeutralCulture)
            {
                var regionInfo = new RegionInfo(firstLanguage);
                return regionInfo.TwoLetterISORegionName;
            }

            var region = new RegionInfo(cultureInfo.CompareInfo.LCID);
            return region.TwoLetterISORegionName;
        }

        /// <summary>
        /// Get country info from request header `accept-language` or from query parameter
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CountryInfo")]
        public ActionResult<CountryInfoDto> CountryInfo([FromQuery] string countryCode = null)
        {
            if (string.IsNullOrEmpty(countryCode))
            {
                countryCode = this.AutoDetectCountryCode();
            }

            var country = new Country.CountryProvider().GetCountry(countryCode);
            if (country == null)
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }

            var countryInfo = CountryHelper.Convert(country);

            return this.StatusCode(StatusCodes.Status200OK, countryInfo);
        }

        /// <summary>
        /// Get all available countries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AvailableCountries")]
        public ActionResult<IEnumerable<CountryV2Dto>> AvailableCountries()
        {
            var countries = from CountryCode o in Enum.GetValues(typeof(CountryCode))
                            where DateSystem.GetPublicHolidays(DateTime.Today.Year, o).Any()
                            select new CountryV2Dto { Key = o.ToString(), Value = this.GetCountryName(o) };

            return this.StatusCode(StatusCodes.Status200OK, countries);
        }

        private string GetCountryName(CountryCode countrycode)
        {
            var country = new Country.CountryProvider().GetCountry(countrycode.ToString());
            if (country == null)
            {
                return string.Empty;
            }

            return country.CommonName;
        }
    }
}
