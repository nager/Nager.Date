using Nager.Date.Website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Nager.Date.Website.Controllers
{
    [RoutePrefix("api/v1")]
    public class PublicHolidayApiController : ApiController
    {
        [HttpGet]
        [Route("get/{countrycode}/{year}")]
        public IEnumerable<PublicHoliday> CountryJson(string countrycode, int year)
        {
            CountryCode countryCode;
            if (!Enum.TryParse(countrycode, true, out countryCode))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var publicHolidays = DateSystem.GetPublicHoliday(countryCode, year);
            if (publicHolidays?.Count() > 0)
            {
                var items = publicHolidays.Select(o => new PublicHoliday(o));
                return items;
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
