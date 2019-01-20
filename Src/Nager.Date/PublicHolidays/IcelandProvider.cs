using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Iceland
    /// https://en.wikipedia.org/wiki/Public_holidays_in_Iceland
    /// </summary>
    public class IcelandProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// IcelandProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public IcelandProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.IS;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var firstDayOfSummer = DateSystem.FindDay(year, 4, 19, DayOfWeek.Thursday);
            var firstMondayInAugust = DateSystem.FindDay(year, 8, DayOfWeek.Monday, 1);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nýársdagur", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Skírdagur", "Maundy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Föstudagurinn langi", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Páskadagur", "Easter Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Annar í páskum", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(firstDayOfSummer, "Sumardagurinn fyrsti", "First Day of Summer", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Verkalýðsdagurinn", "May Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Uppstigningardagur", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Hvítasunnudagur", "Whit Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Annar í hvítasunnu", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 6, 17, "Þjóðhátíðardagurinn", "Icelandic National Day", countryCode));
            items.Add(new PublicHoliday(firstMondayInAugust, "Frídagur verslunarmanna", "Commerce Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Aðfangadagur", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Jóladagur", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Annar í jólum", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Gamlársdagur", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
