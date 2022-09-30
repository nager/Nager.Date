using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Paraguay
    /// </summary>
    internal class ParaguayProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// ParaguayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ParaguayProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.PY;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 1, "Dia de los héroes", "Heroes' day", countryCode));
            items.Add(this._catholicProvider.MaundyThursday("Jueves Santo", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Día de los Trabajadores", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 14, "Independencia", "Paraguayan Independence", countryCode));
            items.Add(new PublicHoliday(year, 5, 15, "Independencia", "Paraguayan Independence", countryCode));
            items.Add(new PublicHoliday(year, 6, 12, "Dia de la Paz del Chaco", "Chaco Armistice", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Fundación de Asunción", "Founding of Asunción", countryCode));
            items.Add(new PublicHoliday(year, 9, 29, "Victoria de Boquerón", "Boqueron Battle Victory Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Virgen de Caacupé", "Virgin of Caacupe", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Día de Navidad", "Christmas Day", countryCode));
            
            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Paraguay"
            };
        }
    }
}
