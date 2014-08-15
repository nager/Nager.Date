using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nager.Date
{
    public static class DateSystem
    {
        public static List<PublicHoliday> GetPublicHoliday(string countryCode, int year)
        {
            var easterSunday = EasterSunday(year);

            var items = new List<PublicHoliday>();
            switch (countryCode)
            {
                case "AT":
                    items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", countryCode));
                    items.Add(new PublicHoliday(6, 1, year, "Heilige Drei Könige", "Epiphany", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter", countryCode));
                    items.Add(new PublicHoliday(1, 5, year, "Staatsfeiertag", "National Holiday", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(39), "Christi Himmelfahrt", "Ascension Day", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", countryCode));
                    items.Add(new PublicHoliday(15, 8, year, "Maria Himmelfahrt", "Assumption of the Virgin Mary", countryCode));
                    items.Add(new PublicHoliday(26, 10, year, "Staatsfeiertag", "National Holiday", countryCode));
                    items.Add(new PublicHoliday(1, 11, year, "Allerheiligen", "All Saints' Day", countryCode));
                    items.Add(new PublicHoliday(8, 12, year, "Mariä Empfängnis", "Immaculate Conception", countryCode));
                    items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", countryCode));
                    items.Add(new PublicHoliday(26, 12, year, "Stefanitag", "St. Stephen's Day", countryCode));
                    break;
                case "DE":
                    items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter", countryCode));
                    items.Add(new PublicHoliday(1, 5, year, "Tag der Arbeit", "Labor Day", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(39), "Christi Himmelfahrt", "Ascension Day", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode));
                    items.Add(new PublicHoliday(3, 10, year, "Tag der Deutschen Einheit", "German Unity Day", countryCode));
                    items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", countryCode));
                    items.Add(new PublicHoliday(26, 12, year, "Stefanitag", "St. Stephen's Day", countryCode));
                    break;
                case "CH":
                    //http://de.wikipedia.org/wiki/Feiertage_in_der_Schweiz
                    items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", countryCode));
                    items.Add(new PublicHoliday(2, 1, year, "Berchtoldstag", "St. Berchtold's Day", countryCode, new string[] { "ZH", "BE", "LU", "OW", "GL", "ZG", "FR", "SO", "SH", "TG", "VD", "NE", "GE", "JU" }));
                    items.Add(new PublicHoliday(6, 1, year, "Heilige Drei Könige", "Epiphany", countryCode, new string[] { "UR", "SZ", "GR", "TI" }));
                    items.Add(new PublicHoliday(19, 1, year, "Josefstag", "Saint Joseph's Day", countryCode, new string[] { "LU", "UR", "SZ", "NW", "ZG", "GR", "TI", "VS" }));
                    items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", countryCode, new string[] { "ZH", "BE", "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "BS", "BL", "SH", "AR", "AI", "SG", "GR", "AG", "TG", "VD", "NE", "GE", "JU" }));
                    items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter", countryCode, new string[] { "ZH", "BE", "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "BS", "BL", "SH", "AR", "AI", "SG", "GR", "AG", "TG", "TI", "VD", "NE", "GE", "JU" }));
                    items.Add(new PublicHoliday(1, 5, year, "Tag der Arbeit", "Labor Day", countryCode, new string[] { "ZH", "FR", "SO", "BS", "BL", "SH", "AG", "TG", "TI", "NE", "JU" }));
                    items.Add(new PublicHoliday(easterSunday.AddDays(39), "Auffahrt", "Ascension Day", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode, new string[] { "ZH", "BE", "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "BS", "BL", "SH", "AR", "AI", "SG", "GR", "AG", "TG", "TI", "VD", "NE", "GE", "JU" }));
                    items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", countryCode, new string[] { "LU", "UR", "SZ", "OW", "NW", "ZG", "FR", "SO", "BL", "AI", "GR", "AG", "TI", "VS", "NE", "JU" }));
                    items.Add(new PublicHoliday(1, 8, year, "Bundesfeier", "Swiss National Day", countryCode));
                    items.Add(new PublicHoliday(15, 8, year, "Maria Himmelfahrt", "Assumption of the Virgin Mary", countryCode, new string[] { "LU", "UR", "SZ", "OW", "NW", "ZG", "FR", "SO", "BL", "AI", "GR", "AG", "TI", "VS", "JU" }));
                    items.Add(new PublicHoliday(1, 11, year, "Allerheiligen", "All Saints' Day", countryCode, new string[] { "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "AI","SG", "GR", "AG", "TI", "VS", "JU" }));
                    items.Add(new PublicHoliday(8, 12, year, "Mariä Empfängnis", "Immaculate Conception", countryCode, new string[] { "LU", "UR", "SZ", "OW", "NW", "ZG", "FR", "SO", "AI", "GR", "AG", "TI", "VS" }));
                    items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", countryCode));
                    items.Add(new PublicHoliday(26, 12, year, "Stephanstag", "St. Stephen's Day", countryCode, new string[] { "ZH", "BE", "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "BS", "BL", "SH", "AR", "AI", "SG", "GR", "AG", "TG" }));
                    break;
                default:
                    break;
            }

            return items;
        }

        public static bool IsPublicHoliday(DateTime date, string countryCode)
        {
            var items = GetPublicHoliday(countryCode, date.Year);
            return items.Where(o => o.Date.Date == date.Date).Any();
        }

        private static DateTime EasterSunday(int year)
        {
            //should be
            //Easter Monday  28 Mar 2005  17 Apr 2006  9 Apr 2007  24 Mar 2008

            //Oudin's Algorithm - http://www.smart.net/~mmontes/oudin.html
            var g = year % 19;
            var c = year / 100;
            var h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            var i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * ((21 - g) / 11));
            var j = (year + year / 4 + i + 2 - c + c / 4) % 7;
            var p = i - j;
            var easterDay = 1 + (p + 27 + (p + 6) / 40) % 31;
            var easterMonth = 3 + (p + 26) / 30;

            return new DateTime(year, easterMonth, easterDay);
        }
    }
}
