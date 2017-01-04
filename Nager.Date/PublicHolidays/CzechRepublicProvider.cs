using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public class CzechRepublicProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Czech Republic
            //https://en.wikipedia.org/wiki/Public_holidays_in_the_Czech_Republic

            var countryCode = CountryCode.CZ;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "Den obnovy samostatného českého státu; Nový rok", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Velký pátek", "Good Friday", countryCode, 2016));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Velikonoční pondělí", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(1, 5, year, "Svátek práce", "Labour Day", countryCode));
            items.Add(new PublicHoliday(8, 5, year, "Den vítězství or Den osvobození", "Liberation Day", countryCode));
            items.Add(new PublicHoliday(5, 7, year, "Den slovanských věrozvěstů Cyrila a Metoděje", "Saints Cyril and Methodius Day", countryCode));
            items.Add(new PublicHoliday(6, 7, year, "Den upálení mistra Jana Husa", "Jan Hus Day", countryCode));
            items.Add(new PublicHoliday(28, 9, year, "Den české státnosti", "St. Wenceslas Day", countryCode));
            items.Add(new PublicHoliday(28, 10, year, "Den vzniku samostatného československého státu", "Independent Czechoslovak State Day", countryCode));
            items.Add(new PublicHoliday(17, 11, year, "Den boje za svobodu a demokracii", "Struggle for Freedom and Democracy Day", countryCode));
            items.Add(new PublicHoliday(24, 12, year, "Štědrý den", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "1. svátek vánoční", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "2. svátek vánoční", "St. Stephen's Day", countryCode));

            return items;
        }
    }
}
