using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Serbia
    /// </summary>
    internal class SerbiaProvider : IPublicHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// SerbiaProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public SerbiaProvider(IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.RS;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nova Godina", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 2, "Nova Godina", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 7, "Božić", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 15, "Dan državnosti Srbije", "Statehood Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 16, "Dan državnosti Srbije", "Statehood Day", countryCode));
            items.Add(this._orthodoxProvider.GoodFriday("Veliki petak", year, countryCode));
            items.Add(this._orthodoxProvider.EasterSunday("Vaskrs (Uskrs)", year, countryCode));
            items.Add(this._orthodoxProvider.EasterMonday("Vaskrsni (Uskrsni) ponedeljak", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Praznik rada", "May Day / International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 2, "Praznik rada", "May Day / International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 11, "Dan primirja", "Armistice Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Serbia"
            };
        }
    }
}
