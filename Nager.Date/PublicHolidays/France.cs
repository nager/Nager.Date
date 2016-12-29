using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public static class France
    {
        public static List<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //France
            var countryCode = CountryCode.FR;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "Jour de l'an", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Vendredi saint", "Good Friday", countryCode, null, new string[] { "FR-A", "FR-54" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Lundi de Pâques", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(1, 5, year, "Fête du premier mai", "Labor Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Jour de l'Ascension", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(8, 5, year, "Fête de la Victoire", "Victory in Europe Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Lundi de Pentecôte", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(14, 7, year, "Fête nationale", "Bastille Day", countryCode));
            items.Add(new PublicHoliday(15, 8, year, "L'Assomption de Marie", "Assumption of Mary to Heaven", countryCode));
            items.Add(new PublicHoliday(1, 11, year, "La Toussaint", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(11, 11, year, "Armistice de 1918", "Armistice Day", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Noël", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "Saint-Étienne", "St. Stephen's Day", countryCode));

            return items;
        }
    }
}
