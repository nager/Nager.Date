using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// United Kingdom
    /// </summary>
    public class UnitedKingdomProvider : IPublicHolidayProvider, ICountyProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// UnitedKingdomProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public UnitedKingdomProvider(ICatholicProvider catholicProvider)
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
            var countryCode = CountryCode.GB;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var firstMondayInMay = DateSystem.FindDay(year, 5, DayOfWeek.Monday, 1);
            var lastMondayInMay = DateSystem.FindLastDay(year, 5, DayOfWeek.Monday);
            var firstMondayInAugust = DateSystem.FindDay(year, 8, DayOfWeek.Monday, 1);
            var lastMondayInAugust = DateSystem.FindLastDay(year, 8, DayOfWeek.Monday);

            var items = new List<PublicHoliday>();

            #region New Year's Day with fallback

            var newYearDay = new DateTime(year, 1, 1);
            if (newYearDay.IsWeekend(countryCode))
            {
                var newYearDayMonday = DateSystem.FindDay(year, 1, 1, DayOfWeek.Monday);
                var newYearDayTuesday = DateSystem.FindDay(year, 1, 1, DayOfWeek.Tuesday);

                items.Add(new PublicHoliday(newYearDay, "New Year's Day", "New Year's Day", countryCode, null, new string[] { "GB-NIR" }));
                items.Add(new PublicHoliday(newYearDayMonday, "New Year's Day", "New Year's Day", countryCode, null, new string[] { "GB-ENG", "GB-WLS" }));
                items.Add(new PublicHoliday(newYearDayTuesday, "New Year's Day", "New Year's Day", countryCode, null, new string[] { "GB-SCT" }));
            }
            else
            {
                items.Add(new PublicHoliday(newYearDay, "New Year's Day", "New Year's Day", countryCode));
            }

            #endregion

            #region New Year's Day 2 with fallback

            var newYearDay2 = new DateTime(year, 1, 2).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(newYearDay2, "New Year's Day", "New Year's Day", countryCode, null, new string[] { "GB-SCT" }));

            #endregion

            items.Add(new PublicHoliday(year, 3, 17, "Saint Patrick's Day", "Saint Patrick's Day", countryCode, null, new string[] { "GB-NIR" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(lastMondayInMay, "Spring Bank Holiday", "Spring Bank Holiday", countryCode, 1971));
            items.Add(new PublicHoliday(year, 11, 30, "Saint Andrew's Day", "Saint Andrew's Day", countryCode, null, new string[] { "GB-SCT" }));
            items.Add(new PublicHoliday(year, 7, 12, "Battle of the Boyne", "Battle of the Boyne", countryCode, null, new string[] { "GB-NIR" }));
            items.Add(new PublicHoliday(firstMondayInAugust, "Summer Bank Holiday", "Summer Bank Holiday", countryCode, 1971, new string[] { "GB-SCT" }));
            items.Add(new PublicHoliday(lastMondayInAugust, "Summer Bank Holiday", "Summer Bank Holiday", countryCode, 1971, new string[] { "GB-ENG", "GB-WLS" }));

            #region Early May Bank Holiday

            var earlyMayBankHoliday = new PublicHoliday(firstMondayInMay, "Early May Bank Holiday", "Early May Bank Holiday", countryCode, 1978);

            if (year == 2020)
            {
                //https://www.bbc.co.uk/news/uk-48565417
                var secondFridayInMay = DateSystem.FindDay(year, 5, DayOfWeek.Friday, 2);
                earlyMayBankHoliday.Date = secondFridayInMay;
            }

            items.Add(earlyMayBankHoliday);

            #endregion

            #region Christmas Day with fallback

            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(3), sunday => sunday.AddDays(2));
            items.Add(new PublicHoliday(christmasDay, "Christmas Day", "Christmas Day", countryCode));

            #endregion

            #region St. Stephen's Day with fallback

            var sanktStehpenDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(sanktStehpenDay, "Boxing Day", "St. Stephen's Day", countryCode));

            #endregion

            return items.OrderBy(o => o.Date);
        }
        /// <summary>
        /// Get counties
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetCounties()
        {
            return new Dictionary<string, string>
            {
                { "GB-NIR", "Northern Ireland" },
                { "GB-SCT", "Scotland" },
                { "GB-ENG", "England" },
                { "GB-WLS", "Wales" },
            };
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_United_Kingdom",
                "https://de.wikipedia.org/wiki/Feiertage_im_Vereinigten_K%C3%B6nigreich"
            };
        }
    }
}
