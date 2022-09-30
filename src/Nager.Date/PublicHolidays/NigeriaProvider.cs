using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Nigeria
    /// </summary>
    internal class NigeriaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// NigerProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NigeriaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.NG;

            //TODO: Add islamic public holidays

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Workers' Day", "Workers' Day", countryCode).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1)));
            items.Add(new PublicHoliday(year, 5, 27, "Children's Day", "Children's Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 12, "Democracy Day", "Democracy Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 1, "National Day", "National Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "National Youth Day", "National Youth Day", countryCode, 2020));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1)));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "Boxing Day", countryCode).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2)));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Nigeria",
                "https://www.officeholidays.com/countries/nigeria/"
            };
        }
    }
}
