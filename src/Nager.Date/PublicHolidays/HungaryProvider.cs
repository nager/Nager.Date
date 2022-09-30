using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Hungary
    /// </summary>
    internal class HungaryProvider : IPublicHolidayProvider
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

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.HU;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Újév", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 15, "Nemzeti ünnep", "1848 Revolution Memorial Day", countryCode));
            items.Add(this._catholicProvider.EasterSunday("Húsvétvasárnap", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Húsvéthétfő", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "A munka ünnepe", "Labour day", countryCode));
            items.Add(this._catholicProvider.Pentecost("Pünkösdvasárnap", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("Pünkösdhétfő", year, countryCode));
            items.Add(new PublicHoliday(year, 8, 20, "Az államalapítás ünnepe", "State Foundation Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 23, "Nemzeti ünnep", "1956 Revolution Memorial Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Mindenszentek", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Karácsony", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Karácsony másnapja", "St. Stephen's Day", countryCode));

            if (year >= 2017)
            {
                items.Add(this._catholicProvider.GoodFriday("Nagypéntek", year, countryCode));
            }

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Hungary",
            };
        }
    }
}
