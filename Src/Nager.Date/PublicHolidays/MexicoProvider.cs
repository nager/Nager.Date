using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class MexicoProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Mexico (Only Statutory holidays)
            //https://en.wikipedia.org/wiki/Public_holidays_in_Mexico

            var countryCode = CountryCode.MX;
            var easterSunday = base.EasterSunday(year);

            var firstMondayOfFebruary = DateSystem.FindDay(year, 2, DayOfWeek.Monday, 1);
            var thirdMondayOfMarch = DateSystem.FindDay(year, 3, DayOfWeek.Monday, 3);
            var thirdMondayOfNovember = DateSystem.FindDay(year, 11, DayOfWeek.Monday, 3);
            var newYearDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            var laborDay = new DateTime(year, 5, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            var independenceDay = new DateTime(year, 9, 16).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            var inaugurationDay = new DateTime(year, 12, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(newYearDay, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(firstMondayOfFebruary, "Día de la Constitución", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayOfMarch, "Natalicio de Benito Juárez", "Benito Juárez's birthday", countryCode));
            items.Add(new PublicHoliday(laborDay, "Día del Trabajo", "Labor Day", countryCode));
            items.Add(new PublicHoliday(independenceDay, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayOfNovember, "Día de la Revolución", "Revolution Day", countryCode));
            if ((year - 2) % 6 == 0)
            {
                items.Add(new PublicHoliday(inaugurationDay, "Transmisión del Poder Ejecutivo Federal", "Inauguration Day", countryCode));
            }
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
