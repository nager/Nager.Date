using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Tunisia
    /// </summary>
    internal class TunisiaProvider : IPublicHolidayProvider
    {
        /// <summary>
        /// TunisiaProvider
        /// </summary>
        public TunisiaProvider()
        {
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            //TODO:Add moon calendar logic

            var countryCode = CountryCode.TN;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 14, "Revolution and Youth Day", "Revolution and Youth Day", countryCode));
            //items.Add(new PublicHoliday(year, 2, 4, "Mouled (Prophet's Anniversary)", "Mouled (Prophet's Anniversary)", countryCode)); // depending on the moon calender      
            items.Add(new PublicHoliday(year, 3, 20, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 9, "Martyrs' Day", "Martyrs' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 1, "Victory Day", "Victory Day", countryCode));
            //items.Add(new PublicHoliday(year, 7, 18, "Eid al-Fitr", "Eid al-Fitr", countryCode)); //depending on the moon calender
            items.Add(new PublicHoliday(year, 7, 25, "Republic Day", "Republic Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 13, "Women's Day", "Women's Day", countryCode));
            //items.Add(new PublicHoliday(year, 9, 24, "Eid al-Idha", "Eid al-Idha", countryCode)); //depending on the moon calender
            //items.Add(new PublicHoliday(year, 10, 15, "Hegire (Islamic New Year)", "Hegire (Islamic New Year) (2015)", countryCode)); //depending on the moon calender
            items.Add(new PublicHoliday(year, 10, 15, "Eid El Jala'", "Eid El Jala'", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Tunisia"
            };
        }
    }
}
