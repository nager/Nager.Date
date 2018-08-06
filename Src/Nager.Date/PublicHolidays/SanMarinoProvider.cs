using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nager.Date.PublicHolidays
{
    public class SanMarinoProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //San Marino 
            //https://en.wikipedia.org/wiki/San_Marino#Public_holidays_and_festivals

            var countryCode = CountryCode.SM;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();

            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Epiphany", "Epiphany", countryCode));
            items.Add(new PublicHoliday(year, 2, 5, "Feast of Saint Agatha", "Feast of Saint Agatha", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Easter", "Easter", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 3, 25, "Anniversary of the Arengo", "Anniversary of the Arengo", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            //items.Add(new PublicHoliday(year, 1, 1, "Corpus Christi", "Corpus Christi", countryCode)); Berechnen
            items.Add(new PublicHoliday(year, 7, 28, "Liberation from Fascism", "Liberation from Fascism", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Ferragosto (Assumption)", "Ferragosto (Assumption)", countryCode));
            items.Add(new PublicHoliday(year, 9, 3, "The Feast of San Marino and the Republic", "The Feast of San Marino and the Republic", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "All Saints' Day", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "Commemoration of all those who died at war", "Commemoration of all those who died at war", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Immaculate Conception", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Christmas Eve", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas", "Christmas", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Saint Stephen's Day", "Saint Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "New Year's Eve", "New Year's Eve", countryCode));


            return items.OrderBy(o => o.Date);
        }
    }
}
