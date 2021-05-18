using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nager.Date.Model;
using Nager.Date.Website.Helper;
using Nager.Date.Website.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nager.Date.Website.Controllers
{
    /// <summary>
    /// Country V3
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "Country V3")]
    [Route("api/v3")]
    public class CountryV3Controller : Controller
    {
        /// <summary>
        /// Get country info from request header `accept-language` or from query parameter
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CountryInfo")]
        public ActionResult<CountryInfoDto> CountryInfo(
            [FromQuery][Required] string countryCode = null)
        {
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
        public ActionResult<IEnumerable<CountryDto>> AvailableCountries()
        {
            var countries = from CountryCode o in Enum.GetValues(typeof(CountryCode))
                            where DateSystem.GetPublicHolidays(DateTime.Today.Year, o).Any()
                            select new CountryDto { Key = o.ToString(), Value = this.GetCountryName(o) };

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
