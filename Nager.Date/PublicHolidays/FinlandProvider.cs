using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public class FinlandProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Finland
            //https://en.wikipedia.org/wiki/Public_holidays_in_Finland

            var countryCode = CountryCode.FI;

            var midsummerEve = DateSystem.FindDay(year, 6, 19, DayOfWeek.Friday);
            var midsummerDay = DateSystem.FindDay(year, 6, 20, DayOfWeek.Saturday);
            var allSaintsDay = DateSystem.FindDay(year, 11, 19, DayOfWeek.Saturday);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "Uudenvuodenpäivä", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(6, 1, year, "Loppiainen", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Pitkäperjantai", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Pääsiäispäivä", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "2. pääsiäispäivä", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(6, 1, year, "Vappu", "May Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Helatorstai", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Helluntaipäivä", "Pentecost", countryCode));
            items.Add(new PublicHoliday(midsummerEve, "Juhannusaatto", "Midsummer Eve", countryCode));
            items.Add(new PublicHoliday(midsummerDay, "Juhannuspäivä", "Midsummer Day", countryCode));
            items.Add(new PublicHoliday(allSaintsDay, "Pyhäinpäivä", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(6, 12, year, "Itsenäisyyspäivä", "Independence Day", countryCode));
            items.Add(new PublicHoliday(24, 12, year, "Jouluaatto", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Joulupäivä", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "2. joulupäivä", "St. Stephen's Day", countryCode));

            return items;
        }
    }
}
