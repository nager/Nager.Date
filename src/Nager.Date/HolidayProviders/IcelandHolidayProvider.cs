using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Iceland HolidayProvider
    /// </summary>
    internal class IcelandHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Iceland HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public IcelandHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.IS;

            var firstDayOfSummer = DateSystem.FindDay(year, Month.April, 19, DayOfWeek.Thursday);
            var firstMondayInAugust = DateSystem.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Nýársdagur",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = firstDayOfSummer,
                    EnglishName = "First Day of Summer",
                    LocalName = "Sumardagurinn fyrsti",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day",
                    LocalName = "Verkalýðsdagurinn",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 17),
                    EnglishName = "Icelandic National Day",
                    LocalName = "Þjóðhátíðardagurinn",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = firstMondayInAugust,
                    EnglishName = "Commerce Day",
                    LocalName = "Frídagur verslunarmanna",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Aðfangadagur",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Jóladagur",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Annar í jólum",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Gamlársdagur",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.MaundyThursday("Skírdagur", year),
                this._catholicProvider.GoodFriday("Föstudagurinn langi", year),
                this._catholicProvider.EasterSunday("Páskadagur", year),
                this._catholicProvider.EasterMonday("Annar í páskum", year),
                this._catholicProvider.AscensionDay("Uppstigningardagur", year),
                this._catholicProvider.Pentecost("Hvítasunnudagur", year),
                this._catholicProvider.WhitMonday("Annar í hvítasunnu", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);


            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Nýársdagur", "New Year's Day", countryCode));
            //items.Add(this._catholicProvider.MaundyThursday("Skírdagur", year, countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Föstudagurinn langi", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Páskadagur", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Annar í páskum", year, countryCode));
            //items.Add(new Holiday(firstDayOfSummer, "Sumardagurinn fyrsti", "First Day of Summer", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Verkalýðsdagurinn", "May Day", countryCode));
            //items.Add(this._catholicProvider.AscensionDay("Uppstigningardagur", year, countryCode));
            //items.Add(this._catholicProvider.Pentecost("Hvítasunnudagur", year, countryCode));
            //items.Add(this._catholicProvider.WhitMonday("Annar í hvítasunnu", year, countryCode));
            //items.Add(new Holiday(year, 6, 17, "Þjóðhátíðardagurinn", "Icelandic National Day", countryCode));
            //items.Add(new Holiday(firstMondayInAugust, "Frídagur verslunarmanna", "Commerce Day", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Aðfangadagur", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Jóladagur", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Annar í jólum", "St. Stephen's Day", countryCode));
            //items.Add(new Holiday(year, 12, 31, "Gamlársdagur", "New Year's Eve", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Iceland",
            };
        }
    }
}
