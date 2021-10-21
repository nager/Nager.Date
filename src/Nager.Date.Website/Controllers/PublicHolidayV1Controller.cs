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
    /// PublicHolidays V1
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "PublicHolidays V1")]
    [Route("api/v1")]
    public class PublicHolidayV1Controller : Controller
    {
        /// <summary>
        /// Get Public Holidays
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{countryCode}/{year}")]
        public ActionResult<IEnumerable<PublicHolidayV2Dto>> CountryJson(
            [FromRoute][Required] string countryCode,
            [FromRoute][Required] int year)
        {
            if (!DateSystem.ParseCountryCode(countryCode, out var parsedCountryCode))
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }

            var publicHolidays = DateSystem.GetPublicHolidays(year, parsedCountryCode);
            if (publicHolidays?.Count() > 0)
            {
                var items = publicHolidays.Where(o => o.Type.HasFlag(PublicHolidayType.Public));
                return this.StatusCode(StatusCodes.Status200OK, items.Adapt<PublicHolidayV2Dto[]>());
            }

            return this.StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
