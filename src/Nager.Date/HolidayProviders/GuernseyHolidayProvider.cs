using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Guernsey HolidayProvider
    /// </summary>
    internal class GuernseyHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Guernsey HolidayProvider
        /// </summary>
        /// <param name="catholicProvider">CatholicProvider</param>
        public GuernseyHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.GG;

            var lastMondayInMay = DateSystem.FindLastDay(year, Month.May, DayOfWeek.Monday);
            var lastMondayInAugust = DateSystem.FindLastDay(year, Month.August, DayOfWeek.Monday);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Early May Bank Holiday", "Early May Bank Holiday", countryCode));
            items.Add(new Holiday(year, 5, 9, "Liberation Day", "Liberation Day", countryCode));
            items.Add(new Holiday(lastMondayInMay, "Spring Bank Holiday", "Spring Bank Holiday", countryCode));
            items.Add(new Holiday(lastMondayInAugust, "Summer Bank Holiday", "Summer Bank Holiday", countryCode));
            items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Guernsey"
            };
        }
    }
}
