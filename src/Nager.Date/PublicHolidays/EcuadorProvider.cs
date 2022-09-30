using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Ecuador
    /// </summary>
    internal class EcuadorProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// EcuadorProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public EcuadorProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.EC;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "International Workers' Day", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 24, "Batalla de Pichincha", "The Battle of Pichincha", countryCode));
            items.Add(new PublicHoliday(year, 8, 10, "Primer Grito de Independencia", "Declaration of Independence of Quito", countryCode));
            items.Add(new PublicHoliday(year, 10, 9, "Independencia de Guayaquil", "Independence of Guayaquil", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "Día de los Difuntos, Día de Muertos", "All Souls' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 3, "Independencia de Cuenca", "Independence of Cuenca", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Día de Navidad", "Christmas Day", countryCode));         

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Ecuador",
            };
        }
    }
}
