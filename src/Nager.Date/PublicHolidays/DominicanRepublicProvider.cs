using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Dominican Republic
    /// </summary>
    internal class DominicanRepublicProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// DominicanRepublicProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public DominicanRepublicProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.DO;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Dia de Reyes", "Day of Kings", countryCode));
            items.Add(new PublicHoliday(year, 1, 21, "Our Lady of Altagracia", "Our Lady of Altagracia", countryCode));
            items.Add(new PublicHoliday(year, 1, 26, "Duarte's Birthday", "Duarte's Birthday", countryCode));
            items.Add(new PublicHoliday(year, 2, 27, "Independence Day", "Independence Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 28, "Mother's Day", "Mother's Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 16, "Restoration Day", "Restoration Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 24, "Nuestra Senora de las Mercedes", "Our Lady of Mercy", countryCode));
            items.Add(new PublicHoliday(year, 11, 6, "Constitution Day", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Dominican_Republic",
            };
        }
    }
}
