using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Peru HolidayProvider
    /// </summary>
    internal class PeruHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Peru HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public PeruHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.PE;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Año Nuevo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-3),
                    EnglishName = "Holy Thursday",
                    LocalName = "Jueves Santo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers' Day",
                    LocalName = "Día del Trabajo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 29),
                    EnglishName = "St. Peter and St. Paul",
                    LocalName = "Día de San Pedro y San Pablo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 28),
                    EnglishName = "Independence Day",
                    LocalName = "Día de la Independencia",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 29),
                    EnglishName = "Independence Day",
                    LocalName = "Día de la Independencia",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 30),
                    EnglishName = "Santa Rosa de Lima",
                    LocalName = "Día de Santa Rosa de Lima",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 8),
                    EnglishName = "Battle of Angamos",
                    LocalName = "Combate de Angamos",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints Day",
                    LocalName = "Día de Todos los Santos",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Inmaculada Concepción",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Navidad",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.MaundyThursday("Jueves Santo", year),
                this._catholicProvider.GoodFriday("Viernes Santo", year),
                this._catholicProvider.EasterSunday("Domingo Santo", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-3), "Jueves Santo", "Holy Thursday", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Domingo Santo", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Día del Trabajo", "International Workers' Day", countryCode));
            //items.Add(new Holiday(year, 6, 29, "Día de San Pedro y San Pablo", "St. Peter and St. Paul", countryCode));
            //items.Add(new Holiday(year, 7, 28, "Día de la Independencia", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 7, 29, "Día de la Independencia", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 8, 30, "Día de Santa Rosa de Lima", "Santa Rosa de Lima", countryCode));
            //items.Add(new Holiday(year, 10, 8, "Combate de Angamos", "Battle of Angamos", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Día de Todos los Santos", "All Saints Day", countryCode));
            //items.Add(new Holiday(year, 12, 8, "Inmaculada Concepción", "Immaculate Conception", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Peru"
            };
        }
    }
}
