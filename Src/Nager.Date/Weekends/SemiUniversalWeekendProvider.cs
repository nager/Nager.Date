using Nager.Date.Contract;
using System;

namespace Nager.Date.Weekends
{
    public class SemiUniversalWeekendProvider : IWeekendProvider
    {
        public bool IsWeekend(DateTime date) =>
            date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday;
    }
}
