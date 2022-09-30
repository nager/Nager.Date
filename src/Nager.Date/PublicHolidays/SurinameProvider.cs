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
    /// </summary>
    internal class SurinameProvider : IPublicHolidayProvider
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

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.SR;

            var thirdSundayInJanuary = DateSystem.FindDay(year, Month.January, DayOfWeek.Sunday, Occurrence.Third);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Three Kings Day", "Three Kings Day", countryCode));
            items.Add(new PublicHoliday(thirdSundayInJanuary, "World Religion Day", "World Religion Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 25, "Day of the Revolution", "Day of the Revolution", countryCode));
            //TODO:Holi
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Easter Sunday", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Ascension Day", year, countryCode));
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

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Suriname#National_holidays"
            };
        }
    }
}
