using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Russia
    /// </summary>
    public class RussiaProvider : IPublicHolidayProvider
    {
        /// <summary>
        /// RussiaProvider
        /// </summary>
        public RussiaProvider()
        {
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.RU;

            var items = new List<PublicHoliday>();
            #region New Years Extended Holidays
            items.Add(new PublicHoliday(year, 1, 1, "Новый год", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 2, "Новогодние каникулы", "New Year holiday", countryCode));
            items.Add(new PublicHoliday(year, 1, 3, "Новогодние каникулы", "New Year holiday", countryCode));
            items.Add(new PublicHoliday(year, 1, 4, "Новогодние каникулы", "New Year holiday", countryCode));
            items.Add(new PublicHoliday(year, 1, 5, "Новогодние каникулы", "New Year holiday", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Новогодние каникулы", "New Year holiday", countryCode));
            items.Add(new PublicHoliday(year, 1, 7, "Рождество Христово", "Orthodox Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 8, "Новогодние каникулы", "New Year holiday", countryCode));
            #endregion

            // with the exception of New Years/Christmas, If a holiday falls onto the weekend
            // then the holiday is shifted to the next non-weekend and non-holiday day (see https://github.com/nager/Nager.Date/issues/324)
            var fatherlandDay = new DateTime(year, 2, 23).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(fatherlandDay, "День защитника Отечества", "Defender of the Fatherland Day", countryCode, 1918));
            var womensDay = new DateTime(year, 3, 8).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(womensDay, "Международный женский день", "International Women's Day", countryCode, 1913));
            var labourDay = new DateTime(year, 5, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(labourDay, "День труда", "Labour Day", countryCode));
            var victoryDay = new DateTime(year, 5, 9).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(victoryDay, "День Победы", "Victory Day", countryCode));
            var russiaDay = new DateTime(year, 6, 12).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(russiaDay, "День России", "Russia Day", countryCode, 2002));
            var unityDay = new DateTime(year, 11, 4).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(unityDay, "День народного единства", "Unity Day", countryCode, 2005));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Russia"
            };
        }
    }
}
