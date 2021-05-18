using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nager.Date.Model;
using Nager.Date.Website.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nager.Date.Website.Controllers
{
    /// <summary>
    /// PublicHolidays V3
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "PublicHolidays V3")]
    [Route("api/v3")]
    public class PublicHolidayV3Controller : Controller
    {
        /// <summary>
        /// Get Public Holidays
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PublicHolidays/{year}/{countryCode}")]
        public ActionResult<IEnumerable<PublicHolidayV3Dto>> PublicHolidaysV3(
            [FromRoute][Required] int year,
            [FromRoute][Required] string countryCode)
        {
            if (!Enum.TryParse(countryCode, true, out CountryCode parsedCountryCode))
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }

            var items = DateSystem.GetPublicHolidays(year, parsedCountryCode);
            if (items?.Count() > 0)
            {
                return this.StatusCode(StatusCodes.Status200OK, items.Adapt<PublicHolidayV3Dto[]>());
            }

            return this.StatusCode(StatusCodes.Status404NotFound);
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
        [Route("IsTodayPublicHoliday/{countryCode}")]
        public ActionResult IsTodayPublicHoliday(
            [FromRoute][Required] string countryCode,
            [FromQuery] string countyCode,
            [FromQuery][Range(-12, 12)] int offset = 0)
        {
            if (!Enum.TryParse(countryCode, true, out CountryCode parsedCountryCode))
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }

            if (string.IsNullOrEmpty(countyCode))
            {
                if (DateSystem.IsPublicHoliday(DateTime.UtcNow.AddHours(offset), parsedCountryCode))
                {
                    return this.StatusCode(StatusCodes.Status200OK);
                }

                return this.StatusCode(StatusCodes.Status204NoContent);
            }

            if (DateSystem.IsPublicHoliday(DateTime.UtcNow.AddHours(offset), parsedCountryCode, countyCode))
            {
                return this.StatusCode(StatusCodes.Status200OK);
            }

            return this.StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        /// Returns the upcoming public holidays for the next 365 days for the given country
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("NextPublicHolidays/{countryCode}")]
        public ActionResult<IEnumerable<PublicHolidayV3Dto>> NextPublicHolidays([FromRoute][Required] string countryCode)
        {
            var publicHolidays = DateSystem.GetPublicHolidays(DateTime.Today, DateTime.Today.AddYears(1), countryCode);
            if (publicHolidays?.Count() > 0)
            {
                var items = publicHolidays.Where(o => o.Type.HasFlag(PublicHolidayType.Public));
                return this.StatusCode(StatusCodes.Status200OK, items.Adapt<PublicHolidayV2Dto[]>());
            }

            return this.StatusCode(StatusCodes.Status404NotFound);
        }

        /// <summary>
        /// Returns the upcoming public holidays for the next 7 days
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("NextPublicHolidaysWorldwide")]
        public ActionResult<IEnumerable<PublicHolidayV3Dto>> NextPublicHolidaysWorldwide()
        {
            var items = DateSystem.GetPublicHolidays(DateTime.Today, DateTime.Today.AddDays(7)).OrderBy(o => o.Date);
            return this.StatusCode(StatusCodes.Status200OK, items.Adapt<PublicHolidayV2Dto[]>());
        }
    }
}
