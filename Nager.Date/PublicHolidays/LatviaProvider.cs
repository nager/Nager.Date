using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class LatviaProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Latvia
            //https://en.wikipedia.org/wiki/Public_holidays_in_Latvia

            var countryCode = CountryCode.LV;
            var easterSunday = base.EasterSunday(year);

            var secondSundayInMay = DateSystem.FindDay(year, 5, DayOfWeek.Sunday, 2);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Jaunais Gads", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Lielā Piektdiena", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Lieldienas", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Otrās Lieldienas", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Darba svētki", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 4, "Latvijas Republikas Neatkarības atjaunošanas diena", "Restoration of Independence day", countryCode));
            items.Add(new PublicHoliday(year, 5, secondSundayInMay, "Mātes diena", "Mother's day", countryCode));
            items.Add(new PublicHoliday(year, 6, 23, "Līgo Diena", "Midsummer Eve", countryCode));
            items.Add(new PublicHoliday(year, 6, 24, "Jāņi", "Midsummer Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 18, "Latvijas Republikas proklamēšanas diena", "Proclamation Day of the Republic of Latvia", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Ziemassvētku vakars", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Ziemassvētki", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Otrie Ziemassvētki", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Vecgada vakars", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
