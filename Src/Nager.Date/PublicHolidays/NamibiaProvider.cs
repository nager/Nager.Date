using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class NamibiaProvider : CatholicBaseProvider
    {
        public override DayOfWeek FirstDayOfWeek => DayOfWeek.Monday;
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Namibia
            //https://en.wikipedia.org/wiki/Public_holidays_in_Namibia

            var countryCode = CountryCode.NA;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 21, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Workers' Day", "Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 4, "Cassinga Day", "Cassinga Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Ascension Day", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 25, "Africa Day", "Africa Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 26, "Heroes' Day", "Heroes' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 10, "Human Rights Day", "Human Rights Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Day of Goodwill", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
