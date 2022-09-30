using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Estonia
    /// </summary>
    internal class EstoniaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// EstoniaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public EstoniaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.EE;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "uusaasta", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 24, "iseseisvuspäev", "Independence Day", countryCode, 1918));
            items.Add(this._catholicProvider.GoodFriday("suur reede", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("ülestõusmispühade 1. püha", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "kevadpüha", "Spring Day", countryCode));
            items.Add(this._catholicProvider.Pentecost("nelipühade 1. püha", year, countryCode));
            items.Add(new PublicHoliday(year, 6, 23, "võidupüha and jaanilaupäev", "Victory Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 24, "jaanipäev", "Midsummer Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 20, "taasiseseisvumispäev", "Day of Restoration of Independence", countryCode, 1991));
            items.Add(new PublicHoliday(year, 12, 24, "jõululaupäev", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "esimene jõulupüha", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "teine jõulupüha", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Estonia",
            };
        }
    }
}
