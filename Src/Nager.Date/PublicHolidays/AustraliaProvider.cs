using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Australia
    /// https://en.wikipedia.org/wiki/Public_holidays_in_Australia
    /// </summary>
    public class AustraliaProvider : IPublicHolidayProvider, ICountyProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// AustraliaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public AustraliaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// GetCounties
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetCounties()
        {
            return new Dictionary<string, string>
            {
                { "AUS-ACT", "Australian Capital Territory" },
                { "AUS-NSW", "New South Wales" },
                { "AUS-NT", "Northern Territory" },
                { "AUS-QLD", "Queensland" },
                { "AUS-SA", "South Australia" },
                { "AUS-TAS", "Tasmania" },
                { "AUS-VIC", "Victoria" },
                { "AUS-WA", "Western Australia" }
            };
        }

        /// <summary>
        /// Gets all Holidays for Australia
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.AU;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var australiaDayHoliday = new DateTime(year, 1, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            var firstMondayInMarch = DateSystem.FindDay(year, 3, DayOfWeek.Monday, 1);
            var secondMondayInMarch = DateSystem.FindDay(year, 3, DayOfWeek.Monday, 2);
            var anzacDayHolidayWA = new DateTime(year, 4, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            var anzacDayHolidayNT = new DateTime(year, 4, 25).Shift(saturday => saturday.AddDays(0), sunday => sunday.AddDays(1));
            var firstMondayInMay = DateSystem.FindDay(year, 5, DayOfWeek.Monday, 1);
            var reconciliationDayACT = new DateTime(year, 5, 27).ShiftToNext(DayOfWeek.Monday);
            var firstMondayInJune = DateSystem.FindDay(year, 6, DayOfWeek.Monday, 1);
            var secondMondayInJune = DateSystem.FindDay(year, 6, DayOfWeek.Monday, 2);
            var firstMondayInAugust = DateSystem.FindDay(year, 8, DayOfWeek.Monday, 1);
            var firstMondayInOctober = DateSystem.FindDay(year, 10, DayOfWeek.Monday, 1);
            var firstTuesdayInNovemberVIC = DateSystem.FindDay(year, 11, DayOfWeek.Tuesday, 1);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            if (year <= 2011)
                items.Add(new PublicHoliday(year, 1, 26, "Australia Day", "Australia Day", countryCode));
            else
                items.Add(new PublicHoliday(australiaDayHoliday, "Australia Day", "Australia Day", countryCode, 2012));
            items.Add(new PublicHoliday(firstMondayInMarch, "Labour Day", "Labour Day", countryCode, null, new string[] { "AUS-WA" }));
            items.Add(new PublicHoliday(secondMondayInMarch, "Canberra Day", "Canberra Day", countryCode, null, new string[] { "AUS-ACT" }));
            items.Add(new PublicHoliday(secondMondayInMarch, "March Public Holiday", "March Public Holiday", countryCode, null, new string[] { "AUS-SA" }));
            items.Add(new PublicHoliday(secondMondayInMarch, "Eight Hours Day", "Eight Hours Day", countryCode, null, new string[] { "AUS-TAS" }));
            items.Add(new PublicHoliday(secondMondayInMarch, "Labour Day", "Labour Day", countryCode, null, new string[] { "AUS-VIC" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "Easter Saturday", "Easter Saturday", countryCode, null, new string[] { "AUS-ACT", "AUS-NSW", "AUS-NT" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "The day after Good Friday", "The day after Good Friday", countryCode, null, new string[] { "AUS-QLD", "AUS-SA" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "Saturday before Easter Sunday", "Saturday before Easter Sunday", countryCode, null, new string[] { "AUS-VIC" }));
            items.Add(new PublicHoliday(easterSunday, "Easter Sunday", "Easter Sunday", countryCode, null, new string[] { "AUS-ACT", "AUS-NSW", "AUS-QLD", "AUS-VIC" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 4, 25, "Anzac Day", "Anzac Day", countryCode));
            items.Add(new PublicHoliday(anzacDayHolidayWA, "Anzac Day Holiday", "Anzac Day Holiday", countryCode, null, new string[] { "AUS-WA" }));
            items.Add(new PublicHoliday(anzacDayHolidayNT, "Anzac Day Holiday", "Anzac Day Holiday", countryCode, null, new string[] { "AUS-NT" }));
            items.Add(new PublicHoliday(firstMondayInMay, "May Day", "May Day", countryCode, null, new string[] { "AUS-NT" }));
            items.Add(new PublicHoliday(firstMondayInMay, "Labour Day", "Labour Day", countryCode, null, new string[] { "AUS-QLD" }));
            items.Add(new PublicHoliday(reconciliationDayACT, "Reconciliation Day", "Reconciliation Day", countryCode, null, new string[] { "AUS-ACT" }));
            items.Add(new PublicHoliday(firstMondayInJune, "Western Australia Day", "Western Australia Day", countryCode, null, new string[] { "AUS-WA" }));
            items.Add(new PublicHoliday(secondMondayInJune, "Queen's Birthday", "Queen's Birthday", countryCode, null, new string[] { "AUS-ACT", "AUS-NSW", "AUS-NT", "AUS-SA", "AUS-TAS", "AUS-VIC" }));
            items.Add(new PublicHoliday(firstMondayInAugust, "Picnic Day", "Picnic Day", countryCode, null, new string[] { "AUS-NT" }));
            // The date of the Western Australia "Queen's Birthday" is variable
            // The date of the Victoria "Friday before the Australian Football League Grand Final" is variable.
            items.Add(new PublicHoliday(firstMondayInOctober, "Queen's Birthday", "Queen's Birthday", countryCode, null, new string[] { "AUS-QLD" }));
            items.Add(new PublicHoliday(firstMondayInOctober, "Labour Day", "Labour Day", countryCode, null, new string[] { "AUS-ACT", "AUS-NSW", "AUS-SA" }));
            items.Add(new PublicHoliday(firstTuesdayInNovemberVIC, "Melbourne Cup", "Melbourne Cup", countryCode, null, new string[] { "AUS-VIC" }));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "Boxing Day", countryCode, null, new string[] { "AUS-ACT", "AUS-NSW", "AUS-NT", "AUS-QLD", "AUS-TAS", "AUS-VIC", "AUS-WA" }));
            items.Add(new PublicHoliday(year, 12, 26, "Proclamation Day", "Proclamation Day", countryCode, null, new string[] { "AUS-SA" }));

            return items.OrderBy(o => o.Date);
        }
    }
}
