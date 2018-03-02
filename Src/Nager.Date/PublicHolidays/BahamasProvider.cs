using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class BahamasProvider : CatholicBaseProvider
    {
        public override DayOfWeek FirstDayOfWeek => DayOfWeek.Monday;

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Bahamas
            //https://en.wikipedia.org/wiki/Public_holidays_in_the_Bahamas

            var countryCode = CountryCode.BS;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 10, "Majority Rule Day", "Majority Rule Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Whit Monday", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 4, 1, "Perry Christie Day", "Perry Christie Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 10, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 5, "Emancipation Day", "Emancipation Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 12, "National Heroes' Day", "National Heroes' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
