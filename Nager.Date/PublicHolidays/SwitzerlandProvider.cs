using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public class SwitzerlandProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Switzerland
            //http://de.wikipedia.org/wiki/Feiertage_in_der_Schweiz

            var countryCode = CountryCode.CH;

            //In canton of Neuchâtel the following dates are considered official county holidays
            //only if Christmas day and new year's day fall on a Sunday : 26.12 and 02.01
            var christmasDate = new DateTime(year, 12, 25);
            var newYearDate = new DateTime(year, 12, 31);
            var isChristmasDateSunday = christmasDate.DayOfWeek == DayOfWeek.Sunday;
            var isNewYearDateSunday = newYearDate.DayOfWeek == DayOfWeek.Sunday;
            //Get Jeune fédéral holiday date for the given year (3rd monday of September)
            var thirdMondayOfSeptember = DateSystem.FindDay(year, 9, DayOfWeek.Monday, 3);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(2, 1, year, "Berchtoldstag", "St. Berchtold's Day", countryCode, null, new string[] { "CH-ZH", "CH-BE", "CH-LU", "CH-OW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-SH", "CH-TG", "CH-VD", "CH-NE", "CH-GE", "CH-JU" }, isNewYearDateSunday));
            items.Add(new PublicHoliday(6, 1, year, "Heilige Drei Könige", "Epiphany", countryCode, null, new string[] { "CH-UR", "CH-SZ", "CH-GR", "CH-TI" }));
            items.Add(new PublicHoliday(19, 3, year, "Josefstag", "Saint Joseph's Day", countryCode, null, new string[] { "CH-LU", "CH-UR", "CH-SZ", "CH-NW", "CH-ZG", "CH-GR", "CH-TI", "CH-VS" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", countryCode, null, new string[] { "CH-ZH", "CH-BE", "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-VD", "CH-NE", "CH-GE", "CH-JU" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, 1642, new string[] { "CH-ZH", "CH-BE", "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-TI", "CH-VD", "CH-NE", "CH-GE", "CH-JU" }));
            items.Add(new PublicHoliday(1, 5, year, "Tag der Arbeit", "Labor Day", countryCode, null, new string[] { "CH-ZH", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AG", "CH-TG", "CH-TI", "CH-NE", "CH-JU" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Auffahrt", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode, null, new string[] { "CH-ZH", "CH-BE", "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-TI", "CH-VD", "CH-NE", "CH-GE", "CH-JU" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", countryCode, null, new string[] { "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-ZG", "CH-FR", "CH-SO", "CH-BL", "CH-AI", "CH-GR", "CH-AG", "CH-TI", "CH-VS", "CH-NE", "CH-JU" }));
            items.Add(new PublicHoliday(1, 8, year, "Bundesfeier", "Swiss National Day", countryCode));
            items.Add(new PublicHoliday(15, 8, year, "Maria Himmelfahrt", "Assumption of the Virgin Mary", countryCode, null, new string[] { "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-ZG", "CH-FR", "CH-SO", "CH-BL", "CH-AI", "CH-GR", "CH-AG", "CH-TI", "CH-VS", "CH-JU" }));
            items.Add(new PublicHoliday(thirdMondayOfSeptember, 9, year, "Jeûne Fédéral", "Jeûne Fédéral", countryCode, null, new string[] { "CH-NE", "CH-VD" }, false));
            items.Add(new PublicHoliday(1, 11, year, "Allerheiligen", "All Saints' Day", countryCode, null, new string[] { "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TI", "CH-VS", "CH-JU" }));
            items.Add(new PublicHoliday(8, 12, year, "Mariä Empfängnis", "Immaculate Conception", countryCode, null, new string[] { "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-ZG", "CH-FR", "CH-SO", "CH-AI", "CH-GR", "CH-AG", "CH-TI", "CH-VS" }));
            items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "Stephanstag", "St. Stephen's Day", countryCode, null, new string[] { "CH-ZH", "CH-BE", "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG" }, isChristmasDateSunday));
            items.Add(new PublicHoliday(31, 12, year, "Silvester", "Silvester", countryCode, null, new string[] { "CH-NE" }, isNewYearDateSunday));

            return items;
        }
    }
}
