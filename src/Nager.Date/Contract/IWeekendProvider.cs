using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.Contract
{
    /// <summary>
    /// IWeekendProvider
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
        /// <returns></returns>
        bool IsWeekend(DateTime date);
        /// <summary>
        /// Is given public holiday in the weekend
        /// </summary>
        /// <param name="publicHoliday"></param>
        /// <returns></returns>
        bool IsWeekend(PublicHoliday publicHoliday);
        /// <summary>
        /// Is given day in the weekend
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        bool IsWeekend(DayOfWeek dayOfWeek);
        /// <summary>
        /// Get first weekend day
        /// </summary>
        DayOfWeek FirstWeekendDay { get; }
        /// <summary>
        /// get last weekend day
        /// </summary>
        DayOfWeek LastWeekendDay { get; }
    }
}
