using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nager.Date.WebsiteCore.Models;
using System;
using System.Collections.Generic;
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
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get Public Holiday
        /// </summary>
        /// <param name="countrycode"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{countrycode}/{year}")]
        public ActionResult<IEnumerable<PublicHoliday>> CountryJson([FromRoute]string countrycode, [FromRoute]int year)
        {
            //Counter++;

            if (!Enum.TryParse(countrycode, true, out CountryCode countryCode))
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var publicHolidays = DateSystem.GetPublicHoliday(countryCode, year);
            if (publicHolidays?.Count() > 0)
            {
                var items = publicHolidays.Where(o => o.Type.HasFlag(Model.PublicHolidayType.Public)).Select(o => new PublicHoliday(o));
                return StatusCode(StatusCodes.Status200OK, items);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
