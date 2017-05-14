using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class GuatemalaProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Guatemala
            //https://en.wikipedia.org/wiki/Public_holidays_in_Guatemala

            var countryCode = CountryCode.GT;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            //Thursday??
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "Holy Saturday", "Holy Saturday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Easter Sunday", "Easter Sunday", countryCode));




            items.Add(new PublicHoliday(easterSunday.AddDays(1), " Pasen", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Hemelvaartsdag", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pinksteren", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Eerste kerstdag", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Tweede kerstdag", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
