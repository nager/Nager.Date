using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Hungary
    /// https://en.wikipedia.org/wiki/Public_holidays_in_Hungary
    /// </summary>
    public class HungaryProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// HungaryProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public HungaryProvider(ICatholicProvider catholicProvider)
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
            var countryCode = CountryCode.HU;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Újév", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 15, "Nemzeti ünnep", "1848 Revolution Memorial Day", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Húsvétvasárnap", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Húsvéthétfő", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "A munka ünnepe", "Labour day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Pünkösdvasárnap", "Pentecost", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pünkösdhétfő", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 8, 20, "Az államalapítás ünnepe", "State Foundation Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 23, "Nemzeti ünnep", "1956 Revolution Memorial Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Mindenszentek", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Karácsony", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Karácsony másnapja", "St. Stephen's Day", countryCode));

            if (year >= 2017)
            {
                items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Nagypéntek", "Good Friday", countryCode));
            }

            return items.OrderBy(o => o.Date);
        }
    }
}
