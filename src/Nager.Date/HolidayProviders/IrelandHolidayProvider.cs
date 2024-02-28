using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Ireland HolidayProvider
    /// </summary>
    internal class IrelandHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Ireland HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public IrelandHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.IE;

            var firstMondayInMay = DateSystem.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            var firstMondayInJune = DateSystem.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.First);
            var firstMondayInAugust = DateSystem.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);
            var lastMondayInOctober = DateSystem.FindLastDay(year, Month.October, DayOfWeek.Monday);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Lá Caille", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 3, 17, "Lá Fhéile Pádraig", "Saint Patrick's Day", countryCode, 1903));
            items.Add(this._catholicProvider.GoodFriday("Aoine an Chéasta", year, countryCode).SetType(HolidayTypes.Bank | HolidayTypes.School));
            items.Add(this._catholicProvider.EasterMonday("Luan Cásca", year, countryCode));
            items.Add(new Holiday(firstMondayInMay, "Lá Bealtaine", "May Day", countryCode, 1994));
            items.Add(new Holiday(firstMondayInJune, "Lá Saoire i mí an Mheithimh", "June Holiday", countryCode, 1973));
            items.Add(new Holiday(firstMondayInAugust, "Lá Saoire i mí Lúnasa", "August Holiday", countryCode));
            items.Add(new Holiday(lastMondayInOctober, "Lá Saoire i mí Dheireadh Fómhair", "October Holiday", countryCode, 1977));
            items.Add(new Holiday(year, 12, 25, "Lá Nollag", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Lá Fhéile Stiofáin", "St. Stephen's Day", countryCode));

            items.AddIfNotNull(this.SaintBrigidsDay(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private Holiday SaintBrigidsDay(int year, CountryCode countryCode)
        {
            if (year < 2023)
            {
                return null;
            }

            var englishName = "Saint Brigid's Day";
            var localName = "Lá Fhéile Bríde";

            var firstFebruary = new DateTime(year, 2, 1);
            if (firstFebruary.DayOfWeek == DayOfWeek.Friday)
            {
                return new Holiday(firstFebruary, localName, englishName, countryCode, launchYear: 2023);
            }

            var firstMondayInFebruary = DateSystem.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.First);
            return new Holiday(firstMondayInFebruary, localName, englishName, countryCode, launchYear: 2023);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Republic_of_Ireland",
            };
        }
    }
}
