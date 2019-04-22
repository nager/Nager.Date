using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Suriname
    /// https://en.wikipedia.org/wiki/Suriname#National_holidays
    /// </summary>
    public class SurinameProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// SurinameProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SurinameProvider(ICatholicProvider catholicProvider)
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
            var countryCode = CountryCode.SR;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var thirdSundayInJanuary = DateSystem.FindDay(year, 1, DayOfWeek.Sunday, 1);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Three Kings Day", "Three Kings Day", countryCode));
            items.Add(new PublicHoliday(thirdSundayInJanuary, "World Religion Day", "World Religion Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 25, "Day of the Revolution", "Day of the Revolution", countryCode));
            //TODO:Holi
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Easter Sunday", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Ascension Day", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 5, "Indian Arrival Day", "Indian Arrival Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 1, "Keti Koti", "Keti Koti", countryCode));
            items.Add(new PublicHoliday(year, 8, 8, "Javanese Arrival Day", "Javanese Arrival Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 9, "Indigenous People's Day", "Indigenous People's Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 10, "Day of the Maroons", "Day of the Maroons", countryCode));
            items.Add(new PublicHoliday(year, 10, 20, "Chinese Arrival day", "Chinese Arrival day", countryCode));
            //TODO:Largest festival of Hindus
            items.Add(new PublicHoliday(year, 11, 25, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "Boxing Day", countryCode));

            if (year > 1901 && year < 2100)
            {
                //LunisolarCalendar .net implementation only valid are between 1901 and 2100, inclusive.
                //https://github.com/dotnet/coreclr/blob/master/src/mscorlib/shared/System/Globalization/ChineseLunisolarCalendar.cs
                //https://stackoverflow.com/questions/30719176/algorithm-to-find-the-gregorian-date-of-the-chinese-new-year-of-a-certain-gregor
                var chineseCalendar = new ChineseLunisolarCalendar();
                var chineseNewYear = chineseCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0);
                items.Add(new PublicHoliday(chineseNewYear, "Chinese New Year", "Chinese New Year", countryCode));
            }

            return items.OrderBy(o => o.Date);
        }
    }
}
