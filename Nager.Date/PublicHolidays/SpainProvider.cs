using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public class SpainProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Spain
            var countryCode = CountryCode.ES;

            var items = new List<PublicHoliday>();
            //https://en.wikipedia.org/wiki/Public_holidays_in_Spain
            items.Add(new PublicHoliday(1, 1, year, "Año Nuevo", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(6, 1, year, "Día de Reyes / Epifanía del Señor", "Epiphany", countryCode));
            items.Add(new PublicHoliday(28, 2, year, "Día de Andalucía", "Regional Holiday", countryCode, null, new string[] { "ES-AN" }));
            items.Add(new PublicHoliday(1, 3, year, "Dia de les Illes Balears", "Regional Holiday", countryCode, null, new string[] { "ES-IB" }));
            items.Add(new PublicHoliday(1, 3, year, "San José", "St. Joseph's Day", countryCode, null, new string[] { "ES-ML", "ES-CM", "ES-GA", "ES-IB", "ES-M", "ES-MU", "ES-NA", "ES-O", "ES-VC" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Jueves Santo", "Maundy Thursday", countryCode, null, new string[] { "ES-AN", "ES-AR", "ES-CE", "ES-ML", "ES-CL", "ES-CM", "ES-IC", "ES-EX", "ES-GA", "ES-IB", "ES-LO", "ES-M", "ES-MU", "ES-NA", "ES-O", "ES-PV", "ES-CB" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Viernes Santo", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, 1642, new string[] { "ES-CT", "ES-IB", "ES-NA", "ES-PV", "ES-VC" }));
            items.Add(new PublicHoliday(23, 4, year, "San Jorge (Día de Aragón)", "Regional Holiday", countryCode, null, new string[] { "ES-AR" }));
            items.Add(new PublicHoliday(23, 4, year, "Día de Castilla y León", "Regional Holiday", countryCode, null, new string[] { "ES-CL" }));
            items.Add(new PublicHoliday(1, 5, year, "Día del Trabajador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(2, 5, year, "Fiesta de la Comunidad de Madrid", "Regional Holiday", countryCode, null, new string[] { "ES-M" }));
            items.Add(new PublicHoliday(17, 5, year, "Día das Letras Galegas", "Regional Holiday", countryCode, null, new string[] { "ES-GA" }));
            items.Add(new PublicHoliday(30, 5, year, "Día de Canarias", "Regional Holiday", countryCode, null, new string[] { "ES-IC" }));
            items.Add(new PublicHoliday(31, 5, year, "Día de la Región Castilla-La Mancha", "Regional Holiday", countryCode, null, new string[] { "ES-CM" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Corpus Christi", "Corpus Christi", countryCode, null, new string[] { "ES-M" }));
            items.Add(new PublicHoliday(9, 6, year, "Día de la Región de Murcia", "Regional Holiday", countryCode, null, new string[] { "ES-MU" }));
            items.Add(new PublicHoliday(9, 6, year, "Día de La Rioja", "Regional Holiday", countryCode, null, new string[] { "ES-LO" }));
            items.Add(new PublicHoliday(24, 6, year, "Sant Joan", "St. John's Day", countryCode, null, new string[] { "ES-CT" }));
            items.Add(new PublicHoliday(25, 7, year, "Santiago Apóstol", "Saint James", countryCode, null, new string[] { "ES-GA" }));
            items.Add(new PublicHoliday(15, 8, year, "Asunción", "Assumption", countryCode));
            items.Add(new PublicHoliday(2, 9, year, "Día de Ceuta", "Municipal Holiday", countryCode, null, new string[] { "ES-CE" }));
            items.Add(new PublicHoliday(8, 9, year, "Día de Asturias", "Regional Holiday", countryCode, null, new string[] { "ES-O" }));
            items.Add(new PublicHoliday(8, 9, year, "Día de Extremadura", "Regional Holiday", countryCode, null, new string[] { "ES-EX" }));
            items.Add(new PublicHoliday(11, 9, year, "Diada Nacional de Catalunya", "National Day of Catalonia", countryCode, null, new string[] { "ES-CT" }));
            items.Add(new PublicHoliday(15, 9, year, "Día de Cantabria", "Regional Holiday", countryCode, null, new string[] { "ES-CB" }));
            items.Add(new PublicHoliday(9, 10, year, "Dia de la Comunitat Valenciana", "Regional Holiday", countryCode, null, new string[] { "ES-VC" }));
            items.Add(new PublicHoliday(12, 10, year, "Fiesta Nacional de España", "Fiesta Nacional de España", countryCode));
            items.Add(new PublicHoliday(25, 10, year, "Euskadi Eguna", "Regional Holiday", countryCode, null, new string[] { "ES-PV" }));
            items.Add(new PublicHoliday(1, 11, year, "Día de todos los Santos", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(6, 12, year, "Día de la Constitución", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(8, 12, year, "Inmaculada Concepción", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Navidad", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "Sant Esteve", "St. Stephen's Day", countryCode, null, new string[] { "ES-CT", "ES-IB" }));

            return items;
        }
    }
}
