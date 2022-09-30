using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Cuba
    /// </summary>
    internal class CubaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// CubaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CubaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.CU;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Triunfo de la Revolución", "Triumph of the Revolution", countryCode));
            items.Add(new PublicHoliday(year, 1, 2, "Día de Victoria de las Fuerzas Armadas", "Victory of Fidel Castro", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Día de los trabajadores", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 25, "Conmemoración del asalto a Moncada", "Day before the Commemoration of the Assault of the Moncada garrison", countryCode));
            items.Add(new PublicHoliday(year, 7, 26, "Día de la Rebeldía Nacional", "Commemoration of the Assault of the Moncada garrison", countryCode));
            items.Add(new PublicHoliday(year, 7, 27, "Conmemoración del asalto a Moncada", "Day after the Commemoration of the Assault of the Moncada garrison", countryCode));
            items.Add(new PublicHoliday(year, 10, 10, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));       

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Cuba",
            };
        }
    }
}
