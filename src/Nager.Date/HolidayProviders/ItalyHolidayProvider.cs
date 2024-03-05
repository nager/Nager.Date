using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Italy HolidayProvider
    /// </summary>
    internal sealed class ItalyHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Italy HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ItalyHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.IT;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Capodanno",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Epifania",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 25),
                    EnglishName = "Liberation Day",
                    LocalName = "Festa della Liberazione",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers Day",
                    LocalName = "Festa del Lavoro",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 2),
                    EnglishName = "Republic Day",
                    LocalName = "Festa della Repubblica",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Ferragosto o Assunzione",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints Day",
                    LocalName = "Tutti i santi",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Immacolata Concezione",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Natale",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Santo Stefano",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterSunday("Pasqua", year),
                this._catholicProvider.EasterMonday("Lunedì dell'Angelo", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Capodanno", "New Year's Day", countryCode, 1967));
            //items.Add(new Holiday(year, 1, 6, "Epifania", "Epiphany", countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Pasqua", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Lunedì dell'Angelo", year, countryCode).SetLaunchYear(1642));
            //items.Add(new Holiday(year, 4, 25, "Festa della Liberazione", "Liberation Day", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Festa del Lavoro", "International Workers Day", countryCode));
            //items.Add(new Holiday(year, 6, 2, "Festa della Repubblica", "Republic Day", countryCode));
            //items.Add(new Holiday(year, 8, 15, "Ferragosto o Assunzione", "Assumption Day", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Tutti i santi", "All Saints Day", countryCode));
            //items.Add(new Holiday(year, 12, 8, "Immacolata Concezione", "Immaculate Conception", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Natale", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Santo Stefano", "St. Stephen's Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Italy",
            };
        }
    }
}
