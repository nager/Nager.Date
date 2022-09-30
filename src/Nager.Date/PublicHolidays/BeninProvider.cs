using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Benin
    /// </summary>
    internal class BeninProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// BeninProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BeninProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BJ;

            //TODO: Add islamic public holidays

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 10, "Traditional Day", "Traditional Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Ascension Day", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Easter Sunday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("Whit Monday", year, countryCode));
            items.Add(new PublicHoliday(year, 8, 1, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Assumption Day", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 26, "Armed Forces Day", "Armed Forces Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "All Saints' Day", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 30, "National Day", "National Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Benin"
            };
        }
    }
}
