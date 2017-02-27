using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class RomaniaProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Romania
            //https://en.wikipedia.org/wiki/Public_holidays_in_Romania

            var countryCode = CountryCode.RO;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Anul Nou", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 2, "Anul Nou", "Day after New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 24, "Unirea Principatelor Române/Mica Unire", "Union Day/Small Union", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Paștele", "Easter", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Paștele", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Ziua Muncii", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 1, "Ziua Copilului", "Children's Day", countryCode, 2017));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Rusaliile", "Pentecost", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(51), "Rusaliile", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Adormirea Maicii Domnului/Sfânta Maria Mare", "Dormition of the Theotokos", countryCode));
            items.Add(new PublicHoliday(year, 11, 30, "Sfântul Andrei", "St. Andrew's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 1, "Ziua Națională/Marea Unire", "National Day/Great Union", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Crăciunul", "Christmas Day", countryCode, null, null, false));
            items.Add(new PublicHoliday(year, 12, 26, "Crăciunul", "St. Stephen's Day", countryCode, null, null, false));

            return items.OrderBy(o => o.Date);
        }
    }
}
