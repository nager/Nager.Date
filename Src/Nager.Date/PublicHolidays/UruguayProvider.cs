﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class UruguayProvider : CatholicBaseProvider
    {
        public UruguayProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Uruguay
            //https://en.wikipedia.org/wiki/Public_holidays_in_Uruguay

            var countryCode = CountryCode.UY;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Día de los Niños", "Children's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Semana de Turismo", "Maundy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Semana de Turismo", "Good Friday", countryCode));
            items.Add(new PublicHoliday(year, 4, 19, "Desembarco de los 33 Orientales", "Landing of the 33 Patriots Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Día de los Trabajadores", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 18, "Batalla de las Piedras", "Battle of Las Piedras", countryCode));
            items.Add(new PublicHoliday(year, 6, 19, "Natalicio de Artigas y Día del Nunca Más", "Birthday of José Gervasio Artigas and Never Again Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 18, "Jura de la Constitución", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 25, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 12, "Día de la Raza", "Day of the race", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "Día de los Difuntos", "Deceased ones day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Día de la Familia", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
