using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public class MaltaProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Malta
            var countryCode = CountryCode.MT;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "L-Ewwel tas-Sena", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(10, 2, year, "In-Nawfraġju ta’ San Pawl", "Feast of St. Paul's Shipwreck", countryCode));
            items.Add(new PublicHoliday(19, 3, year, "San Ġużepp", "Feast of St. Joseph", countryCode));
            items.Add(new PublicHoliday(31, 3, year, "Jum il-Ħelsien", "Freedom Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Il-Ġimgħa l-Kbira", "Good Friday", countryCode));
            items.Add(new PublicHoliday(1, 5, year, "Jum il-Ħaddiem", "Worker's Day", countryCode));
            items.Add(new PublicHoliday(7, 6, year, "Sette Giugno", "​Sette Giugno", countryCode));
            items.Add(new PublicHoliday(29, 6, year, "L-Imnarja", "​​Feast of St.Peter and St.Paul", countryCode));
            items.Add(new PublicHoliday(15, 8, year, "Santa Marija", "​​​Feast of the Assumption", countryCode));
            items.Add(new PublicHoliday(8, 9, year, "Il-Vittorja", "Feast of Our Lady of Victories", countryCode));
            items.Add(new PublicHoliday(21, 9, year, "L-Indipendenza", "Independence Day", countryCode));
            items.Add(new PublicHoliday(8, 12, year, "L-Immakulata Kunċizzjoni", "​Feast of the Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(13, 12, year, "Jum ir-Repubblika", "Republic Day", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Il-Milied​", "​Christmas Day", countryCode));

            return items;
        }
    }
}
