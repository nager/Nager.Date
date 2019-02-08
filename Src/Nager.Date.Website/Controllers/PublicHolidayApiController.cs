using Nager.Date.Website.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Nager.Date.Website.Controllers
{
    [RoutePrefix("api/v1")]
    public class PublicHolidayApiController : ApiController
    {
        private static ConcurrentDictionary<string, int> ApiStatistic = new ConcurrentDictionary<string, int>();

        [HttpGet]
        [Route("statistic")]
        public KeyValuePair<string, int>[] Statistic()
        {
            return ApiStatistic.Select(o => new KeyValuePair<string, int>(o.Key, o.Value)).ToArray();
        }

        [HttpGet]
        [Route("get/{countrycode}/{year}")]
        public IEnumerable<PublicHoliday> CountryJson(string countrycode, int year)
        {
            var ipAddress = HttpContext.Current.Request.UserHostAddress;
            ApiStatistic.AddOrUpdate(ipAddress, 1, (s, i) => i + 1);

            CountryCode countryCode;
            if (!Enum.TryParse(countrycode, true, out countryCode))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var publicHolidays = DateSystem.GetPublicHoliday(year, countryCode);
            if (publicHolidays?.Count() > 0)
            {
                var items = publicHolidays.Select(o => new PublicHoliday(o));
                return items;
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
