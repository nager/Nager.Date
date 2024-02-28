using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Gambia HolidayProvider
    /// </summary>
    internal class GambiaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Gambia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GambiaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.GM;

            //TODO: Add islamic public holidays

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 2, 18, "Independence Day", "Independence Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new Holiday(year, 5, 25, "Africa Day", "Africa Day", countryCode));
            items.Add(new Holiday(year, 7, 22, "Revolution Day", "Revolution Day", countryCode));
            items.Add(new Holiday(year, 8, 15, "Assumption Day", "Assumption Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Gambia",
            };
        }
    }
}
