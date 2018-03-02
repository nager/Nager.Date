using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nager.Date.Model;

namespace Nager.Date.PublicHolidays
{
    public class MozambiqueProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.MZ;

            var items = new List<PublicHoliday>();

            items.Add(new PublicHoliday(year, 1, 1, "Dia de Ano Novo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 3, "Dia do Heroi Nacional", "Heroes's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 7, "Dia da Mulher", "Women's Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dia do Trabalhador", "worker's Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 25, "Dia da Independência", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 7, "Dia da Victória", "Victory Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 25, "Dia da Revolução", "Revolution Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 4, "Dia da Paz e da Reconcialição", "Day of Peace and Reconciliation", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natal", "Christmas Day", countryCode));

            return items;
        }

        public override DayOfWeek FirstDayOfWeek => DayOfWeek.Monday;
    }
}
