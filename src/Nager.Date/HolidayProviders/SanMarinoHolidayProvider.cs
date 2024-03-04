using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// San Marino HolidayProvider
    /// </summary>
    internal class SanMarinoHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// San Marino HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SanMarinoHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.SM;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Epiphany",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 5),
                    EnglishName = "Feast of Saint Agatha",
                    LocalName = "Feast of Saint Agatha",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 25),
                    EnglishName = "Anniversary of the Arengo",
                    LocalName = "Anniversary of the Arengo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 28),
                    EnglishName = "Liberation from Fascism",
                    LocalName = "Liberation from Fascism",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Ferragosto (Assumption)",
                    LocalName = "Ferragosto (Assumption)",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 3),
                    EnglishName = "The Feast of San Marino and the Republic",
                    LocalName = "The Feast of San Marino and the Republic",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "All Saints' Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 2),
                    EnglishName = "Commemoration of all those who died at war",
                    LocalName = "Commemoration of all those who died at war",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Immaculate Conception",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Christmas Eve",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "St. Stephen's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "New Year's Eve",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterSunday("Easter Sunday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this._catholicProvider.CorpusChristi("Corpus Christi", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Epiphany", "Epiphany", countryCode));
            //items.Add(new Holiday(year, 2, 5, "Feast of Saint Agatha", "Feast of Saint Agatha", countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Easter Sunday", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            //items.Add(new Holiday(year, 3, 25, "Anniversary of the Arengo", "Anniversary of the Arengo", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            //items.Add(this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode));
            //items.Add(new Holiday(year, 7, 28, "Liberation from Fascism", "Liberation from Fascism", countryCode));
            //items.Add(new Holiday(year, 8, 15, "Ferragosto (Assumption)", "Ferragosto (Assumption)", countryCode));
            //items.Add(new Holiday(year, 9, 3, "The Feast of San Marino and the Republic", "The Feast of San Marino and the Republic", countryCode));
            //items.Add(new Holiday(year, 11, 1, "All Saints' Day", "All Saints' Day", countryCode));
            //items.Add(new Holiday(year, 11, 2, "Commemoration of all those who died at war", "Commemoration of all those who died at war", countryCode));
            //items.Add(new Holiday(year, 12, 8, "Immaculate Conception", "Immaculate Conception", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Christmas Eve", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "St. Stephen's Day", "St. Stephen's Day", countryCode));
            //items.Add(new Holiday(year, 12, 31, "New Year's Eve", "New Year's Eve", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/San_Marino#Public_holidays_and_festivals"
            };
        }
    }
}
