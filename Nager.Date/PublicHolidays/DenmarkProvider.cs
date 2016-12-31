using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public class DenmarkProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Denmark
            //https://en.wikipedia.org/wiki/Public_holidays_in_Denmark

            var countryCode = CountryCode.DK;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "Nytårsdag", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Skærtorsdag", "Maundy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Langfredag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Påskedag", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "2. Påskedag", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(26), "Store bededag", "General Prayer Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Kristi Himmelfartsdag", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Pinsedag", "Pentecost", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "2. Pinsedag", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Juledag / 1. juledag", "First Day of Christmas", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "2. juledag", "Second Day of Christmas", countryCode));

            return items;
        }
    }
}
