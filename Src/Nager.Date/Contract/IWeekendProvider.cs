using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.Contract
{
    public interface IWeekendProvider
    {
        IEnumerable<DayOfWeek> WeekendDays { get; }
        bool IsWeekend(DateTime date);
        bool IsWeekend(PublicHoliday publicHoliday);
        bool IsWeekend(DayOfWeek dayOfWeek);
        DayOfWeek FirstWeekendDay { get; }
        DayOfWeek LastWeekendDay { get; }
    }
}
