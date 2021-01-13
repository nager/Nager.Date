using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.Weekends
{
    /// <summary>
    /// WeekendProvider
    /// </summary>
    public class WeekendProvider : IWeekendProvider
    {
        /// <summary>
        /// WeekendProvider
        /// </summary>
        /// <param name="weekendDays"></param>
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

        public static IWeekendProvider FridayOnly { get; } = new WeekendProvider(DayOfWeek.Friday);
        public static IWeekendProvider SaturdayOnly { get; } = new WeekendProvider(DayOfWeek.Saturday);
        public static IWeekendProvider SundayOnly { get; } = new WeekendProvider(DayOfWeek.Sunday);
        public static IWeekendProvider FridaySunday { get; } = new WeekendProvider(DayOfWeek.Friday, DayOfWeek.Sunday);
        public static IWeekendProvider SemiUniversal { get; } = new WeekendProvider(DayOfWeek.Friday, DayOfWeek.Saturday);
        public static IWeekendProvider Universal { get; } = new WeekendProvider(DayOfWeek.Saturday, DayOfWeek.Sunday);

    }
}
