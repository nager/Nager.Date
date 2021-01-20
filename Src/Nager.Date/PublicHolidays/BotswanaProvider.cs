using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Botswana
    /// </summary>
    public class BotswanaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// BotswanaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BotswanaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.BW;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var thirdMondayInJuly = DateSystem.FindDay(year, 7, DayOfWeek.Monday, 3);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Ascension Day", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 1, "Sir Seretse Khama Day", "Sir Seretse Khama Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayInJuly, "Presidents' Day", "Presidents' Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 30, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 1, "Botswana Day holiday", "Botswana Day holiday", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Botswana"
            };
        }
    }
}
