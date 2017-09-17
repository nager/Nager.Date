using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class AustraliaProvider : CatholicBaseProvider
    {
        public IDictionary<string, string> GetCounties()
        {
            return new Dictionary<string, string>
            {
                { "AUT-ACT", "Australian Capital Territory" },
                { "AUS-NSW", "New South Wales" },
                { "AUS-NT", "Northern Territory" },
                { "AUS-QLD", "Queensland" },
                { "AUS-SA", "South Australia" },
                { "AUS-TAS", "Tasmania" },
                { "AUS-VIC", "Victoria" },
                { "AUS-WA", "Western Australia" }
            };
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Australia
            //https://en.wikipedia.org/wiki/Public_holidays_in_Australia

            var countryCode = CountryCode.AU;
            var easterSunday = base.EasterSunday(year);

            var firstMondayInMarch = DateSystem.FindDay(year, 3, DayOfWeek.Monday, 1);
            var secondMondayInMarch = DateSystem.FindDay(year, 3, DayOfWeek.Monday, 2);
            var firstMondayInMay = DateSystem.FindDay(year, 5, DayOfWeek.Monday, 1);
            var firstMondayInJune = DateSystem.FindDay(year, 6, DayOfWeek.Monday, 1);
            var secondMondayInJune = DateSystem.FindDay(year, 6, DayOfWeek.Monday, 2);
            var firstMondayInAugust = DateSystem.FindDay(year, 8, DayOfWeek.Monday, 1);
            var firstMondayInOctober = DateSystem.FindDay(year, 10, DayOfWeek.Monday, 1);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 26, "Australia Day", "Australia Day", countryCode));
            items.Add(new PublicHoliday(firstMondayInMarch, "Labour Day", "Labour Day", countryCode, null, new string[] { "AUS-WA" }));
            items.Add(new PublicHoliday(secondMondayInMarch, "Canberra Day", "Canberra Day", countryCode, null, new string[] { "AUS-ACT" }));
            items.Add(new PublicHoliday(secondMondayInMarch, "March Public Holiday", "March Public Holiday", countryCode, null, new string[] { "AUS-SA" }));
            items.Add(new PublicHoliday(secondMondayInMarch, "Eight Hours Day", "Eight Hours Day", countryCode, null, new string[] { "AUS-TAS" }));
            items.Add(new PublicHoliday(secondMondayInMarch, "Labour Day", "Labour Day", countryCode, null, new string[] { "AUS-VIC" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "Easter Eve", "Holy Saturday", countryCode, null, new string[] { "AUS-ACT", "AUS-NSW", "AUS-NT", "AUS-QLD", "AUS-SA", "AUS-VIC" }));
            items.Add(new PublicHoliday(easterSunday, "Easter Sunday", "Easter Sunday", countryCode, null, new string[] { "AUS-ACT", "AUS-NSW", "AUS-VIC" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 4, 25, "Anzac Day", "Anzac Day", countryCode));
            items.Add(new PublicHoliday(firstMondayInMay, "May Day", "May Day", countryCode, null, new string[] { "AUS-NT" }));
            items.Add(new PublicHoliday(firstMondayInMay, "Labour Day", "Labour Day", countryCode, null, new string[] { "AUS-QLD" }));
            items.Add(new PublicHoliday(firstMondayInJune, "Western Australia Day", "Western Australia Day", countryCode, null, new string[] { "AUS-WA" }));
            items.Add(new PublicHoliday(secondMondayInJune, "Queen's Birthday", "Queen's Birthday", countryCode, null, new string[] { "AUS-ACT", "AUS-NSW", "AUS-NT", "AUS-SA", "AUS-TAS", "AUS-VIC" }));
            items.Add(new PublicHoliday(firstMondayInAugust, "Picnic Day", "Picnic Day", countryCode, null, new string[] { "AUS-NT" }));
            items.Add(new PublicHoliday(firstMondayInAugust, "Labour Day", "Labour Day", countryCode, null, new string[] { "AUS-ACT", "AUS-NSW", "AUS-SA" }));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
