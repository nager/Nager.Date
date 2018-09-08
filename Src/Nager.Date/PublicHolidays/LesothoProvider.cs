using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class LesothoProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Lesotho
            //https://en.wikipedia.org/wiki/Public_holidays_in_Lesotho

            var countryCode = CountryCode.LS;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 11, "Moshoeshoe Day", "Moshoeshoe Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Workers' Day", "Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 9, "Ascension Day", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 25, "Africa Day/ Heroes' Day", "Africa Day/ Heroes' Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 17, "King Letsie III's Birthday", "King Letsie III's Birthday", countryCode));
            items.Add(new PublicHoliday(year, 10, 4, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
