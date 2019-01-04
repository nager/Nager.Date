using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class GabonProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Gabon
        /// https://en.wikipedia.org/wiki/Public_holidays_in_Gabon
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GabonProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.GA;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 12, "Renovation Day", "Renovation Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 4, 17, "Women's Day", "Women's Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 6, "Martyr's Day", "Martyr's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Whit Monday", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Assumption Day", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 17, "Independence Day", "Independence Day", countryCode));
            //items.Add(new PublicHoliday(year, 8, 8, "Eid al-Fitr", "End of Ramadan", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "All Saints' Day", "All Saints' Day", countryCode));
            //items.Add(new PublicHoliday(year, 10, 15, "Eid al-Adha", "Feast of the Sacrifice", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Božić", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
