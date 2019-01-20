using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Honduras
    /// https://en.wikipedia.org/wiki/Public_holidays_in_Honduras
    /// </summary>
    public class HondurasProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// HondurasProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public HondurasProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.HN;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 14, "America's Day", "America's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Holy Thursday", "Holy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "Holy Saturday", "Holy Saturday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 15, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 3, "Francisco Morazán's Day/Soldier's Day", "Francisco Morazán's Day/Soldier's Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 12, "Columbus Day", "Columbus Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 21, "Army Day", "Army Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            
            return items.OrderBy(o => o.Date);
        }
    }
}
