using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Gibraltar
    /// </summary>
    internal class GibraltarProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// GibraltarProvider
        /// </summary>
        /// <param name="catholicProvider">CatholicProvider</param>
        public GibraltarProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.GI;

            var secondMondayInMarch = DateSystem.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Second);
            var lastMondayInMay = DateSystem.FindLastDay(year, Month.May, DayOfWeek.Monday);
            var thirdMondayInJune = DateSystem.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Second);
            var lastMondayInAugust = DateSystem.FindLastDay(year, Month.August, DayOfWeek.Monday);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(secondMondayInMarch, "Commonwealth Day", "Commonwealth Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new PublicHoliday(year, 4, 28, "Workers' Memorial Day", "Workers' Memorial Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "May Day Bank Holiday", "May Day Bank Holiday", countryCode));
            items.Add(new PublicHoliday(lastMondayInMay, "Spring Bank Holiday", "Spring Bank Holiday", countryCode));
            items.Add(new PublicHoliday(thirdMondayInJune, "Queen's Birthday", "Queen's Birthday", countryCode));
            items.Add(new PublicHoliday(lastMondayInAugust, "Summer Bank Holiday", "Summer Bank Holiday", countryCode));
            items.Add(new PublicHoliday(year, 9, 10, "Gibraltar National Day", "Gibraltar National Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Gibraltar"
            };
        }
    }
}
