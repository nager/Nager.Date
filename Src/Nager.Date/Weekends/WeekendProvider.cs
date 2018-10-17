using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.Weekends
{
    public class WeekendProvider : IWeekendProvider
    {
        public WeekendProvider(params DayOfWeek[] weekendDays)
        {
            WeekendDays = weekendDays;

            var min = WeekendDays.Min();
            var max = WeekendDays.Max();

            if (max - min > (min + 7) - max)
            {
                FirstWeekendDay = min;
                LastWeekendDay = max;
            }
            else
            {
                FirstWeekendDay = max;
                LastWeekendDay = min;
            }
        }

        public IEnumerable<DayOfWeek> WeekendDays { get; }

        public bool IsWeekend(DateTime date) =>
            IsWeekend(date.DayOfWeek);

        public bool IsWeekend(PublicHoliday publicHoliday) =>
            IsWeekend(publicHoliday.Date);

        public bool IsWeekend(DayOfWeek dayOfWeek) =>
            WeekendDays.Contains(dayOfWeek);

        public DayOfWeek FirstWeekendDay { get; }

        public DayOfWeek LastWeekendDay { get; }

        public static WeekendProvider FridayOnly => new WeekendProvider(DayOfWeek.Friday);
        public static WeekendProvider SaturdayOnly => new WeekendProvider(DayOfWeek.Saturday);
        public static WeekendProvider SundayOnly => new WeekendProvider(DayOfWeek.Sunday);
        public static WeekendProvider FridaySunday => new WeekendProvider(DayOfWeek.Friday, DayOfWeek.Sunday);
        public static WeekendProvider SemiUniversal => new WeekendProvider(DayOfWeek.Friday, DayOfWeek.Saturday);
        public static WeekendProvider Universal => new WeekendProvider(DayOfWeek.Saturday, DayOfWeek.Sunday);

    }
}
