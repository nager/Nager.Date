using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date
{
    public static class DateSystem
    {
        /// <summary>
        /// Get Public Holidays
        /// </summary>
        /// <param name="countryCode">ISO 3166-1 ALPHA-2</param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static List<PublicHoliday> GetPublicHoliday(string countryCode, int year)
        {
            if (String.IsNullOrEmpty(countryCode))
            {
                return null;
            }

            countryCode = countryCode.ToUpper();
            var easterSunday = EasterSunday(year);

            var items = new List<PublicHoliday>();
            switch (countryCode)
            {
                case "AT":
                    items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", countryCode));
                    items.Add(new PublicHoliday(6, 1, year, "Heilige Drei Könige", "Epiphany", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode));
                    items.Add(new PublicHoliday(1, 5, year, "Staatsfeiertag", "National Holiday", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(39), "Christi Himmelfahrt", "Ascension Day", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", countryCode));
                    items.Add(new PublicHoliday(15, 8, year, "Maria Himmelfahrt", "Assumption of the Virgin Mary", countryCode));
                    items.Add(new PublicHoliday(26, 10, year, "Staatsfeiertag", "National Holiday", countryCode));
                    items.Add(new PublicHoliday(1, 11, year, "Allerheiligen", "All Saints' Day", countryCode));
                    items.Add(new PublicHoliday(8, 12, year, "Mariä Empfängnis", "Immaculate Conception", countryCode));
                    items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", countryCode));
                    items.Add(new PublicHoliday(26, 12, year, "Stefanitag", "St. Stephen's Day", countryCode));
                    break;
                case "DE":
                    items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode));
                    items.Add(new PublicHoliday(1, 5, year, "Tag der Arbeit", "Labor Day", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(39), "Christi Himmelfahrt", "Ascension Day", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode));
                    items.Add(new PublicHoliday(3, 10, year, "Tag der Deutschen Einheit", "German Unity Day", countryCode));
                    items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", countryCode));
                    items.Add(new PublicHoliday(26, 12, year, "Stefanitag", "St. Stephen's Day", countryCode));
                    break;
                case "CH":
                    //http://de.wikipedia.org/wiki/Feiertage_in_der_Schweiz
                    items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", countryCode));
                    items.Add(new PublicHoliday(2, 1, year, "Berchtoldstag", "St. Berchtold's Day", countryCode, new string[] { "ZH", "BE", "LU", "OW", "GL", "ZG", "FR", "SO", "SH", "TG", "VD", "NE", "GE", "JU" }));
                    items.Add(new PublicHoliday(6, 1, year, "Heilige Drei Könige", "Epiphany", countryCode, new string[] { "UR", "SZ", "GR", "TI" }));
                    items.Add(new PublicHoliday(19, 3, year, "Josefstag", "Saint Joseph's Day", countryCode, new string[] { "LU", "UR", "SZ", "NW", "ZG", "GR", "TI", "VS" }));
                    items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", countryCode, new string[] { "ZH", "BE", "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "BS", "BL", "SH", "AR", "AI", "SG", "GR", "AG", "TG", "VD", "NE", "GE", "JU" }));
                    items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, new string[] { "ZH", "BE", "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "BS", "BL", "SH", "AR", "AI", "SG", "GR", "AG", "TG", "TI", "VD", "NE", "GE", "JU" }));
                    items.Add(new PublicHoliday(1, 5, year, "Tag der Arbeit", "Labor Day", countryCode, new string[] { "ZH", "FR", "SO", "BS", "BL", "SH", "AG", "TG", "TI", "NE", "JU" }));
                    items.Add(new PublicHoliday(easterSunday.AddDays(39), "Auffahrt", "Ascension Day", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode, new string[] { "ZH", "BE", "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "BS", "BL", "SH", "AR", "AI", "SG", "GR", "AG", "TG", "TI", "VD", "NE", "GE", "JU" }));
                    items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", countryCode, new string[] { "LU", "UR", "SZ", "OW", "NW", "ZG", "FR", "SO", "BL", "AI", "GR", "AG", "TI", "VS", "NE", "JU" }));
                    items.Add(new PublicHoliday(1, 8, year, "Bundesfeier", "Swiss National Day", countryCode));
                    items.Add(new PublicHoliday(15, 8, year, "Maria Himmelfahrt", "Assumption of the Virgin Mary", countryCode, new string[] { "LU", "UR", "SZ", "OW", "NW", "ZG", "FR", "SO", "BL", "AI", "GR", "AG", "TI", "VS", "JU" }));
                    items.Add(new PublicHoliday(1, 11, year, "Allerheiligen", "All Saints' Day", countryCode, new string[] { "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "AI","SG", "GR", "AG", "TI", "VS", "JU" }));
                    items.Add(new PublicHoliday(8, 12, year, "Mariä Empfängnis", "Immaculate Conception", countryCode, new string[] { "LU", "UR", "SZ", "OW", "NW", "ZG", "FR", "SO", "AI", "GR", "AG", "TI", "VS" }));
                    items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", countryCode));
                    items.Add(new PublicHoliday(26, 12, year, "Stephanstag", "St. Stephen's Day", countryCode, new string[] { "ZH", "BE", "LU", "UR", "SZ", "OW", "NW", "GL", "ZG", "FR", "SO", "BS", "BL", "SH", "AR", "AI", "SG", "GR", "AG", "TG" }));
                    break;
                case "LI":
                    //http://en.wikipedia.org/wiki/Public_holidays_in_Liechtenstein
                    items.Add(new PublicHoliday(1, 1, year, "Neujahr", "New Year's Day", countryCode));
                    items.Add(new PublicHoliday(2, 1, year, "Berchtoldstag", "St. Berchtold's Day", countryCode));
                    items.Add(new PublicHoliday(6, 1, year, "Heilige Drei Könige", "Epiphany", countryCode));
                    items.Add(new PublicHoliday(2, 2, year, "Mariä Lichtmess", "Candlemas", countryCode));
                    items.Add(new PublicHoliday(19, 3, year, "Josefstag", "Saint Joseph's Day", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode));
                    items.Add(new PublicHoliday(1, 5, year, "Tag der Arbeit", "Labor Day", countryCode));
                    items.Add(new PublicHoliday(29, 5, year, "Auffahrt", "Ascension", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", countryCode));
                    items.Add(new PublicHoliday(15, 8, year, "Staatsfeiertag", "National Holiday", countryCode));
                    items.Add(new PublicHoliday(8, 9, year, "Maria Geburt", "Nativity of Our Lady", countryCode));
                    items.Add(new PublicHoliday(1, 11, year, "Allerheiligen", "All Saints Day", countryCode));
                    items.Add(new PublicHoliday(8, 12, year, "Mariä Empfängnis", "Immaculate Conception", countryCode));
                    items.Add(new PublicHoliday(24, 12, year, "Heiliger Abend", "Christmas Eve", countryCode));
                    items.Add(new PublicHoliday(25, 12, year, "Weihnachten", "Christmas Day", countryCode));
                    items.Add(new PublicHoliday(26, 12, year, "Stephanstag", "St. Stephen's Day", countryCode));
                    items.Add(new PublicHoliday(31, 12, year, "Silvester", "New Year's Eve", countryCode));
                    break;
                case "ES":
                    //https://en.wikipedia.org/wiki/Public_holidays_in_Spain
                    items.Add(new PublicHoliday(1, 1, year, "Año Nuevo", "New Year's Day", countryCode));
                    items.Add(new PublicHoliday(6, 1, year, "Día de Reyes / Epifanía del Señor", "Epiphany", countryCode));
                    items.Add(new PublicHoliday(28, 2, year, "Día de Andalucía", "Regional Holiday", countryCode, new string[] { "AN" }));
                    items.Add(new PublicHoliday(1, 3, year, "Dia de les Illes Balears", "Regional Holiday", countryCode, new string[] { "IB" }));
                    items.Add(new PublicHoliday(1, 3, year, "San José", "St. Joseph's Day", countryCode, new string[] { "ML", "CM", "GA", "IB", "M", "MU", "NA", "O", "VC" }));
                    items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Jueves Santo", "Maundy Thursday", countryCode, new string[] { "AN", "AR", "CE", "ML", "CL", "CM", "IC", "EX", "GA", "IB", "LO", "M", "MU", "NA", "O", "PV", "CB" }));
                    items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Viernes Santo", "Good Friday", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, new string[] { "CT", "IB", "NA", "PV", "VC" }));
                    items.Add(new PublicHoliday(23, 4, year, "San Jorge (Día de Aragón)", "Regional Holiday", countryCode, new string[] { "AR" }));
                    items.Add(new PublicHoliday(23, 4, year, "Día de Castilla y León", "Regional Holiday", countryCode, new string[] { "CL" }));
                    items.Add(new PublicHoliday(1, 5, year, "Día del Trabajador", "Labour Day", countryCode));
                    items.Add(new PublicHoliday(2, 5, year, "Fiesta de la Comunidad de Madrid", "Regional Holiday", countryCode, new string[] { "M" }));
                    items.Add(new PublicHoliday(17, 5, year, "Día das Letras Galegas", "Regional Holiday", countryCode, new string[] { "GA" }));
                    items.Add(new PublicHoliday(30, 5, year, "Día de Canarias", "Regional Holiday", countryCode, new string[] { "IC" }));
                    items.Add(new PublicHoliday(31, 5, year, "Día de la Región Castilla-La Mancha", "Regional Holiday", countryCode, new string[] { "CM" }));
                    items.Add(new PublicHoliday(easterSunday.AddDays(60), "Corpus Christi", "Corpus Christi", countryCode, new string[] { "M" }));
                    items.Add(new PublicHoliday(9, 6, year, "Día de la Región de Murcia", "Regional Holiday", countryCode, new string[] { "MU" }));
                    items.Add(new PublicHoliday(9, 6, year, "Día de La Rioja", "Regional Holiday", countryCode, new string[] { "LO" }));
                    items.Add(new PublicHoliday(24, 6, year, "Sant Joan", "St. John's Day", countryCode, new string[] { "CT" }));
                    items.Add(new PublicHoliday(25, 7, year, "Santiago Apóstol", "Saint James", countryCode, new string[] { "GA" }));
                    items.Add(new PublicHoliday(15, 8, year, "Asunción", "Assumption", countryCode));
                    items.Add(new PublicHoliday(2, 9, year, "Día de Ceuta", "Municipal Holiday", countryCode, new string[] { "CE" }));
                    items.Add(new PublicHoliday(8, 9, year, "Día de Asturias", "Regional Holiday", countryCode, new string[] { "O" }));
                    items.Add(new PublicHoliday(8, 9, year, "Día de Extremadura", "Regional Holiday", countryCode, new string[] { "EX" }));
                    items.Add(new PublicHoliday(11, 9, year, "Diada Nacional de Catalunya", "National Day of Catalonia", countryCode, new string[] { "CT" }));
                    items.Add(new PublicHoliday(15, 9, year, "Día de Cantabria", "Regional Holiday", countryCode, new string[] { "CB" }));
                    items.Add(new PublicHoliday(9, 10, year, "Dia de la Comunitat Valenciana", "Regional Holiday", countryCode, new string[] { "VC" }));
                    items.Add(new PublicHoliday(12, 10, year, "Fiesta Nacional de España", "Fiesta Nacional de España", countryCode));
                    items.Add(new PublicHoliday(25, 10, year, "Euskadi Eguna", "Regional Holiday", countryCode, new string[] { "PV" }));
                    items.Add(new PublicHoliday(1, 11, year, "Día de todos los Santos", "All Saints Day", countryCode));
                    items.Add(new PublicHoliday(6, 12, year, "Día de la Constitución", "Constitution Day", countryCode));
                    items.Add(new PublicHoliday(8, 12, year, "Inmaculada Concepción", "Immaculate Conception", countryCode));
                    items.Add(new PublicHoliday(25, 12, year, "Navidad", "Christmas Day", countryCode));
                    items.Add(new PublicHoliday(26, 12, year, "Sant Esteve", "St. Stephen's Day", countryCode, new string[] { "CT", "IB" }));
                    break;
                case "IT":
                    //https://en.wikipedia.org/wiki/Public_holidays_in_Italy
                    items.Add(new PublicHoliday(1, 1, year, "Capodanno", "New Year's Day", countryCode));
                    items.Add(new PublicHoliday(6, 1, year, "Epifania", "Epiphany", countryCode));
                    items.Add(new PublicHoliday(easterSunday.AddDays(1), "Lunedì dell'Angelo", "Easter Monday", countryCode));
                    items.Add(new PublicHoliday(25, 4, year, "Festa della Liberazione", "Liberation Day", countryCode));
                    items.Add(new PublicHoliday(1, 5, year, "Festa del Lavoro", "International Workers Day", countryCode));
                    items.Add(new PublicHoliday(2, 6, year, "Festa della Repubblica", "Republic Day", countryCode));
                    items.Add(new PublicHoliday(15, 8, year, "Ferragosto and Assunta", "Assumption Day", countryCode));
                    items.Add(new PublicHoliday(1, 11, year, "Tutti i santi", "All Saints Day", countryCode));
                    items.Add(new PublicHoliday(8, 12, year, "Immacolata Concezione", "Immaculate Conception", countryCode));
                    items.Add(new PublicHoliday(25, 12, year, "Natale", "Christmas Day", countryCode));
                    items.Add(new PublicHoliday(25, 12, year, "Santo Stefano", "St. Stephen's Day", countryCode));
                    break;
                default:
                    break;
            }

            return items;
        }

        public static bool IsPublicHoliday(DateTime date, string countryCode)
        {
            var items = GetPublicHoliday(countryCode, date.Year);
            return items.Where(o => o.Date.Date == date.Date).Any();
        }

        /// <summary>
        /// Get Catholic easter for requested year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime EasterSunday(int year)
        {
            var g = year % 19;
            var c = year / 100;
            var h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            var i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * ((21 - g) / 11));
            var j = (year + year / 4 + i + 2 - c + c / 4) % 7;
            var p = i - j;
            var easterDay = 1 + (p + 27 + (p + 6) / 40) % 31;
            var easterMonth = 3 + (p + 26) / 30;

            return new DateTime(year, easterMonth, easterDay);
        }
    }
}