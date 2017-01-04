using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public class RomaniaProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Romania
            //https://en.wikipedia.org/wiki/Public_holidays_in_Romania

            var countryCode = CountryCode.RO;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "Anul Nou", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(2, 1, year, "Anul Nou", "Day after New Year's Day", countryCode));
            items.Add(new PublicHoliday(24, 1, year, "Unirea Principatelor Române/Mica Unire", "Union Day/Small Union", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Paștele", "Easter", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Paștele", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(1, 5, year, "Ziua Muncii", "Labour Day", countryCode));
            items.Add(new PublicHoliday(1, 6, year, "Ziua Copilului", "Children's Day", countryCode, 2017));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Rusaliile", "Pentecost", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(51), "Rusaliile", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(15, 8, year, "Adormirea Maicii Domnului/Sfânta Maria Mare", "Dormition of the Theotokos", countryCode));
            items.Add(new PublicHoliday(30, 11, year, "Sfântul Andrei", "St. Andrew's Day", countryCode));
            items.Add(new PublicHoliday(1, 12, year, "Ziua Națională/Marea Unire", "National Day/Great Union", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Crăciunul", "Christmas Day", countryCode, null, null, false));
            items.Add(new PublicHoliday(26, 12, year, "Crăciunul", "St. Stephen's Day", countryCode, null, null, false));

            return items;
        }
    }
}
