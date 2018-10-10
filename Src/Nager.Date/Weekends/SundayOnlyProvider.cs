using Nager.Date.Contract;
using System;

namespace Nager.Date.Weekends
{
    public class SundayOnlyProvider : IWeekendProvider
    {
        public bool IsWeekend(DateTime date) =>
            date.DayOfWeek == DayOfWeek.Sunday;
    }
}
