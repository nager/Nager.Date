using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// United States of America
    /// </summary>
    public class UnitedStatesProvider : IPublicHolidayProvider
    {
        /// <summary>
        /// UnitedStatesProvider
        /// </summary>
        public UnitedStatesProvider()
        {
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.US;

            var thirdMondayInJannuar = DateSystem.FindDay(year, 1, DayOfWeek.Monday, 3);
            var thirdMondayInFebruary = DateSystem.FindDay(year, 2, DayOfWeek.Monday, 3);
            var lastMondayInMay = DateSystem.FindLastDay(year, 5, DayOfWeek.Monday);
            var firstMondayInSeptember = DateSystem.FindDay(year, 9, DayOfWeek.Monday, 1);
            var secondMondayInOctober = DateSystem.FindDay(year, 10, DayOfWeek.Monday, 2);
            var fourthThursdayInNovember = DateSystem.FindDay(year, 11, DayOfWeek.Thursday, 4);

            var items = new List<PublicHoliday>();

            #region New Years Day with fallback

            var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(newYearsDay, "New Year's Day", "New Year's Day", countryCode));

            #endregion

            items.Add(new PublicHoliday(thirdMondayInJannuar, "Martin Luther King, Jr. Day", "Martin Luther King, Jr. Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayInFebruary, "Presidents Day", "Washington's Birthday", countryCode));
            items.Add(new PublicHoliday(lastMondayInMay, "Memorial Day", "Memorial Day", countryCode));

            #region Independence Day with fallback

            var independenceDay = new DateTime(year, 7, 4).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(independenceDay, "Independence Day", "Independence Day", countryCode));

            #endregion

            items.Add(new PublicHoliday(firstMondayInSeptember, "Labor Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(secondMondayInOctober, "Columbus Day", "Columbus Day", countryCode, null, new string[] { "US-AL", "US-AZ", "US-CO", "US-CT", "US-DC", "US-GA", "US-ID", "US-IL", "US-IN", "US-IA", "US-KS", "US-KY", "US-LA", "US-ME", "US-MD", "US-MA", "US-MS", "US-MO", "US-MT", "US-NE", "US-NH", "US-NJ", "US-NM", "US-NY", "US-NC", "US-OH", "US-OK", "US-PA", "US-RI", "US-SC", "US-TN", "US-UT", "US-VA", "US-WV" }));

            #region Veterans Day with fallback

            var veteransDay = new DateTime(year, 11, 11).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(veteransDay, "Veterans Day", "Veterans Day", countryCode));

            #endregion

            items.Add(new PublicHoliday(fourthThursdayInNovember, "Thanksgiving Day", "Thanksgiving Day", countryCode, 1863));

            #region Christmas Day with fallback

            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(christmasDay, "Christmas Day", "Christmas Day", countryCode));

            #endregion

            #region Inauguration Day (every 4 years)

            if ((year - 1) % 4 == 0)
            {
                if (year >= 1937)
                {
                    items.Add(new PublicHoliday(year, 1, 20, "Inauguration Day", "Inauguration Day", countryCode, null, new string[] { "US-DC", "US-LA", "US-MD", "US-VA" }));
                }
                else
                {
                    items.Add(new PublicHoliday(year, 3, 4, "Inauguration Day", "Inauguration Day", countryCode, null, new string[] { "US-DC", "US-LA", "US-MD", "US-VA" }));
                }
            }

            #endregion

            return items.OrderBy(o => o.Date);
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Federal_holidays_in_the_United_States"
            };
        }
    }
}
