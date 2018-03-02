using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class EstoniaProvider : CatholicBaseProvider
    {
        public override DayOfWeek FirstDayOfWeek => DayOfWeek.Monday;
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Estonia
            //https://en.wikipedia.org/wiki/Public_holidays_in_Estonia

            var countryCode = CountryCode.EE;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "uusaasta", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 24, "iseseisvuspäev", "Independence Day", countryCode, 1918));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "suur reede", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "ülestõusmispühade 1. püha", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "kevadpüha", "Spring Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "nelipühade 1. püha", "Pentecost", countryCode));
            items.Add(new PublicHoliday(year, 6, 23, "võidupüha and jaanilaupäev", "Victory Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 24, "jaanipäev", "Midsummer Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 20, "taasiseseisvumispäev", "Day of Restoration of Independence", countryCode, 1991));
            items.Add(new PublicHoliday(year, 12, 24, "jõululaupäev", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "esimene jõulupüha", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "teine jõulupüha", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
