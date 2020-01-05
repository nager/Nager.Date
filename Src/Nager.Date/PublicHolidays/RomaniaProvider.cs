using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Romania
    /// </summary>
    public class RomaniaProvider : IPublicHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// RomaniaProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public RomaniaProvider(IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.RO;
            var easterSunday = this._orthodoxProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Anul Nou", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 2, "Anul Nou", "Day after New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 24, "Unirea Principatelor Române/Mica Unire", "Union Day/Small Union", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Vinerea mare", "Good Friday", countryCode, 2018));
            items.Add(new PublicHoliday(easterSunday, "Paștele", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Paștele", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Ziua Muncii", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 1, "Ziua Copilului", "Children's Day", countryCode, 2017));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Rusaliile", "Pentecost", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Rusaliile", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Adormirea Maicii Domnului/Sfânta Maria Mare", "Dormition of the Theotokos", countryCode));
            items.Add(new PublicHoliday(year, 11, 30, "Sfântul Andrei", "St. Andrew's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 1, "Ziua Națională/Marea Unire", "National Day/Great Union", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Crăciunul", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Crăciunul", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date)
                        .Where(x => x.LaunchYear == null || x.LaunchYear <= year);
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Romania"
            };
        }
    }
}
