using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Bolivia HolidayProvider
    /// </summary>
    internal class BoliviaHolidayProvider : IHolidayProvider
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

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 2, 2, "Fiesta de la Virgen de Candelaria", "Feast of the Virgin of Candelaria", countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-48), "Feriado por Carnaval", "Carnival", countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-47), "Feriado por Carnaval", "Carnival", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            items.Add(this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Dia del trabajo", "Labour Day", countryCode));
            items.Add(new Holiday(year, 6, 21, "Año Nuevo Andino", "Andean New Year", countryCode));
            items.Add(new Holiday(year, 8, 2, "Día de la Revolución Agraria", "Agrarian Reform Day", countryCode));
            items.Add(new Holiday(year, 8, 6, "Dia de la Patria", "Independence Day", countryCode));
            items.Add(new Holiday(year, 11, 2, "Todos Santos", "All Saints' Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bolivia"
            };
        }
    }
}
