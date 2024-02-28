using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Peru
    /// </summary>
    internal class PeruProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// PeruProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public PeruProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.PE;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-3), "Jueves Santo", "Holy Thursday", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Domingo Santo", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Día del Trabajo", "International Workers' Day", countryCode));
            items.Add(new Holiday(year, 6, 29, "Día de San Pedro y San Pablo", "St. Peter and St. Paul", countryCode));
            items.Add(new Holiday(year, 7, 28, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new Holiday(year, 7, 29, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new Holiday(year, 8, 30, "Día de Santa Rosa de Lima", "Santa Rosa de Lima", countryCode));
            items.Add(new Holiday(year, 10, 8, "Combate de Angamos", "Battle of Angamos", countryCode));
            items.Add(new Holiday(year, 11, 1, "Día de Todos los Santos", "All Saints Day", countryCode));
            items.Add(new Holiday(year, 12, 8, "Inmaculada Concepción", "Immaculate Conception", countryCode));
            items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            
            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Peru"
            };
        }
    }
}
