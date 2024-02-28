using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Ecuador HolidayProvider
    /// </summary>
    internal class EcuadorHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Ecuador HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public EcuadorHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.EC;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "International Workers' Day", "International Workers' Day", countryCode));
            items.Add(new Holiday(year, 5, 24, "Batalla de Pichincha", "The Battle of Pichincha", countryCode));
            items.Add(new Holiday(year, 8, 10, "Primer Grito de Independencia", "Declaration of Independence of Quito", countryCode));
            items.Add(new Holiday(year, 10, 9, "Independencia de Guayaquil", "Independence of Guayaquil", countryCode));
            items.Add(new Holiday(year, 11, 2, "Día de los Difuntos, Día de Muertos", "All Souls' Day", countryCode));
            items.Add(new Holiday(year, 11, 3, "Independencia de Cuenca", "Independence of Cuenca", countryCode));
            items.Add(new Holiday(year, 12, 25, "Día de Navidad", "Christmas Day", countryCode));         

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Ecuador",
            };
        }
    }
}
