using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.Data
{
    public static class DataIT
    {
        public static List<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            var countryCode = "IT";

            var items = new List<PublicHoliday>();
            //https://en.wikipedia.org/wiki/Public_holidays_in_Italy
            items.Add(new PublicHoliday(1, 1, year, "Capodanno", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(6, 1, year, "Epifania", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Lunedì dell'Angelo", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(25, 4, year, "Festa della Liberazione", "Liberation Day", countryCode));
            items.Add(new PublicHoliday(1, 5, year, "Festa del Lavoro", "International Workers Day", countryCode));
            items.Add(new PublicHoliday(2, 6, year, "Festa della Repubblica", "Republic Day", countryCode));
            items.Add(new PublicHoliday(15, 8, year, "Ferragosto and Assunta", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(1, 11, year, "Tutti i santi", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(8, 12, year, "Immacolata Concezione", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Natale", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Santo Stefano", "St. Stephen's Day", countryCode));

            return items;
        }
    }
}
