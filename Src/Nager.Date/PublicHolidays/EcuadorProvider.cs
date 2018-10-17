﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class EcuadorProvider : CatholicBaseProvider
    {
        public EcuadorProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Ecuador
            //https://en.wikipedia.org/wiki/Public_holidays_in_Ecuador

            var countryCode = CountryCode.EC;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "International Workers' Day", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 24, "Batalla de Pichincha", "The Battle of Pichincha", countryCode));
            items.Add(new PublicHoliday(year, 8, 10, "Primer Grito de Independencia", "Declaration of Independence of Quito", countryCode));
            items.Add(new PublicHoliday(year, 10, 9, "Independencia de Guayaquil", "Independence of Guayaquil", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "Día de los Difuntos, Día de Muertos", "All Souls' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 3, "Independencia de Cuenca", "Independence of Cuenca", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Día de Navidad", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
