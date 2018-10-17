using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class CzechRepublicProvider : CatholicBaseProvider
    {
        public CzechRepublicProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Czech Republic
            //https://en.wikipedia.org/wiki/Public_holidays_in_the_Czech_Republic

            var countryCode = CountryCode.CZ;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Den obnovy samostatného českého státu; Nový rok", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Velký pátek", "Good Friday", countryCode, 2016));
            items.Add(new PublicHoliday(easterSunday, "Velikonoční", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Velikonoční pondělí", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Svátek práce", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 8, "Den vítězství or Den osvobození", "Liberation Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 5, "Den slovanských věrozvěstů Cyrila a Metoděje", "Saints Cyril and Methodius Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 6, "Den upálení mistra Jana Husa", "Jan Hus Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 28, "Den české státnosti", "St. Wenceslas Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 28, "Den vzniku samostatného československého státu", "Independent Czechoslovak State Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 17, "Den boje za svobodu a demokracii", "Struggle for Freedom and Democracy Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Štědrý den", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "1. svátek vánoční", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "2. svátek vánoční", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
