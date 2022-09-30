using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Papua New Guinea
    /// </summary>
    internal class PapuaNewGuineaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// PapuaNewGuineaProvider
        /// </summary>
        /// <param name="catholicProvider">CatholicProvider</param>
        public PapuaNewGuineaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.PG;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var secondMondayInJune = DateSystem.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Second);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "Holy Saturday", "Holy Saturday", countryCode));
            items.Add(this._catholicProvider.EasterSunday("Easter Sunday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new PublicHoliday(secondMondayInJune, "Queen's Birthday", "Queen's Birthday", countryCode));
            items.Add(new PublicHoliday(year, 7, 23, "Remembrance Day", "Remembrance Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 26, "Repentance Day", "Repentance Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 16, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Papua_New_Guinea"
            };
        }
    }
}
