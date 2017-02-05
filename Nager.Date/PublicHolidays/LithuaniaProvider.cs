using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class LithuaniaProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Lithuania
            https://en.wikipedia.org/wiki/Public_holidays_in_Lithuania

            var countryCode = CountryCode.LT;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Naujieji metai", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 16, "Lietuvos valstybės atkūrimo diena", "The Day of Restoration of the State of Lithuania", countryCode));
            items.Add(new PublicHoliday(year, 3, 11, "Lietuvos nepriklausomybės atkūrimo diena", "Day of Restoration of Independence of Lithuania", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Velykos", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Tarptautinė darbo diena", "International Working Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 24, "Joninės, Rasos", "St. John's Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 6, "Valstybės diena", "Statehood Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Žolinė", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Visų šventųjų diena", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Šv. Kūčios", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Šv. Kalėdos", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Šv. Kalėdos", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
