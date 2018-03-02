using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class SloveniaProvider : CatholicBaseProvider
    {
        public override DayOfWeek FirstDayOfWeek => DayOfWeek.Monday;
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Slovenia
            //https://en.wikipedia.org/wiki/Public_holidays_in_Slovenia

            var countryCode = CountryCode.SI;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "novo leto", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 2, "novo leto", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 8, "Prešernov dan", "Prešeren Day", countryCode));
            items.Add(new PublicHoliday(easterSunday, "velikonočna nedelja in ponedeljek", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "velikonočna nedelja in ponedeljek", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 4, 27, "dan upora proti okupatorju", "Day of Uprising Against Occupation", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "praznik dela", "May Day Holiday", countryCode, 1949));
            items.Add(new PublicHoliday(year, 5, 2, "praznik dela", "May Day Holiday", countryCode, 1949));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "binkoštna nedelja, binkošti", "Whit Sunday", countryCode));
            //items.Add(new PublicHoliday(year, 6, 8, "dan Primoža Trubarja", "Primož Trubar Day", countryCode)); not work-free
            items.Add(new PublicHoliday(year, 6, 25, "dan državnosti", "Statehood Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Marijino vnebovzetje", "Assumption Day", countryCode, 1992));
            items.Add(new PublicHoliday(year, 10, 31, "dan reformacije", "Reformation Day", countryCode, 1992));
            items.Add(new PublicHoliday(year, 11, 1, "dan spomina na mrtve", "Day of the Dead", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "božič", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "dan samostojnosti in enotnosti", "Independence and Unity Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
