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
            items.Add(new PublicHoliday(1, 1, year, "Nowy Rok", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(6, 1, year, "Święto Trzech Króli", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday, "pierwszy dzień Wielkiej Nocy", "Easter Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "drugi dzień Wielkiej Nocy", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(1, 5, year, "Święto Państwowe", "May Day", countryCode));
            items.Add(new PublicHoliday(3, 5, year, "Święto Narodowe Trzeciego Maja", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "pierwszy dzień Zielonych Świątek", "Pentecost Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "dzień Bożego Ciała", "Corpus Christi", countryCode));
            items.Add(new PublicHoliday(15, 8, year, "Wniebowzięcie Najświętszej Maryi Panny", "Assumption of the Virgin Mary", countryCode));
            items.Add(new PublicHoliday(1, 11, year, "Wszystkich Świętych", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(11, 11, year, "Narodowe Święto Niepodległości", "Independence Day", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "pierwszy dzień Bożego Narodzenia", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "drugi dzień Bożego Narodzenia", "Boxing Day", countryCode));

            return items;
        }
    }
}
