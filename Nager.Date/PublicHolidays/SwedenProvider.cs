using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class SwedenProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Sweden
            //https://en.wikipedia.org/wiki/Public_holidays_in_Sweden

            var countryCode = CountryCode.SE;

            var midsummerDay = DateSystem.FindDay(year, 6, 20, DayOfWeek.Saturday);
            var allSaintsDay = DateSystem.FindDay(year, 10, 31, DayOfWeek.Saturday);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "nyårsdagen", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "trettondedag jul", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "långfredagen", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "annandag påsk", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Första maj", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Kristi himmelsfärds dag", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 6, "Sveriges nationaldag", "National Day of Sweden", countryCode));
            items.Add(new PublicHoliday(midsummerDay.AddDays(-1), "midsommarafton", "Midsummer Eve", countryCode));
            items.Add(new PublicHoliday(midsummerDay, "midsommardagen", "Midsummer Day", countryCode));
            items.Add(new PublicHoliday(allSaintsDay, "alla helgons dag", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "julafton", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "juldagen", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "annandag jul", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "nyårsafton", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
