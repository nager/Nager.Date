using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Niger HolidayProvider
    /// </summary>
    internal class NigerHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Niger HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NigerHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.NE;
 
            //TODO: Add islamic public holidays

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 4, 24, "Concord Day", "Concord Day", countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new Holiday(year, 8, 3, "Nigerien Independence Day", "Nigerien Independence Day", countryCode));
            items.Add(new Holiday(year, 12, 18, "Nigerien Republic Day", "Nigerien Republic Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Niger"
            };
        }
    }
}
