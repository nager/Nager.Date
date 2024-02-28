using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Cuba HolidayProvider
    /// </summary>
    internal class CubaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Cuba HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CubaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.CU;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Triunfo de la Revolución", "Triumph of the Revolution", countryCode));
            items.Add(new Holiday(year, 1, 2, "Día de Victoria de las Fuerzas Armadas", "Victory of Fidel Castro", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Día de los trabajadores", "Labour Day", countryCode));
            items.Add(new Holiday(year, 7, 25, "Conmemoración del asalto a Moncada", "Day before the Commemoration of the Assault of the Moncada garrison", countryCode));
            items.Add(new Holiday(year, 7, 26, "Día de la Rebeldía Nacional", "Commemoration of the Assault of the Moncada garrison", countryCode));
            items.Add(new Holiday(year, 7, 27, "Conmemoración del asalto a Moncada", "Day after the Commemoration of the Assault of the Moncada garrison", countryCode));
            items.Add(new Holiday(year, 10, 10, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));       

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Cuba",
            };
        }
    }
}
