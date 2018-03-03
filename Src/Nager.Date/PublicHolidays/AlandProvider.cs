using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class AlandProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Åland
            //https://de.wikipedia.org/wiki/%C3%85land

            var countryCode = CountryCode.AD;
            var easterSunday = base.EasterSunday(year);

            var thirdFridayInJune = DateSystem.FindDay(year, 6, DayOfWeek.Friday, 3);
            var thirdSaturdayInJune = DateSystem.FindDay(year, 6, DayOfWeek.Friday, 3);
            var firstSaturdayInNovember = DateSystem.FindDay(year, 11, DayOfWeek.Friday, 3);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nyårsdagen", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 1, "Trettondagen", "Epiphany", countryCode));
            items.Add(new PublicHoliday(year, 3, 30, "Ålands demilitariseringsdag", "Demilitarization Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Långfredag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Påskdagen", "Easter Sunday", countryCode, 1642));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Annandag påsk", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(year, 4, 30, "Valborgsmässoafton", "Walpurgis Night", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Första maj", "May Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Kristi himmelsfärdsdagn", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Pingstdagen", "Pentecost", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Annandag Pingst", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 6, 9, "Självstyrelsedagen", "Autonomy Day", countryCode));
            items.Add(new PublicHoliday(thirdFridayInJune, "Midsommarafton", "Midsummer Eve", countryCode));
            items.Add(new PublicHoliday(thirdSaturdayInJune, "Midsommardagen", "Midsummer Day", countryCode));
            items.Add(new PublicHoliday(firstSaturdayInNovember, "Alla helgons dag", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 6, "Självständighetsdagen", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Julafton", "	Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Juldagen", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Annandag jul", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
