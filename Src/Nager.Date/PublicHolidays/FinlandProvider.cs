using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class FinlandProvider : CatholicBaseProvider
    {
        public override DayOfWeek FirstDayOfWeek => DayOfWeek.Monday;
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Finland
            //https://en.wikipedia.org/wiki/Public_holidays_in_Finland

            var countryCode = CountryCode.FI;
            var easterSunday = base.EasterSunday(year);

            var midsummerEve = DateSystem.FindDay(year, 6, 19, DayOfWeek.Friday);
            var midsummerDay = DateSystem.FindDay(year, 6, 20, DayOfWeek.Saturday);
            var allSaintsDay = DateSystem.FindDay(year, 11, 19, DayOfWeek.Saturday);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Uudenvuodenpäivä", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Loppiainen", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Pitkäperjantai", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Pääsiäispäivä", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "2. pääsiäispäivä", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Vappu", "May Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Helatorstai", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Helluntaipäivä", "Pentecost", countryCode));
            items.Add(new PublicHoliday(midsummerEve, "Juhannusaatto", "Midsummer Eve", countryCode));
            items.Add(new PublicHoliday(midsummerDay, "Juhannuspäivä", "Midsummer Day", countryCode));
            items.Add(new PublicHoliday(allSaintsDay, "Pyhäinpäivä", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 6, "Itsenäisyyspäivä", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Jouluaatto", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Joulupäivä", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "2. joulupäivä", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
