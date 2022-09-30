using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Montserrat
    /// </summary>
    internal class MontserratProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// MontserratProvider
        /// </summary>
        /// <param name="catholicProvider">CatholicProvider</param>
        public MontserratProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.MS;

            var firstMondayInMay = DateSystem.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            var secondMondayInJune = DateSystem.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Second);
            var firstMondayInAugust = DateSystem.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 17, "Saint Patrick's Day", "Saint Patrick's Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new PublicHoliday(firstMondayInMay, "Labour Day", "Labour Day", countryCode));
            items.Add(this._catholicProvider.WhitMonday("Whit Monday", year, countryCode));
            items.Add(new PublicHoliday(secondMondayInJune, "Queen's Birthday", "Queen's Birthday", countryCode));
            items.Add(new PublicHoliday(firstMondayInAugust, "Emancipation Day", "Emancipation Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Festival Day", "Festival Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Montserrat",
            };
        }
    }
}
