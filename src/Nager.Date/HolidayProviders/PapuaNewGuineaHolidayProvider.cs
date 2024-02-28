using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Papua New Guinea HolidayProvider
    /// </summary>
    internal class PapuaNewGuineaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Papua New Guinea HolidayProvider
        /// </summary>
        /// <param name="catholicProvider">CatholicProvider</param>
        public PapuaNewGuineaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.PG;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var secondMondayInJune = DateSystem.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Second);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-1), "Holy Saturday", "Holy Saturday", countryCode));
            items.Add(this._catholicProvider.EasterSunday("Easter Sunday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new Holiday(secondMondayInJune, "Queen's Birthday", "Queen's Birthday", countryCode));
            items.Add(new Holiday(year, 7, 23, "Remembrance Day", "Remembrance Day", countryCode));
            items.Add(new Holiday(year, 8, 26, "Repentance Day", "Repentance Day", countryCode));
            items.Add(new Holiday(year, 9, 16, "Independence Day", "Independence Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Papua_New_Guinea"
            };
        }
    }
}
