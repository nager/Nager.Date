using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Luxembourg HolidayProvider
    /// </summary>
    internal class LuxembourgHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Luxembourg HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public LuxembourgHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.LU;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Neijoerschdag", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.EasterMonday("Ouschterméindeg", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Dag vun der Aarbecht", "Labour Day", countryCode));
            items.Add(new Holiday(year, 5, 9, "Europadag", "Europe Day", countryCode, 2019));
            items.Add(this._catholicProvider.GoodFriday("Karfreideg", year, countryCode).SetType(HolidayTypes.Bank));
            items.Add(this._catholicProvider.AscensionDay("Christi Himmelfaart", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("Péngschtméindeg", year, countryCode));
            items.Add(new Holiday(year, 6, 23, "Groussherzogsgebuertsdag", "Sovereign's birthday", countryCode));
            items.Add(new Holiday(year, 8, 15, "Léiffrawëschdag", "Assumption Day", countryCode));
            items.Add(new Holiday(year, 11, 1, "Allerhellgen", "All Saints' Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Chrëschtdag", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Stiefesdag", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Luxembourg"
            };
        }
    }
}
