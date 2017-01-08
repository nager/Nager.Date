using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public class PolandProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Poland
            //https://en.wikipedia.org/wiki/Public_holidays_in_Poland

            var countryCode = CountryCode.PL;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nowy Rok", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Święto Trzech Króli", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday, "pierwszy dzień Wielkiej Nocy", "Easter Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "drugi dzień Wielkiej Nocy", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Święto Państwowe", "May Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 3, "Święto Narodowe Trzeciego Maja", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "pierwszy dzień Zielonych Świątek", "Pentecost Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "dzień Bożego Ciała", "Corpus Christi", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Wniebowzięcie Najświętszej Maryi Panny", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Wszystkich Świętych", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 11, "Narodowe Święto Niepodległości", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "pierwszy dzień Bożego Narodzenia", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "drugi dzień Bożego Narodzenia", "St. Stephen's Day", countryCode));

            return items;
        }
    }
}
