using Nager.Date.Models;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Holiday Provider Interface
    /// </summary>
    public interface IHolidayProvider
    {
        /// <summary>
        /// Get Holidays of the given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Set of holidays for given year</returns>
        IEnumerable<Holiday> GetHolidays(int year);

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns>Set of holiday sources (links)</returns>
        IEnumerable<string> GetSources();
    }
}
