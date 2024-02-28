using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Honduras HolidayProvider
    /// </summary>
    internal class HondurasHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Honduras HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public HondurasHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.HN;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 4, 14, "America's Day", "America's Day", countryCode));
            items.Add(this._catholicProvider.MaundyThursday("Holy Thursday", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-1), "Holy Saturday", "Holy Saturday", countryCode));
            items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new Holiday(year, 9, 15, "Independence Day", "Independence Day", countryCode));
            items.Add(new Holiday(year, 10, 3, "Francisco Morazán's Day/Soldier's Day", "Francisco Morazán's Day/Soldier's Day", countryCode));
            items.Add(new Holiday(year, 10, 12, "Columbus Day", "Columbus Day", countryCode));
            items.Add(new Holiday(year, 10, 21, "Army Day", "Army Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            
            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Honduras",
            };
        }
    }
}
