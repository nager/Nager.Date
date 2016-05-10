using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.Data
{
    public static class DataDE
    {
        public static List<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            var countryCode = "DE";

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(1, 5, year, "Tag der Arbeit", "Labor Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Christi Himmelfahrt", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(3, 10, year, "Tag der Deutschen Einheit", "German Unity Day", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "Stefanitag", "St. Stephen's Day", countryCode));

            return items;
        }
    }
}
