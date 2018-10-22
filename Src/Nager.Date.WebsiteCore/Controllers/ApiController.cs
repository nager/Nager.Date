using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nager.Date.WebsiteCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.WebsiteCore.Controllers
{
    [Route("[controller]")]
    //[ApiController]
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("get/{countrycode}/{year}")]
        public ActionResult<IEnumerable<PublicHoliday>> CountryJson(string countrycode, int year)
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
