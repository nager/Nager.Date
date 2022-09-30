using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Lesotho
    /// </summary>
    internal class LesothoProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// LesothoProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public LesothoProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.LS;
  
            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 11, "Moshoeshoe Day", "Moshoeshoe Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Workers' Day", "Workers' Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Ascension Day", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 25, "Africa Day/ Heroes' Day", "Africa Day/ Heroes' Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 17, "King Letsie III's Birthday", "King Letsie III's Birthday", countryCode));
            items.Add(new PublicHoliday(year, 10, 4, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Lesotho"
            };
        }
    }
}
