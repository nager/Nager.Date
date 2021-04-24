using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// New Zealand
    /// </summary>
    public class NewZealandProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// NewZealandProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NewZealandProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.NZ;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var firstMondayInJune = DateSystem.FindDay(year, 6, DayOfWeek.Monday, 1);
            var fourthMondayInOctober = DateSystem.FindDay(year, 10, DayOfWeek.Monday, 4);

            var items = new List<PublicHoliday>();

            #region New Year's Day with fallback

            var newYearDay1 = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(newYearDay1, "New Year's Day", "New Year's Day", countryCode));

            var newYearDay2 = new DateTime(year, 1, 2).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            items.Add(new PublicHoliday(newYearDay2, "Day after New Year's Day", "Day after New Year's Day", countryCode));

            #endregion

            #region Anzac Day with fallback

            if (year >= 2015)
            {
                var anzacDay = new DateTime(year, 4, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
                items.Add(new PublicHoliday(anzacDay, "Anzac Day", "Anzac Day", countryCode));
            }
            else
            {
                items.Add(new PublicHoliday(year, 4, 25, "Anzac Day", "Anzac Day", countryCode));
            }

            #endregion

            #region Anzac Day with fallback

            if (year >= 2016)
            {
                var anzacDay = new DateTime(year, 2, 6).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
                items.Add(new PublicHoliday(anzacDay, "Waitangi Day", "Waitangi Day", countryCode));
            }
            else
            {
                items.Add(new PublicHoliday(year, 2, 6, "Waitangi Day", "Waitangi Day", countryCode));
            }

            #endregion

            #region Christmas Day with fallback

            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(christmasDay, "Christmas Day", "Christmas Day", countryCode));

            #endregion

            #region Boxing Day with fallback

            var boxingDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            items.Add(new PublicHoliday(boxingDay, "Boxing Day", "Boxing Day", countryCode));

            #endregion

            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new PublicHoliday(firstMondayInJune, "Queen's Birthday", "Queen's Birthday", countryCode));
            items.Add(new PublicHoliday(fourthMondayInOctober, "Labour Day", "Labour Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_New_Zealand"
            };
        }
    }
}
