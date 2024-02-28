using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Gabon
    /// </summary>
    internal class GabonProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// GabonProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GabonProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.GA;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 3, 12, "Renovation Day", "Renovation Day", countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new Holiday(year, 4, 17, "Women's Day", "Women's Day", countryCode));
            items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new Holiday(year, 5, 6, "Martyr's Day", "Martyr's Day", countryCode));
            items.Add(this._catholicProvider.WhitMonday("Whit Monday", year, countryCode));
            items.Add(new Holiday(year, 8, 15, "Assumption Day", "Assumption Day", countryCode));
            items.Add(new Holiday(year, 8, 17, "Independence Day", "Independence Day", countryCode));
            //items.Add(new PublicHoliday(year, 8, 8, "Eid al-Fitr", "End of Ramadan", countryCode));
            items.Add(new Holiday(year, 11, 1, "All Saints' Day", "All Saints' Day", countryCode));
            //items.Add(new PublicHoliday(year, 10, 15, "Eid al-Adha", "Feast of the Sacrifice", countryCode));
            items.Add(new Holiday(year, 12, 25, "Božić", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Gabon",
            };
        }
    }
}
