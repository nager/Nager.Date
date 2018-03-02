using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class ParaguayProvider : CatholicBaseProvider
    {
        public override DayOfWeek FirstDayOfWeek => DayOfWeek.Monday;
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Paraguay
            //https://en.wikipedia.org/wiki/Public_holidays_in_Paraguay

            var countryCode = CountryCode.PY;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 1, "Dia de los héroes", "Heroes' day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Jueves Santo", "Maundy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Viernes Santo", "Good Friday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Día de los Trabajadores", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 14, "Independencia", "Paraguayan Independence", countryCode));
            items.Add(new PublicHoliday(year, 5, 15, "Independencia", "Paraguayan Independence", countryCode));
            items.Add(new PublicHoliday(year, 6, 12, "Dia de la Paz del Chaco", "Chaco Armistice", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Fundación de Asunción", "Founding of Asunción", countryCode));
            items.Add(new PublicHoliday(year, 9, 29, "Victoria de Boquerón", "Boqueron Battle Victory Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Virgen de Caacupé", "Virgin of Caacupe", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Día de Navidad", "Christmas Day", countryCode));
            
            return items.OrderBy(o => o.Date);
        }
    }
}
