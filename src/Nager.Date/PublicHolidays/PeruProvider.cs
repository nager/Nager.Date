using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Peru
    /// </summary>
    internal class PeruProvider : IPublicHolidayProvider
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
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.PE;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Jueves Santo", "Holy Thursday", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Domingo Santo", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Día del Trabajo", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 29, "Día de San Pedro y San Pablo", "St. Peter and St. Paul", countryCode));
            items.Add(new PublicHoliday(year, 7, 28, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 29, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 30, "Día de Santa Rosa de Lima", "Santa Rosa de Lima", countryCode));
            items.Add(new PublicHoliday(year, 10, 8, "Combate de Angamos", "Battle of Angamos", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Día de Todos los Santos", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Inmaculada Concepción", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            
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
