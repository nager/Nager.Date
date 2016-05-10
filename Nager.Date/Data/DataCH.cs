using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.Data
{
    public static class DataCH
    {
        public static List<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            var countryCode = "CH";

            var items = new List<PublicHoliday>();
            //http://de.wikipedia.org/wiki/Feiertage_in_der_Schweiz
            items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(2, 1, year, "Berchtoldstag", "St. Berchtold's Day", countryCode, null, new string[] { "ZH", "BE", "LU", "OW", "GL", "ZG", "FR", "SO", "SH", "TG", "VD", "NE", "GE", "JU" }));
            items.Add(new PublicHoliday(6, 1, year, "Heilige Drei Könige", "Epiphany", countryCode, null, new string[] { "UR", "SZ", "GR", "TI" }));
            items.Add(new PublicHoliday(19, 3, year, "Josefstag", "Saint Joseph's Day", countryCode, null, new string[] { "LU", "UR", "SZ", "NW", "ZG", "GR", "TI", "VS" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", countryCode, null, new string[] { "ZH", "BE", "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "BS", "BL", "SH", "AR", "AI", "SG", "GR", "AG", "TG", "VD", "NE", "GE", "JU" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, 1642, new string[] { "ZH", "BE", "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "BS", "BL", "SH", "AR", "AI", "SG", "GR", "AG", "TG", "TI", "VD", "NE", "GE", "JU" }));
            items.Add(new PublicHoliday(1, 5, year, "Tag der Arbeit", "Labor Day", countryCode, null, new string[] { "ZH", "FR", "SO", "BS", "BL", "SH", "AG", "TG", "TI", "NE", "JU" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Auffahrt", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode, null, new string[] { "ZH", "BE", "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "BS", "BL", "SH", "AR", "AI", "SG", "GR", "AG", "TG", "TI", "VD", "NE", "GE", "JU" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", countryCode, null, new string[] { "LU", "UR", "SZ", "OW", "NW", "ZG", "FR", "SO", "BL", "AI", "GR", "AG", "TI", "VS", "NE", "JU" }));
            items.Add(new PublicHoliday(1, 8, year, "Bundesfeier", "Swiss National Day", countryCode));
            items.Add(new PublicHoliday(15, 8, year, "Maria Himmelfahrt", "Assumption of the Virgin Mary", countryCode, null, new string[] { "LU", "UR", "SZ", "OW", "NW", "ZG", "FR", "SO", "BL", "AI", "GR", "AG", "TI", "VS", "JU" }));
            items.Add(new PublicHoliday(1, 11, year, "Allerheiligen", "All Saints' Day", countryCode, null, new string[] { "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "AI", "SG", "GR", "AG", "TI", "VS", "JU" }));
            items.Add(new PublicHoliday(8, 12, year, "Mariä Empfängnis", "Immaculate Conception", countryCode, null, new string[] { "LU", "UR", "SZ", "OW", "NW", "ZG", "FR", "SO", "AI", "GR", "AG", "TI", "VS" }));
            items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "Stephanstag", "St. Stephen's Day", countryCode, null, new string[] { "ZH", "BE", "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "BS", "BL", "SH", "AR", "AI", "SG", "GR", "AG", "TG" }));

            return items;
        }
    }
}
