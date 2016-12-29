using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public static class Liechtenstein
    {
        public static List<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Liechtenstein
            var countryCode = CountryCode.LI;

            var items = new List<PublicHoliday>();
            //http://en.wikipedia.org/wiki/Public_holidays_in_Liechtenstein
            items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(2, 1, year, "Berchtoldstag", "St. Berchtold's Day", countryCode));
            items.Add(new PublicHoliday(6, 1, year, "Heilige Drei Könige", "Epiphany", countryCode));
            items.Add(new PublicHoliday(2, 2, year, "Mariä Lichtmess", "Candlemas", countryCode));
            items.Add(new PublicHoliday(19, 3, year, "Josefstag", "Saint Joseph's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(1, 5, year, "Tag der Arbeit", "Labor Day", countryCode));
            items.Add(new PublicHoliday(29, 5, year, "Auffahrt", "Ascension", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", countryCode));
            items.Add(new PublicHoliday(15, 8, year, "Staatsfeiertag", "National Holiday", countryCode));
            items.Add(new PublicHoliday(8, 9, year, "Maria Geburt", "Nativity of Our Lady", countryCode));
            items.Add(new PublicHoliday(1, 11, year, "Allerheiligen", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(8, 12, year, "Mariä Empfängnis", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(24, 12, year, "Heiliger Abend", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "Stephanstag", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(31, 12, year, "Silvester", "New Year's Eve", countryCode));

            return items;
        }
    }
}
