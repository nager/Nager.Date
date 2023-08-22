using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Zimbabwe
    /// </summary>
    internal class ZimbabweProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// ZimbabweProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ZimbabweProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.ZW;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var secondMondayInAugust = DateSystem.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.Second);
            var tuesdayAfterSecondMondayInAugust = secondMondayInAugust.AddDays(1);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 21, "Robert Mugabe National Youth Day", "Robert Mugabe National Youth Day", countryCode, 2018));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "Easter Saturday", "Easter Saturday", countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new PublicHoliday(year, 4, 18, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Worker's Day", "Worker's Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 25, "Africa Day", "Africa Day", countryCode));
            items.Add(new PublicHoliday(secondMondayInAugust, "Heroes' Day", "Heroes' Day", countryCode));
            items.Add(new PublicHoliday(tuesdayAfterSecondMondayInAugust, "Defence Forces Day", "Defence Forces Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 22, "Unity Day", "Unity Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.m.wikipedia.org/wiki/Public_holidays_in_Zimbabwe"
            };
        }
    }
}
