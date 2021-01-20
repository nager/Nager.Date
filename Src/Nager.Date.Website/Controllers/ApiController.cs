using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nager.Date.Model;
using Nager.Date.WebsiteCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace Nager.Date.WebsiteCore.Controllers
{
    /// <summary>
    /// Api
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        private string AutoDetectCountryCode()
        {
            var acceptLanguages = HttpContext?.Request?.GetTypedHeaders()?.AcceptLanguage;
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

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get Public Holiday
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/Get/{countrycode}/{year}")]
        public ActionResult<IEnumerable<PublicHolidayDto>> CountryJson(
            [FromRoute] [Required] string countryCode,
            [FromRoute] [Required] int year)
        {
            if (!Enum.TryParse(countryCode, true, out CountryCode parsedCountryCode))
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var publicHolidays = DateSystem.GetPublicHoliday(year, parsedCountryCode);
            if (publicHolidays?.Count() > 0)
            {
                var items = publicHolidays.Where(o => o.Type.HasFlag(PublicHolidayType.Public));
                return StatusCode(StatusCodes.Status200OK, items.Adapt<PublicHolidayDto[]>());
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        /// <summary>
        /// Get Public Holiday
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v2/PublicHolidays/{year}/{countrycode}")]
        public ActionResult<IEnumerable<PublicHolidayDto>> PublicHolidays(
            [FromRoute] [Required] int year,
            [FromRoute] [Required] string countryCode)
        {
            if (!Enum.TryParse(countryCode, true, out CountryCode parsedCountryCode))
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var items = DateSystem.GetPublicHoliday(year, parsedCountryCode);
            if (items?.Count() > 0)
            {
                return StatusCode(StatusCodes.Status200OK, items.Adapt<PublicHolidayDto[]>());
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        /// <summary>
        /// Is today a public holiday
        /// </summary>
        /// <remarks>
        /// This i a special endpoint for `curl`<br/><br/>
        /// 200 = Today is a public holiday<br/>
        /// 204 = Today is not a public holiday<br/><br/>
        /// `STATUSCODE=$(curl --silent --output /dev/stderr --write-out "%{http_code}" https://date.nager.at/Api/v2/IsTodayPublicHoliday/AT)`<br/><br/>
        /// `if [ $STATUSCODE -ne 200 ]; then # error handling; fi`
        /// </remarks>
        /// <param name="countryCode"></param>
        /// <param name="countyCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v2/IsTodayPublicHoliday/{countrycode}")]
        public ActionResult<IEnumerable<PublicHolidayDto>> PublicHolidays(
            [FromRoute][Required] string countryCode,
            [FromQuery] string countyCode)
        {
            if (!Enum.TryParse(countryCode, true, out CountryCode parsedCountryCode))
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            if (string.IsNullOrEmpty(countyCode))
            {
                if (DateSystem.IsPublicHoliday(DateTime.Today, parsedCountryCode))
                {
                    return StatusCode(StatusCodes.Status200OK);
                }

                return StatusCode(StatusCodes.Status204NoContent);
            }

            if (DateSystem.IsPublicHoliday(DateTime.Today, parsedCountryCode, countyCode))
            {
                return StatusCode(StatusCodes.Status200OK);
            }

            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        /// Get next public holidays for a given country
        /// in the next 365 days
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v2/NextPublicHolidays/{countryCode}")]
        public ActionResult<IEnumerable<PublicHolidayDto>> NextPublicHolidays([FromRoute] [Required] string countryCode)
        {
            var publicHolidays = DateSystem.GetPublicHoliday(DateTime.Today, DateTime.Today.AddYears(1), countryCode);
            if (publicHolidays?.Count() > 0)
            {
                var items = publicHolidays.Where(o => o.Type.HasFlag(PublicHolidayType.Public));
                return StatusCode(StatusCodes.Status200OK, items.Adapt<PublicHolidayDto[]>());
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        /// <summary>
        /// Get next public holidays worldwide
        /// in the next 7 days
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v2/NextPublicHolidaysWorldwide")]
        public ActionResult<IEnumerable<PublicHolidayDto>> NextPublicHolidaysWorldwide()
        {
            var items = DateSystem.GetPublicHolidays(DateTime.Today, DateTime.Today.AddDays(7)).OrderBy(o => o.Date);
            return StatusCode(StatusCodes.Status200OK, items.Adapt<PublicHolidayDto[]>());
        }

        /// <summary>
        /// Get long weekends for a given country
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v2/LongWeekend/{year}/{countrycode}")]
        public ActionResult<LongWeekendDto[]> LongWeekend(
            [FromRoute] [Required] int year,
            [FromRoute] [Required] string countryCode)
        {
            if (!Enum.TryParse(countryCode, true, out CountryCode parsedCountryCode))
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var items = DateSystem.GetLongWeekend(year, parsedCountryCode);
            return items.Adapt<LongWeekendDto[]>();
        }

        /// <summary>
        /// Get country info from request header `accept-language` or from query parameter
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v2/CountryInfo")]
        public ActionResult<CountryInfoDto> CountryInfo([FromQuery] string countryCode = null)
        {
            if (string.IsNullOrEmpty(countryCode))
            {
                countryCode = this.AutoDetectCountryCode();
            }

            var country = new Country.CountryProvider().GetCountry(countryCode);
            if (country == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var countryInfo = new CountryInfoDto
            {
                CommonName = country.CommonName,
                OfficialName = country.OfficialName,
                CountryCode = countryCode,
                AlternativeSpellings = country.Translations.Select(o => o.Name).ToArray(),
                Region = country.Region.ToString(),
                Borders = this.GetCountryInfos(country.BorderCountrys)
            };

            return StatusCode(StatusCodes.Status200OK, countryInfo);
        }

        /// <summary>
        /// Get all available countries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v2/AvailableCountries")]
        public ActionResult<IEnumerable<PublicHolidayDto>> AvailableCountries()
        {
            var countries = from CountryCode o in Enum.GetValues(typeof(CountryCode))
                            where DateSystem.GetPublicHoliday(DateTime.Today.Year, o).Any()
                            select new { Key = o.ToString(), Value = this.GetCountryName(o) };

            return StatusCode(StatusCodes.Status200OK, countries);
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

        private CountryInfoDto[] GetCountryInfos(Country.Alpha2Code[] countryCodes)
        {
            var countryProvider = new Country.CountryProvider();
            var items = new List<CountryInfoDto>();

            foreach (var countryCode in countryCodes)
            {
                var country = countryProvider.GetCountry(countryCode);

                var countryInfo = new CountryInfoDto
                {
                    CommonName = country.CommonName,
                    OfficialName = country.OfficialName,
                    CountryCode = country.Alpha2Code.ToString(),
                    AlternativeSpellings = country.Translations.Select(o => o.Name).ToArray(),
                    Region = country.Region.ToString()
                };

                items.Add(countryInfo);
            }

            return items.ToArray();
        }
    }
}
