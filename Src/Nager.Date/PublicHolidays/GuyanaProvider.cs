using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class GuyanaProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Guyana
            //https://en.wikipedia.org/wiki/Public_holidays_in_Guyana

            var countryCode = CountryCode.GY;
            var easterSunday = base.EasterSunday(year);

            var firstMondayInJuly = DateSystem.FindDay(year, 7, DayOfWeek.Monday, 1);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 23, "Republic Day", "Republic Day", countryCode));
            //TODO:Phagwah ??? (Hindu calendar)
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 5, "Arrival Day", "Arrival Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 26, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(firstMondayInJuly, "Caricom Day", "Caricom Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 1, "Emancipation Day", "Emancipation Day", countryCode));
            //TODO:Deepavali ??? (Hindu calendar)
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "Boxing Day", countryCode));
            //TODO:Youman-Nabi ??? (Muslim holidays)
            //TODO:Eid-ul-Adha ??? (Muslim holidays)
            return items.OrderBy(o => o.Date);
        }
    }
}
