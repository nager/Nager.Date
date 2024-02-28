using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Guatemala HolidayProvider
    /// </summary>
    internal class GuatemalaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Guatemala HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GuatemalaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.GT;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.MaundyThursday("Maundy Thursday", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-1), "Holy Saturday", "Holy Saturday", countryCode));
            items.Add(this._catholicProvider.EasterSunday("Easter Sunday", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "International Workers' Day", "International Workers' Day", countryCode));
            items.Add(new Holiday(year, 6, 30, "Army Day", "Army Day", countryCode));
            items.Add(new Holiday(year, 9, 15, "Independence Day", "Independence Day", countryCode));
            items.Add(new Holiday(year, 10, 20, "Revolution Day", "Revolution Day", countryCode));
            items.Add(new Holiday(year, 11, 1, "All Saints' Day", "All Saints' Day", countryCode));
            items.Add(new Holiday(year, 12, 24, "Christmas Eve", "Christmas Eve", countryCode));
            items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 31, "New Year's Eve", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Guatemala",
            };
        }
    }
}
