using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Australia
    /// </summary>
    internal class AustraliaProvider : IHolidayProvider, ISubdivisionCodesProvider
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

        ///<inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "AU-ACT", "Australian Capital Territory" },
                { "AU-NSW", "New South Wales" },
                { "AU-NT", "Northern Territory" },
                { "AU-QLD", "Queensland" },
                { "AU-SA", "South Australia" },
                { "AU-TAS", "Tasmania" },
                { "AU-VIC", "Victoria" },
                { "AU-WA", "Western Australia" }
            };
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.AU;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var secondMondayInMarch = DateSystem.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Second);
            var firstMondayInMay = DateSystem.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            var firstMondayAfterOr27May = DateSystem.FindDay(year, Month.May, 27, DayOfWeek.Monday);
            var firstMondayInJune = DateSystem.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.First);
            
            var firstMondayInAugust = DateSystem.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);
            var firstMondayInOctober = DateSystem.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.First);
            var firstTuesdayInNovember = DateSystem.FindDay(year, Month.November, DayOfWeek.Tuesday, Occurrence.First);

            var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            var boxingDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            var australiaDay = new DateTime(year, 1, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));

            var items = new List<Holiday>();
            items.Add(new Holiday(newYearsDay, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new Holiday(australiaDay, "Australia Day", "Australia Day", countryCode));
            items.Add(new Holiday(secondMondayInMarch, "Canberra Day", "Canberra Day", countryCode, null, new string[] { "AU-ACT" }));
            items.Add(new Holiday(secondMondayInMarch, "March Public Holiday", "March Public Holiday", countryCode, null, new string[] { "AU-SA" }));
            items.Add(new Holiday(secondMondayInMarch, "Eight Hours Day", "Eight Hours Day", countryCode, null, new string[] { "AU-TAS" }));

            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-1), "Easter Eve", "Holy Saturday", countryCode, null, new string[] { "AU-ACT", "AU-NSW", "AU-NT", "AU-QLD", "AU-SA", "AU-VIC" }));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new Holiday(year, 4, 25, "Anzac Day", "Anzac Day", countryCode));
            items.Add(new Holiday(firstMondayInMay, "May Day", "May Day", countryCode, null, new string[] { "AU-NT" }));

            items.Add(new Holiday(firstMondayAfterOr27May, "Reconciliation Day", "Reconciliation Day", countryCode, 2018, new string[] { "AU-ACT" }));
            items.Add(new Holiday(firstMondayInJune, "Western Australia Day", "Western Australia Day", countryCode, null, new string[] { "AU-WA" }));
            items.Add(new Holiday(firstMondayInAugust, "Picnic Day", "Picnic Day", countryCode, null, new string[] { "AU-NT" }));

            items.Add(new Holiday(firstTuesdayInNovember, "Melbourne Cup", "Melbourne Cup", countryCode, null, new string[] { "AU-VIC" }));

            items.Add(new Holiday(christmasDay, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new Holiday(boxingDay, "Boxing Day", "St. Stephen's Day", countryCode));

            items.AddRangeIfNotNull(this.LabourDay(year, countryCode));
            items.AddIfNotNull(this.MourningForQueenElizabeth(year, countryCode));
            items.AddRangeIfNotNull(this.MonarchBirthday(year, countryCode));
            items.AddIfNotNull(this.EasterSunday(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private Holiday EasterSunday(int year, CountryCode countryCode)
        {
            var counties = new [] { "AU-ACT", "AU-NSW", "AU-VIC" };
            if (year >= 2022)
            {
                counties = new[] { "AU-ACT", "AU-NSW", "AU-VIC", "AU-WA" };
            }

            return this._catholicProvider.EasterSunday("Easter Sunday", year, countryCode).SetCounties(counties);
        }

        private Holiday[] LabourDay(int year, CountryCode countryCode)
        {
            var firstMondayInMarch = DateSystem.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.First);
            var secondMondayInMarch = DateSystem.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Second);
            var firstMondayInMay = DateSystem.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            var firstMondayInOctober = DateSystem.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.First);

            return new Holiday[]
            {
                new Holiday(firstMondayInMarch, "Labour Day", "Labour Day", countryCode, null, new string[] { "AU-WA" }),
                new Holiday(secondMondayInMarch, "Labour Day", "Labour Day", countryCode, null, new string[] { "AU-VIC" }),
                new Holiday(firstMondayInMay, "Labour Day", "Labour Day", countryCode, null, new string[] { "AU-QLD" }),
                new Holiday(firstMondayInOctober, "Labour Day", "Labour Day", countryCode, null, new string[] { "AU-ACT", "AU-NSW", "AU-SA" })
            };
        }

        private Holiday[] MonarchBirthday(int year, CountryCode countryCode)
        {
            var name = "Queen's Birthday";
            if (year >= 2023)
            {
                name = "King's Birthday";
            }

            var secondMondayInJune = DateSystem.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Second);
            var firstMondayInOctober = DateSystem.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.First);

            return new Holiday[]
            {
                new Holiday(secondMondayInJune, name, name, countryCode, null, new string[] { "AU-ACT", "AU-NSW", "AU-NT", "AU-SA", "AU-TAS", "AU-VIC" }),
                new Holiday(firstMondayInOctober, name, name, countryCode, null, new string[] { "AU-QLD" })
            };
        }

        private Holiday MourningForQueenElizabeth(int year, CountryCode countryCode)
        {
            if (year == 2022)
            {
                //Australia's national day of mourning for Queen Elizabeth II to be public holiday
                //https://www.abc.net.au/news/2022-09-11/national-day-of-mourning-queen-death-to-be-public-holiday/101427050
                return new Holiday(year, 9, 22, "National Day of Mourning", "National Day of Mourning", countryCode);
            }

            return null;
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Australia"
            };
        }
    }
}
