using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.Data
{
    public static class DataES
    {
        public static List<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            var countryCode = "ES";

            var items = new List<PublicHoliday>();
            //https://en.wikipedia.org/wiki/Public_holidays_in_Spain
            items.Add(new PublicHoliday(1, 1, year, "Año Nuevo", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(6, 1, year, "Día de Reyes / Epifanía del Señor", "Epiphany", countryCode));
            items.Add(new PublicHoliday(28, 2, year, "Día de Andalucía", "Regional Holiday", countryCode, null, new string[] { "AN" }));
            items.Add(new PublicHoliday(1, 3, year, "Dia de les Illes Balears", "Regional Holiday", countryCode, null, new string[] { "IB" }));
            items.Add(new PublicHoliday(1, 3, year, "San José", "St. Joseph's Day", countryCode, null, new string[] { "ML", "CM", "GA", "IB", "M", "MU", "NA", "O", "VC" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Jueves Santo", "Maundy Thursday", countryCode, null, new string[] { "AN", "AR", "CE", "ML", "CL", "CM", "IC", "EX", "GA", "IB", "LO", "M", "MU", "NA", "O", "PV", "CB" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Viernes Santo", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, 1642, new string[] { "CT", "IB", "NA", "PV", "VC" }));
            items.Add(new PublicHoliday(23, 4, year, "San Jorge (Día de Aragón)", "Regional Holiday", countryCode, null, new string[] { "AR" }));
            items.Add(new PublicHoliday(23, 4, year, "Día de Castilla y León", "Regional Holiday", countryCode, null, new string[] { "CL" }));
            items.Add(new PublicHoliday(1, 5, year, "Día del Trabajador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(2, 5, year, "Fiesta de la Comunidad de Madrid", "Regional Holiday", countryCode, null, new string[] { "M" }));
            items.Add(new PublicHoliday(17, 5, year, "Día das Letras Galegas", "Regional Holiday", countryCode, null, new string[] { "GA" }));
            items.Add(new PublicHoliday(30, 5, year, "Día de Canarias", "Regional Holiday", countryCode, null, new string[] { "IC" }));
            items.Add(new PublicHoliday(31, 5, year, "Día de la Región Castilla-La Mancha", "Regional Holiday", countryCode, null, new string[] { "CM" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Corpus Christi", "Corpus Christi", countryCode, null, new string[] { "M" }));
            items.Add(new PublicHoliday(9, 6, year, "Día de la Región de Murcia", "Regional Holiday", countryCode, null, new string[] { "MU" }));
            items.Add(new PublicHoliday(9, 6, year, "Día de La Rioja", "Regional Holiday", countryCode, null, new string[] { "LO" }));
            items.Add(new PublicHoliday(24, 6, year, "Sant Joan", "St. John's Day", countryCode, null, new string[] { "CT" }));
            items.Add(new PublicHoliday(25, 7, year, "Santiago Apóstol", "Saint James", countryCode, null, new string[] { "GA" }));
            items.Add(new PublicHoliday(15, 8, year, "Asunción", "Assumption", countryCode));
            items.Add(new PublicHoliday(2, 9, year, "Día de Ceuta", "Municipal Holiday", countryCode, null, new string[] { "CE" }));
            items.Add(new PublicHoliday(8, 9, year, "Día de Asturias", "Regional Holiday", countryCode, null, new string[] { "O" }));
            items.Add(new PublicHoliday(8, 9, year, "Día de Extremadura", "Regional Holiday", countryCode, null, new string[] { "EX" }));
            items.Add(new PublicHoliday(11, 9, year, "Diada Nacional de Catalunya", "National Day of Catalonia", countryCode, null, new string[] { "CT" }));
            items.Add(new PublicHoliday(15, 9, year, "Día de Cantabria", "Regional Holiday", countryCode, null, new string[] { "CB" }));
            items.Add(new PublicHoliday(9, 10, year, "Dia de la Comunitat Valenciana", "Regional Holiday", countryCode, null, new string[] { "VC" }));
            items.Add(new PublicHoliday(12, 10, year, "Fiesta Nacional de España", "Fiesta Nacional de España", countryCode));
            items.Add(new PublicHoliday(25, 10, year, "Euskadi Eguna", "Regional Holiday", countryCode, null, new string[] { "PV" }));
            items.Add(new PublicHoliday(1, 11, year, "Día de todos los Santos", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(6, 12, year, "Día de la Constitución", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(8, 12, year, "Inmaculada Concepción", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Navidad", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "Sant Esteve", "St. Stephen's Day", countryCode, null, new string[] { "CT", "IB" }));

            return items;
        }
    }
}
