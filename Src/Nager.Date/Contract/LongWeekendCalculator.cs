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
                var previoudDayResult = this.AvailableDay(publicHoliday.Date, -1, publicHolidays);
                var nextDayResult = this.AvailableDay(publicHoliday.Date, 1, publicHolidays);

                if (previoudDayResult.DayCount == 0 && nextDayResult.DayCount == 0)
                {
                    continue;
                }

                if (previoudDayResult.DayCount + nextDayResult.DayCount < this._weekendProvider.WeekendDays.Count())
                {
                    continue;
                }

                var startDate = publicHoliday.Date.AddDays(-previoudDayResult.DayCount);
                var endDate = publicHoliday.Date.AddDays(nextDayResult.DayCount);

                if (items.Any(o => startDate >= o.StartDate && endDate <= o.EndDate))
                {
                    continue;
                }

                items.Add(new LongWeekend
                {
                    Bridge = previoudDayResult.BridgeDayRequired || nextDayResult.BridgeDayRequired,
                    StartDate = startDate,
                    EndDate = endDate
                });
            }

            return items;
        }

        private AvailableDayResult AvailableDay(DateTime startDate, int addValue, IEnumerable<PublicHoliday> publicHolidays)
        {
            var calculationDate = startDate.AddDays(addValue);
            var count = 0;
            var bridgeDayRequired = false;

            //Maximum one bridge day
            for (var i = 0; i <= 1; i++)
            {
                while (this.ContinueWith(calculationDate, publicHolidays))
                {
                    count++;
                    calculationDate = calculationDate.AddDays(addValue);

                    //Bridge day loop
                    if (i == 1 && !bridgeDayRequired)
                    {
                        count++;
                        bridgeDayRequired = true;
                    }
                }

                //First loop, activate bridge day jump
                if (i == 0)
                {
                    calculationDate = calculationDate.AddDays(addValue);
                }
            }

            return new AvailableDayResult
            {
                BridgeDayRequired = bridgeDayRequired,
                DayCount = count
            };
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
