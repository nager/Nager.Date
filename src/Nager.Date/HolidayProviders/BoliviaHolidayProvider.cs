using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Bolivia HolidayProvider
    /// </summary>
    internal sealed class BoliviaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Bolivia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BoliviaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BO;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Año Nuevo",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 2),
                    EnglishName = "Feast of the Virgin of Candelaria",
                    LocalName = "Fiesta de la Virgen de Candelaria",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Dia del trabajo",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 21),
                    EnglishName = "Andean New Year",
                    LocalName = "Año Nuevo Andino",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 2),
                    EnglishName = "Agrarian Reform Day",
                    LocalName = "Día de la Revolución Agraria",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 6),
                    EnglishName = "Independence Day",
                    LocalName = "Dia de la Patria",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 2),
                    EnglishName = "All Saints' Day",
                    LocalName = "Todos Santos",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Navidad",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-48),
                    EnglishName = "Carnival",
                    LocalName = "Feriado por Carnaval",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-47),
                    EnglishName = "Carnival",
                    LocalName = "Feriado por Carnaval",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Viernes Santo", year),
                this._catholicProvider.CorpusChristi("Corpus Christi", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 2, 2, "Fiesta de la Virgen de Candelaria", "Feast of the Virgin of Candelaria", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-48), "Feriado por Carnaval", "Carnival", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-47), "Feriado por Carnaval", "Carnival", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            //items.Add(this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Dia del trabajo", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 6, 21, "Año Nuevo Andino", "Andean New Year", countryCode));
            //items.Add(new Holiday(year, 8, 2, "Día de la Revolución Agraria", "Agrarian Reform Day", countryCode));
            //items.Add(new Holiday(year, 8, 6, "Dia de la Patria", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 11, 2, "Todos Santos", "All Saints' Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bolivia"
            ];
        }
    }
}
