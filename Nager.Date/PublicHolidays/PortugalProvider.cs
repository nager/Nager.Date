using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public class PortugalProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Portugal
            var countryCode = CountryCode.PT;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "Solenidade de Santa Maria, Mãe de Deus", "Solemnity of Mary, Mother of God", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Sexta-feira Santa", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Domingo de Páscoa", "Easter Day", countryCode));
            items.Add(new PublicHoliday(25, 4, year, "Dia da Liberdade", "Freedom Day", countryCode));
            items.Add(new PublicHoliday(1, 5, year, "Dia do Trabalhador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Corpo de Deus", "Corpus Christi", countryCode));
            items.Add(new PublicHoliday(1, 6, year, "Dia dos Açores", "Azores Day", countryCode, null, new string[] { "PT-01", "PT-02", "PT-03", "PT-04", "PT-05", "PT-06", "PT-07", "PT-08", "PT-09", "PT-10", "PT-11", "PT-12", "PT-13", "PT-14", "PT-15", "PT-16", "PT-17", "PT-18", "PT-20" }));
            items.Add(new PublicHoliday(10, 6, year, "Dia de Portugal, de Camões e das Comunidades Portuguesas", "National Day", countryCode));
            items.Add(new PublicHoliday(1, 7, year, "Dia da Madeira", "Madeira Day", countryCode, null, new string[] { "PT-01", "PT-02", "PT-03", "PT-04", "PT-05", "PT-06", "PT-07", "PT-08", "PT-09", "PT-10", "PT-11", "PT-12", "PT-13", "PT-14", "PT-15", "PT-16", "PT-17", "PT-18", "PT-30" }));
            items.Add(new PublicHoliday(15, 8, year, "Assunção de Nossa Senhora", "Assumption", countryCode));
            items.Add(new PublicHoliday(5, 10, year, "Implantação da República", "Republic Day", countryCode));
            items.Add(new PublicHoliday(1, 11, year, "Dia de Todos-os-Santos", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(1, 12, year, "Restauração da Independência", "Restoration of Independence", countryCode));
            items.Add(new PublicHoliday(8, 12, year, "Imaculada Conceição", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Natal", "Christmas Day", countryCode, null));
            items.Add(new PublicHoliday(26, 12, year, "Segunda Oitava", "Boxing Day", countryCode, null, new string[] { "PT-01", "PT-02", "PT-03", "PT-04", "PT-05", "PT-06", "PT-07", "PT-08", "PT-09", "PT-10", "PT-11", "PT-12", "PT-13", "PT-14", "PT-15", "PT-16", "PT-17", "PT-18", "PT-20" }));

            return items;
        }
    }
}
