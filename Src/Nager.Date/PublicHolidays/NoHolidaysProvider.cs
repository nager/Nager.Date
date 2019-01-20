using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// NoHolidaysProvider
    /// </summary>
    public class NoHolidaysProvider : IPublicHolidayProvider
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            return Enumerable.Empty<PublicHoliday>();
        }
    }
}
