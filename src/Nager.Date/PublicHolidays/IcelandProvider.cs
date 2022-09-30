using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Iceland
    /// </summary>
    internal class IcelandProvider : IPublicHolidayProvider
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

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.IS;

            var firstDayOfSummer = DateSystem.FindDay(year, Month.April, 19, DayOfWeek.Thursday);
            var firstMondayInAugust = DateSystem.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nýársdagur", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.MaundyThursday("Skírdagur", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Föstudagurinn langi", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Páskadagur", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Annar í páskum", year, countryCode));
            items.Add(new PublicHoliday(firstDayOfSummer, "Sumardagurinn fyrsti", "First Day of Summer", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Verkalýðsdagurinn", "May Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Uppstigningardagur", year, countryCode));
            items.Add(this._catholicProvider.Pentecost("Hvítasunnudagur", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("Annar í hvítasunnu", year, countryCode));
            items.Add(new PublicHoliday(year, 6, 17, "Þjóðhátíðardagurinn", "Icelandic National Day", countryCode));
            items.Add(new PublicHoliday(firstMondayInAugust, "Frídagur verslunarmanna", "Commerce Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Aðfangadagur", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Jóladagur", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Annar í jólum", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Gamlársdagur", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Iceland",
            };
        }
    }
}
