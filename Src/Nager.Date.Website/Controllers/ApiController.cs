using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nager.Date.Model;
using Nager.Date.Website.Helper;
using Nager.Date.Website.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace Nager.Date.Website.Controllers
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
        [Route("v1/Get/{countryCode}/{year}")]
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
        [Route("v2/PublicHolidays/{year}/{countryCode}")]
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
        /// The calculation is made on the basis of UTC time to adjust the time please use the offset.<br/>
        /// This is a special endpoint for `curl`<br/><br/>
        /// 200 = Today is a public holiday<br/>
        /// 204 = Today is not a public holiday<br/><br/>
        /// `STATUSCODE=$(curl --silent --output /dev/stderr --write-out "%{http_code}" https://date.nager.at/Api/v2/IsTodayPublicHoliday/AT)`<br/><br/>
        /// `if [ $STATUSCODE -ne 200 ]; then # error handling; fi`
        /// </remarks>
        /// <param name="countryCode"></param>
        /// <param name="countyCode"></param>
        /// <param name="offset">utc timezone offset</param>
        /// <returns></returns>
        /// <response code="200">Today is a public holiday</response>
        /// <response code="204">Today is not a public holiday</response>
        /// <response code="400">Validation failure</response>
        /// <response code="404">CountryCode is unknown</response>
        [HttpGet]
        [Route("v2/IsTodayPublicHoliday/{countryCode}")]
        public ActionResult IsTodayPublicHoliday(
            [FromRoute] [Required] string countryCode,
            [FromQuery] string countyCode,
            [FromQuery] [Range(-12, 12)] int offset = 0)
        {
            if (!Enum.TryParse(countryCode, true, out CountryCode parsedCountryCode))
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            if (string.IsNullOrEmpty(countyCode))
            {
                if (DateSystem.IsPublicHoliday(DateTime.UtcNow.AddHours(offset), parsedCountryCode))
                {
                    return StatusCode(StatusCodes.Status200OK);
                }

                return StatusCode(StatusCodes.Status204NoContent);
            }

            if (DateSystem.IsPublicHoliday(DateTime.UtcNow.AddHours(offset), parsedCountryCode, countyCode))
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
        [Route("v2/LongWeekend/{year}/{countryCode}")]
        public ActionResult<LongWeekendDto[]> LongWeekend(
            [FromRoute] [Required] int year,
            [FromRoute] [Required] string countryCode)
        {
            if (!Enum.TryParse(countryCode, true, out CountryCode parsedCountryCode))
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var items = DateSystem.GetLongWeekend(year, parsedCountryCode);
            return StatusCode(StatusCodes.Status200OK, items.Adapt<LongWeekendDto[]>());
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

            var countryInfo = CountryHelper.Convert(country);

            return StatusCode(StatusCodes.Status200OK, countryInfo);
        }

        /// <summary>
        /// Get all available countries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v2/AvailableCountries")]
        public ActionResult<IEnumerable<CountryDto>> AvailableCountries()
        {
            var countries = from CountryCode o in Enum.GetValues(typeof(CountryCode))
                            where DateSystem.GetPublicHoliday(DateTime.Today.Year, o).Any()
                            select new CountryDto { Key = o.ToString(), Value = this.GetCountryName(o) };

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
    }
}
