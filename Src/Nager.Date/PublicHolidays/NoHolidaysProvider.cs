using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class NoHolidaysProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(int year) =>
            Enumerable.Empty<PublicHoliday>();
    }
}
