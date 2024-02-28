using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Canada
    /// </summary>
    internal class CanadaProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// CanadaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CanadaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "CA-AB", "Alberta" },
                { "CA-BC", "British Columbia" },
                { "CA-MB", "Manitoba" },
                { "CA-NB", "New Brunswick" },
                { "CA-NL", "Newfoundland and Labrador" },
                { "CA-NS", "Nova Scotia" },
                { "CA-ON", "Ontario" },
                { "CA-PE", "Prince Edward Island" },
                { "CA-QC", "Québec" },
                { "CA-SK", "Saskatchewan" },
                { "CA-NT", "Northwest Territories" },
                { "CA-NU", "Nunavut" },
                { "CA-YT", "Yukon" }
            };
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.CA;

            var thirdMondayInFebruary = DateSystem.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.Third);
            var mondayOnOrBeforeMay24 = DateSystem.FindDayBefore(year, Month.May, 25, DayOfWeek.Monday);
            var firstMondayInAugust = DateSystem.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);
            var thirdMondayInAugust = DateSystem.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.Third);
            var firstMondayInSeptember = DateSystem.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.First);
            var secondMondayInOctober = DateSystem.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Second);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new Holiday(thirdMondayInFebruary, "Louis Riel Day", "Louis Riel Day", countryCode, null, new string[] { "CA-MB" }));
            items.Add(new Holiday(thirdMondayInFebruary, "Islander Day", "Islander Day", countryCode, null, new string[] { "CA-PE" }));
            items.Add(new Holiday(thirdMondayInFebruary, "Heritage Day", "Heritage Day", countryCode, null, new string[] { "CA-NS" }));
            items.Add(new Holiday(year, 3, 17, "Saint Patrick's Day", "Saint Patrick's Day", countryCode, null, new string[] { "CA-NL" }));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode).SetCounties("CA-AB", "CA-PE"));
            items.Add(new Holiday(year, 4, 23, "Saint George's Day", "Saint George's Day", countryCode, null, new string[] { "CA-NL" }));
            items.Add(new Holiday(mondayOnOrBeforeMay24, "National Patriots' Day", "National Patriots' Day", countryCode, null, new string[] { "CA-QC" }));
            items.Add(new Holiday(mondayOnOrBeforeMay24, "Victoria Day", "Victoria Day", countryCode));
            items.Add(new Holiday(year, 6, 21, "National Aboriginal Day", "National Aboriginal Day", countryCode, null, new string[] { "CA-NT" }));
            items.Add(new Holiday(year, 6, 24, "Discovery Day", "Discovery Day", countryCode, null, new string[] { "CA-NL" }));
            items.Add(new Holiday(year, 6, 24, "Fête nationale du Québec", "National Holiday", countryCode, null, new string[] { "CA-QC" }));
            items.Add(new Holiday(year, 7, 12, "Orangemen's Day", "Orangemen's Day", countryCode, null, new string[] { "CA-NL" }));
            items.Add(new Holiday(firstMondayInAugust, "Civic Holiday", "Civic Holiday", countryCode, null, new string[] {"CA-MB", "CA-NL", "CA-NT", "CA-NU", "CA-ON" }));
            items.Add(new Holiday(firstMondayInAugust, "British Columbia Day", "British Columbia Day", countryCode, null, new string[] { "CA-BC" }));
            items.Add(new Holiday(firstMondayInAugust, "Heritage Day", "Heritage Day", countryCode, null, new string[] { "CA-AB", "CA-YT" }));
            items.Add(new Holiday(firstMondayInAugust, "New Brunswick Day", "New Brunswick Day", countryCode, null, new string[] { "CA-NB" }));
            items.Add(new Holiday(firstMondayInAugust, "Natal Day", "Natal Day", countryCode, null, new string[] { "CA-NS" }));
            items.Add(new Holiday(firstMondayInAugust, "Saskatchewan Day", "Saskatchewan Day", countryCode, null, new string[] { "CA-SK" }));
            items.Add(new Holiday(thirdMondayInAugust, "Gold Cup Parade Day", "Gold Cup Parade Day", countryCode, null, new string[] { "CA-PE" }));
            items.Add(new Holiday(thirdMondayInAugust, "Discovery Day", "Discovery Day", countryCode, null, new string[] { "CA-YT" }));
            items.Add(new Holiday(firstMondayInSeptember, "Labour Day", "Labour Day", countryCode));
            items.Add(new Holiday(year, 9, 30, "National Day for Truth and Reconciliation", "National Day for Truth and Reconciliation", countryCode));
            items.Add(new Holiday(secondMondayInOctober, "Thanksgiving", "Thanksgiving", countryCode));
            items.Add(new Holiday(year, 11, 11, "Armistice Day", "Armistice Day", countryCode, null, new string[] { "CA-NL" }));
            items.Add(new Holiday(year, 11, 11, "Remembrance Day", "Remembrance Day", countryCode, null, new string[] { "CA-AB", "CA-BC", "CA-NB", "CA-NT", "CA-NS", "CA-NU", "CA-PE", "CA-SK", "CA-YT" }));
            items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode, null, new string[] { "CA-AB", "CA-NB", "CA-NS", "CA-ON", "CA-PE" }));

            items.AddRange(this.CanadaDay(year, countryCode));
            items.AddRange(this.FamilyDay(year, countryCode));
            items.AddIfNotNull(this.FuneralForQueenElizabeth(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private Holiday FuneralForQueenElizabeth(int year, CountryCode countryCode)
        {
            if (year == 2022)
            {
                //Canada announces a national holiday to mark Queen Elizabeth’s death
                //https://globalnews.ca/news/9122726/canada-national-holiday-sept-19-queens-funeral/
                return new Holiday(year, 9, 19, "State Funeral of Queen Elizabeth II", "State Funeral of Queen Elizabeth II", countryCode);
            }

            return null;
        }

        private Holiday[] FamilyDay(int year, CountryCode countryCode)
        {
            var holidayName = "Family Day";
            var thirdMondayInFebruary = DateSystem.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.Third);

            if (year < 2019)
            {
                var secondMondayInFebruary = DateSystem.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.Second);
                return new Holiday[]
                {
                    new Holiday(secondMondayInFebruary, holidayName, holidayName, countryCode, 2013, new string[] { "CA-BC" }),
                    new Holiday(thirdMondayInFebruary, holidayName, holidayName, countryCode, null, new string[] { "CA-AB", "CA-ON", "CA-SK" })
                };
            }

            return new Holiday[]
            {
                new Holiday(thirdMondayInFebruary, holidayName, holidayName, countryCode, null, new string[] { "CA-AB", "CA-BC", "CA-NB", "CA-ON", "CA-SK" })
            };
        }

        private Holiday[] CanadaDay(int year, CountryCode countryCode)
        {
            var holidayName = "Canada Day";
            var canadaDay = new DateTime(year, 7, 1);

            if (canadaDay.DayOfWeek == DayOfWeek.Sunday)
            {
                return new Holiday[]
                {
                    new Holiday(canadaDay, holidayName, holidayName, countryCode, null, new string[] { "CA-BC", "CA-MB", "CA-NB", "CA-NL", "CA-NS", "CA-ON", "CA-PE", "CA-QC", "CA-SK", "CA-NT", "CA-NU", "CA-YT" } ),
                    //Canada Day is on July 1 every year except when it falls on a Sunday, then it’s on July 2.
                    new Holiday(canadaDay.AddDays(1), holidayName, holidayName, countryCode, null, new string[] { "CA-AB" })
                };
            }

            return new Holiday[] { new Holiday(canadaDay, holidayName, holidayName, countryCode) };
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Canada",
                "https://www.canada.ca/en/department-national-defence/maple-leaf/defence/2021/07/federal-statutory-holiday-national-day-for-truth-and-reconciliation.html"
            };
        }
    }
}
