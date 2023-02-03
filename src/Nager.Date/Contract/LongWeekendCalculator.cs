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
        /// <param name="availableBridgeDays"></param>
        /// <returns>Set of long weekends for given set of public holidays</returns>
        public IEnumerable<LongWeekend> Calculate(
            IEnumerable<PublicHoliday> publicHolidays,
            int availableBridgeDays = 1)
        {
            var filteredPublicHolidays = publicHolidays.Where(o => o.Global && o.Type == PublicHolidayType.Public);

            var items = new List<LongWeekend>();

            void AddUniqueLongWeekend(LongWeekend longWeekend)
            {
                if (items.Any(item => longWeekend.StartDate >= item.StartDate && longWeekend.EndDate <= item.EndDate))
                {
                    return;
                }

                items.Add(longWeekend);
            }

            foreach (var publicHoliday in filteredPublicHolidays)
            {
                var previousDayResult = this.AnalyzeFollowingDays(publicHoliday.Date, DateSearchDirection.Backward, availableBridgeDays, filteredPublicHolidays);
                var nextDayResult = this.AnalyzeFollowingDays(publicHoliday.Date, DateSearchDirection.Forward, availableBridgeDays, filteredPublicHolidays);

                if (previousDayResult.DayCount == 0 && nextDayResult.DayCount == 0)
                {
                    continue;
                }

                if (previousDayResult.DayCount + nextDayResult.DayCount < this._weekendProvider.WeekendDays.Count())
                {
                    continue;
                }

                if (previousDayResult.BridgeDayCount + nextDayResult.BridgeDayCount > availableBridgeDays)
                {
                    var startDate1 = publicHoliday.Date.AddDays(-previousDayResult.DayCount);
                    var endDate1 = publicHoliday.Date;

                    AddUniqueLongWeekend(new LongWeekend
                    {
                        Bridge = previousDayResult.BridgeDayRequired,
                        StartDate = startDate1,
                        EndDate = endDate1
                    });

                    var startDate2 = publicHoliday.Date;
                    var endDate2 = publicHoliday.Date.AddDays(nextDayResult.DayCount);

                    AddUniqueLongWeekend(new LongWeekend
                    {
                        Bridge = nextDayResult.BridgeDayRequired,
                        StartDate = startDate2,
                        EndDate = endDate2
                    });

                    continue;
                }
                else
                {
                    var startDate = publicHoliday.Date.AddDays(-previousDayResult.DayCount);
                    var endDate = publicHoliday.Date.AddDays(nextDayResult.DayCount);

                    AddUniqueLongWeekend(new LongWeekend
                    {
                        Bridge = previousDayResult.BridgeDayRequired || nextDayResult.BridgeDayRequired,
                        StartDate = startDate,
                        EndDate = endDate
                    });
                }
            }

            return items;
        }

        private FollowingDayReport AnalyzeFollowingDays(
            DateTime startDate,
            DateSearchDirection dateSearchDirection,
            int allowedBridgeDays,
            IEnumerable<PublicHoliday> publicHolidays)
        {
            var availableBridgeDays = allowedBridgeDays;

            var multiplier = 1;
            if (dateSearchDirection == DateSearchDirection.Backward)
            {
                multiplier = -1;
            }

            var calculationDate = startDate.AddDays(1 * multiplier);
            var count = 0;
            var bridgeDayCount = 0;
            var bridgeDayRequired = false;
            var bridgeDays = new List<DateTime>();
            var checkNextDay = true;

            while (checkNextDay)
            {
                if (this.IsPublicHolidayOrWeekend(calculationDate, publicHolidays))
                {
                    calculationDate = calculationDate.AddDays(1 * multiplier);
                    count++;
                    continue;
                }

                var bridgeReport = this.CanJumpWithBridgeDaysToNextPublicHolidayOrWeekend(calculationDate, dateSearchDirection, availableBridgeDays, publicHolidays);
                if (bridgeReport.Item1)
                {
                    bridgeDayRequired = true;
                    count += bridgeReport.Item2;
                    availableBridgeDays -= bridgeReport.Item2;
                    bridgeDayCount += bridgeReport.Item2;

                    calculationDate = calculationDate.AddDays(bridgeReport.Item2 * multiplier);
                    continue;
                }

                checkNextDay = false;
            }

            return new FollowingDayReport
            {
                BridgeDayRequired = bridgeDayRequired,
                BridgeDayCount = bridgeDayCount,
                DayCount = count
            };
        }

        private Tuple<bool, int> CanJumpWithBridgeDaysToNextPublicHolidayOrWeekend(
            DateTime startDate,
            DateSearchDirection dateSearchDirection,
            int bridgeDaySize,
            IEnumerable<PublicHoliday> publicHolidays)
        {
            var multiplier = 1;
            if (dateSearchDirection == DateSearchDirection.Backward)
            {
                multiplier = -1;
            }

            for (var bridgeDayCount = 1; bridgeDayCount <= bridgeDaySize; bridgeDayCount++)
            {
                if (this.IsPublicHolidayOrWeekend(startDate.AddDays(bridgeDayCount * multiplier), publicHolidays))
                {
                    //TODO: Return bridge days

                    return new Tuple<bool, int>(true, bridgeDayCount);
                }
            }

            return new Tuple<bool, int>(false, 0);
        }

        private bool IsPublicHolidayOrWeekend(DateTime givenDate, IEnumerable<PublicHoliday> publicHolidays)
        {
            if (this._weekendProvider.WeekendDays.Contains(givenDate.DayOfWeek))
            {
                return true;
            }

            return publicHolidays.Any(o => o.Date.Date.Equals(givenDate.Date));
        }
    }
}
