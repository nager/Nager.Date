using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nager.Date.PublicHolidays
{
    public class AlbaniaProvider : OrthodoxBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Albania
            //https://en.wikipedia.org/wiki/Public_holidays_in_Albania

            var countryCode = CountryCode.AL;
            var easterSunday = base.EasterSunday(year);
            var easterMonday = easterSunday.AddDays(1);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Viti i Ri", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 2, "Viti i Ri", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 14, "Dita e Verës", "Summer Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 22, "Dita e Sulltan Nevruzit", "Nowruz", countryCode));
            //Catholic Easter is not implemented
            //Orthodox easter and monday
            items.Add(new PublicHoliday(easterSunday, "Pashkët Ortodokse", "Orthodox Easter", countryCode));
            items.Add(new PublicHoliday(easterMonday, "Pashkët Ortodokse", "Orthodox Easter", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dita Ndërkombëtare e Punonjësve", "May Day", countryCode));
            //Eid ul-Fitr is not implemented
            //Eid ul-Adha is not implemented

            items.Add(new PublicHoliday(year, 10, 19, "Dita e Nënë Terezës", "Mother Teresa Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 28, "Dita e Pavarësisë", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 29, "Dita e Çlirimit", "Liberation Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 08, "Dita Kombëtare e Rinisë", "Youth Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Krishtlindjet", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
