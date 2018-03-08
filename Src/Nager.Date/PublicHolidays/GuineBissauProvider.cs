using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nager.Date.Contract;
using Nager.Date.Model;
using NodaTime;
using Nager.Date.Extensions;

namespace Nager.Date.PublicHolidays
{
    public class GuineBissauProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.GW;

            //Guiné Bissau
            //Wiki
            //https://pt.wikipedia.org/wiki/Guin%C3%A9-Bissau

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Dia de Ano Novo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 20, "Dia dos heróis", "Nacional Heroes Days", countryCode));
            items.Add(new PublicHoliday(year, 3, 8, "Dia Internacional da Mulher", "Womens Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dia do Trabalhador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 3, "Dia dos Mártires da Colonização", "Colonization Martyr's Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 24, "Dia da independência", "Independence Day", countryCode));
            items.Add(new PublicHoliday(EndOfRamadanDate(year), "Final do Ramadão Muçulmano - Idul Fitri", "End of Ramadan - Idul Fitri", countryCode));
            items.Add(new PublicHoliday(year, 12, 20, "Festa do Cordeiro", "Lamb's Festival", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natal", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        private DateTime EndOfRamadanDate(int year)
        {
            var endRamadan = LocalDate.FromDateTime(new DateTime().FirstDayOfTheYear(year)).WithCalendar(CalendarSystem.UmAlQura).With(DateAdjusters.Month(9)).With(DateAdjusters.EndOfMonth);
            var gregrorianEndDate = endRamadan.WithCalendar(CalendarSystem.Gregorian);

            return gregrorianEndDate.ToDateTimeUnspecified();
        }
    }
}
