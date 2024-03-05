using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.WeekendProviders
{
    /// <summary>
    /// WeekendProvider Interface
    /// </summary>
    public interface IWeekendProvider
    {
        /// <summary>
        /// Get weekend days
        /// </summary>
        IEnumerable<DayOfWeek> WeekendDays { get; }

        /// <summary>
        /// Is given date in the weekend
        /// </summary>
        /// <param name="date"></param>
        /// <returns>True if given date is weekend, false otherwise</returns>
        bool IsWeekend(DateTime date);

        /// <summary>
        /// Is given holiday in the weekend
        /// </summary>
        /// <param name="publicHoliday"></param>
        /// <returns>True if given holiday is in the weekend, false otherwise</returns>
        bool IsWeekend(Holiday publicHoliday);

        /// <summary>
        /// Is given day in the weekend
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns>True if given day of week is in the weekend, false otherwise</returns>
        bool IsWeekend(DayOfWeek dayOfWeek);

        /// <summary>
        /// Get first weekend day
        /// </summary>
        DayOfWeek FirstWeekendDay { get; }

        /// <summary>
        /// Get last weekend day
        /// </summary>
        DayOfWeek LastWeekendDay { get; }
    }
}
