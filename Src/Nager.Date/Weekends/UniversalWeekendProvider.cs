using Nager.Date.Contract;
using System;

namespace Nager.Date.Weekends
{
    public class UniversalWeekendProvider : IWeekendProvider
    {
        public bool IsWeekend(DateTime date) =>
            date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
    }
}
