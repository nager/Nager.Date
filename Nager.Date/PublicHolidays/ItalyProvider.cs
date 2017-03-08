using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class ItalyProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Italy
            //https://en.wikipedia.org/wiki/Public_holidays_in_Italy

            var countryCode = CountryCode.IT;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Capodanno", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(year, 1, 6, "Epifania", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Pasqua", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Lunedì dell'Angelo", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(year, 4, 25, "Festa della Liberazione", "Liberation Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Festa del Lavoro", "International Workers Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 2, "Festa della Repubblica", "Republic Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Ferragosto and Assunta", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Tutti i santi", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Immacolata Concezione", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natale", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Santo Stefano", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
