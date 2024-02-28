using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Uruguay
    /// </summary>
    internal class UruguayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// UruguayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public UruguayProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.UY;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 1, 6, "Día de los Niños", "Children's Day", countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(this._catholicProvider.MaundyThursday("Semana de Turismo", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Semana de Turismo", year, countryCode));
            items.Add(new Holiday(year, 4, 19, "Desembarco de los 33 Orientales", "Landing of the 33 Patriots Day", countryCode));
            items.Add(new Holiday(year, 5, 1, "Día de los Trabajadores", "International Workers' Day", countryCode));
            items.Add(new Holiday(year, 5, 18, "Batalla de las Piedras", "Battle of Las Piedras", countryCode));
            items.Add(new Holiday(year, 6, 19, "Natalicio de Artigas y Día del Nunca Más", "Birthday of José Gervasio Artigas and Never Again Day", countryCode));
            items.Add(new Holiday(year, 7, 18, "Jura de la Constitución", "Constitution Day", countryCode));
            items.Add(new Holiday(year, 8, 25, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new Holiday(year, 10, 12, "Día de la Raza", "Day of the race", countryCode));
            items.Add(new Holiday(year, 11, 2, "Día de los Difuntos", "Deceased ones day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Día de la Familia", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Uruguay"
            };
        }
    }
}
