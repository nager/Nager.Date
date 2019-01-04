using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class SouthAfricaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// South Africa
        /// https://en.wikipedia.org/wiki/Public_holidays_in_South_Africa
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SouthAfricaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.ZA;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode, 1910));
            items.Add(new PublicHoliday(year, 3, 21, "Human Rights Day", "Human Rights Day", countryCode, 1990));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode, 1910));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Family Day", "Family Day", countryCode, 1910));
            items.Add(new PublicHoliday(year, 4, 27, "Freedom Day", "Freedom Day", countryCode, 1994));
            items.Add(new PublicHoliday(year, 5, 1, "Workers' Day", "Workers' Day", countryCode, 1910));
            items.Add(new PublicHoliday(year, 6, 16, "Youth Day", "Youth Day", countryCode, 1995));
            items.Add(new PublicHoliday(year, 8, 9, "National Women's Day", "National Women's Day", countryCode, 1995));
            items.Add(new PublicHoliday(year, 9, 24, "Heritage Day", "Heritage Day", countryCode, 1995));
            items.Add(new PublicHoliday(year, 12, 16, "Day of Reconciliation", "Day of Reconciliation", countryCode, 1995));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode, 1910));
            items.Add(new PublicHoliday(year, 12, 26, "Day of Goodwill", "St. Stephen's Day", countryCode, 1910));

            return items.OrderBy(o => o.Date);
        }
    }
}
