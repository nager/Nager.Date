using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nager.Date.PublicHolidays
{
    public class EastTimorProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.TL;
            var easterSunday = EasterSunday(year);
            //East TImor Official Goverment links
            //http://www.mj.gov.tl/jornal/?q=node/910
            //http://timor-leste.gov.tl/?p=17138
            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Dia de ano novo", "New Year's day", countryCode));
            items.Add(new PublicHoliday(year, 3, 3, "Dia dos Veteranos", "Veteran's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Sexta-feira Santa", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Domingo de Páscoa", "Easter Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dia do Trabalhador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 20, "Dia da Restauração da Independência", "Restauration Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 30, "Dia da Consulta Popular", "Popular Consultation Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Dia de Todos-os-Santos", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "Dia de Todos-os-Fiéis Defuntos", "Day of All-Faithful Dead", countryCode));
            items.Add(new PublicHoliday(year, 11, 12, "Dia Nacional da Juventude", "National Youth Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 28, "Dia da Proclamação da Independência", "Indepence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 7, "Dia da Memória", "Rememberance Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Dia da Nossa Senhora da Imaculada Conceição e Padroeira de Timor-Leste", "Immaculate Conception - Protector of East Timor", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natal", "Christmas Day", countryCode, null));
            items.Add(new PublicHoliday(year, 12, 31, "Dia dos Heróis Nacionais", "Christmas Day", countryCode, null));
            items.Add(new PublicHoliday(EndOfRamadanDate(year), "Final do Ramadão Muçulmano - Idul Fitri", "End of Ramadan - Eid al-Fitr", countryCode));
            items.Add(new PublicHoliday(EndEidalAdha(year), "Festa do Sacrifício - Idul Adha", "Sacrifice Feast - Eid al-Adha", countryCode));
            items.Add(new PublicHoliday(CorpusChristi(year), "Festa do Corpo de Deus", "Corpus Christi", countryCode));

            return items.OrderBy(o => o.Date);
        }

        private DateTime EndOfRamadanDate(int year)
        {
            var endRamadan = LocalDate.FromDateTime(new DateTime().FirstDayOfTheYear(year),CalendarSystem.UmAlQura).With(DateAdjusters.Month(9)).With(DateAdjusters.EndOfMonth);
            var gregrorianEndDate = endRamadan.WithCalendar(CalendarSystem.Gregorian);

            return gregrorianEndDate.ToDateTimeUnspecified();
        }

        private DateTime EndEidalAdha(int year)
        {
            var EidalAdha = LocalDate.FromDateTime(new DateTime().FirstDayOfTheYear(year), CalendarSystem.UmAlQura).With(DateAdjusters.Month(12)).With(DateAdjusters.DayOfMonth(12));
            var gregrorianEndDate = EidalAdha.WithCalendar(CalendarSystem.Gregorian);

            return gregrorianEndDate.ToDateTimeUnspecified();
        }
    }
}
