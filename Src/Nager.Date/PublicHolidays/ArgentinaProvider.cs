﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class ArgentinaProvider : CatholicBaseProvider
    {
        public ArgentinaProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Argentina
            //https://en.wikipedia.org/wiki/Public_holidays_in_Argentina

            var countryCode = CountryCode.AR;
            var easterSunday = base.EasterSunday(year);

            var thirdMondayInAugust = DateSystem.FindDay(year, 8, DayOfWeek.Monday, 3);
            var secondMondayInOctober = DateSystem.FindDay(year, 10, DayOfWeek.Monday, 2);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(year, 3, 24, "Día Nacional de la Memoria por la Verdad y la Justicia", "Day of Remembrance for Truth and Justice", countryCode));
            items.Add(new PublicHoliday(year, 4, 2, "Día del Veterano y de los Caídos en la Guerra de Malvinas", "Day of the Veterans and Fallen of the Malvinas War", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Viernes Santo", "Good Friday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Día del Trabajador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 25, "Día de la Revolución de Mayo", "May Revolution", countryCode));
            items.Add(new PublicHoliday(year, 6, 17, "Paso a la Inmortalidad del General Martín Miguel de Güemes", "Anniversary of the Passing of General Martín Miguel de Güemes", countryCode, 2016));
            items.Add(new PublicHoliday(year, 6, 20, "Paso a la Inmortalidad del General Manuel Belgrano", "General Manuel Belgrano Memorial Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 9, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayInAugust, "Paso a la Inmortalidad del General José de San Martín", "General José de San Martín Memorial Day", countryCode));
            items.Add(new PublicHoliday(secondMondayInOctober, "Día del Respeto a la Diversidad Cultural", "Day of Respect for Cultural Diversity", countryCode));
            items.Add(new PublicHoliday(year, 11, 20, "Día de la Soberanía Nacional", "National Sovereignty Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Día de la Inmaculada Concepción de María", "Immaculate Conception Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
