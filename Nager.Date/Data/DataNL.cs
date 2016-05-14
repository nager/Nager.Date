using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.Data
{
    public static class DataNL
    {
        public static List<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Netherlands
            var countryCode = "NL";

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "Nieuwjaarsdag", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Goede Vrijdag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), " Pasen", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(27, 4, year, "Koningsdag", "King's Day", countryCode));
            items.Add(new PublicHoliday(5, 5, year, "Bevrijdingsdag", "Liberation Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Hemelvaartsdag", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pinksteren", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "TweedeKerstdag", "Boxing Day", countryCode));

            return items;
        }
    }
}
