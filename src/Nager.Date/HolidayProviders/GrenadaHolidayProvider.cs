using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Grenada HolidayProvider
    /// </summary>
    internal class GrenadaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Grenada HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GrenadaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.GD;

            var firstMondayInAugust = DateSystem.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 2, 7, "Independence Day", "Independence Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new Holiday(year, 5, 1, "Indian Arrival Day", "Indian Arrival Day", countryCode));
            items.Add(this._catholicProvider.WhitMonday("Whit Monday", year, countryCode));
            items.Add(this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode));
            items.Add(new Holiday(firstMondayInAugust, "Emancipation Day", "Emancipation Day", countryCode));
            items.Add(new Holiday(year, 8, 11, "Carnival", "Carnival", countryCode));
            items.Add(new Holiday(year, 10, 25, "Thanksgiving Day", "Thanksgiving Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Boxing Day", "Boxing Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Grenada",
            };
        }
    }
}
