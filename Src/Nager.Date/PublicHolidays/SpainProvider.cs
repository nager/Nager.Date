﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class SpainProvider : CatholicBaseProvider
    {
        public SpainProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Spain
            //https://en.wikipedia.org/wiki/Public_holidays_in_Spain

            var countryCode = CountryCode.ES;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(year, 1, 6, "Día de Reyes / Epifanía del Señor", "Epiphany", countryCode));
            items.Add(new PublicHoliday(year, 2, 28, "Día de Andalucía", "Regional Holiday", countryCode, null, new string[] { "ES-AN" }));
            items.Add(new PublicHoliday(year, 3, 1, "Dia de les Illes Balears", "Regional Holiday", countryCode, null, new string[] { "ES-IB" }));
            items.Add(new PublicHoliday(year, 3, 1, "San José", "St. Joseph's Day", countryCode, null, new string[] { "ES-ML", "ES-CM", "ES-GA", "ES-IB", "ES-M", "ES-MU", "ES-NA", "ES-O", "ES-VC" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Jueves Santo", "Maundy Thursday", countryCode, null, new string[] { "ES-AN", "ES-AR", "ES-CE", "ES-ML", "ES-CL", "ES-CM", "ES-IC", "ES-EX", "ES-GA", "ES-IB", "ES-LO", "ES-M", "ES-MU", "ES-NA", "ES-O", "ES-PV", "ES-CB" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Viernes Santo", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Pascua de Resurrección", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, 1642, new string[] { "ES-CT", "ES-IB", "ES-NA", "ES-PV", "ES-VC" }));
            items.Add(new PublicHoliday(year, 4, 23, "San Jorge (Día de Aragón)", "Regional Holiday", countryCode, null, new string[] { "ES-AR" }));
            items.Add(new PublicHoliday(year, 4, 23, "Día de Castilla y León", "Regional Holiday", countryCode, null, new string[] { "ES-CL" }));
            items.Add(new PublicHoliday(year, 5, 1, "Día del Trabajador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 2, "Fiesta de la Comunidad de Madrid", "Regional Holiday", countryCode, null, new string[] { "ES-M" }));
            items.Add(new PublicHoliday(year, 5, 17, "Día das Letras Galegas", "Regional Holiday", countryCode, null, new string[] { "ES-GA" }));
            items.Add(new PublicHoliday(year, 5, 30, "Día de Canarias", "Regional Holiday", countryCode, null, new string[] { "ES-IC" }));
            items.Add(new PublicHoliday(year, 5, 31, "Día de la Región Castilla-La Mancha", "Regional Holiday", countryCode, null, new string[] { "ES-CM" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Corpus Christi", "Corpus Christi", countryCode, null, new string[] { "ES-M" }));
            items.Add(new PublicHoliday(year, 6, 9, "Día de la Región de Murcia", "Regional Holiday", countryCode, null, new string[] { "ES-MU" }));
            items.Add(new PublicHoliday(year, 6, 9, "Día de La Rioja", "Regional Holiday", countryCode, null, new string[] { "ES-LO" }));
            items.Add(new PublicHoliday(year, 6, 24, "Sant Joan", "St. John's Day", countryCode, null, new string[] { "ES-CT" }));
            items.Add(new PublicHoliday(year, 7, 25, "Santiago Apóstol", "Saint James", countryCode, null, new string[] { "ES-GA" }));
            items.Add(new PublicHoliday(year, 8, 15, "Asunción", "Assumption", countryCode));
            items.Add(new PublicHoliday(year, 9, 2, "Día de Ceuta", "Municipal Holiday", countryCode, null, new string[] { "ES-CE" }));
            items.Add(new PublicHoliday(year, 9, 8, "Día de Asturias", "Regional Holiday", countryCode, null, new string[] { "ES-O" }));
            items.Add(new PublicHoliday(year, 9, 8, "Día de Extremadura", "Regional Holiday", countryCode, null, new string[] { "ES-EX" }));
            items.Add(new PublicHoliday(year, 9, 11, "Diada Nacional de Catalunya", "National Day of Catalonia", countryCode, null, new string[] { "ES-CT" }));
            items.Add(new PublicHoliday(year, 9, 15, "Día de Cantabria", "Regional Holiday", countryCode, null, new string[] { "ES-CB" }));
            items.Add(new PublicHoliday(year, 10, 9, "Dia de la Comunitat Valenciana", "Regional Holiday", countryCode, null, new string[] { "ES-VC" }));
            items.Add(new PublicHoliday(year, 10, 12, "Fiesta Nacional de España", "Fiesta Nacional de España", countryCode));
            items.Add(new PublicHoliday(year, 10, 25, "Euskadi Eguna", "Regional Holiday", countryCode, null, new string[] { "ES-PV" }));
            items.Add(new PublicHoliday(year, 11, 1, "Día de todos los Santos", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 6, "Día de la Constitución", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Inmaculada Concepción", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Sant Esteve", "St. Stephen's Day", countryCode, null, new string[] { "ES-CT", "ES-IB" }));

            return items.OrderBy(o => o.Date);
        }
    }
}
