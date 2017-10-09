using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class AndorraProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Andorra
            //https://en.wikipedia.org/wiki/Public_holidays_in_Andorra

            var countryCode = CountryCode.AD;
            //var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Any nou", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 14, "Dia de la Constitució", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 14, "Mare de Déu de Meritxell", "National Holiday", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Nadal", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
