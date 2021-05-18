using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nager.Date.Website.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nager.Date.Website.Controllers
{
    /// <summary>
    /// LongWeekend V2
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "LongWeekend V2")]
    [Route("api/v2")]
    public class LongWeekendV2Controller : Controller
    {
        /// <summary>
        /// Get long weekends for a given country
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("LongWeekend/{year}/{countryCode}")]
        public ActionResult<LongWeekendDto[]> LongWeekend(
            [FromRoute][Required] int year,
            [FromRoute][Required] string countryCode)
        {
            if (!Enum.TryParse(countryCode, true, out CountryCode parsedCountryCode))
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }

            var items = DateSystem.GetLongWeekend(year, parsedCountryCode);
            return this.StatusCode(StatusCodes.Status200OK, items.Adapt<LongWeekendDto[]>());
        }
    }
}
