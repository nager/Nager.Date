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
                    items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", "AT"));
                    items.Add(new PublicHoliday(6, 1, year, "Heilige Drei Könige", "Epiphany", "AT"));
                    items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter", "AT"));
                    items.Add(new PublicHoliday(1, 5, year, "Staatsfeiertag", "National Holiday", "AT"));
                    items.Add(new PublicHoliday(easterSunday.AddDays(39), "Christi Himmelfahrt", "Ascension Day", "AT"));
                    items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", "AT"));
                    items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", "AT"));
                    items.Add(new PublicHoliday(15, 8, year, "Maria Himmelfahrt", "Assumption of the Virgin Mary", "AT"));
                    items.Add(new PublicHoliday(26, 10, year, "Staatsfeiertag", "National Holiday", "AT"));
                    items.Add(new PublicHoliday(1, 11, year, "Allerheiligen", "All Saints' Day", "AT"));
                    items.Add(new PublicHoliday(8, 12, year, "Mariä Empfängnis", "Immaculate Conception", "AT"));
                    items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", "AT"));
                    items.Add(new PublicHoliday(26, 12, year, "Stefanitag", "St. Stephen's Day", "AT"));
                    break;
                case "DE":
                    items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", "DE"));
                    items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", "DE"));
                    items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter", "DE"));
                    items.Add(new PublicHoliday(1, 5, year, "Tag der Arbeit", "Labor Day", "DE"));
                    items.Add(new PublicHoliday(easterSunday.AddDays(39), "Christi Himmelfahrt", "Ascension Day", "DE"));
                    items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", "DE"));
                    items.Add(new PublicHoliday(3, 10, year, "Tag der Deutschen Einheit", "German Unity Day", "DE"));
                    items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", "DE"));
                    items.Add(new PublicHoliday(26, 12, year, "Stefanitag", "St. Stephen's Day", "DE"));
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
