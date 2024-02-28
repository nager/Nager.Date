using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Botswana HolidayProvider
    /// </summary>
    internal class BotswanaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Botswana HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BotswanaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BW;

            var thirdMondayInJuly = DateSystem.FindDay(year, Month.July, DayOfWeek.Monday, Occurrence.Third);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Ascension Day", year, countryCode));
            items.Add(new Holiday(year, 7, 1, "Sir Seretse Khama Day", "Sir Seretse Khama Day", countryCode));
            items.Add(new Holiday(thirdMondayInJuly, "Presidents' Day", "Presidents' Day", countryCode));
            items.Add(new Holiday(year, 9, 30, "Independence Day", "Independence Day", countryCode));
            items.Add(new Holiday(year, 10, 1, "Botswana Day holiday", "Botswana Day holiday", countryCode));
            items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Botswana"
            };
        }
    }
}
