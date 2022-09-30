using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Guyana
    /// </summary>
    internal class GuyanaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// GuyanaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GuyanaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.GY;

            var firstMondayInJuly = DateSystem.FindDay(year, Month.July, DayOfWeek.Monday, Occurrence.First);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 23, "Republic Day", "Republic Day", countryCode));
            //TODO:Phagwah ??? (Hindu calendar)
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 5, "Arrival Day", "Arrival Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 26, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(firstMondayInJuly, "Caricom Day", "Caricom Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 1, "Emancipation Day", "Emancipation Day", countryCode));
            //TODO:Deepavali ??? (Hindu calendar)
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "Boxing Day", countryCode));
            //TODO:Youman-Nabi ??? (Muslim holidays)
            //TODO:Eid-ul-Adha ??? (Muslim holidays)
            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Guyana",
            };
        }
    }
}
