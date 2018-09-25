using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class SwedenProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Sweden
            //https://en.wikipedia.org/wiki/Public_holidays_in_Sweden

            var countryCode = CountryCode.SE;
            var easterSunday = base.EasterSunday(year);

            var midsummerDay = DateSystem.FindDay(year, 6, 20, DayOfWeek.Saturday);
            var allSaintsDay = DateSystem.FindDay(year, 10, 31, DayOfWeek.Saturday);

            var items = new List<PublicHoliday>();

            items.Add(new PublicHoliday(year, 1, 5, "Trettondagsafton", "Twelth night", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Trettondedag jul", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Skärtorsdagen", "Maundy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Långfredagen", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "Påskafton", "Easter Saturday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Påskdagen", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Annandag påsk", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(48), "Pingstafton", "Whitsun Eve", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Pingstdagen", "Withsun Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Första maj", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Kristi himmelsfärdsdag", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 6, "Nationaldagen", "National Day of Sweden", countryCode));
            items.Add(new PublicHoliday(midsummerDay.AddDays(-1), "Midsommarafton", "Midsummer Eve", countryCode));
            items.Add(new PublicHoliday(midsummerDay, "Midsommardagen", "Midsummer Day", countryCode));
            items.Add(new PublicHoliday(allSaintsDay.AddDays(-1), "Allhelgonaafton", "Saint's Eve", countryCode));
            items.Add(new PublicHoliday(allSaintsDay, "Alla helgons dag", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Julafton", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Juldagen", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Annandag jul", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 1, "Nyårsdagen", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Nyårsafton", "New Year's Eve", countryCode));
            items.Add(new PublicHoliday(year, 4, 30, "Valborgsmässoafton", "Walpurgis night", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
