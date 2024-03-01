using Nager.Date.Models;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Morocco HolidayProvider
    /// </summary>
    internal class MoroccoHolidayProvider : IHolidayProvider
    {
        /// <summary>
        /// Morocco HolidayProvider
        /// </summary>
        public MoroccoHolidayProvider()
        {
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.MA;

            //TODO:Islamic calendar
            //Muslim New Year (Fatih Muharram)
            //Birth of the Prophet Muhammad (Eid Al Mawled)
            //Eid ul-Fitr (Eid Sghir)
            //Eid ul-Adha (Eid Kbir)

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Ras l' âm", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 1, 11, "Takdim watikat al-istiqlal", "Proclamation of Independence", countryCode, 1956));
            items.Add(new Holiday(year, 5, 1, "Eid Ash-Shughl", "Labour Day", countryCode));
            items.Add(new Holiday(year, 7, 30, "Eid Al-Ârch", "Enthronement", countryCode));
            items.Add(new Holiday(year, 8, 14, "Oued Ed-Dahab Day", "Zikra Oued Ed-Dahab", countryCode));
            items.Add(new Holiday(year, 8, 20, "Thawrat al malik wa shâab", "Revolution of the King and the People", countryCode));
            items.Add(new Holiday(year, 8, 21, "Eid Al Chabab", "Youth Day", countryCode));
            items.Add(new Holiday(year, 11, 6, "Eid Al Massira Al Khadra", "Green March", countryCode));
            items.Add(new Holiday(year, 11, 18, "Eid Al Istiqulal", "Independence Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Morocco"
            };
        }
    }
}