using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class SvalbardUndJanMayenProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Svalbard und Jan Mayen 
            //https://en.wikipedia.org/wiki/Public_holidays_in_Svalbard

            var countryCode = CountryCode.SJ;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Første nyttårsdag", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Skjærtorsdag", "Maundy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Langfredag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Første påskedag", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Andre påskedag", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Første mai", "May Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 17, "Syttende mai", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Kristi himmelfartsdag", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Første pinsedag", "Whit Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Andre pinsedag", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Første juledag", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Andre juledag", "Second day of Christmas", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
