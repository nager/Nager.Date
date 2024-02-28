using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Madagascar HolidayProvider
    /// </summary>
    internal class MadagascarHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Madagascar HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public MadagascarHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.MG;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 3, 29, "Martyrs' Day", "Martyrs' Day", countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Ascension Day", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("Whit Monday", year, countryCode));
            items.Add(new Holiday(year, 6, 26, "Independence Day", "Independence Day", countryCode));
            items.Add(new Holiday(year, 8, 15, "Assumption Day", "Assumption Day", countryCode));
            items.Add(new Holiday(year, 11, 1, "All Saints' Day", "All Saints' Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Madagascar"
            };
        }
    }
}
