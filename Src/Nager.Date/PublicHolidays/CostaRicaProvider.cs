using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Costa Rica
    /// </summary>
    public class CostaRicaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// CostaRicaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CostaRicaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.CR;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 11, "Día de Juan Santamaría", "Juan Santamaría Day", countryCode));
            items.Add(this._catholicProvider.MaundyThursday("Jueves Santo", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Día Internacional del Trabajo", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 25, "Anexión del Partido de Nicoya a Costa Rica", "Annexation of the Party of Nicoya to Costa Rica", countryCode));
            items.Add(new PublicHoliday(year, 8, 2, "Fiesta de Nuestra Señora de los Ángeles", "Feast of Our Lady of the Angels", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Día de la Madre", "Mother's Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 15, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 1, "Día de la Abolición del Ejército", "Army Abolition Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Costa_Rica",
            };
        }
    }
}
