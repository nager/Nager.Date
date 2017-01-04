using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public class UnitedKingdomProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //United Kingdom
            //https://en.wikipedia.org/wiki/Public_holidays_in_the_United_Kingdom
            //https://de.wikipedia.org/wiki/Feiertage_im_Vereinigten_K%C3%B6nigreich

            var countryCode = CountryCode.UK;

            var firstMondayInMay = DateSystem.FindDay(year, 5, DayOfWeek.Monday, 1);
            var lastMondayInMay = DateSystem.FindLastDay(year, 5, DayOfWeek.Monday);
            var firstMondayInAugust = DateSystem.FindDay(year, 8, DayOfWeek.Monday, 1);
            var lastMondayInAugust = DateSystem.FindLastDay(year, 8, DayOfWeek.Monday);

            //TODO: finish weekend fallback to monday or tuesday
            var newYearDay = new DateTime(year, 1, 1);
            if (newYearDay.DayOfWeek == DayOfWeek.Saturday || newYearDay.DayOfWeek == DayOfWeek.Sunday)
            {

            }

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(2, 1, year, "New Year's Day", "New Year's Day", countryCode, null, new string[] { "GB-NIR" }));
            items.Add(new PublicHoliday(12, 7, year, "Saint Patrick's Day", "Saint Patrick's Day", countryCode, null, new string[] { "GB-SCT" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(firstMondayInMay, 5, year, "Early May Bank Holiday", "Early May Bank Holiday", countryCode, 1978));
            items.Add(new PublicHoliday(lastMondayInMay, 5, year, "Spring Bank Holiday", "Spring Bank Holiday", countryCode, 1971));
            items.Add(new PublicHoliday(12, 7, year, "Battle of the Boyne", "Battle of the Boyne", countryCode, null, new string[] { "GB-NIR" }));
            items.Add(new PublicHoliday(firstMondayInAugust, 8, year, "Summer Bank Holiday", "Summer Bank Holiday", countryCode, 1971, new string[] { "GB-SCT" }));
            items.Add(new PublicHoliday(lastMondayInAugust, 8, year, "Summer Bank Holiday", "Summer Bank Holiday", countryCode, 1971, new string[] { "GB-ENG", "GB-WLS" }));
            items.Add(new PublicHoliday(25, 12, year, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "Boxing Day", "St. Stephen's Day", countryCode));

            return items;
        }
    }
}
