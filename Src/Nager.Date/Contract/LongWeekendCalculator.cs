using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.Contract
{
    /// <summary>
    /// LongWeekendCalculator
    /// </summary>
    public class LongWeekendCalculator : ILongWeekendCalculator
    {
        private readonly IWeekendProvider _weekendProvider;
        private readonly IEnumerable<PublicHoliday> _publicHolidays;

        /// <summary>
        /// LongWeekendCalculator
        /// </summary>
        /// <param name="weekendProvider"></param>
        public LongWeekendCalculator(IWeekendProvider weekendProvider)
        {
            this._weekendProvider = weekendProvider;
        }

        /// <summary>
        /// Calculate long weekends
        /// </summary>
        /// <param name="publicHolidays"></param>
        /// <returns></returns>
        public IEnumerable<LongWeekend> Calculate(IEnumerable<PublicHoliday> publicHolidays)
        {
            var items = new List<LongWeekend>();

            foreach (var publicHoliday in publicHolidays)
            {
                var previoudDayCount = this.AvailableDays(publicHoliday.Date, -1, publicHolidays);
                var nextDayCount = this.AvailableDays(publicHoliday.Date, 1, publicHolidays);

                if (previoudDayCount == 0 && nextDayCount == 0)
                {
                    continue;
                }

                var startDate = publicHoliday.Date.AddDays(-previoudDayCount);
                var endDate = publicHoliday.Date.AddDays(nextDayCount);

                if (items.Any(o => o.StartDate.Equals(startDate) && o.EndDate.Equals(endDate)))
                {
                    continue;
                }

                items.Add(new LongWeekend
                {
                    Bridge = false,
                    StartDate = startDate,
                    EndDate = endDate
                });
            }

            return items;
        }

        private int AvailableDays(DateTime startDate, int addValue, IEnumerable<PublicHoliday> publicHolidays)
        {
            var calculationDate = startDate.AddDays(addValue);
            var count = 0;

            while (this.ContinueWith(calculationDate, publicHolidays))
            {
                calculationDate = calculationDate.AddDays(addValue);
                count++;
            }

            return count;
        }

        private bool ContinueWith(DateTime givenDate, IEnumerable<PublicHoliday> publicHolidays)
        {
            if (this._weekendProvider.WeekendDays.Contains(givenDate.DayOfWeek))
            {
                return true;
            }

            return publicHolidays.Any(o => o.Date.Date.Equals(givenDate.Date));
        }
    }
}
