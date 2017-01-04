using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public class IrelandProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Ireland
            //https://en.wikipedia.org/wiki/Public_holidays_in_the_Republic_of_Ireland

            var countryCode = CountryCode.IE;

            var mayDay = DateSystem.FindDay(year, 5, DayOfWeek.Monday, 0);
            var juneHoliday = DateSystem.FindDay(year, 5, DayOfWeek.Monday, 0);
            var augustHoliday = DateSystem.FindDay(year, 5, DayOfWeek.Monday, 0);
            var octoberHoliday = DateSystem.FindLastDay(year, 5, DayOfWeek.Monday);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "Lá Caille", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(17, 3, year, "Lá Fhéile Pádraig", "Saint Patrick's Day", countryCode, 1903));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Luan Cásca", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(mayDay, 5, year, "Lá Bealtaine", "May Day", countryCode, 1994));
            items.Add(new PublicHoliday(juneHoliday, 6, year, "Lá Saoire i mí an Mheithimh", "June Holiday", countryCode, 1973));
            items.Add(new PublicHoliday(augustHoliday, 8, year, "Lá Saoire i mí Lúnasa", "August Holiday", countryCode));
            items.Add(new PublicHoliday(octoberHoliday, 10, year, "Lá Saoire i mí Dheireadh Fómhair", "October Holiday", countryCode, 1977));
            items.Add(new PublicHoliday(25, 12, year, "Lá Nollag", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "Lá Fhéile Stiofáin", "St. Stephen's Day", countryCode));

            return items;
        }
    }
}
