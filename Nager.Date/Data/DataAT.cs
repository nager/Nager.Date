using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.Data
{
    public static class DataAT
    {
        public static List<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            var countryCode = "AT";

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(6, 1, year, "Heilige Drei Könige", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(1, 5, year, "Staatsfeiertag", "National Holiday", countryCode, 1955));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Christi Himmelfahrt", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", countryCode));
            items.Add(new PublicHoliday(15, 8, year, "Maria Himmelfahrt", "Assumption of the Virgin Mary", countryCode));
            items.Add(new PublicHoliday(26, 10, year, "Staatsfeiertag", "National Holiday", countryCode));
            items.Add(new PublicHoliday(1, 11, year, "Allerheiligen", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(8, 12, year, "Mariä Empfängnis", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "Stefanitag", "St. Stephen's Day", countryCode));

            return items;
        }
    }
}
