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
        /// <param name="availableBridgeDays"></param>
        /// <returns>Set of long weekends for given public holidays</returns>
        IEnumerable<LongWeekend> Calculate(IEnumerable<PublicHoliday> publicHolidays, int availableBridgeDays = 1);
    }
}
