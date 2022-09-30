using Nager.Date.Model;
using System.Collections.Generic;

namespace Nager.Date.Contract
{
    /// <summary>
    /// Public Holiday Provider Interface
    /// </summary>
    public interface IPublicHolidayProvider
    {
        /// <summary>
        /// Get Holidays of the given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Set of public holidays for given year</returns>
        IEnumerable<PublicHoliday> GetHolidays(int year);

        /// <summary>
        ///Get the Holiday Sources
        /// </summary>
        /// <returns>Set of public holiday sources (links)</returns>
        IEnumerable<string> GetSources();
    }
}
