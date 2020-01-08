using Nager.Date.Model;
using System.Collections.Generic;

namespace Nager.Date.Contract
{
    /// <summary>
    /// ILongWeekendCalculator
    /// </summary>
    public interface ILongWeekendCalculator
    {
        /// <summary>
        /// Calculate Long weekends
        /// </summary>
        /// <param name="publicHolidays"></param>
        /// <returns></returns>
        IEnumerable<LongWeekend> Calculate(IEnumerable<PublicHoliday> publicHolidays);
    }
}
