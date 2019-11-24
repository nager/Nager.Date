using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Canada
    /// </summary>
    public class CanadaProvider : IPublicHolidayProvider, ICountyProvider
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

        /// <summary>
        /// GetCounties
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetCounties()
        {
            var items = new Dictionary<string, string>();
            items.Add("CA-AB", "Alberta");
            items.Add("CA-BC", "British Columbia");
            items.Add("CA-MB", "Manitoba");
            items.Add("CA-NB", "New Brunswick");
            items.Add("CA-NL", "Newfoundland and Labrador");
            items.Add("CA-NS", "Nova Scotia");
            items.Add("CA-ON", "Ontario");
            items.Add("CA-PE", "Prince Edward Island");
            items.Add("CA-QC", "Québec");
            items.Add("CA-SK", "Saskatchewan");
            items.Add("CA-NT", "Northwest Territories");
            items.Add("CA-NU", "Nunavut");
            items.Add("CA-YT", "Yukon");
            return items;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.CA;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var secondMondayInFebruary = DateSystem.FindDay(year, 2, DayOfWeek.Monday, 2);
            var thirdMondayInFebruary = DateSystem.FindDay(year, 2, DayOfWeek.Monday, 3);
            var mondayOnOrBeforeMay24 = DateSystem.FindDayBefore(year, 5, 25, DayOfWeek.Monday);
            var firstMondayInAugust = DateSystem.FindDay(year, 8, DayOfWeek.Monday, 1);
            var thirdMondayInAugust = DateSystem.FindDay(year, 8, DayOfWeek.Monday, 3);
            var firstMondayInSeptember = DateSystem.FindDay(year, 9, DayOfWeek.Monday, 1);
            var secondMondayInOctober = DateSystem.FindDay(year, 10, DayOfWeek.Monday, 2);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(secondMondayInFebruary, "Family Day", "Family Day", countryCode, 2013, new string[] { "CA-BC" }));
            items.Add(new PublicHoliday(thirdMondayInFebruary, "Louis Riel Day", "Louis Riel Day", countryCode, null, new string[] { "CA-MB" }));
            items.Add(new PublicHoliday(thirdMondayInFebruary, "Islander Day", "Islander Day", countryCode, null, new string[] { "CA-PE" }));
            items.Add(new PublicHoliday(thirdMondayInFebruary, "Family Day", "Family Day", countryCode, null, new string[] { "CA-AB", "CA-ON", "CA-SK" }));
            items.Add(new PublicHoliday(thirdMondayInFebruary, "Heritage Day", "Heritage Day", countryCode, null, new string[] { "CA-NS" }));
            items.Add(new PublicHoliday(year, 3, 17, "Saint Patrick's Day", "Saint Patrick's Day", countryCode, null, new string[] { "CA-NL" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));            
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode, null, new string[] { "CA-AB", "CA-PE" }));
            items.Add(new PublicHoliday(year, 4, 23, "Saint George's Day", "Saint George's Day", countryCode, null, new string[] { "CA-NL" }));
            items.Add(new PublicHoliday(mondayOnOrBeforeMay24, "National Patriots' Day", "National Patriots' Day", countryCode, null, new string[] { "CA-QC" }));
            items.Add(new PublicHoliday(mondayOnOrBeforeMay24, "Victoria Day", "Victoria Day", countryCode, null, new string[] { "CA-AB", "CA-BC", "CA-MB", "CA-NB", "CA-NT", "CA-NS", "CA-NU", "CA-ON", "CA-PE", "CA-SK", "CA-YT" }));
            items.Add(new PublicHoliday(year, 6, 21, "National Aboriginal Day", "National Aboriginal Day", countryCode, null, new string[] { "CA-NT" }));
            items.Add(new PublicHoliday(year, 6, 24, "Discovery Day", "Discovery Day", countryCode, null, new string[] { "CA-NL" }));
            items.Add(new PublicHoliday(year, 6, 24, "Fête nationale du Québec", "National Holiday", countryCode, null, new string[] { "CA-QC" }));
            items.Add(new PublicHoliday(year, 7, 12, "Orangemen's Day", "Orangemen's Day", countryCode, null, new string[] { "CA-NL" }));
            items.Add(new PublicHoliday(firstMondayInAugust, "Civic Holiday", "Civic Holiday", countryCode, null, new string[] { "CA-BC", "CA-MB", "CA-NL", "CA-NT", "CA-NU", "CA-ON" }));
            items.Add(new PublicHoliday(firstMondayInAugust, "Heritage Day", "Heritage Day", countryCode, null, new string[] { "CA-AB", "CA-YT" }));
            items.Add(new PublicHoliday(firstMondayInAugust, "New Brunswick Day", "New Brunswick Day", countryCode, null, new string[] { "CA-NB" }));
            items.Add(new PublicHoliday(firstMondayInAugust, "Natal Day", "Natal Day", countryCode, null, new string[] { "CA-NS" }));
            items.Add(new PublicHoliday(thirdMondayInAugust, "Gold Cup Parade Day", "Gold Cup Parade Day", countryCode, null, new string[] { "CA-PE" }));
            items.Add(new PublicHoliday(thirdMondayInAugust, "Discovery Day", "Discovery Day", countryCode, null, new string[] { "CA-YT" }));
            items.Add(new PublicHoliday(firstMondayInSeptember, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(secondMondayInOctober, "Thanksgiving", "Thanksgiving", countryCode));
            items.Add(new PublicHoliday(year, 11, 11, "Armistice Day", "Armistice Day", countryCode, null, new string[] { "CA-NL" }));
            items.Add(new PublicHoliday(year, 11, 11, "Remembrance Day", "Remembrance Day", countryCode, null, new string[] { "CA-AB", "CA-BC", "CA-NB", "CA-NT", "CA-NS", "CA-NU", "CA-PE", "CA-SK", "CA-YT" }));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "St. Stephen's Day", "St. Stephen's Day", countryCode, null, new string[] { "CA-AB", "CA-NB", "CA-NS", "CA-ON", "CA-PE" }));

            items.AddRange(this.CanadaDay(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private PublicHoliday[] CanadaDay(int year, CountryCode countryCode)
        {
            var canadaDay = new DateTime(year, 7, 1);
            if (canadaDay.DayOfWeek == DayOfWeek.Sunday)
            {
                return new PublicHoliday[] {
                    new PublicHoliday(year, 7, 1, "Canada Day", "Canada Day", countryCode, null, new string[] { "CA-BC", "CA-MB", "CA-NB", "CA-NL", "CA-NS", "CA-ON", "CA-PE", "CA-QC", "CA-SK", "CA-NT", "CA-NU", "CA-YT" } ),
                    //Canada Day is on July 1 every year except when it falls on a Sunday, then it’s on July 2.
                    new PublicHoliday(year, 7, 2, "Canada Day", "Canada Day", countryCode, null, new string[] { "CA-AB" }) { Fixed = false }
                };
            }

            return new PublicHoliday[] { new PublicHoliday(year, 7, 1, "Canada Day", "Canada Day", countryCode) };
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Canada",
            };
        }
    }
}
