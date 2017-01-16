using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public class CanadaProvider : IPublicHolidayProvider
    {
        private IDictionary<string, string> GetCounties()
        {
            var items = new Dictionary<string, string>();
            items.Add("CA-AB", "Alberta");
            items.Add("CA-BC", "British Columbia");
            items.Add("CA-MB", "Manitoba");
            items.Add("CA-NB", "New Brunswick");
            items.Add("CA-NL", "Neufundland und Labrador");
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

        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Canada
            //https://en.wikipedia.org/wiki/Public_holidays_in_Canada

            var countryCode = CountryCode.CA;

            var secondMondayInFebruary = DateSystem.FindDay(year, 2, DayOfWeek.Monday, 2);
            var thirdMondayInFebruary = DateSystem.FindDay(year, 2, DayOfWeek.Monday, 3);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, secondMondayInFebruary, "Family Day", "Family Day", countryCode, 2013, new string[] { "CA-BC" }));
            items.Add(new PublicHoliday(year, 2, thirdMondayInFebruary, "Louis Riel Day", "Louis Riel Day", countryCode, null, new string[] { "CA-MB" }));
            items.Add(new PublicHoliday(year, 2, thirdMondayInFebruary, "Islander Day", "Islander Day", countryCode, null, new string[] { "CA-PE" }));
            items.Add(new PublicHoliday(year, 2, thirdMondayInFebruary, "Family Day", "Family Day", countryCode, null, new string[] { "CA-AB", "CA-ON", "CA-SK" }));
            items.Add(new PublicHoliday(year, 2, thirdMondayInFebruary, "Heritage Day", "Heritage Day", countryCode, null, new string[] { "CA-NS" }));
            items.Add(new PublicHoliday(year, 3, 17, "Saint Patrick's Day", "Saint Patrick's Day", countryCode, null, new string[] { "CA-NL" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode, null, new string[] { "CA-AB", "CA-PE" }));
            items.Add(new PublicHoliday(year, 4, 23, "Saint George's Day", "Saint George's Day", countryCode, null, new string[] { "CA-NL" }));

            return items;
        }
    }
}
