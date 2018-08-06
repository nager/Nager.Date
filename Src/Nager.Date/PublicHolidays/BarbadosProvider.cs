using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class BarbadosProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Barbados
            //https://en.wikipedia.org/wiki/Public_holidays_in_Barbados

            var countryCode = CountryCode.BB;
            var easterSunday = base.EasterSunday(year);

            var firstMondayInAugust = DateSystem.FindDay(year, 8, DayOfWeek.Monday, 1);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 21, "Errol Barrow Day", "Errol Barrow Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 4, 28, "National Heroes' Day", "National Heroes' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Whit Monday", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 8, 1, "Emancipation Day", "Emancipation Day", countryCode));
            items.Add(new PublicHoliday(firstMondayInAugust, "Kadooment Day", "Kadooment Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 30, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "Boxing Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
